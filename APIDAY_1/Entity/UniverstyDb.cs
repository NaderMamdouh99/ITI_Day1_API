using APIDAY_1.Models;
using Microsoft.EntityFrameworkCore;

namespace APIDAY_1.Entity
{
    public class UniverstyDb:DbContext
    {
        public UniverstyDb() { }
        public UniverstyDb(DbContextOptions op) : base(op)
        {

        }
        
        public DbSet<Student> Students { get; set; }
    }
}
