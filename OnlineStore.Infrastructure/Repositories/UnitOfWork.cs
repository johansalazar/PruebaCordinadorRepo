using OnlineStore.Domain.Entities;
using OnlineStore.Domain.Interfaces;
using OnlineStore.Infrastructure.Data;

namespace OnlineStore.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly OnlineStoreDbContext _context;
        private IPedidoRepository _pedidoRepository;

        public UnitOfWork(OnlineStoreDbContext context)
        {
            _context = context;

        }
        public IPedidoRepository PedidoRepository
        {
            get
            {
                return _pedidoRepository ??= new PedidoRepository(_context);
            }
        }
        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteAsync(int id)
        {
            var entity = await _context.Pedidos.FindAsync(id);
            if (entity != null)
            {
                _context.Pedidos.Remove(entity);
                return await _context.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<int> UpdateAsync(int id)
        {
            var entity = await _context.Pedidos.FindAsync(id);
            if (entity != null)
            {
                _context.Pedidos.Update(entity);
                return await _context.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<int> InsertAsync(int id)
        {
            var entity = new Pedido { Id = id };
            _context.Pedidos.Add(entity);
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
