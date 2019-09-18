using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineBinaryExpressionEvaluator.Models;

namespace OnlineBinaryExpressionEvaluator.Pages.BinaryAdditions
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
        public BinaryAddition BinaryAddition { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            BinaryAddition.AdditionResult = BinaryAddition.EvaluateBinaryAddition(BinaryAddition.Operand1, BinaryAddition.Operand2);
            _context.BinaryAddition.Add(BinaryAddition);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}