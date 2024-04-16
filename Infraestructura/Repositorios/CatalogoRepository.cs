using Dominio.Entidades;
using Infraestructura.Contexto;
using Microsoft.EntityFrameworkCore;
using System.Collections.Immutable;
using System.Threading;

namespace Infraestructura.Repositorios
{
    public class CatalogoRepository : ICatalogoRepository
    {
        private readonly ApplicationDbContext _context;

        public CatalogoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Catalogo>> ObtenerCatalogosAsync(CancellationToken cancellationToken)
        {
            var resultado = await _context.Catalogos.Include(p => p.AlimentosCatalogo).ToListAsync(cancellationToken: cancellationToken);
            return resultado;
        }


        public async Task<Catalogo> ObtenerCatalogoPorIdAsync(int CatalogoId, CancellationToken cancellationToken)
        {
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            var Catalogo = await _context.Catalogos.FirstOrDefaultAsync(x => x.Id == CatalogoId, cancellationToken: cancellationToken);

            if (Catalogo == null)
            {
                throw new Exception($"No existe el Catalogo para el id {CatalogoId}");
            }

            return Catalogo;
        }

        public async Task<List<AlimentoCatalogo>> ObtenerAlimentosPorCatalogoIdAsync(int catalogoId, CancellationToken cancellationToken)
        {
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            var catalogo = await _context.Catalogos
                                .Include(p => p.AlimentosCatalogo)
                                .FirstOrDefaultAsync(x => x.Id == catalogoId, cancellationToken: cancellationToken);

            if (catalogo == null)
            {
                throw new Exception($"No existe el Catalogo para el id {catalogoId}");
            }

            return catalogo.AlimentosCatalogo;
        }

        public async Task AgregarAlimentosCatalogoAsync(int catalogoId, List<AlimentoCatalogo> alimentoCatalogos, CancellationToken cancellationToken)
        {
            var catalogo = await _context.Catalogos.FirstOrDefaultAsync(x => x.Id == catalogoId, cancellationToken: cancellationToken);

            if (catalogo == null)
            {
                throw new Exception($"No existe el Catalogo para el id {catalogoId}");
            }

            catalogo.AlimentosCatalogo.AddRange(alimentoCatalogos);

            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task CrearCatalogoAsync(Catalogo Catalogo, CancellationToken cancellationToken)
        {
            _context.Add(Catalogo);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<bool> BorrarAlimentoCatalogoAsync(int catalogoId, int alimentoId, CancellationToken cancellationToken)
        {
            var catalogo = await _context.Catalogos.FirstOrDefaultAsync(x => x.Id == catalogoId);
            if (catalogo == null)
            {
                throw new Exception($"No existe el Catalogo para el id {catalogoId}");
            }
            var result = await _context.AlimentoCatalogos.Where(x => x.CatalogoId == catalogoId && x.AlimentoId == alimentoId).ExecuteDeleteAsync(cancellationToken);
            return result > 0;
        }
    }
}
