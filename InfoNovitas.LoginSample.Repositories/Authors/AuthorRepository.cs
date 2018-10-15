using InfoNovitas.LoginSample.Model.Authors;
using InfoNovitas.LoginSample.Repositories.DatabaseModel;
using InfoNovitas.LoginSample.Repositories.Mapping;
using System.Collections.Generic;
using System.Linq;

namespace InfoNovitas.LoginSample.Repositories.Authors
{
    public class AuthorRepository : IAuthorRepository
    {
        public List<Author> FindAll()
        {
            using (var context = new IdentityExDbEntities())
            {
                return context.Author_GetAll().MapToModels();
            }
        }

        public bool Delete(Author item)
        {
            using (var context = new IdentityExDbEntities())
            {
                context.Author_Delete(item.Id, item.LastModified, item.UserLastModified?.Id);
            }
            return true;
        }

        public int Add(Author item)
        {
            using (var context = new IdentityExDbEntities())
            {
                return context.Author_Insert(
                    item.FirstName,
                    item.LastName, 
                    item.DateCreated, 
                    item.UserCreated?.Id, 
                    item.BirthDate,
                    item.BirthPlace,
                    item.DeathDate,
                    item.DeathPlace,
                    item.Description,
                    item.Url
                   ).SingleOrDefault().GetValueOrDefault();
            }
        }

        public Author Save(Author item)
        {
            using (var context = new IdentityExDbEntities())
            {
                context.Author_Save(item.Id, item.FirstName, item.LastName, item.LastModified, item.UserLastModified?.Id);
                return item;
            }
        }

        public Author FindBy(int key)
        {
            using (var context = new IdentityExDbEntities())
            {
                return context.Author_Get(key).FirstOrDefault().MapToModel();
            }
        }
    }
}
