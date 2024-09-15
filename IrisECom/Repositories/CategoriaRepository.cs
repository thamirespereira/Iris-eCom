using IrisECom.Data;
using IrisECom.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace IrisECom.Repositories
{
    public class CategoriaRepository
    {
        private readonly DataContext context;

        public CategoriaRepository(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            var options = new DbContextOptionsBuilder<DataContext>() // Configurando options para o DataContext
                .UseSqlServer(connectionString)
                .Options;
            context = new DataContext(options);
        }

        public IEnumerable<Categoria> BuscarTodos()
        {
            return context.Categorias
                .AsNoTracking();
        }

        public Categoria? BuscarPorId(int id)
        {
            return context.Categorias
                .Where(c => c.Id == id)
                .FirstOrDefault();
        }

        public IEnumerable<Categoria> BuscarPorNome(string nome)
        {
            return context.Categorias
                .Where(c => c.Nome.Contains(nome)).ToList();
        }

        public int Inserir(Categoria categoria)
        {
            try
            {
                context.Add(categoria);
                return context.SaveChanges();
            }
            catch(Exception ex)
            {
                throw new Exception("Erro ao inserir categoria: " + ex.Message);
            }
        }

        public int Atualizar(Categoria categoria)
        {
            try
            {
                context.Entry(categoria).State = EntityState.Modified;
                return context.SaveChanges();
            }
            catch(Exception ex)
            {
                throw new Exception("Erro ao atualizar categoria: " + ex.Message);
            }
        }

        public int Excluir (int id)
        {
            Categoria? categoria = BuscarPorId(id);

            if(categoria != null)
            {
                context.Remove(categoria);
                return context.SaveChanges();
            }
            return 0;
        }
    }
}
