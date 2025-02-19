using ContactsWebApp.Application.Contacts.Models;
using ContactsWebApp.Application.Contacts.Queries;
using ContactsWebApp.Infrastructure.Persistence;
using ContactsWebApp.Infrastructure.Services;
using MediatR;

namespace ContactsWebApp.Application.Contacts.Handlers.Queries
{
    public class GetContactByIdQueryHandler : IRequestHandler<GetContactByIdQuery, ContactDto>
    {
        private readonly AppDbContext context;
        private readonly IEncryptionService encryptionService;

        public GetContactByIdQueryHandler(AppDbContext context, IEncryptionService encryptionService)
        {
            this.context = context;
            this.encryptionService = encryptionService;
        }

        public async Task<ContactDto> Handle(GetContactByIdQuery request, CancellationToken cancellationToken)
        {
            var contact = await context.Contacts.FindAsync(request.Id);
            if (contact == null)
            {
                throw new Exception($"Contact with ID {request.Id} not found.");
            }

            var decriptedIBAN = encryptionService.Decrypt(contact.IBAN);

            return new ContactDto
            {
                Id = contact.Id,
                FirstName = contact.FirstName,
                Surname = contact.Surname,
                DateOfBirth = contact.DateOfBirth,
                Address = contact.Address,
                PhoneNumber = contact.PhoneNumber,
                IBAN = decriptedIBAN
            };
        }
    }
}