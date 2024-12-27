using Global.Application.Commands.Results.Contact;
using Global.Domain.Interfaces;

namespace Global.Application.Commands.Handlers.Contact;

public class GetContactCommandHandler
{
    private readonly IContactRepository _contactRepository;

    public GetContactCommandHandler(IContactRepository contactRepository)
    {
        _contactRepository = contactRepository;
    }

    public async Task<GetContactCommandResult?> Handle(int id)
    {
        var contact = await _contactRepository.GetByIdAsync(id);

        if (contact == null) return null;

        return new GetContactCommandResult
        {
            Id = contact.Id,
            Name = contact.Name
        };
    }
}