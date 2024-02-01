using Lec03CRRUDSingle.Models.Entity;

namespace Lec03CRRUDSingle.Services;

public interface IPersonRepository
{
    Task<ICollection<Person>> ReadAllAsync();
    Task<Person> CreateAsync(Person newPerson);
    Task<Person?> ReadAsync(int id);
    Task UpdateAsync(int oldId, Person person);
    Task DeleteAsync(int id);
}
