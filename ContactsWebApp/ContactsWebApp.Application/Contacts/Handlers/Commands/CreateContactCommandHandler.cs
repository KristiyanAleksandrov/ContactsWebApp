using ContactsWebApp.Application.Contacts.Commands;
using ContactsWebApp.Domain;
using ContactsWebApp.Infrastructure;
using MediatR;

namespace ContactsWebApp.Application.Contacts.Handlers.Commands
{
    public class CreateContactCommandHandler : IRequestHandler<CreateContactCommand, Guid>
    {
        private readonly AppDbContext _context;

        public CreateContactCommandHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(CreateContactCommand request, CancellationToken cancellationToken)
        {
            //TODO: Do it in the class
            var contact = new Contact()
            {
                FirstName = request.FirstName,
                Surname = request.Surname,
                DateOfBirth = request.DateOfBirth,
                Address = request.Address,
                PhoneNumber = request.PhoneNumber,
                IBAN = request.IBAN //TODO: Encrypt before storing!
            };

            await _context.Contacts.AddAsync(contact);
            await _context.SaveChangesAsync(cancellationToken);
            return contact.Id;
        }
    }
}
