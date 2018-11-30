using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DAL
{
    public class ApiContextFactory : IDesignTimeDbContextFactory<ApiDbContext>
    {
        public ApiContextFactory(){}

        public ApiDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApiDbContext>();
            
            var connection = "Server=localhost;User Id=root;Password=jonathan;Database=api;port=3306";
           
            optionsBuilder.UseMySql(connection);

            return new ApiDbContext(optionsBuilder.Options);
        }
    }
}
