namespace OnlineStore.Domain.Interfaces
{
	public interface IUnitOfWork : IDisposable
	{
		IPedidoRepository PedidoRepository { get; }
		Task<int> SaveChangesAsync();
		Task<int> CommitAsync(); // Método para guardar los cambios en la base de datos		
		Task<int> DeleteAsync(int id);
		Task<int> InsertAsync(int id);
		Task<int> UpdateAsync(int id);

	}
}
