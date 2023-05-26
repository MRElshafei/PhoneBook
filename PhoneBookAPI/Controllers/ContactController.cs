using MediatR;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using PhoneBook.Apllication.Features.Contacts.Commands.AddContact;
using PhoneBook.Apllication.Features.Contacts.Commands.DeleteContact;
using PhoneBook.Apllication.Features.Contacts.Commands.UpdateContact;
using PhoneBook.Apllication.Features.Contacts.Queries.GetAllContact;
using PhoneBook.Domain;
using System;
using System.Security.Claims;

namespace PhoneNumberApplication.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ContactController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet("getallcontact")]
        public async Task<IActionResult> GetAllContacts()
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.Email);
                var getAllContactsQuery = new GetAllContactsQueryInput
                {
                    Email = userId
                };

                if (string.IsNullOrEmpty(getAllContactsQuery.Email))
                {
                    return NotFound("No Contacts Yet!!");
                }

                var contacts = await _mediator.Send(getAllContactsQuery);
                if (contacts == null)
                {
                    return NotFound("No Contacts Yet!!");
                }

                return Ok(contacts);
            }


            catch (Exception)
            {
                return StatusCode(500, "Sorry, something went wrong!");
            }




        }
        [HttpPost("addcontact")]
        public async Task<IActionResult> Create([FromBody] ContactDTO Contact)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                else
                {
                    //check if contactInfo is empty
                    if (Contact is null)
                    {
                        return BadRequest("Your Contact Informations are Wrong or Empty !!");
                    }
                    var userId = User.FindFirstValue(ClaimTypes.Email);

                    var getEventDetailQuery = new AddContactCommandInput
                    {
                        UserEmail= userId,
                        NewContact= Contact,
                        
                    };
                    var NewContactInfo = await _mediator.Send(getEventDetailQuery);

                    return Ok(NewContactInfo);
                }
            }
            catch (Exception)
            {

                return StatusCode(500, "Sorry, something went wrong!");
            }

        }

        [HttpPut("UpdatePost")]
        public async Task<IActionResult> Update([FromBody] ContactInfo contactInfo)
        {
            try
            {
                //check if contactInfo is empty
                if (contactInfo is null)
                {
                    return BadRequest("Contact information is missing or invalid!");
                }
                var getEventDetailQuery = new UpdateContactCommandInput
                {
                    UpdatedContact= contactInfo
                };
                var NewContactInfo = await _mediator.Send(getEventDetailQuery);
                return Ok(NewContactInfo);
            }
            catch (Exception)
            {

                return StatusCode(500, "Sorry, something went wrong!");
            }

        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete([FromQuery] Guid contactId)
        {
            try
            {
                if (contactId == Guid.Empty)
                {
                    return BadRequest("Invalid Contact ID!");
                }

                var deleteContactCommand = new DeleteContactQueryInput
                {
                    ContactId = contactId
                };
                var result = await _mediator.Send(deleteContactCommand);

                if (result!=null)
                {
                    return Ok(result.message);
                }
                else
                {
                    return NotFound("Contact not found");
                }
            }
            catch (Exception)
            {
                return StatusCode(500, "Sorry, something went wrong!");
            }
        }


    }
}
