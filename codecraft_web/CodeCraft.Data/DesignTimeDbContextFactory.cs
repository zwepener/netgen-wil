using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace CodeCraft.Data
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<CodeCraftDbContext>
    {
        public CodeCraftDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<CodeCraftDbContext>();

            // Specify the database provider (e.g., SQL Server)
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=CodeCraftDB;Trusted_Connection=True;MultipleActiveResultSets=true");

            // Return a new instance of your DbContext
            return new CodeCraftDbContext(optionsBuilder.Options);
        }
    }
}
