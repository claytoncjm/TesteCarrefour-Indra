using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FluxoCaixa.Models;

namespace FluxoCaixa.Data
{
    public class FluxoCaixaDbContext : DbContext
    {
        public FluxoCaixaDbContext (DbContextOptions<FluxoCaixaDbContext> options)
            : base(options)
        {
        }

        public DbSet<FluxoCaixa.Models.FluxoCaixaModels> FluxoCaixaModels { get; set; } = default!;
    }
}
