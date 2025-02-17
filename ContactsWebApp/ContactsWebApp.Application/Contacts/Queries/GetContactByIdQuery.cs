using ContactsWebApp.Application.Contacts.Models;
using MediatR;

namespace ContactsWebApp.Application.Contacts.Queries
{
    public class GetContactByIdQuery : IRequest<ContactDto>
    {
        public Guid Id { get; set; }
    }
}
