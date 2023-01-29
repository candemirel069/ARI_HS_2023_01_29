namespace WebApp1.Data
{
    public abstract class EntityBase
    {
        public int Id { get; set; }
    }

    public class Product : EntityBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public int BrandId { get; set; }
        public virtual Brand Brand { get; set; }
    }
    public class Category : EntityBase
    {
        public string Name { get; set; }
        public virtual List<Product> Products { get; set; }
    }
    public class Brand : EntityBase
    {
        public string Name { get; set; }
        public virtual  List<Product> Products { get; set; }
    }   
}
