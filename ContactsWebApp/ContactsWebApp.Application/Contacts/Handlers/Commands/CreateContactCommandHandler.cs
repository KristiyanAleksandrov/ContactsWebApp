using ContactsWebApp.Application.Contacts.Commands;
using ContactsWebApp.Domain;
using ContactsWebApp.Infrastructure.Persistence;
using ContactsWebApp.Infrastructure.Services;
using MediatR;

namespace ContactsWebApp.Application.Contacts.Handlers.Commands
{
    public class CreateContactCommandHandler : IRequestHandler<CreateContactCommand, Guid>
    {
        private readonly AppDbContext context;
        private readonly IEncryptionService encryptionService;

        public CreateContactCommandHandler(AppDbContext context, IEncryptionService encryptionService)
        {
            this.context = context;
            this.encryptionService = encryptionService;
        }

        public async Task<Guid> Handle(CreateContactCommand request, CancellationToken cancellationToken)
        {
            var encriptedIBAN = encryptionService.Encrypt(request.IBAN);

            var contact = new Contact()
            {
                FirstName = request.FirstName,
                Surname = request.Surname,
                DateOfBirth = request.DateOfBirth,
                Address = request.Address,
                PhoneNumber = request.PhoneNumber,
                IBAN = encriptedIBAN
            };

            await context.Contacts.AddAsync(contact);
            await context.SaveChangesAsync(cancellationToken);
            return contact.Id;
        }
    }
}
