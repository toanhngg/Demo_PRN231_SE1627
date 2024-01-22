using System.Security;

namespace ConsoleApp1
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Manager m = new Manager();
            while (true)
            {
                Console.WriteLine("1. Show list category");
                Console.WriteLine("2. Search category");
                Console.WriteLine("3. Add category");
                Console.WriteLine("4. Update category by id");
                Console.WriteLine("5. Delete category by id");
                Console.WriteLine("6. Show list product");
                Console.WriteLine("7. Add product");
                Console.WriteLine("8. Update product by id");
                Console.WriteLine("9. Delete product by id");
                Console.WriteLine("10. Search product");


                Console.WriteLine("0. Exit");
                int option = Convert.ToInt32(Console.ReadLine());
                switch (option)
                {
                    case 0:
                        Console.WriteLine("Exit");
                        return;
                    case 1:
                        await m.ShowList();
                        Console.ReadKey();
                        break;
                    case 2:

                        Console.WriteLine("Nhap id:");
                        int id = Convert.ToInt32(Console.ReadLine());

                        await m.searchById(id);
                        Console.WriteLine("Press any key to continue");
                        Console.ReadKey();


                        break;
                    case 3:
                        Console.WriteLine("Enter name: ");
                        string name = Console.ReadLine();
                        await m.InsertCategoryAsync(name);

                        break;
                    case 4:
                        Console.WriteLine("Nhap id: ");
                        int id1 = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Enter name: ");
                        string name1 = Console.ReadLine();
                        await m.updateCategory(id1, name1);
                        break;
                    case 5:
                        Console.WriteLine("Nhap id delete:");
                        int id2 = Convert.ToInt32(Console.ReadLine());
                        await m.deletebyID(id2);

                        break;
                    case 6:
                        Console.WriteLine("Show list product");
                        await m.showListProduct();
                        break;
                    case 7:
                        Console.WriteLine("Add product");
                        Console.WriteLine("Nhap ProductName: ");
                        string ProductName = Console.ReadLine();
                        Console.WriteLine("Nhap UnitPrice: ");
                        int UnitPrice = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Nhap UnitsInStock: ");
                        int UnitsInStock = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Nhap Image: ");
                        string Image = Console.ReadLine();
                        Console.WriteLine("Nhap CategoryId: ");
                        int CategoryId = Convert.ToInt32(Console.ReadLine());
                       await m.addProduct(ProductName, UnitPrice, UnitsInStock, Image, CategoryId);

                        break;
                    case 8:
                        Console.WriteLine("Update product by id");
                        Console.WriteLine("Nhap ProductId: ");
                        int ProductId1 = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Nhap ProductName: ");
                        string ProductName1 = Console.ReadLine();
                        Console.WriteLine("Nhap UnitPrice: ");
                        int UnitPrice1 = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Nhap UnitsInStock: ");
                        int UnitsInStock1 = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Nhap Image: ");
                        string Image1 = Console.ReadLine();
                        Console.WriteLine("Nhap CategoryId: ");
                        int CategoryId1 = Convert.ToInt32(Console.ReadLine());
                        await m.updateProduct(ProductId1,ProductName1, UnitPrice1, UnitsInStock1, Image1, CategoryId1);
                        break;
                    case 9:
                        Console.WriteLine("Delete product by id");
                        int ProductId2 = Convert.ToInt32(Console.ReadLine());
                        await m.deleteProduct(ProductId2);

                        break;

                }
            }
        }
    }
}