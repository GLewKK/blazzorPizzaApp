using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BlazingPizza.Shared.CoreItems
{
    class CoreImplementation
    {
        
        static void Main(string[] args)
        {
            MyPizzaBuilder builder = new MyPizzaBuilder();

            var dought = new FlatBreadFactory();
            var cheeze = new MozzarellaCheeseFactory();
            var sausage = new ItalianSausageFactory();

            builder.CreateNewPizza();
            builder.PrepareDough(dought.GetDought());
            builder.ApplyCheese(cheeze.GetCheese());
            builder.ApplySausage(new AddSausage(), sausage.GetSausage());
            builder.ApplySausage(new AddSausage(), sausage.GetSausage());
            builder.ApplySausage(new AddSausage(), sausage.GetSausage());
            builder.ApplySausage(new AddSausage(), sausage.GetSausage());
            builder.ApplySausage(new AddSausage(), sausage.GetSausage());
            builder.AddCondiments();
            var pizza = builder.GetPizza();


        }
    }

    //Pizza
    public class Pizza
    {
        public BaseEntity DoughType { get; set; } //factory

        public Size Size { get; set; }

        public Cheese CheeseType { get; set; } //factory

        public SausageList SausageTypeList { get; set; } //factory

        //public List<List<string>> Vegetables { get; set; } //factory

        public bool IsRedPeper { get; set; }

        public decimal Cost { get; set; }
    }
    public class SausageList
    {
        public List<Sausage> Sausages { get; set; }

        public decimal TotalCost { get; set; }

    }

    public abstract class BaseEntity
    {
        public abstract string Name { get; set; }
        public abstract string Description { get; set; }
        public abstract decimal Price { get; set; }
        public abstract string ImgSrc { get; set; }
    }

    #region Dought Factory
    public abstract class Dough : BaseEntity
    {
    }

    public class ThinCrust : Dough
    {
        private string _name;
        private string _description;
        private decimal _price;
        private string _imgsrc;

        public ThinCrust(string name, string description, decimal price, string src)
        {
            _name = name;
            _description = description;
            _price = price;
            _imgsrc = src;
        }

        public override string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }
        public override string Description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
            }
        }
        public override decimal Price
        {
            get
            {
                return _price;
            }
            set
            {
                _price = value;
            }
        }
        public override string ImgSrc
        {
            get => _imgsrc;
            set { _imgsrc = value; }
        }
    }

    public class FlatBreadCrust : Dough
    {
        private string _name;
        private string _description;
        private decimal _price;
        private string _imgsrc;

        public FlatBreadCrust(string name, string description, decimal price, string src)
        {
            _name = name;
            _description = description;
            _price = price;
            _imgsrc = src;
        }
        public override string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }
        public override string Description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
            }
        }
        public override decimal Price
        {
            get
            {
                return _price;
            }
            set
            {
                _price = value;
            }
        }
        public override string ImgSrc
        {
            get => _imgsrc;
            set { _imgsrc = value; }
        }
    }

    public abstract class AbstractFactory
    {
        

        public abstract BaseEntity GetEntity(); 
    }
    public abstract class DoughtFactory : AbstractFactory
    {
        
        public abstract Dough GetDought();
    }
    public class ThinCrustFactory : DoughtFactory
    {
        public override Dough GetDought()
        {
            // din baza se scot datele
            return new ThinCrust("Thin Crust", "Thinnest Crust", 12, "/img/Dough/Thin-Crust-Pizza-Dough.jpg");
        }

        public override BaseEntity GetEntity()
        {
            return new ThinCrust("Thin Crust", "Thinnest Crust", 12, "/img/Dough/Thin-Crust-Pizza-Dough.jpg");
        }
    }
    public class FlatBreadFactory : DoughtFactory
    {

        public override Dough GetDought()
        {
            //var asd = _client.GetJsonAsync<DbDough>("doughs/1");
            Debug.WriteLine("Testam API");
            //Debug.WriteLine(asd.Result.Name);
            return new FlatBreadCrust("Flat Bread", "Very flat..", 15, "/img/Dough/flatbreadcrust-dough.jpg");
        }

        public override BaseEntity GetEntity()
        {
            return new FlatBreadCrust("Flat Bread", "Very flat..", 15, "/img/Dough/flatbreadcrust-dough.jpg");
        }
    }

    #endregion

    #region Cheese Factory
    public abstract class Cheese : BaseEntity
    {
    }

    public class MozzarellaCheese : Cheese
    {
        private string _name;
        private string _description;
        private decimal _price;
        private string _imgSrc;

        public MozzarellaCheese(string cheeseType, string description, decimal price, string imgSrc)
        {
            _name = cheeseType;
            _description = description;
            _price = price;
            _imgSrc = imgSrc;
        }
        public override string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }
        public override string Description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
            }
        }
        public override decimal Price
        {
            get
            {
                return _price;
            }
            set
            {
                _price = value;
            }
        }

        public override string ImgSrc
        {
            get
            {
                return _imgSrc;
            }
            set
            {
                _imgSrc = value;
            }
        }
    }
    public class CheddarChesse : Cheese
    {
        private string _name;
        private string _description;
        private decimal _price;
        private string _imgSrc;


        public CheddarChesse(string cheeseType, string description, decimal price, string imgSrc)
        {
            _name = cheeseType;
            _description = description;
            _price = price;
            _imgSrc = imgSrc;
        }
        public override string Name
        { 
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }
        public override string Description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
            }
        }
        public override decimal Price
        {
            get
            {
                return _price;
            }
            set
            {
                _price = value;
            }
        }
        public override string ImgSrc
        {
            get
            {
                return _imgSrc;
            }
            set
            {
                _imgSrc = value;
            }
        }
    }

    public abstract class CheeseFactory : AbstractFactory
    {
        public abstract Cheese GetCheese();
    }
    public class MozzarellaCheeseFactory : CheeseFactory
    {
        public override Cheese GetCheese()
        {
            return new MozzarellaCheese("Mozzarella", "Its mozzarella cheese", 8, "/img/cheese/mozzarellaCheese.jpg");
        }

        public override BaseEntity GetEntity()
        {
            return new MozzarellaCheese("Mozzarella", "Its mozzarella cheese", 8, "/img/cheese/mozzarellaCheese.jpg");
        }
    }
    public class CheddarChesseFactory : CheeseFactory
    {
        public override Cheese GetCheese()
        {
            return new CheddarChesse("Cheddar Chesse", "Description", 9, "/img/cheese/cheddarCheese.jpeg");
        }

        public override BaseEntity GetEntity()
        {
            return new CheddarChesse("Cheddar Chesse", "Description", 9, "/img/cheese/cheddarCheese.jpeg");
        }
    }
    #endregion

    #region Sausage Factory
    public abstract class Sausage : BaseEntity
    {
    }

    public class KielbasaSausage : Sausage
    {
        private string _name;
        private string _description;
        private decimal _price;
        private string _imgSrc;

        public KielbasaSausage(string sausageType, string description, decimal price, string imgSrc)
        {
            _name = sausageType;
            _description = description;
            _price = price;
            _imgSrc = imgSrc;
        }
        public override string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }
        public override string Description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
            }
        }
        public override decimal Price
        {
            get
            {
                return _price;
            }
            set
            {
                _price = value;
            }
        }
        public override string ImgSrc
        {
            get
            {
                return _imgSrc;
            }
            set
            {
                _imgSrc = value;
            }
        }

    }
    public class ItalianSausage : Sausage
    {

        private string _name;
        private string _description;
        private decimal _price;
        private string _imgSrc;


        public ItalianSausage(string sausageType, string description, decimal price, string imgSrc)
        {
            _name = sausageType;
            _description = description;
            _price = price;
            _imgSrc = imgSrc;
        }
        public override string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }
        public override string Description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
            }
        }
        public override decimal Price
        {
            get
            {
                return _price;
            }
            set
            {
                _price = value;
            }
        }
        public override string ImgSrc
        {
            get
            {
                return _imgSrc;
            }
            set
            {
                _imgSrc = value;
            }
        }

    }

    public abstract class SausageFactory : AbstractFactory
    {
        public abstract Sausage GetSausage();
    }
    public class KielbasaSausageFactory : SausageFactory
    {
        public override BaseEntity GetEntity()
        {
            return new KielbasaSausage("Kielbata", "Polish sausage", 7, "/img/sausage/kielbasaSausage.jpg");
        }

        public override Sausage GetSausage()
        {
            return new KielbasaSausage("Kielbata", "Polish sausage", 7, "/img/sausage/kielbasaSausage.jpg");
        }
    }
    public class ItalianSausageFactory : SausageFactory
    {
        public override BaseEntity GetEntity()
        {
            return new ItalianSausage("Italian", "Pretty sure it is from Italy", 10, "/img/sausage/italianSausage.jpg");
        }

        public override Sausage GetSausage()
        {
            return new ItalianSausage("Italian", "Pretty sure it is from Italy", 10, "/img/sausage/italianSausage.jpg");
        }
    }
    #endregion


    #region Builder
    public abstract class PizzaBuilder
    {
        protected Pizza pizza;

        public Pizza GetPizza()
        {
            return pizza;
        }
        public void CreateNewPizza()
        {
            pizza = new Pizza();
            pizza.SausageTypeList = new SausageList();
            pizza.SausageTypeList.Sausages = new List<Sausage>();
        }

        public abstract void PrepareDough(BaseEntity dought);
        public abstract void ApplyCheese(Cheese cheese);
        public abstract void ApplySausage(SausageDecorator decorator, Sausage sausage);
        public abstract void AddCondiments();

    }

    public class MyPizzaBuilder : PizzaBuilder
    {
        public override void AddCondiments()
        {
            pizza.IsRedPeper = true;
        }

        public override void ApplyCheese(Cheese cheese)
        {
            pizza.CheeseType = cheese;
        }

        public override void ApplySausage(SausageDecorator decorator, Sausage sausage)
        {

            var validator = new SausageValidator();
            var vegetablesValidator = new VegetablesValidator();

            var command = new SetNextCommand(vegetablesValidator);
            command.Execute(validator);


            if (validator.IsValid(pizza.SausageTypeList.Sausages,decorator).HasValue)
            {
                if (validator.IsValid(pizza.SausageTypeList.Sausages, decorator).Value)
                {
                    if (decorator is AddSausage)
                    {
                        pizza.SausageTypeList.Sausages.Add(sausage);
                        SausageDecorator sausageDecorator = new AddSausage(sausage);
                        pizza.SausageTypeList.TotalCost = sausageDecorator.GetCost();
                    }

                    if (decorator is RemoveSausage)
                    {
                        var exists = pizza.SausageTypeList.Sausages.FirstOrDefault(x => x.GetType().IsEquivalentTo(sausage.GetType()));
                        if ( exists != null)
                        {
                            pizza.SausageTypeList.Sausages.Remove(exists);
                            SausageDecorator sausageDecorator = new RemoveSausage(exists);
                            pizza.SausageTypeList.TotalCost = sausageDecorator.GetCost();
                        }
                    }
                    SausageCount.Count = pizza.SausageTypeList.Sausages.Count;
                }
                else
                {
                    Debug.WriteLine("Value is not valid");
                }
            }

        }

        public override void PrepareDough(BaseEntity dought)
        {
            if(dought is Dough)
            {
                pizza.DoughType = dought;
            }
        }
    }

    #endregion


    #region Decorators
    public abstract class AbstractDecorator
    {
        public virtual decimal GetCost()
        {
            return default;
        }

    }
    public abstract class SausageDecorator : AbstractDecorator
    {
        private Sausage _sausage;

        public SausageDecorator(Sausage sausage)
        {
            _sausage = sausage;
        }

        protected SausageDecorator()
        {
        }

        public override decimal GetCost()
        {
            return _sausage.Price;
        }
    }

    public class AddSausage : SausageDecorator
    {
        public AddSausage(Sausage sausage) : base(sausage)
        {

        }
        public AddSausage() : base()
        {

        }

        public override decimal GetCost()
        {
            return base.GetCost() + 10;
        }

    }

    public class RemoveSausage : SausageDecorator
    {
        public RemoveSausage(Sausage sausage) : base(sausage)
        {

        }
        public RemoveSausage() : base()
        {

        }

        public override decimal GetCost()
        {
            return base.GetCost() - 10;
        }

    }

    #endregion

    #region Chain of Responsibility
    public abstract class Validator
    {
        protected Validator nextValidator;
        public void SetNextValidator(Validator validator)
        {
            nextValidator = validator;
        }

        public abstract bool? IsValid(IEnumerable<object> genericList, AbstractDecorator abstractDecorator);
    }

    public class SausageValidator : Validator
    {
        public override bool? IsValid(IEnumerable<object> genericList, AbstractDecorator abstractDecorator)
        {
            if (genericList is List<Sausage> && abstractDecorator is SausageDecorator)
            {
                if(abstractDecorator is AddSausage && genericList.Count() >= (int)TopicsSize.SausageSize)
                {
                    return false;
                }
                if(abstractDecorator is RemoveSausage && genericList.Count() == 0)
                {
                    return false;
                }
                return true;
            }
            else if (nextValidator != null)
            {
                nextValidator.IsValid(genericList, abstractDecorator);
            }

            return null;
        }
    }
    public class VegetablesValidator : Validator
    {
        public override bool? IsValid(IEnumerable<object> genericList, AbstractDecorator abstractDecorator)
        {
            if (genericList is List<int>)
            {
                return true;
            }

            return null;
        }
    }

    #endregion



    #region Command
    public abstract class Command
    {
        public abstract void Execute(Validator validator);
    }

    public class SetNextCommand : Command
    {
        private Validator _targetValidator;

        public SetNextCommand(Validator firstValidator)
        {
            _targetValidator = firstValidator;
        }



        public override void Execute(Validator validator)
        {
            validator.SetNextValidator(_targetValidator);
        }
    }
    #endregion
    public enum Size
    {
        Small,
        Medium,
        Large
    }

    public enum TopicsSize
    {
        SausageSize = 4,
        VegetablesTotal = 6
    }

    public static class SausageCount
    {
        public static int Count { get; set; } = 0;
    }
}
