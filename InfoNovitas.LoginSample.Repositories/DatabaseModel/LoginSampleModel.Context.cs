﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace InfoNovitas.LoginSample.Repositories.DatabaseModel
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class IdentityExDbEntities : DbContext
    {
        public IdentityExDbEntities()
            : base("name=IdentityExDbEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<UserInfo> UserInfoes { get; set; }
    
        public virtual int Author_Delete(Nullable<int> id, Nullable<System.DateTimeOffset> lastModified, Nullable<int> userLastModified)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(int));
    
            var lastModifiedParameter = lastModified.HasValue ?
                new ObjectParameter("LastModified", lastModified) :
                new ObjectParameter("LastModified", typeof(System.DateTimeOffset));
    
            var userLastModifiedParameter = userLastModified.HasValue ?
                new ObjectParameter("UserLastModified", userLastModified) :
                new ObjectParameter("UserLastModified", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Author_Delete", idParameter, lastModifiedParameter, userLastModifiedParameter);
        }
    
        public virtual ObjectResult<Author_Get_Result> Author_Get(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Author_Get_Result>("Author_Get", idParameter);
        }
    
        public virtual ObjectResult<Author_GetAll_Result> Author_GetAll()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Author_GetAll_Result>("Author_GetAll");
        }
    
        public virtual ObjectResult<Nullable<int>> Author_Insert(string firstName, string lastName, Nullable<System.DateTimeOffset> dateCreated, Nullable<int> userCreated, Nullable<System.DateTime> birthDate, string birthPlace, Nullable<System.DateTime> deathDate, string deathPlace, string description, string url)
        {
            var firstNameParameter = firstName != null ?
                new ObjectParameter("FirstName", firstName) :
                new ObjectParameter("FirstName", typeof(string));
    
            var lastNameParameter = lastName != null ?
                new ObjectParameter("LastName", lastName) :
                new ObjectParameter("LastName", typeof(string));
    
            var dateCreatedParameter = dateCreated.HasValue ?
                new ObjectParameter("DateCreated", dateCreated) :
                new ObjectParameter("DateCreated", typeof(System.DateTimeOffset));
    
            var userCreatedParameter = userCreated.HasValue ?
                new ObjectParameter("UserCreated", userCreated) :
                new ObjectParameter("UserCreated", typeof(int));
    
            var birthDateParameter = birthDate.HasValue ?
                new ObjectParameter("BirthDate", birthDate) :
                new ObjectParameter("BirthDate", typeof(System.DateTime));
    
            var birthPlaceParameter = birthPlace != null ?
                new ObjectParameter("BirthPlace", birthPlace) :
                new ObjectParameter("BirthPlace", typeof(string));
    
            var deathDateParameter = deathDate.HasValue ?
                new ObjectParameter("DeathDate", deathDate) :
                new ObjectParameter("DeathDate", typeof(System.DateTime));
    
            var deathPlaceParameter = deathPlace != null ?
                new ObjectParameter("DeathPlace", deathPlace) :
                new ObjectParameter("DeathPlace", typeof(string));
    
            var descriptionParameter = description != null ?
                new ObjectParameter("Description", description) :
                new ObjectParameter("Description", typeof(string));
    
            var urlParameter = url != null ?
                new ObjectParameter("Url", url) :
                new ObjectParameter("Url", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("Author_Insert", firstNameParameter, lastNameParameter, dateCreatedParameter, userCreatedParameter, birthDateParameter, birthPlaceParameter, deathDateParameter, deathPlaceParameter, descriptionParameter, urlParameter);
        }
    
        public virtual int Author_Save(Nullable<int> id, string firstName, string lastName, Nullable<System.DateTime> birthDate, string birthPlace, Nullable<System.DateTime> deathDate, string deathPlace, string description, string url, Nullable<System.DateTimeOffset> lastModified, Nullable<int> userLastModified)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(int));
    
            var firstNameParameter = firstName != null ?
                new ObjectParameter("FirstName", firstName) :
                new ObjectParameter("FirstName", typeof(string));
    
            var lastNameParameter = lastName != null ?
                new ObjectParameter("LastName", lastName) :
                new ObjectParameter("LastName", typeof(string));
    
            var birthDateParameter = birthDate.HasValue ?
                new ObjectParameter("BirthDate", birthDate) :
                new ObjectParameter("BirthDate", typeof(System.DateTime));
    
            var birthPlaceParameter = birthPlace != null ?
                new ObjectParameter("BirthPlace", birthPlace) :
                new ObjectParameter("BirthPlace", typeof(string));
    
            var deathDateParameter = deathDate.HasValue ?
                new ObjectParameter("DeathDate", deathDate) :
                new ObjectParameter("DeathDate", typeof(System.DateTime));
    
            var deathPlaceParameter = deathPlace != null ?
                new ObjectParameter("DeathPlace", deathPlace) :
                new ObjectParameter("DeathPlace", typeof(string));
    
            var descriptionParameter = description != null ?
                new ObjectParameter("Description", description) :
                new ObjectParameter("Description", typeof(string));
    
            var urlParameter = url != null ?
                new ObjectParameter("Url", url) :
                new ObjectParameter("Url", typeof(string));
    
            var lastModifiedParameter = lastModified.HasValue ?
                new ObjectParameter("LastModified", lastModified) :
                new ObjectParameter("LastModified", typeof(System.DateTimeOffset));
    
            var userLastModifiedParameter = userLastModified.HasValue ?
                new ObjectParameter("UserLastModified", userLastModified) :
                new ObjectParameter("UserLastModified", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Author_Save", idParameter, firstNameParameter, lastNameParameter, birthDateParameter, birthPlaceParameter, deathDateParameter, deathPlaceParameter, descriptionParameter, urlParameter, lastModifiedParameter, userLastModifiedParameter);
        }
    
        public virtual ObjectResult<Book_Authors_GetAll_Result> Book_Authors_GetAll(Nullable<int> bookId)
        {
            var bookIdParameter = bookId.HasValue ?
                new ObjectParameter("BookId", bookId) :
                new ObjectParameter("BookId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Book_Authors_GetAll_Result>("Book_Authors_GetAll", bookIdParameter);
        }
    
        public virtual int Book_DeleteBook(Nullable<int> id, Nullable<System.DateTimeOffset> dateModified)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(int));
    
            var dateModifiedParameter = dateModified.HasValue ?
                new ObjectParameter("DateModified", dateModified) :
                new ObjectParameter("DateModified", typeof(System.DateTimeOffset));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Book_DeleteBook", idParameter, dateModifiedParameter);
        }
    
        public virtual ObjectResult<Book_GetAllBooks_Result> Book_GetAllBooks()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Book_GetAllBooks_Result>("Book_GetAllBooks");
        }
    
        public virtual ObjectResult<Book_GetBook_Result> Book_GetBook(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Book_GetBook_Result>("Book_GetBook", idParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> Book_InsertBook(Nullable<System.DateTimeOffset> dateCreated, Nullable<int> createdBy, string name, string description, string shortContent, string genre, Nullable<System.DateTime> year, string author, Nullable<System.DateTimeOffset> dateModified)
        {
            var dateCreatedParameter = dateCreated.HasValue ?
                new ObjectParameter("DateCreated", dateCreated) :
                new ObjectParameter("DateCreated", typeof(System.DateTimeOffset));
    
            var createdByParameter = createdBy.HasValue ?
                new ObjectParameter("CreatedBy", createdBy) :
                new ObjectParameter("CreatedBy", typeof(int));
    
            var nameParameter = name != null ?
                new ObjectParameter("Name", name) :
                new ObjectParameter("Name", typeof(string));
    
            var descriptionParameter = description != null ?
                new ObjectParameter("Description", description) :
                new ObjectParameter("Description", typeof(string));
    
            var shortContentParameter = shortContent != null ?
                new ObjectParameter("ShortContent", shortContent) :
                new ObjectParameter("ShortContent", typeof(string));
    
            var genreParameter = genre != null ?
                new ObjectParameter("Genre", genre) :
                new ObjectParameter("Genre", typeof(string));
    
            var yearParameter = year.HasValue ?
                new ObjectParameter("Year", year) :
                new ObjectParameter("Year", typeof(System.DateTime));
    
            var authorParameter = author != null ?
                new ObjectParameter("Author", author) :
                new ObjectParameter("Author", typeof(string));
    
            var dateModifiedParameter = dateModified.HasValue ?
                new ObjectParameter("DateModified", dateModified) :
                new ObjectParameter("DateModified", typeof(System.DateTimeOffset));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("Book_InsertBook", dateCreatedParameter, createdByParameter, nameParameter, descriptionParameter, shortContentParameter, genreParameter, yearParameter, authorParameter, dateModifiedParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> Book_SaveBook(Nullable<int> id, Nullable<System.DateTimeOffset> dateCreated, Nullable<int> createdBy, string name, string description, string shortContent, string genre, Nullable<System.DateTime> year, string author, Nullable<System.DateTimeOffset> dateModified)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(int));
    
            var dateCreatedParameter = dateCreated.HasValue ?
                new ObjectParameter("DateCreated", dateCreated) :
                new ObjectParameter("DateCreated", typeof(System.DateTimeOffset));
    
            var createdByParameter = createdBy.HasValue ?
                new ObjectParameter("CreatedBy", createdBy) :
                new ObjectParameter("CreatedBy", typeof(int));
    
            var nameParameter = name != null ?
                new ObjectParameter("Name", name) :
                new ObjectParameter("Name", typeof(string));
    
            var descriptionParameter = description != null ?
                new ObjectParameter("Description", description) :
                new ObjectParameter("Description", typeof(string));
    
            var shortContentParameter = shortContent != null ?
                new ObjectParameter("ShortContent", shortContent) :
                new ObjectParameter("ShortContent", typeof(string));
    
            var genreParameter = genre != null ?
                new ObjectParameter("Genre", genre) :
                new ObjectParameter("Genre", typeof(string));
    
            var yearParameter = year.HasValue ?
                new ObjectParameter("Year", year) :
                new ObjectParameter("Year", typeof(System.DateTime));
    
            var authorParameter = author != null ?
                new ObjectParameter("Author", author) :
                new ObjectParameter("Author", typeof(string));
    
            var dateModifiedParameter = dateModified.HasValue ?
                new ObjectParameter("DateModified", dateModified) :
                new ObjectParameter("DateModified", typeof(System.DateTimeOffset));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("Book_SaveBook", idParameter, dateCreatedParameter, createdByParameter, nameParameter, descriptionParameter, shortContentParameter, genreParameter, yearParameter, authorParameter, dateModifiedParameter);
        }
    
        public virtual int Genre_DeleteGenre(Nullable<int> id, Nullable<System.DateTimeOffset> dateModified)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(int));
    
            var dateModifiedParameter = dateModified.HasValue ?
                new ObjectParameter("DateModified", dateModified) :
                new ObjectParameter("DateModified", typeof(System.DateTimeOffset));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Genre_DeleteGenre", idParameter, dateModifiedParameter);
        }
    
        public virtual ObjectResult<Genre_GetAllGenres_Result> Genre_GetAllGenres()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Genre_GetAllGenres_Result>("Genre_GetAllGenres");
        }
    
        public virtual ObjectResult<Genre_GetGenre_Result> Genre_GetGenre(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Genre_GetGenre_Result>("Genre_GetGenre", idParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> Genre_InsertGenre(Nullable<System.DateTimeOffset> dateCreated, string name, string description, Nullable<System.DateTimeOffset> dateModified, Nullable<System.DateTimeOffset> datePicked)
        {
            var dateCreatedParameter = dateCreated.HasValue ?
                new ObjectParameter("DateCreated", dateCreated) :
                new ObjectParameter("DateCreated", typeof(System.DateTimeOffset));
    
            var nameParameter = name != null ?
                new ObjectParameter("Name", name) :
                new ObjectParameter("Name", typeof(string));
    
            var descriptionParameter = description != null ?
                new ObjectParameter("Description", description) :
                new ObjectParameter("Description", typeof(string));
    
            var dateModifiedParameter = dateModified.HasValue ?
                new ObjectParameter("DateModified", dateModified) :
                new ObjectParameter("DateModified", typeof(System.DateTimeOffset));
    
            var datePickedParameter = datePicked.HasValue ?
                new ObjectParameter("DatePicked", datePicked) :
                new ObjectParameter("DatePicked", typeof(System.DateTimeOffset));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("Genre_InsertGenre", dateCreatedParameter, nameParameter, descriptionParameter, dateModifiedParameter, datePickedParameter);
        }
    
        public virtual int Genre_SaveGenre(Nullable<int> id, Nullable<System.DateTime> dateCreated, string name, string description, Nullable<System.DateTimeOffset> dateModified, Nullable<System.DateTimeOffset> datePicked)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(int));
    
            var dateCreatedParameter = dateCreated.HasValue ?
                new ObjectParameter("DateCreated", dateCreated) :
                new ObjectParameter("DateCreated", typeof(System.DateTime));
    
            var nameParameter = name != null ?
                new ObjectParameter("Name", name) :
                new ObjectParameter("Name", typeof(string));
    
            var descriptionParameter = description != null ?
                new ObjectParameter("Description", description) :
                new ObjectParameter("Description", typeof(string));
    
            var dateModifiedParameter = dateModified.HasValue ?
                new ObjectParameter("DateModified", dateModified) :
                new ObjectParameter("DateModified", typeof(System.DateTimeOffset));
    
            var datePickedParameter = datePicked.HasValue ?
                new ObjectParameter("DatePicked", datePicked) :
                new ObjectParameter("DatePicked", typeof(System.DateTimeOffset));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Genre_SaveGenre", idParameter, dateCreatedParameter, nameParameter, descriptionParameter, dateModifiedParameter, datePickedParameter);
        }
    }
}
