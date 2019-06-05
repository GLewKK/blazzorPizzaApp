using BlazingPizza.Shared.CoreItems;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace BlazzingPizza.Client
{
    public class StateOfOrder
    {
        public bool ShowingConfigureDialog { get; private set; }

        public Pizza Pizza { get; set; } = new Pizza();
        public MyPizzaBuilder Builder { get; private set; } = new MyPizzaBuilder();

        public Dough Dought { get; set; }

        public bool ShowError { get; set; } = false;

        public bool? IsTakenDough { get; set; } = null;

        public string SelectedDough { get; set; }

        public bool? IsSelectedSausage { get; set; } = null;

        public Sausage SelectedSausage { get; set; }

        public bool? IsSelectedCheese { get; set; } = null;

        public string SelectedCheese { get; set; }

        public bool? IsPizzaReady { get; set; } = null;

        public SausageDecorator SelectedDecorator { get; set; }

        public List<AbstractFactory> DoughtFactories { get; set; } = new List<AbstractFactory>
        {
            new FlatBreadFactory(),
            new ThinCrustFactory()
        };

        public List<CheeseFactory> CheeseFactories { get; set; } = new List<CheeseFactory>
        {
            new MozzarellaCheeseFactory(),
            new CheddarChesseFactory()
        };

        public List<SausageFactory> SausageFactories { get; set; } = new List<SausageFactory>
        {
            new ItalianSausageFactory(),
            new KielbasaSausageFactory()
        };

        public List<SausageDecorator> SausageDecorators { get; set; } = new List<SausageDecorator>
        {
            new AddSausage(),
            new RemoveSausage()
        };

        public void SelectDough(BaseEntity dought)
        {
            try
            {
                Builder.PrepareDough(dought);
                IsTakenDough = true;
                SelectedDough = dought.Name;

                IsSelectedCheese = false;
            }
            catch
            {
                Debug.WriteLine("Error while Selecting Dough");
            }
        }

        public void SelectCheese(Cheese cheese)
        {
            try
            {
                Builder.ApplyCheese(cheese);
                IsSelectedCheese = true;
                SelectedCheese = cheese.Name;

                IsSelectedSausage = false;
            }
            catch
            {
                Debug.WriteLine("Error while Selecting Cheese");
            }
        }

        public void SelectSausage(Sausage sausage)
        {
            try
            {
                SelectedSausage = sausage;
            }
            catch
            {
                Debug.WriteLine("Error whilte selecting sausage");
            }


        }
        public void ApplySausage(SausageDecorator decorator)
        {
            try
            {
                if (SelectedSausage != null)
                {
                    Builder.ApplySausage(decorator, SelectedSausage);
                }
            }
            catch (Exception)
            {

                Debug.WriteLine("Error while Apply Sausages!");
            }
            
        }

        public void GetPizza()
        {
            try
            {
                Pizza = Builder.GetPizza();
                IsPizzaReady = true;
            }
            catch
            {
                Debug.WriteLine("Error while trying to get Pizza");
            }
        }
        public void ShowAnSelectError()
        {
            Debug.WriteLine("Eroor naxui");
        }

        public void FinishSausageSelection()
        {

            IsSelectedSausage = true;

            IsPizzaReady = false;

        }
    }
}
