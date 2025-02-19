using ContactsWebApp.Domain;
using Microsoft.EntityFrameworkCore;

namespace ContactsWebApp.Infrastructure.Persistence
{
    public class SeedData
    {
        public static async Task InitializeAsync(AppDbContext context)
        {
            if (await context.Contacts.AnyAsync()) return;

            var contacts = new List<Contact>
            {
                new Contact("John", "Doe", new DateTime(1990, 5, 15), "123 Main St", "+1234567890", "DE44500105175407324931"),
                new Contact("Alice", "Smith", new DateTime(1985, 10, 22), "456 Elm St", "+1987654321", "GB29NWBK60161331926819"),
                new Contact("Bob", "Johnson", new DateTime(1978, 3, 8), "789 Oak St", "+1555123456", "FR7630001007941234567890185"),
                new Contact("Emma", "Williams", new DateTime(1995, 7, 30), "567 Maple St", "+1444333222", "ES9121000418450200051332")
            };

            await context.Contacts.AddRangeAsync(contacts);
            await context.SaveChangesAsync();
        }
    }
}
