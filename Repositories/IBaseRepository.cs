using KopiusLibrary.Model.Entities;
using KopiusLibrary.Model.Interfaces;

namespace KopiusLibrary.Repositories
{
    public interface IBaseRepository
    {
        void UpdateService<T>(T entity, string updatedBy) where T : BaseEntity;
    }
}

//public void Update(Book book)
//{
//    Context.Books.Update(book);
//    Save(book)
//}

//public void Save(Book updated)
//{

//    UpdateService(updated),
//        context.SaveChanges();
//}

//que context.savechanges y el log vayan de la mano y DEBAN ser implementados, forzando una integridad.

//se podria hacer como parte de la clase base
