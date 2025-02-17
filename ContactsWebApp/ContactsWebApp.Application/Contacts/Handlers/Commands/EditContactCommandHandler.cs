using ContactsWebApp.Application.Contacts.Commands;
using ContactsWebApp.Domain;
using ContactsWebApp.Infrastructure;
using MediatR;

namespace ContactsWebApp.Application.Contacts.Handlers.Commands
{
    public class EditContactCommandHandler : IRequestHandler<EditContactCommand, Guid>
    {
        private readonly AppDbContext _context;

        public EditContactCommandHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(EditContactCommand request, CancellationToken cancellationToken)
        {
            var contact = await _context.Contacts.FindAsync(request.Id);
            if (contact == null)
            {
                throw new Exception($"Contact with ID {request.Id} not found.");
            }

            contact.FirstName = request.FirstName;
            contact.Surname = request.Surname;
            contact.DateOfBirth = request.DateOfBirth;
            contact.Address = request.Address;
            contact.PhoneNumber = request.PhoneNumber;
            contact.IBAN = request.IBAN;

            _context.Contacts.Update(contact);
            await _context.SaveChangesAsync(cancellationToken);

            return contact.Id;
        }
    }
}
