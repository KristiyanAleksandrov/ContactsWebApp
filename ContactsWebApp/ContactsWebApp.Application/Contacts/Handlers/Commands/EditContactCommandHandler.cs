using ContactsWebApp.Application.Contacts.Commands;
using ContactsWebApp.Domain;
using ContactsWebApp.Infrastructure.Persistence;
using MediatR;

namespace ContactsWebApp.Application.Contacts.Handlers.Commands
{
    public class EditContactCommandHandler : IRequestHandler<EditContactCommand, Guid>
    {
        private readonly AppDbContext context;

        public EditContactCommandHandler(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<Guid> Handle(EditContactCommand request, CancellationToken cancellationToken)
        {
            var contact = await context.Contacts.FindAsync(request.Id);
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

            context.Contacts.Update(contact);
            await context.SaveChangesAsync(cancellationToken);

            return contact.Id;
        }
    }
}
