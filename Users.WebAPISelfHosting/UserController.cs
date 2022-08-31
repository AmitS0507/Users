using System.Net;
using System.Web.Http;
using Users.IBL;
using Users.Model;

namespace Users.WebAPI.SelfHosting
{
    [RoutePrefix("api/users")]
    public class UserController : ApiController
    {

        private IUserRepository _userRepository = null;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [Route("")]
        [HttpGet]
        public IHttpActionResult GetUsers()
        {
            var users = _userRepository.GetUsers();
            if (users.Count == 0)
            {
                return NotFound();
            }

            return Ok(users);
        }


        [Route("{id:int}")]
        [HttpGet]
        public IHttpActionResult GetUserByID(int id)
        {
            var user = _userRepository.GetUserByID(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);

        }

        [Route("")]
        [HttpPost]
        public IHttpActionResult PostNewUser(UserModel value)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");

            if (value != null)
            
                _userRepository.InsertUser(value);
            
            return CreatedAtRoute("DefaultApi", new { id = value.Id }, value);
            
        }

        [Route("updateuser")]
        [HttpPut]
        public IHttpActionResult Put(UserModel value)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");
            var status = _userRepository.UpdateUser(value);
            if (status == "Not Found")
                return NotFound();
            else
                return Content(HttpStatusCode.Accepted, value); ;
        }

        [Route("deleteuser")]
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            if (id <= 0)
                return BadRequest("Not a valid user id");
            _userRepository.DeleteUser(id);
            return Ok();
        }
    }
}
