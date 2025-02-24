
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatabaseFirstWebApi.Models
{
    public class Table1
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        public int Id { get; set; }

        [Required]
        [StringLength(50)] 
        public string Name { get; set; }

        public int Value { get; set; } 
    }

    public class MyDataBaseApproachContext : DbContext
    {
        public MyDataBaseApproachContext(DbContextOptions<MyDataBaseApproachContext> options) : base(options)
        {
        }

        public DbSet<Table1> Table1 { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Table1>()
                .ToTable("Table1"); 
        }
    }
}
