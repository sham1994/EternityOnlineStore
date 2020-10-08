namespace EternityStore.Entity
{ 
    public class ProductForListDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal UnitPrice { get; set; }
        public int ProductCategoryId { get; set; }
        public string PhotoUrl { get; set; }


    }
}