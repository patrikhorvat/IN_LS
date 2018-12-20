using InfoNovitas.LoginSample.Model.Subscriber;
using InfoNovitas.LoginSample.Repositories.DatabaseModel;
using InfoNovitas.LoginSample.Repositories.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoNovitas.LoginSample.Repositories.Subscriber
{
    public class SubscriberRepository : ISubscriberRepository
    {
        public int Add(Model.Subscriber.Subscriber item)
        {
            using (var context = new IdentityExDbEntities())
            {
                return context.Subscriber_GetAll().MapToModels();
            }
        }

        public bool Delete(Model.Subscriber.Subscriber item)
        {
            throw new NotImplementedException();
        }

        public List<Model.Subscriber.Subscriber> FindAll()
        {
            throw new NotImplementedException();
        }

        public Model.Subscriber.Subscriber FindBy(int key)
        {
            throw new NotImplementedException();
        }

        public Model.Subscriber.Subscriber Save(Model.Subscriber.Subscriber item)
        {
            throw new NotImplementedException();
        }
    }
}
