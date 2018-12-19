using InfoNovitas.LoginSample.Model.Books;
using InfoNovitas.LoginSample.Repositories.DatabaseModel;
using System;
using System.Collections.Generic;
using InfoNovitas.LoginSample.Repositories.Mapping;

namespace InfoNovitas.LoginSample.Repositories.Books
{
    public class BookRepository : IBookRepository
    {
        public List<Book> FindAll()
        {
            using (var context = new IdentityExDbEntities())
            {
                return context.Book_GetAllBooks().MapToModels();
            }
        }

        #region Not implemented
        public int Add(Book item)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Book item)
        {
            throw new NotImplementedException();
        }



        public Book FindBy(int key)
        {
            throw new NotImplementedException();
        }

        public Book Save(Book item)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
