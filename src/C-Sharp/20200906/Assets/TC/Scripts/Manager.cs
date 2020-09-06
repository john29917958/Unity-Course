using System;
using UnityEngine;

namespace tc
{
	[Serializable]
	public class ProductBag
	{
		public string Product;

		public int Price;

		public int Item;

		[Range(0, 1)]
		public float Discount = 1f;
	}

	public class Manager : MonoBehaviour
	{
		public ProductBag[] ProductBags;

		public int Number = 10;
		public float RealNumber = 0.5f;
		public bool Flag = true;
		public string Message = "Hello World!";

		// Use this for initialization
		void Start()
		{
			Debug.Log("Program starts");

			PerformsBasicCalculations();
			PrintsBasicQuizAnswer();
			PrintAdvancedQuizAnswer();
		}

		// Update is called once per frame
		void Update()
		{
			//Debug.Log("Program updates");
		}

		private void PerformsBasicCalculations()
		{
			Number = 3 + 7;
			Number = 15 - 5;
			Number = 5 * 2;
			Number = 20 / 2;
			Number = 110 % 100;

			Number += 5;
			Number -= 5;
			Number *= 5;
			Number /= 5;
			Number %= 3;

			Number++;
			Number--;
		}

		private void PrintsBasicQuizAnswer()
		{
			string product1, product2;
			int price1, price2;
			int item1, item2;

			product1 = "瓶汽水";
			price1 = 25;
			item1 = 2;

			Debug.Log(item1 + product1 + " = " + price1 * item1 + "元");
			Debug.Log(string.Format("{0}{1} = {2}元", item1, product1, price1 * item1));

			product1 = "包洋芋片";
			price1 = 20;
			item1 = 3;

			product2 = "顆糖果";
			price2 = 10;
			item2 = 5;

			Debug.Log(item1 + product1 + "(" + price1 * item1 + ") + " + item2 + product2 + "(" + price2 * item2 + ") = " + (price1 * item1 + price2 * item2) + "元");
			Debug.Log(string.Format("{0}{1}({2}) + {3}{4}({5}) = {6}元", item1, product1, price1 * item1, item2, product2, price2 * item2, price1 * item1 + price2 * item2));
		}

		private void PrintAdvancedQuizAnswer()
		{
			foreach (ProductBag bag in ProductBags)
			{
				Debug.Log(bag.Item + bag.Product + " = " + bag.Price * bag.Item + "元，打" + bag.Discount + "折後變" + bag.Price * bag.Item * bag.Discount + "元");
				Debug.Log(string.Format("{0}{1} = {2}元，打{3}折後變{4}元", bag.Item, bag.Product, bag.Price * bag.Item, bag.Discount, bag.Price * bag.Item * bag.Discount));
			}
		}
	}

}