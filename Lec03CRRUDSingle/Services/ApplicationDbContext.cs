using Lec03CRRUDSingle.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace Lec03CRRUDSingle.Services;

public class ApplicationDbContext(DbContextOptions options) 
    : DbContext(options)
{
    public DbSet<Person> People => Set<Person>();
}

