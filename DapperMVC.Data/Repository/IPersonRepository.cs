using DapperMVC.Data.Models.Domain;

namespace DapperMVC.Data.Repository
{
    public interface IPersonRepository
    {
        Task<bool> AddAsync(Person person);

        Task<bool> UpdateAsync(Person person);

        Task<bool> DeleteAsync(int id); 

        Task<Person>GetByIdAsync(int id);  

        Task<IEnumerable<Person>> GetAllAsync();

    }
}