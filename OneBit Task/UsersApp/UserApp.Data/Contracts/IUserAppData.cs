namespace UserApp.Data.Contracts
{
    using DBModels.DBModels;

   public interface IUserAppData
    {
        IRepository<User> Users { get; }

        IRepository<Status> Statuses { get; }

        IRepository<Gender> Genders { get; }

        int SaveChanges();
    
    }
}