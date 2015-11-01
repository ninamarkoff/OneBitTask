using UserApp.DBModels.DBModels;

namespace UserApp.Data.Contracts
{
   public interface IUserAppData
    {
        IRepository<User> Users { get; }

        IRepository<Status> Statuses { get; }

        IRepository<Gender> Genders { get; }

        int SaveChanges();
    
    }
}