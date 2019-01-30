using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YeniShoppingProject.Models;

namespace YeniShoppingProject.Viewmodel
{
    public class MyModel
    {
        internal List<Photo> sekiller;

        public List<Photo> _photos { get; set; }

        public List<Category> _categories { get; set; }
        public List<Brand> _brands { get; set; }
        public List<Mallar> _mallars { get; set; }
        public List<Order> _orders { get; set; }
        public List<OrderStatu> _orderstatus { get; set; }
        public List<Photo> _sekiller { get; set; }
        public List<User> _users { get; set; }
        public List<OthBxo> _boxesss { get; set; }
        public List<Company> _allcompanies { get; set; }
        public List<MessageWant> _messages { get; set; }
    }
}