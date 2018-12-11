using InfoNovitas.LoginSample.Model.Genres;
using InfoNovitas.LoginSample.Repositories.DatabaseModel;
using InfoNovitas.LoginSample.Repositories.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoNovitas.LoginSample.Repositories.Genres
{
    public class GenreRepository:IGenreRepository
    {
        public List<Genre> FindAll()
        {
            using (var context = new IdentityExDbEntities())
            {
                return context.Genre_GetAllGenres().MapToModels();
            }
        }

        #region Not implemented
        public int Add(Genre item)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Genre item)
        {
            throw new NotImplementedException();
        }



        public Genre FindBy(int key)
        {
            throw new NotImplementedException();
        }

        public Genre Save(Genre item)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
