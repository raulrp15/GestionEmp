using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CapaENT;

namespace EjercicioAzure.Data
{
    public class EjercicioAzureContext : DbContext
    {
        public EjercicioAzureContext (DbContextOptions<EjercicioAzureContext> options)
            : base(options)
        {
        }

        public DbSet<CapaENT.ClsPersona> Personas { get; set; } = default!;
    }
}
