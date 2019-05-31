using BlazingPizza.Shared;
using BlazingPizza.Shared.CoreItems;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlazingPizza
{
    public class FullySuppliedPizza
    {
        public int Id { get; set; }

        public DbDough Dough { get; set; }
        public int DoughId { get; set; }

        public Size Size { get; set; }

        public DbCheese Cheese { get; set; }
        public int CheeseId { get; set; }

        public List<PizzaSausages> SausageList { get; set; }

        public bool IsRedPeper { get; set; }

        public decimal Cost { get; set; }

    }

    public class BaseEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Cost { get; set; }

        public string ImgSrc { get; set; }

    }

    public class DbSausage : BaseEntity
    {
    }

    public class DbCheese : BaseEntity
    {
    }

    public class DbDough : BaseEntity
    {
    }

    public class PizzaSausages
    {
        public DbSausage Sausage { get; set; }

        public int SausageId { get; set; }

        public int FullySuppliedPizzaId { get; set; }
    }
}
