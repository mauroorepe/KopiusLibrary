using KopiusLibrary.Model;
using KopiusLibrary.Model.Entities;

namespace KopiusLibrary.Repositories
{
    public class BranchRepository : IBranchRepository
    {
        public LibraryContext Context { get; set; }
        public BranchRepository(LibraryContext libraryContext)
        {
            Context = libraryContext;
        }
        public Branch BranchByName(string address)
        {
            return Context.Branchs.FirstOrDefault(b => (b.Address).ToLower() == address.ToLower());
        }
    }
}
