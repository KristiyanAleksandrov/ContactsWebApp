using MediatR;

namespace ContactsWebApp.Application.Contacts.Commands
{
    public class CreateContactCommand : IRequest<Guid>
    {
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string IBAN { get; set; }
    }
}
