using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CadastroAluno.Models;

namespace CadastroAluno.Data
{
    public class CadastroAlunoContext : DbContext
    {
        public CadastroAlunoContext (DbContextOptions<CadastroAlunoContext> options)
            : base(options)
        {
        }

        public DbSet<CadastroAluno.Models.Aluno> Aluno { get; set; }
    }
}
