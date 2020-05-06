using System;
using System.Linq;

namespace DataBaseTask2
{
    class Program
    {
        static void Main(string[] args)
        {
            DataBase db = new DataBase("ShopDataBase");

            db.CreateTable<Good>();
            db.CreateTable<Shop>();

            db.InsertInto<Shop>(new ShopFactory("Auchan"));
            db.InsertInto<Shop>(new ShopFactory("Magnit"));

            db.InsertInto<Good>(new GoodFactory("Pepsi", 1));
            db.InsertInto(new GoodFactory("3 korochki", 1));
            db.InsertInto(new GoodFactory("Ohota", 2));
            db.InsertInto(new GoodFactory("Lays", 3));

            var auchanId = (from shop in db.Table<Shop>()
                            where shop.Name == "Auchan"
                            select shop.Id).First();

            var allAuchanGoods = from good in db.Table<Good>()
                                 where good.ShopId == auchanId
                                 select good.Name;

            foreach (var goodName in allAuchanGoods)
            {
                Console.WriteLine(goodName);
            }

            Console.ReadKey();
        }
    }
}