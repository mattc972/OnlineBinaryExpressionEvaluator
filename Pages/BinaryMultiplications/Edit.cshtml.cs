using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OnlineBinaryExpressionEvaluator.Models;

namespace OnlineBinaryExpressionEvaluator.Pages.BinaryMultiplications
{
    public class EditModel : PageModel
    {
        private readonly OnlineBinaryExpressionEvaluator.Models.OnlineBinaryExpressionEvaluatorContext _context;

        public EditModel(OnlineBinaryExpressionEvaluator.Models.OnlineBinaryExpressionEvaluatorContext context)
        {
            _context = context;
        }

        [BindProperty]
        public BinaryMultiplication BinaryMultiplication { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            BinaryMultiplication = await _context.BinaryMultiplication.FirstOrDefaultAsync(m => m.ID == id);

            if (BinaryMultiplication == null)
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

            _context.Attach(BinaryMultiplication).State = EntityState.Modified;

            try
            {
                BinaryMultiplication.MultiplicationResult = BinaryMultiplication.EvaluateBinaryMultiplication(BinaryMultiplication.Operand1, BinaryMultiplication.Operand2);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BinaryMultiplicationExists(BinaryMultiplication.ID))
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

        private bool BinaryMultiplicationExists(int id)
        {
            return _context.BinaryMultiplication.Any(e => e.ID == id);
        }
    }
}
