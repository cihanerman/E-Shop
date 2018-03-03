using System.Collections.Generic;

namespace E_Shop.Models 
{
    public class OrderProduct 
    {
        public int OrderProductId { get; set; }
        public int Piece { get; set; }

        public List<int> ProductIds { get; set; }

        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}