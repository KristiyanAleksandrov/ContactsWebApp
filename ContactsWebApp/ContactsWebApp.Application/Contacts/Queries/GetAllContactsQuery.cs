using ContactsWebApp.Application.Contacts.Models;
using MediatR;

namespace ContactsWebApp.Application.Contacts.Queries
{
    public class GetAllContactsQuery : IRequest<IEnumerable<ContactDto>>
    {

    }
}
