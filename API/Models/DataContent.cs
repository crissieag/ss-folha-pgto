using Microsoft.EntityFrameworkCore;

namespace API.Models
{
    public class DataContext : DbContext
    {
        //estabelece a conexão com o banco
        //o options passado como base faz a parte de herança de atributos para o filho
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        //é o que permite que a classe se torne uma tabela no banco
        public DbSet<Funcionario> Funcionarios { get; set; }
    }

}