using ContactsWebApp.Application.Contacts.Commands;
using ContactsWebApp.Infrastructure.Persistence;
using ContactsWebApp.Infrastructure.Services;
using MediatR;

namespace ContactsWebApp.Application.Contacts.Handlers.Commands
{
    public class EditContactCommandHandler : IRequestHandler<EditContactCommand, Guid>
    {
        private readonly AppDbContext context;
        private readonly IEncryptionService encryptionService;

        public EditContactCommandHandler(AppDbContext context, IEncryptionService encryptionService)
        {
            this.context = context;
            this.encryptionService = encryptionService;
        }

        public async Task<Guid> Handle(EditContactCommand request, CancellationToken cancellationToken)
        {
            var contact = await context.Contacts.FindAsync(request.Id);
            if (contact == null)
            {
                throw new Exception($"Contact with ID {request.Id} not found.");
            }

            contact.Edit(request.FirstName, request.Surname, request.DateOfBirth, request.Address, request.PhoneNumber, request.IBAN);

            context.Contacts.Update(contact);
            await context.SaveChangesAsync(cancellationToken);

            return contact.Id;
        }
    }
}
