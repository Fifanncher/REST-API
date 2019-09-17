using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_API.Models
{
    public class QuestionsContext : DbContext
    {
        public DbSet<Question> Questions { get; set; }
        public QuestionsContext(DbContextOptions<QuestionsContext> options)
            : base(options)
        { }
    }
}
