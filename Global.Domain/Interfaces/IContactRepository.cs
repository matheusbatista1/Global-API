using Global.Domain.Entities;

namespace Global.Domain.Interfaces;

public interface IContactRepository
{
    Task<Contact> GetByIdAsync(int id);
    Task<bool> CreateAsync(Contact contact);
    Task<bool> UpdateAsync(Contact contact);
}