using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace CodeCraft.Data;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<CodeCraftDbContext>
{
    public CodeCraftDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<CodeCraftDbContext>();

        return new CodeCraftDbContext(optionsBuilder.Options);
    }
}
