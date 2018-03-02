using System.Collections.Generic;

namespace E_Shop.Models {
    public class Order {
        public int OrderId { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}