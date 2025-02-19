namespace ContactsWebApp.Domain
{
    public class Contact
    {
        public Guid Id { get; private set; }
        public string FirstName { get; private set; }
        public string Surname { get; private set; }
        public DateTime DateOfBirth { get; private set; }
        public string Address { get; private set; }
        public string PhoneNumber { get; private set; }
        public string IBAN { get; private set; }
        public bool IsDeleted { get; private set; }
        public DateTime? DeletedAt { get; private set; }

        private Contact() { }

        public Contact(string firstName, string surname, DateTime dateOfBirth, string address, string phoneNumber, string iban)
        {
            Id = Guid.NewGuid();
            FirstName = firstName;
            Surname = surname;
            DateOfBirth = dateOfBirth;
            Address = address;
            PhoneNumber = phoneNumber;
            IBAN = iban;
        }

        public void Edit(string firstName, string surname, DateTime dateOfBirth, string address, string phoneNumber, string iban)
        {
            FirstName = firstName;
            Surname = surname;
            DateOfBirth = dateOfBirth;
            Address = address;
            PhoneNumber = phoneNumber;
            IBAN = iban;
        }
        public void Delete()
        {
            IsDeleted = true;
            DeletedAt = DateTime.UtcNow;
        }
    }
}
