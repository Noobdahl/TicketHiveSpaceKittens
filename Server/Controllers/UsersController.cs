using Microsoft.AspNetCore.Mvc;
using TicketHiveSpaceKittens.Server.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TicketHiveSpaceKittens.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepo repo;

        public UsersController(IUserRepo repo)
        {
            this.repo = repo;
        }
        // GET: api/<UsersController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<UsersController>/5
        [HttpGet("{username}")]
        public async Task<ActionResult<string>> Get(string username)
        {
            var result = await repo.GetCountryAsync(username);
            return Ok(result);
        }

        // POST api/<UsersController>
        [HttpPost]
        public void Post([FromBody] string username)
        {
            repo.AddUser(username, "Sweden");//TODO change to input country
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
