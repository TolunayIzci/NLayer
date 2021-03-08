using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyNLayerProject.API.DTOs;
using UdemyNLayerProject.Core.Models;
using UdemyNLayerProject.Core.Services;

namespace UdemyNLayerProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IService<Person> _PersonService;

        public PersonsController(IService<Person> service, IMapper mapper)
        {

            _PersonService = service;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var persons = await _PersonService.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<PersonDto>>(persons));
        }
        [HttpPost]
        public async Task<IActionResult> Add(PersonDto personDto)
        {
            var persons = await _PersonService.AddAsync(_mapper.Map<Person>(personDto));
            return Created(string.Empty, _mapper.Map<PersonDto>(persons));
        }
    }


}
