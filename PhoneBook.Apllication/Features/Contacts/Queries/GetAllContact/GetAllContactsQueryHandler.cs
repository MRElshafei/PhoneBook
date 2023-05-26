using AutoMapper;
using MediatR;
using PhoneBook.Apllication.Interfaces;
using PhoneBook.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Apllication.Features.Contacts.Queries.GetAllContact
{
    public class GetAllContactsQueryHandler : IRequestHandler<GetAllContactsQueryInput, GetAllContactsQueryOutput>
    {
        private readonly IAsyncRepository _asyncRepository;
        private readonly IMapper _mapper;

        public GetAllContactsQueryHandler(IAsyncRepository asyncRepository, IMapper mapper)
        {
            _asyncRepository = asyncRepository;
            _mapper = mapper;
        }
        public async Task<GetAllContactsQueryOutput> Handle(GetAllContactsQueryInput request, CancellationToken cancellationToken)
        {
            var contacts = await _asyncRepository.GetAllContactsAsync(request.Email);
            var output = new GetAllContactsQueryOutput
            {
                AllContacts = _mapper.Map<List<AllContacts>>(contacts)
            };

            #region another solution 

            //GetAllContactsQueryOutput output = new GetAllContactsQueryOutput();

            //output.AllContacts =  contacts.Select(c => new AllContacts
            //{
            //   FirstName= c.FirstName,
            //   LastName= c.LastName,    
            //   PhoneNumber= c.PhoneNumber,
            //   Adress= c.Adress,
            //   Emaile= c.Emaile,
            //   HomeNumber= c.HomeNumber,
            //   WorkNumber= c.WorkNumber

            //}).ToList();
            #endregion

            return output;
        }

  
    }
}
