using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E03.ShoppingSpree
{
    public class Person
    {
		private string name;
		private decimal money;
		private List<Product> bagOfProducts;

        public Person(string name, decimal money)
        {
            Name = name;
            Money = money;
			bagOfProducts= new List<Product>();
        }

        public string Name
		{
			get { return name; }
			private set 
			{
				if (value == "" || value == null || value == " ")
				{
					throw new ArgumentException("Name cannot be empty");
				}

				name = value; 
			}
		}
		public decimal Money
		{
			get { return money; }
			private set 
			{
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                
				money = value; 
			}
		}

        public void  BuyProduct(Product product)
		{
			if (product.Cost <= this.money)
			{
				bagOfProducts.Add(product);
				this.money -= product.Cost;
				Console.WriteLine($"{this.name} bought {product.Name}");
			}
			else
			{
				Console.WriteLine($"{this.name} can't afford {product.Name}");
			}
		}

		public override string ToString()
		{
			StringBuilder sb = new();

			sb.Append(Name + " - ");

			if (bagOfProducts.Count == 0)
			{
				sb.Append("Nothing bought");
			}
			else
			{
				sb.Append(string.Join(", ", bagOfProducts));
			}

			return sb.ToString();
		}
	}
}
