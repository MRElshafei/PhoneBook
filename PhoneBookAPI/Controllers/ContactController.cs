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
        private readonly ISender _sender;

        public ContactController(ISender sender)
        {
            _sender = sender;
        }

        
        [HttpGet("getallcontact")]
        public async Task<IActionResult> GetAllContacts()
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.Email);
                var getEventDetailQuery = new GetAllContactsQuery(userId);
                // Check if there is no contacts
                if (getEventDetailQuery is null|| string.IsNullOrEmpty(getEventDetailQuery.ToString())  )
                {
                    return Ok("No Contacts Yet!!");
                }
                return Ok(await _sender.Send(getEventDetailQuery));
            }
            catch (Exception)
            {

                return Ok("Sorry,Something went wrong!!!!");
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
                        return Ok("Your Contact Informations are Wrong or Empty !!");
                    }
                    var userId = User.FindFirstValue(ClaimTypes.Email);
                    contactInfo.UserEmaile = userId;

                    var getEventDetailQuery = new AddContactCommand(contactInfo);
                    var NewContactInfo = await _sender.Send(getEventDetailQuery);

                    return Ok(NewContactInfo);
                }
            }
            catch (Exception)
            {

                return Ok("Sorry,Something went wrong!!!!");
            }
          
        }

        [HttpPut( "UpdatePost")]
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
                var NewContactInfo = await _sender.Send(getEventDetailQuery);
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
                var Massage = await _sender.Send(deletePostCommand);
                return Ok(Massage);
            }
            catch (Exception)
            {

                return Ok("Sorry,Something went wrong!!!!");
            }
            
        }

    }
}
