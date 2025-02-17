using ContactsWebApp.Application.Contacts.Models;
using ContactsWebApp.Application.Contacts.Queries;
using ContactsWebApp.Infrastructure;
using MediatR;

namespace ContactsWebApp.Application.Contacts.Handlers.Queries
{
    public class GetContactByIdQueryHandler : IRequestHandler<GetContactByIdQuery, ContactDto>
    {
        private readonly AppDbContext _context;

        public GetContactByIdQueryHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ContactDto> Handle(GetContactByIdQuery request, CancellationToken cancellationToken)
        {
            var contact = await _context.Contacts.FindAsync(request.Id);
            if (contact == null)
            {
                throw new Exception($"Contact with ID {request.Id} not found.");
            }

            return new ContactDto
            {
                Id = contact.Id,
                FirstName = contact.FirstName,
                Surname = contact.Surname,
                DateOfBirth = contact.DateOfBirth,
                Address = contact.Address,
                PhoneNumber = contact.PhoneNumber,
                IBAN = contact.IBAN
            };
        }
    }
}