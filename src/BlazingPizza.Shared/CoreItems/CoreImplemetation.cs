using System;
using System.Collections.Generic;
using System.Linq;
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
        public Dought DoughtType { get; set; } //factory

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
        public abstract string Description { get; set; }
        public abstract decimal Price { get; set; }
    }

    #region Dought Factory
    public abstract class Dought : BaseEntity
    {
        public abstract string DoughtType { get; set; }
        public abstract string ImgSrc { get; set; }
    }

    public class ThinCrust : Dought
    {
        private string _doughtType;
        private string _description;
        private decimal _price;
        private string _imgsrc;

        public ThinCrust(string doughtType, string description, decimal price, string src)
        {
            _doughtType = doughtType;
            _description = description;
            _price = price;
            _imgsrc = src;
        }

        public override string DoughtType
        {
            get
            {
                return _doughtType;
            }
            set
            {
                _doughtType = value;
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

    public class FlatBreadCrust : Dought
    {
        private string _doughtType;
        private string _description;
        private decimal _price;
        private string _imgsrc;

        public FlatBreadCrust(string doughtType, string description, decimal price, string src)
        {
            _doughtType = doughtType;
            _description = description;
            _price = price;
            _imgsrc = src;
        }
        public override string DoughtType
        {
            get
            {
                return _doughtType;
            }
            set
            {
                _doughtType = value;
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

    public abstract class DoughtFactory
    {
        public abstract Dought GetDought();
    }
    public class ThinCrustFactory : DoughtFactory
    {
        public override Dought GetDought()
        {
            // din baza se scot datele
            return new ThinCrust("Thin Crust", "Thinnest Crust", 12, "~/Images/Dough/Thin-Crust-Pizza-Dough.jpg");
        }
    }
    public class FlatBreadFactory : DoughtFactory
    {
        public override Dought GetDought()
        {
            return new FlatBreadCrust("Flat Bread", "Very flat..", 15, "~/Images/Dough/flatbreadcrust-dough.jpg");
        }
    }

    #endregion

    #region Cheese Factory
    public abstract class Cheese : BaseEntity
    {
        public abstract string CheeseType { get; set; }
    }

    public class MozzarellaCheese : Cheese
    {
        private string _cheeseType;
        private string _description;
        private decimal _price;

        public MozzarellaCheese(string cheeseType, string description, decimal price)
        {
            _cheeseType = cheeseType;
            _description = description;
            _price = price;
        }
        public override string CheeseType
        {
            get
            {
                return _cheeseType;
            }
            set
            {
                _cheeseType = value;
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
    }
    public class CheddarChesse : Cheese
    {
        private string _cheeseType;
        private string _description;
        private decimal _price;

        public CheddarChesse(string cheeseType, string description, decimal price)
        {
            _cheeseType = cheeseType;
            _description = description;
            _price = price;
        }
        public override string CheeseType
        {
            get
            {
                return _cheeseType;
            }
            set
            {
                _cheeseType = value;
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
    }

    public abstract class CheeseFactory
    {
        public abstract Cheese GetCheese();
    }
    public class MozzarellaCheeseFactory : CheeseFactory
    {
        public override Cheese GetCheese()
        {
            return new MozzarellaCheese("Mozzarella", "Its mozzarella cheese", 8);
        }
    }
    public class CheddarChesseFactory : CheeseFactory
    {
        public override Cheese GetCheese()
        {
            return new CheddarChesse("Cheddar Chesse", "Description", 9);
        }
    }
    #endregion

    #region Sausage Factory
    public abstract class Sausage : BaseEntity
    {
        public abstract string SausageType { get; set; }
    }

    public class KielbasaSausage : Sausage
    {
        private string _sausageType;
        private string _description;
        private decimal _price;

        public KielbasaSausage(string sausageType, string description, decimal price)
        {
            _sausageType = sausageType;
            _description = description;
            _price = price;
        }
        public override string SausageType
        {
            get
            {
                return _sausageType;
            }
            set
            {
                _sausageType = value;
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

    }
    public class ItalianSausage : Sausage
    {

        private string _sausageType;
        private string _description;
        private decimal _price;

        public ItalianSausage(string sausageType, string description, decimal price)
        {
            _sausageType = sausageType;
            _description = description;
            _price = price;
        }
        public override string SausageType
        {
            get
            {
                return _sausageType;
            }
            set
            {
                _sausageType = value;
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

    }

    public abstract class SausageFactory
    {
        public abstract Sausage GetSausage();
    }
    public class KielbasaSausageFactory : SausageFactory
    {
        public override Sausage GetSausage()
        {
            return new KielbasaSausage("Kielbata", "Polish sausage", 7);
        }
    }
    public class ItalianSausageFactory : SausageFactory
    {
        public override Sausage GetSausage()
        {
            return new ItalianSausage("Italian", "Pretty sure it is from Italy", 10);
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

        public abstract void PrepareDough(Dought dought);
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


            if (validator.IsValid(pizza.SausageTypeList.Sausages).HasValue)
            {
                if (validator.IsValid(pizza.SausageTypeList.Sausages).Value)
                {
                    if (decorator is AddSausage)
                    {
                        pizza.SausageTypeList.Sausages.Add(sausage);
                        SausageDecorator sausageDecorator = new AddSausage(sausage);
                        pizza.SausageTypeList.TotalCost = sausageDecorator.GetCost();
                    }

                    if (decorator is RemoveSausage)
                    {
                        if (pizza.SausageTypeList.Sausages.Any(x => x.SausageType.Equals(sausage.SausageType)))
                        {
                            pizza.SausageTypeList.Sausages.Remove(sausage);
                            SausageDecorator sausageDecorator = new RemoveSausage(sausage);
                            pizza.SausageTypeList.TotalCost = sausageDecorator.GetCost();
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Value is not valid");
                }
            }

        }

        public override void PrepareDough(Dought dought)
        {
            pizza.DoughtType = dought;
        }
    }

    #endregion


    #region Decorators
    public abstract class SausageDecorator : Sausage
    {
        private Sausage _sausage;

        public SausageDecorator(Sausage sausage)
        {
            _sausage = sausage;
        }

        protected SausageDecorator()
        {
        }

        public virtual decimal GetCost()
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

        public override string SausageType { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override string Description { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override decimal Price { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

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
        public override string SausageType { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override string Description { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override decimal Price { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

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

        public abstract bool? IsValid(IEnumerable<object> genericList);
    }

    public class SausageValidator : Validator
    {
        public override bool? IsValid(IEnumerable<object> genericList)
        {
            if (genericList is List<Sausage>)
            {
                if (genericList.Count() <= 3)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (nextValidator != null)
            {
                nextValidator.IsValid(genericList);
            }

            return null;
        }
    }
    public class VegetablesValidator : Validator
    {
        public override bool? IsValid(IEnumerable<object> genericList)
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
}
