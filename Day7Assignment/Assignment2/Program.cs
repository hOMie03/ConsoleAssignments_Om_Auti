namespace Assignment2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Products> productsList = new List<Products>
            {
                new Products() { ProductID = 1, ProductName = "TV", ProductCategory = "Electronics", ProductPrice = 30000M},
                new Products() { ProductID = 2, ProductName = "Milk", ProductCategory = "Groceries", ProductPrice = 30M},
                new Products() { ProductID = 3, ProductName = "Smartphone", ProductCategory = "Electronics", ProductPrice = 15999.99M},
                new Products() { ProductID = 4, ProductName = "Handkerchief Set", ProductCategory = "Clothes", ProductPrice = 100M},
                new Products() { ProductID = 5, ProductName = "Smartwatch", ProductCategory = "Electronics", ProductPrice = 999.49M},
            };

            #region Q1
            var findElectronics =
                from product in productsList
                where product.ProductCategory == "Electronics" && product.ProductPrice > 1000
                select product;
            Console.WriteLine("Electronics costing more than Rs. 1000");
            foreach (var product in findElectronics)
            {
                Console.WriteLine($"Name: {product.ProductName} \t Price: Rs. {product.ProductPrice}");
            }
            #endregion

            #region Q3
            var expensiveProduct = productsList.MaxBy(p => p.ProductPrice);
            Console.WriteLine("Most expensive product available in list: ");
            Console.WriteLine($"Name: {expensiveProduct.ProductName} \t Price: {expensiveProduct.ProductPrice}");
            #endregion
        }
    }
}
