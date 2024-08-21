using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CadastroCS.Models;

namespace CadastroCS.Data
{
    public class CadastroCSContext : DbContext
    {
        public CadastroCSContext (DbContextOptions<CadastroCSContext> options)
            : base(options)
        {
        }

        public DbSet<CadastroCS.Models.Fornecedor> Fornecedor { get; set; } = default!;
    }
}
