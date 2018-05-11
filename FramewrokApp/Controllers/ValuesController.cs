using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FrameworkApp.ServiceInterfaces.Interfaces;
using Microsoft.AspNetCore.Mvc;
using FrameworkApp.DependencyInjection.ViewModels.User;
using FrameworkApp.ServiceInterfaces.DTO;

namespace FramewrokApp.Controllers
{
    [Route("api/Values")]
    public class ValuesController : Controller
    {
        private IServiceFactory serviceFactory;
        private readonly IMapper _mapper;
       public ValuesController(IServiceFactory _serviceFactory, IMapper mapper)
        {
            serviceFactory = _serviceFactory;
            _mapper = mapper;
        }

        [Route("GetUser")]
        public IActionResult GetUser()
        {
            UserDTO userDTO= serviceFactory.UserService.GetUser("qwe@qwe.ww");
            UserViewModel result = _mapper.Map<UserViewModel>(userDTO);
            return Ok(result);
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
