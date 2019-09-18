using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineBinaryExpressionEvaluator.Models
{
    public class BinaryAddition
    {
        public int ID { get; set;  }

        [RegularExpression(@"^[01]+$")]
        [StringLength(7, MinimumLength = 7)]
        [Required]
        public string Operand1 { get; set; }


        [RegularExpression(@"^[01]+$")]
        [StringLength(7, MinimumLength = 7)]
        [Required]
        public string Operand2 { get; set; }


        [RegularExpression(@"^[01]+$")]
        [StringLength(8, MinimumLength = 8)]
        public string AdditionResult { get; set; }

        public string EvaluateBinaryAddition(string a, string b)
        {
            // There is no input checking required; the data was checked for validity upon being put in the database.

            char[] c = new char[8];
            char carryOver = '0';

            for (int i = 6; i > -1; i--)
            {
                // If the ith bit in a is not equal to the ith bit in b:
                if (a.ElementAt(i).CompareTo(b.ElementAt(i)) != 0)
                {
                    // If the carry-over is currently 0:
                    if (carryOver == '0')
                    {
                        c[i + 1] = '1';
                    }

                    // Otherwise, if the carry-over is currently 1:
                    else
                    {
                        c[i + 1] = '0';
                        carryOver = '1';
                    }
                }

                // If the ith bit in a is equal to the ith bit in b:
                if (a.ElementAt(i).CompareTo(b.ElementAt(i)) == 0)
                {
                    // If the ith bit of a is 0:
                    if (a.ElementAt(i) == '0')
                    {
                        // If the carry-over is currently 1:
                        if (carryOver == '1')
                        {
                            c[i + 1] = '1';
                            carryOver = '0';

                        }

                        // Otherwise, if the carry-over is currently 0:
                        else
                        {
                            c[i + 1] = '0';
                        }
                    }

                    // If the ith bit of a is 1:
                    if (a.ElementAt(i) == '1')
                    {
                        // If the carry-over is currently 1:
                        if (carryOver == '1')
                        {
                            c[i + 1] = '1';
                            carryOver = '1';
                        }

                        // Otherwise, if the carry-over is currently 0:
                        else
                        {
                            c[i + 1] = '0';
                            carryOver = '1';
                        }
                    }

                    // if this is the final interation of the loop:
                    if (i == 0)
                    {
                        // If the carry-over is currently 0:
                        if (carryOver == '0')
                        {
                            c[0] = '0';
                        }

                        // Otherwise, if the carry-over is currently 1:
                        else
                        {
                            c[0] = '1';
                        }
                    }
                }
            }

            string result = new string(c);
            return result;
        }
    }
}
