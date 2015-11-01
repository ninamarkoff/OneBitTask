namespace UserApp.Data
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using Contracts;
    using DBModels.DBModels;
    using Interfaces;

    public class UserAppData : IUserAppData
    {
        private DbContext context;
        private IDictionary<Type, object> repositories;

        public UserAppData(DbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public IRepository<User> Users
        {
            get
            {
                return this.GetRepository<User>();
            }
        }

        public IRepository<Status> Statuses
        {
            get
            {
                return this.GetRepository<Status>();
            }
        }

        public IRepository<Gender> Genders
        {
            get
            {
                return this.GetRepository<Gender>();
            }
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            var typeOfModel = typeof(T);
            if (!this.repositories.ContainsKey(typeOfModel))
            {
                var type = typeof(Repository<T>);

                this.repositories.Add(typeOfModel, Activator.CreateInstance(type, this.context));
            }

            return (IRepository<T>)this.repositories[typeOfModel];
        }
    }
}
