namespace HotelProject.WebUI.Services
{
    public interface IApiService<T> where T : class
    {
        Task<List<T>?> GetAllAsync();
        Task<T?> GetByIdAsync(int id);
        Task<bool> CreateAsync(T entity);
        Task<bool> UpdateAsync(T entity);
        Task<bool> DeleteAsync(int id);
    }
}