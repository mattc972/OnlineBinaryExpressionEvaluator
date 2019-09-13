using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBinaryExpressionEvaluator.Models
{
    public class Expression
    {
        public int ID { get; set;  }
        public string Operand1 { get; set;  }
        public string Operand2 { get; set;  }
        public string AdditionResult { get; set; }
        public string MultiplicationResult { get; set;  }
        public string NegationResult1 { get; set;  }
        public string NegationResult2 { get; set;  }
    }
}
