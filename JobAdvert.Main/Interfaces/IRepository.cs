namespace JobAdvert.Main.Interfaces
{
    public interface IRepository<T1, T2> where T1 : class
    {
        Task<List<T1>> GetAllAsync();
        Task<T1> GetByIdAsync(T2 id);
        Task Create(T1 model);
        Task Update(T1 model);
        Task Delete(T2 id);
    }
}
