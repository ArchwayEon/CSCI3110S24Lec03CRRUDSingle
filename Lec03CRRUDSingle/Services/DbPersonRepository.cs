using Lec03CRRUDSingle.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace Lec03CRRUDSingle.Services;

public class DbPersonRepository(ApplicationDbContext db) 
    : IPersonRepository
{
    private readonly ApplicationDbContext _db = db;

    public async Task<Person> CreateAsync(Person newPerson)
    {
        await _db.People.AddAsync(newPerson);
        await _db.SaveChangesAsync();
        return newPerson;
    }

    public async Task DeleteAsync(int id)
    {
        Person? personToDelete = await ReadAsync(id);
        if (personToDelete != null)
        {
            _db.People.Remove(personToDelete);
            await _db.SaveChangesAsync();
        }
    }

    public async Task<ICollection<Person>> ReadAllAsync()
    {
        return await _db.People.ToListAsync();
    }

    public async Task<Person?> ReadAsync(int id)
    {
        return await _db.People.FindAsync(id);
        //return await _db.People.FirstOrDefaultAsync((p) => p.Id == id);
    }

    public async Task UpdateAsync(int oldId, Person person)
    {
        Person? personToUpdate = await ReadAsync(oldId);
        if (personToUpdate != null)
        {
            personToUpdate.FirstName = person.FirstName;
            personToUpdate.MiddleName = person.MiddleName;
            personToUpdate.LastName = person.LastName;
            personToUpdate.DateOfBirth = person.DateOfBirth;
            await _db.SaveChangesAsync();
        }
    }
}
