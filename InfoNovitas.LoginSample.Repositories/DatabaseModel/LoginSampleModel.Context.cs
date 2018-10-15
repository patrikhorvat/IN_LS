﻿

//------------------------------------------------------------------------------
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


    public virtual int Author_Save(Nullable<int> id, string firstName, string lastName, Nullable<System.DateTimeOffset> lastModified, Nullable<int> userLastModified)
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


        var lastModifiedParameter = lastModified.HasValue ?
            new ObjectParameter("LastModified", lastModified) :
            new ObjectParameter("LastModified", typeof(System.DateTimeOffset));


        var userLastModifiedParameter = userLastModified.HasValue ?
            new ObjectParameter("UserLastModified", userLastModified) :
            new ObjectParameter("UserLastModified", typeof(int));


        return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Author_Save", idParameter, firstNameParameter, lastNameParameter, lastModifiedParameter, userLastModifiedParameter);
    }


    public virtual ObjectResult<Nullable<int>> Author_Insert(string firstName, string lastName, Nullable<System.DateTimeOffset> dateCreated, Nullable<int> userCreated, Nullable<System.DateTime> birthDate)
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


        return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("Author_Insert", firstNameParameter, lastNameParameter, dateCreatedParameter, userCreatedParameter, birthDateParameter);
    }

}

}

