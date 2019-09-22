using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineBinaryExpressionEvaluator.Models
{
    public class BinaryMultiplication
    {
        public int ID { get; set;  }

        [RegularExpression(@"^[01]+$")]
        [StringLength(4, MinimumLength = 4)]
        [Required]
        public string Operand1 { get; set; }

        [RegularExpression(@"^[01]+$")]
        [StringLength(4, MinimumLength = 4)]
        [Required]
        public string Operand2 { get; set; }

        [RegularExpression(@"^[01]+$")]
        [StringLength(8, MinimumLength = 8)]
        public string MultiplicationResult { get; set; }

        public string EvaluateBinaryMultiplication(string a, string b)
        {
            // No input checking is required; validation was done on the data upon entry into the database.

            char[] m1 = new char[8];
            char[] m2 = new char[8];
            char[] m3 = new char[8];
            char[] m4 = new char[8];

            // Initialization of all 4 product sums.
            for(int x = 0; x < 8; x++)
            {
                m1[x] = '0';
                m2[x] = '0';
                m3[x] = '0';
                m4[x] = '0';
            }

            // The result of the 1st product sum will be 0000XXXX
            for (int x = 7; x > 3; x--)
            {
                if (b[3] == '1' && a[x - 4] == '1')
                {
                    m1[x] = '1';
                }
            }

            // The result of the 2nd product sum will be 000XXXX0
            for (int x = 6; x > 2; x--)
            {
                if (b[2] == '1' && a[x - 3] == '1')
                {
                    m2[x] = '1';
                }
            }

            // The result of the 3rd product sum will be 00XXXX00
            for(int x = 5; x > 1; x--)
            {
                if (b[1] == '1' && a[x - 2] == '1')
                {
                    m3[x] = '1';
                }
            }

            // The result of the 4th product sum will be 0XXXX000
            for (int x = 4; x > 0; x--)
            {
                if (b[0] == '1' && a[x - 1] == '1')
                {
                    m4[x] = '1';
                }
            }

            string sm1 = new string(m1);
            string sm2 = new string(m2);
            string sm3 = new string(m3);
            string sm4 = new string(m4);

            string t1 = evalAddString(sm1, sm2);
            string t2 = evalAddString(sm3, sm4);
            string final = evalAddString(t1, t2);

            return final;
        }

        private string evalAddString(string a, string b)
        {
            char[] c = new char[8];
            char carryOver = '0';

            for (int i = 0; i < 8; i++)
            {
                c[i] = '0';
            }

            for (int x = 7; x > -1; x--)
            {
                if (a.ElementAt(x).CompareTo(b.ElementAt(x)) != 0)
                {
                    if (carryOver == '0')
                    {
                        c[x] = '1';
                    }
                    else
                    {
                        c[x] = '0';
                        carryOver = '1';
                    }
                }

                if (a.ElementAt(x).CompareTo(b.ElementAt(x)) == 0)
                {
                    if (a.ElementAt(x) == '0')
                    {
                        if (carryOver == '1')
                        {
                            c[x] = '1';
                            carryOver = '0';
                        }

                        else
                        {
                            c[x] = '0';
                            carryOver = '0';
                        }
                    }

                    else
                    {
                        if (carryOver == '1')
                        {
                            c[x] = '1';
                            carryOver = '1';
                        }

                        else
                        {
                            c[x] = '0';
                            carryOver = '1';
                        }
                    }
                }
            }

            string result = new string(c);
            return result;
        }
    }
}
