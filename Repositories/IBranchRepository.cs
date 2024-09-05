using KopiusLibrary.Model.Entities;

namespace KopiusLibrary.Repositories
{
    public interface IBranchRepository
    {
        Branch BranchByName(string Address);
    }
}
