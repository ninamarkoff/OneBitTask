namespace UsersApp.WebAPI.Controllers
{
    using UserApp.Data.Contracts;

    using System.Web.Http;
    using System.Web.Mvc;

    //[HandleError(View = "All")]
    public class BaseController : ApiController
    {
        protected IUserAppData data;

        public BaseController(IUserAppData data)
        {
            this.data = data;
        }
    }
}