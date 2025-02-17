using MediatR;

namespace ContactsWebApp.Application.Contacts.Commands
{
    public class DeleteContactCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
