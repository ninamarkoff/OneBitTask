using System.Collections;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using UserApp.Data;
using UserApp.Data.Contracts;
using UserApp.DBModels.DBModels;
using UsersApp.WebAPI.ViewModels;

namespace UsersApp.WebAPI.Controllers
{
    using System.Web.Http;

    public class UserController : BaseController
    {
        public UserController(IUserAppData data) :
            base(data)
        {

        }

        [HttpGet]
        public IHttpActionResult All()
        {
            var dbUsers = data.Users.All().Where(p => p.Status.Description.ToLower() != "deleted");
            var usersViewModels = Mapper.Map<ICollection<UserViewModel>>(dbUsers);
            return Ok(usersViewModels);
        }


        [HttpGet]
        public IHttpActionResult GetById([FromUri]int id)
        {
            var dbUser = data.Users.All().FirstOrDefault(p => p.UserId == id && p.Status.Description.ToLower() != "deleted");
            if (dbUser == null)
            {
                return NotFound();
            }

            var userViewModels = Mapper.Map<UserViewModel>(dbUser);
            return Ok(userViewModels);
        }

        [HttpPut]
        public IHttpActionResult UpdateUser(int id)
        {
            var dbUser = data.Users.All().FirstOrDefault(p => p.UserId == id && p.Status.Description.ToLower() != "deleted");
            if (dbUser == null)
            {
                return NotFound();
            }
            if (dbUser.StatusId == 0)
            {
                dbUser.StatusId = 1;
            }
            else if (dbUser.StatusId == 1)
            {
                dbUser.StatusId = 0;
            }
            data.Users.Update(dbUser);
            dbUser = data.Users.All().FirstOrDefault(p => p.UserId == id && p.Status.Description.ToLower() != "deleted");
            var userViewModels = Mapper.Map<UserViewModel>(dbUser);
            return Ok(userViewModels);
        }

        [HttpDelete]
        public IHttpActionResult DeleteUser(int id)
        {
            var dbUser = data.Users.All().FirstOrDefault(p => p.UserId == id && p.Status.Description.ToLower() != "deleted");
            if (dbUser == null)
            {
                return NotFound();
            }

            dbUser.StatusId = 2;
            data.Users.Update(dbUser);
            dbUser = data.Users.All().FirstOrDefault(p => p.UserId == id);

            if (dbUser.StatusId == 2)
            {
                return Ok();
            }

            return BadRequest("Not deleted");
        }
    }
}
