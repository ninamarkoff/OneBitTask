namespace UsersApp.WebAPI.Controllers
{
    using UserApp.Data.Contracts;
    using System.Web.Http;

    //[HandleError(View = "Some Error Occured")]
    public class BaseController : ApiController
    {
        protected IUserAppData data;

        public BaseController(IUserAppData data)
        {
            this.data = data;
        }
    }
}