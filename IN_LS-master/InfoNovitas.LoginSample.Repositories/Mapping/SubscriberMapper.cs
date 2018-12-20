using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoNovitas.LoginSample.Repositories.Mapping
{
    public static class SubscriberMapper
    {
        public static Model.Subscriber.Subscriber MapToModel(this DatabaseModel.Subscriber_GetAll_Result dbResult)
        {
            if (dbResult == null)
                return null;
            return new Model.Subscriber.Subscriber()
            {
                Id = dbResult.Id,
                FName = dbResult.FName,
                LName=dbResult.LName,
                BooksReserved=dbResult.BooksReserved
            };
        }

        public static List<Model.Subscriber.Subscriber> MapToModels(this IEnumerable<DatabaseModel.Subscriber_GetAll_Result> dbResults)
        {
            var result = new List<Model.Subscriber.Subscriber>();
            if (dbResults == null)
                return result;
            result.AddRange(dbResults.Select(b => b.MapToModel()));
            return result;
        }
    }
}
