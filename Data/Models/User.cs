﻿namespace Ninja.Data.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public List<Inventory> Inventories { get; set; }
        public List<PurchaseHistory> PurchaseHistories { get; set; }
    }
}