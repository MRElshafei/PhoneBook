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
                var getAllContactsQuery = new GetAllContactsQuery
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
                // Handle unexpected exceptions
                return StatusCode(500, "Sorry, something went wrong!");
            }




        }
        [HttpPost("addcontact")]
        public async Task<IActionResult> Create([FromBody] ContactInfo contactInfo)
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
                    if (contactInfo is null)
                    {
                        return BadRequest("Your Contact Informations are Wrong or Empty !!");
                    }
                    var userId = User.FindFirstValue(ClaimTypes.Email);
                    contactInfo.UserEmaile = userId;

                    var getEventDetailQuery = new AddContactCommand(contactInfo);
                    var NewContactInfo = await _mediator.Send(getEventDetailQuery);

                    return Ok(NewContactInfo);
                }
            }
            catch (Exception)
            {

                return Ok("Sorry,Something went wrong!!!!");
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
                    return Ok("Your Contact Informations are Wrong or Empty !!");
                }
                var getEventDetailQuery = new UpdateContactCommand(contactInfo);
                var NewContactInfo = await _mediator.Send(getEventDetailQuery);
                return Ok(NewContactInfo);
            }
            catch (Exception)
            {

                return Ok("Sorry,Something went wrong!!!!");
            }

        }

        [HttpDelete("DeletePost")]
        public async Task<IActionResult> Delete([FromBody] ContactInfo contactInfo)
        {
            try
            {
                //check if contactInfo is empty
                if (contactInfo is null)
                {
                    return Ok("Your Contact Informations are Wrong or Empty !!");
                }
                var deletePostCommand = new DeleteContactQuery(contactInfo);
                //check if there is no contact like this
                if (deletePostCommand is null)
                {
                    return Ok("Your Contact Informations are Wrong  !!");
                }
                var Massage = await _mediator.Send(deletePostCommand);
                return Ok(Massage);
            }
            catch (Exception)
            {

                return Ok("Sorry,Something went wrong!!!!");
            }

        }

    }
}
