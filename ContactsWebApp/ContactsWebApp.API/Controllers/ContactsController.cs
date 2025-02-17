using ContactsWebApp.Application.Contacts.Commands;
using ContactsWebApp.Application.Contacts.Models;
using ContactsWebApp.Application.Contacts.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ContactsWebApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ContactsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContactDto>>> GetAllContacts()
        {
            var contacts = await _mediator.Send(new GetAllContactsQuery());
            return Ok(contacts);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ContactDto>> GetById(Guid id)
        {
            var contact = await _mediator.Send(new GetContactByIdQuery { Id = id });
            return Ok(contact);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateContact(CreateContactCommand command)
        {
            var contactId = await _mediator.Send(command);
            return Ok(contactId);
        }

        [HttpPut]
        public async Task<ActionResult<Guid>> EditContact(EditContactCommand command)
        {
            //TODO: Add validatiors for everything
            var contactId = await _mediator.Send(command);
            return Ok(contactId);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteContact(Guid id)
        {
            await _mediator.Send(new DeleteContactCommand { Id = id });
            return Ok();
        }
    }
}
