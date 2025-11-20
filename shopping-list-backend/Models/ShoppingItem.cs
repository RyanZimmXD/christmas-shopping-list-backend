namespace shopping_list_backend.Models
{
    public class ShoppingItem
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string Item { get; set; }
        public bool Purchased {  get; set; }

    }
}
