using Global.Application.Commands.Handlers.Contact;
using Global.Application.Commands.Results.Contact;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Global_api.Controllers.Contact;

[Route("api/[controller]")]
[Authorize]
[ApiController]
public class ContactController : ControllerBase
{
    private readonly CreateContactCommandHandler _createContactCommandHandler;
    private readonly UpdateContactCommandHandler _updateContactCommandHandler;
    private readonly GetContactCommandHandler _getContactCommandHandler;

    public ContactController(
        CreateContactCommandHandler createContactCommandHandler,
        UpdateContactCommandHandler updateContactCommandHandler,
        GetContactCommandHandler getContactCommandHandler)
    {
        _createContactCommandHandler = createContactCommandHandler;
        _updateContactCommandHandler = updateContactCommandHandler;
        _getContactCommandHandler = getContactCommandHandler;
    }

    #region GET
    [HttpGet]
    [Route("{id}")]
    public async Task<ActionResult<GetContactCommandResult>> GetById([FromRoute] int id)
    {
        var result = await _getContactCommandHandler.Handle(id);
        if (result == null)
        {
            return NotFound(new { Message = "Contact not found" });
        }
        return Ok(result);
    }
    #endregion

//    #region POST
//    [HttpPost]
//    public async Task<ActionResult<CreateContactCommandResult>> Create([FromBody] CreateContactCommand command)
//    {
//        if (command == null)
//        {
//            return BadRequest(new { Message = "Invalid contact data" });
//        }

//        var result = await _createContactCommandHandler.Handle(command);
//        if (result == null)
//        {
//            return BadRequest(new { Message = "Error creating contact" });
//        }

//        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
//    }
//    #endregion

//    #region PATCH
//    [HttpPatch]
//    [Route("{id}")]
//    public async Task<ActionResult> UpdatePartial([FromRoute] int id, [FromBody] UpdateContactCommand command)
//    {
//        if (command == null || id != command.Id)
//        {
//            return BadRequest(new { Message = "Invalid contact data" });
//        }

//        var result = await _updateContactCommandHandler.Handle(command);
//        if (result == null)
//        {
//            return NotFound(new { Message = "Contact not found to update" });
//        }

//        return NoContent(); // No content returned on successful update
//    }
//    #endregion

//    #region PUT
//    [HttpPut]
//    [Route("{id}")]
//    public async Task<ActionResult> Update([FromRoute] int id, [FromBody] UpdateContactCommand command)
//    {
//        if (command == null || id != command.Id)
//        {
//            return BadRequest(new { Message = "Invalid contact data" });
//        }

//        var result = await _updateContactCommandHandler.Handle(command);
//        if (result == null)
//        {
//            return NotFound(new { Message = "Contact not found to update" });
//        }

//        return Ok(result); // Return updated contact
//    }
//    #endregion

//    #region DELETE
//    [HttpDelete]
//    [Route("{id}")]
//    public async Task<ActionResult> Delete([FromRoute] int id)
//    {
//        var success = await _createContactCommandHandler.DeleteContact(id);
//        if (!success)
//        {
//            return NotFound(new { Message = "Contact not found" });
//        }

//        return NoContent(); // Return 204 on successful delete
//    }
//    #endregion
}
