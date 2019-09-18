﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using OnlineBinaryExpressionEvaluator.Models;

namespace OnlineBinaryExpressionEvaluator.Pages.BinaryMultiplications
{
    public class IndexModel : PageModel
    {
        private readonly OnlineBinaryExpressionEvaluator.Models.OnlineBinaryExpressionEvaluatorContext _context;

        public IndexModel(OnlineBinaryExpressionEvaluator.Models.OnlineBinaryExpressionEvaluatorContext context)
        {
            _context = context;
        }

        public IList<BinaryMultiplication> BinaryMultiplication { get;set; }

        public async Task OnGetAsync()
        {
            BinaryMultiplication = await _context.BinaryMultiplication.ToListAsync();
        }
    }
}
