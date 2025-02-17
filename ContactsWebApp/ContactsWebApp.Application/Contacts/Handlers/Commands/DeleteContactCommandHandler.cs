using ContactsWebApp.Application.Contacts.Commands;
using ContactsWebApp.Infrastructure;
using MediatR;

namespace ContactsWebApp.Application.Contacts.Handlers.Commands
{
    public class DeleteContactCommandHandler : IRequestHandler<DeleteContactCommand>
    {
        private readonly AppDbContext _context;

        public DeleteContactCommandHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task Handle(DeleteContactCommand request, CancellationToken cancellationToken)
        {
            var contact = await _context.Contacts.FindAsync(request.Id);
            if (contact == null)
            {
                throw new Exception($"Contact with ID {request.Id} not found.");
            }

            contact.Delete();
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}