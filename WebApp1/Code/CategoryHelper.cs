using WebApp1.Data;

namespace WebApp1.Code
{
    public interface ICategoryHelper
    {
        bool IsExistsName(string name, int? id = null);
    }

    public class CategoryHelper : ICategoryHelper
    {
        private readonly BigStoreContext _context;

        public CategoryHelper(BigStoreContext context)
        {
            _context = context;
        }

        public bool IsExistsName(string name, int? id = null)
        {
            return _context.Categories
                .Where(x => x.Name == name && (id.HasValue && x.Id != id))
                .Any();
        }
    }
}
