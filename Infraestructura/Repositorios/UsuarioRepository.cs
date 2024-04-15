using Dominio.Entidades;
using Infraestructura.Contexto;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura.Repositorios
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ApplicationDbContext _context;

        public UsuarioRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task ActualizarUsuarioAsync(Usuario usuario, CancellationToken cancellationToken)
        {
            _context.Update(usuario);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<bool> BorrarUsuarioAsync(int usuarioId, CancellationToken cancellationToken)
        {
            var result = await _context.Usuarios.Where(x => x.Id == usuarioId).ExecuteDeleteAsync(cancellationToken);
            return result > 0;
        }

        public async Task CrearUsuarioAsync(Usuario usuario, CancellationToken cancellationToken)
        {
            _context.Add(usuario);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<Usuario> ObtenerUsuarioPorIdAsync(int usuarioId, CancellationToken cancellationToken)
        {
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            var usuario = await _context.Usuarios.FirstOrDefaultAsync(x => x.Id == usuarioId, cancellationToken: cancellationToken);

            if (usuario == null)
            {
                throw new Exception($"No existe el usuario para el id {usuario}");
            }

            return usuario;
        }

        public async Task<List<Usuario>> ObtenerUsuariosAsync(CancellationToken cancellationToken) =>
            await _context.Usuarios.ToListAsync(cancellationToken);

    }
}
