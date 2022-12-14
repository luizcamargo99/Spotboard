namespace Spotboard.Shared.Interfaces;

public interface IRepository<T> where T : class
{
    Task SaveAsync(T? model);
    Task<T> GetAsync();
}