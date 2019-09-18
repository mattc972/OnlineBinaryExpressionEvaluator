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
            return "1";
        }
    }
}
