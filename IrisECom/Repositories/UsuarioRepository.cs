using IrisECom.Data;
using IrisECom.Models;
using Microsoft.EntityFrameworkCore;

namespace IrisECom.Repositories
{
    public class UsuarioRepository
    {
        private readonly DataContext context;

        // IConfiguration é uma interface que fornece acesso a configurações do aplicativo
        public UsuarioRepository(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            var options = new DbContextOptionsBuilder<DataContext>() // Configurando options para o DataContext
                .UseSqlServer(connectionString)
                .Options;
            context = new DataContext(options);
        }

        public IEnumerable<Usuario> BuscarTodos()
        {
            return context.Usuarios
                .Include(u => u.Produtos)
                .AsNoTracking();
        }

        public Usuario? BuscarPorId(int id)
        {
            return context.Usuarios
                .Include(u => u.Produtos)
                .Where(u => u.Id == id)
                .FirstOrDefault();
        }

        public IEnumerable<Usuario> BuscarPorEmail(string email)
        {
            return context.Usuarios
                .Include(u => u.Produtos)
                .Where(u => u.Email.Contains(email)).ToList();
        }

        public int Inserir(Usuario usuario)
        {
            try
            {
                context.Usuarios.Add(usuario);
                return context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao inserir Usuário." + ex.Message);
            }
        }

        public int Atualizar(Usuario usuario)
        {
            try
            {
                context.Entry(usuario).State = EntityState.Modified;
                return context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao atualizar Usuário." + ex.Message);
            }
        }

        public int Excluir(int id)
        {
            Usuario? usuario = BuscarPorId(id);

            if (usuario != null)
            {
                context.Usuarios.Remove(usuario);
                return context.SaveChanges();
            }
            return 0;
        }
    }
}
