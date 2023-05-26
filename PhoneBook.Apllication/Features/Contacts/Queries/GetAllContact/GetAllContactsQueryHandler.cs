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
    public class GetAllContactsQueryHandler : IRequestHandler<GetAllContactsQuery, GetAllContactsQueryOutput>
    {
        private readonly IAsyncRepository _asyncRepository;
        private readonly IMapper _mapper;

        public GetAllContactsQueryHandler(IAsyncRepository asyncRepository, IMapper mapper)
        {
            _asyncRepository = asyncRepository;
            _mapper = mapper;
        }
        public async Task<GetAllContactsQueryOutput> Handle(GetAllContactsQuery request, CancellationToken cancellationToken)
        {

            //GetAllContactsQueryOutput output = new GetAllContactsQueryOutput();
            var contacts = await _asyncRepository.GetAllContactsAsync(request.Email);
            var output = new GetAllContactsQueryOutput
            {
                AllContacts = _mapper.Map<List<AllContacts>>(contacts)
            };
             
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

            return output;
        }

  
    }
}
