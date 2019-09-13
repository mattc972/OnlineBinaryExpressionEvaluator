using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace OnlineBinaryExpressionEvaluator.Models
{
    public class OnlineBinaryExpressionEvaluatorContext : DbContext
    {
        public OnlineBinaryExpressionEvaluatorContext (DbContextOptions<OnlineBinaryExpressionEvaluatorContext> options)
            : base(options)
        {
        }

        public DbSet<OnlineBinaryExpressionEvaluator.Models.Expression> Expression { get; set; }
    }
}
