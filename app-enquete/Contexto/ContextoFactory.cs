
using app_enquete.Comun;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace app_enquete.contexto
{
    public class ContextoFactory : IDesignTimeDbContextFactory<Contexto>
    {
        public Contexto CreateDbContext(string[] args)
        {
            var configuration = Configuracao.GetConfiguration(Directory.GetCurrentDirectory());
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            if (connectionString == null)
                connectionString = "Server=localhost;Port=5432;Database=citiwide;User Id=postgres;Password=lugo2012;Enlist=true;Integrated Security = true";

            var optionsBuilder = new DbContextOptionsBuilder<Contexto>();
            optionsBuilder.UseMySQL(connectionString);
            return Contexto.Create(optionsBuilder.Options);
        }
    }
}
