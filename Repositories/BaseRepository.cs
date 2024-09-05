namespace KopiusLibrary.Repositories
{
    public class BaseRepository : IBaseRepository
    {
        void IBaseRepository.UpdateService<T>(T entity, string updatedBy)
        {
            entity.UpdatedBy = updatedBy;
            entity.Updated = DateTime.Now;
        }
    }
}
