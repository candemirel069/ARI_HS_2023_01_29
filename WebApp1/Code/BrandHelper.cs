using WebApp1.Data;

namespace WebApp1.Code
{
    public interface IBrandHelper
    {
        bool IsExistsName(string name);
    }

    public class BrandHelper : IBrandHelper
    {
        private readonly BigStoreContext _context;
        public BrandHelper(BigStoreContext context)
        {
            _context = context;
        }

        public bool IsExistsName(string name)
        {
            return _context.Brands.Where(b => b.Name == name).Any();
        }
    }
}
