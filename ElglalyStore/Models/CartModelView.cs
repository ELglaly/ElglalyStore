namespace ElglalyStore.Models
{
    public class CartModelView
    {

        public int Product_id {  get; set; }
        public string? Name { get; set; }
        public string? Image { get; set; }
        public decimal Price { get; set; }

        public int Quantity { get; set;}

        public decimal Total_Price { get; set; }

        public int? Increase_Quantity()
        {
            return ++Quantity;
        }
        public int? Decrease_Quantity()
        { 
       
           return (Quantity < 0)? 0 : --Quantity;
        }



    }
}
