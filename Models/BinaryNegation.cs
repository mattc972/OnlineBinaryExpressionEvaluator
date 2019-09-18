using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineBinaryExpressionEvaluator.Models
{
    public class BinaryNegation
    {
        public int ID { get; set;  }

        [RegularExpression(@"^[01]+$")]
        [StringLength(7, MinimumLength = 7)]
        [Required]
        public string Operand { get; set; }

        [RegularExpression(@"^[01]+$")]
        [StringLength(8, MinimumLength = 8)]
        public string NegationResult { get; set; }

        public string EvaluateBinaryNegation(string a)
        {
            // No input checking is done; input checking was done once user submitted the operand set to the database.

            char[] b = new char[8];

            for (int i = 0; i < 7; i++)
            {
                // If the ith bit of a is 0:
                if (a.ElementAt(i) == '0')
                {
                    b[i + 1] = '1';
                }

                // Otherwise, if the ith bit of a is 1:
                else
                {
                    b[i + 1] = '0';
                }
            }

            // This value is the 1 that is added to the inverted binary integer.
            char carryOver = '1';
            b[0] = '1';

            for (int i = 7; i > -1 && carryOver == '1'; i--)
            {
                // If the ith bit of b is 1:
                if (b[i] == '1')
                {
                    b[i] = '0';
                }

                // Otherwise, if the ith bit of b is 0:
                else
                {
                    b[i] = '1';
                    carryOver = '0';
                }
            }

            string result = new string(b);
            return result;
        }
    }
}
