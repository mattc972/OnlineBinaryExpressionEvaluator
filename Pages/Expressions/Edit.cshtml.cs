using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OnlineBinaryExpressionEvaluator.Models;

namespace OnlineBinaryExpressionEvaluator.Pages.Expressions
{
    public class EditModel : PageModel
    {
        private readonly OnlineBinaryExpressionEvaluator.Models.OnlineBinaryExpressionEvaluatorContext _context;

        public EditModel(OnlineBinaryExpressionEvaluator.Models.OnlineBinaryExpressionEvaluatorContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Expression Expression { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Expression = await _context.Expression.FirstOrDefaultAsync(m => m.ID == id);

            if (Expression == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Expression).State = EntityState.Modified;

            try
            {
                Expression.AdditionResult = Expression.BinaryAddition(Expression.Operand1, Expression.Operand2);
                Expression.MultiplicationResult = Expression.BinaryMultiplication(Expression.Operand1, Expression.Operand2);
                Expression.NegationResult1 = Expression.BinaryNegation(Expression.Operand1);
                Expression.NegationResult2 = Expression.BinaryNegation(Expression.Operand2);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExpressionExists(Expression.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ExpressionExists(int id)
        {
            return _context.Expression.Any(e => e.ID == id);
        }
    }
}
