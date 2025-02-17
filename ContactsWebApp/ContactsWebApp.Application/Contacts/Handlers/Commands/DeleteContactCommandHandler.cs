using ContactsWebApp.Application.Contacts.Commands;
using ContactsWebApp.Infrastructure.Persistence;
using MediatR;

namespace ContactsWebApp.Application.Contacts.Handlers.Commands
{
    public class DeleteContactCommandHandler : IRequestHandler<DeleteContactCommand>
    {
        private readonly AppDbContext context;

        public DeleteContactCommandHandler(AppDbContext context)
        {
            this.context = context;
        }

        public async Task Handle(DeleteContactCommand request, CancellationToken cancellationToken)
        {
            var contact = await context.Contacts.FindAsync(request.Id);
            if (contact == null)
            {
                throw new Exception($"Contact with ID {request.Id} not found.");
            }

            contact.Delete();
            await context.SaveChangesAsync(cancellationToken);
        }
    }
}