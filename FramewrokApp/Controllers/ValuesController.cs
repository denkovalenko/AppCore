using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FrameworkApp.ServiceInterfaces.Interfaces;
using FramewrokApp.Models;
using Microsoft.AspNetCore.Mvc;

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

        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            var qws = AppDomain.CurrentDomain.GetAssemblies();
            var qw = AppDomain.CurrentDomain.GetAssemblies().Where(x => x.FullName.Contains("FramewrokApp"));

            var q = serviceFactory.UserService.GetUser();
            UserViewModel mod = _mapper.Map<UserViewModel>(q);
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
