using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnlineBinaryExpressionEvaluator.Models;

namespace OnlineBinaryExpressionEvaluator.Models
{
    public class OnlineBinaryExpressionEvaluatorContext : DbContext
    {
        public OnlineBinaryExpressionEvaluatorContext (DbContextOptions<OnlineBinaryExpressionEvaluatorContext> options)
            : base(options)
        {
        }

        public DbSet<OnlineBinaryExpressionEvaluator.Models.BinaryAddition> BinaryAddition { get; set; }

        public DbSet<OnlineBinaryExpressionEvaluator.Models.BinaryMultiplication> BinaryMultiplication { get; set; }

        public DbSet<OnlineBinaryExpressionEvaluator.Models.BinaryNegation> BinaryNegation { get; set; }
    }
}
