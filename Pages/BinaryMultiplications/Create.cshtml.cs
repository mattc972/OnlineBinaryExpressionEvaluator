using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineBinaryExpressionEvaluator.Models;

namespace OnlineBinaryExpressionEvaluator.Pages.BinaryMultiplications
{
    public class CreateModel : PageModel
    {
        private readonly OnlineBinaryExpressionEvaluator.Models.OnlineBinaryExpressionEvaluatorContext _context;

        public CreateModel(OnlineBinaryExpressionEvaluator.Models.OnlineBinaryExpressionEvaluatorContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public BinaryMultiplication BinaryMultiplication { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            BinaryMultiplication.MultiplicationResult = BinaryMultiplication.EvaluateBinaryMultiplication(BinaryMultiplication.Operand1, BinaryMultiplication.Operand2);
            _context.BinaryMultiplication.Add(BinaryMultiplication);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}