using Dominio.Entidades;
using Infraestructura.Contexto;
using Microsoft.EntityFrameworkCore;
using System;

namespace Infraestructura.Repositorios
{
    public class AlimentoRepository : IAlimentoRepository
    {
        private readonly ApplicationDbContext _context;

        public AlimentoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Alimento>> ObtenerAlimentosAsync(CancellationToken cancellationToken) =>
            await _context.Alimentos.ToListAsync(cancellationToken: cancellationToken);
        

        public async Task<Alimento> ObtenerAlimentoPorIdAsync(int alimentoId, CancellationToken cancellationToken)
        {
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            var alimento = await _context.Alimentos.FirstOrDefaultAsync(x => x.Id == alimentoId, cancellationToken: cancellationToken);

            if (alimento == null)
            {
                throw new Exception($"No existe el alimento para el id {alimentoId}");
            }

            return alimento;
        }

        public async Task CrearAlimentoAsync(Alimento alimento, CancellationToken cancellationToken)
        {
            _context.Add(alimento);
             await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task ActualizarAlimentoAsync(Alimento alimento, CancellationToken cancellationToken)
        {
            _context.Update(alimento);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<bool> BorrarAlimentoAsync(int alimentoId, CancellationToken cancellationToken)
        {
            var result = await _context.Alimentos.Where(x => x.Id == alimentoId).ExecuteDeleteAsync(cancellationToken);
            return result > 0;
        }
    }
}
