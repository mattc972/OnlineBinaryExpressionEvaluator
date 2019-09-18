﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using OnlineBinaryExpressionEvaluator.Models;

namespace OnlineBinaryExpressionEvaluator.Pages.BinaryNegations
{
    public class DetailsModel : PageModel
    {
        private readonly OnlineBinaryExpressionEvaluator.Models.OnlineBinaryExpressionEvaluatorContext _context;

        public DetailsModel(OnlineBinaryExpressionEvaluator.Models.OnlineBinaryExpressionEvaluatorContext context)
        {
            _context = context;
        }

        public BinaryNegation BinaryNegation { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            BinaryNegation = await _context.BinaryNegation.FirstOrDefaultAsync(m => m.ID == id);

            if (BinaryNegation == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
