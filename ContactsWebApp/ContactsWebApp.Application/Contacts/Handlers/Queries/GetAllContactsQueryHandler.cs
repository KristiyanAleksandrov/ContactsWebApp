using ContactsWebApp.Application.Contacts.Models;
using ContactsWebApp.Application.Contacts.Queries;
using ContactsWebApp.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ContactsWebApp.Application.Contacts.Handlers.Queries
{
    public class GetAllContactsQueryHandler : IRequestHandler<GetAllContactsQuery, IEnumerable<ContactDto>>
    {
        private readonly AppDbContext _context;

        public GetAllContactsQueryHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ContactDto>> Handle(GetAllContactsQuery request, CancellationToken cancellationToken)
        {
            var contacts = await _context.Contacts
                .Select(c => new ContactDto
                {
                    Id = c.Id,
                    FirstName = c.FirstName,
                    Surname = c.Surname,
                    DateOfBirth = c.DateOfBirth,
                    Address = c.Address,
                    PhoneNumber = c.PhoneNumber,
                    IBAN = c.IBAN
                })
                .ToListAsync(cancellationToken);

            return contacts;
        }
    }
}
