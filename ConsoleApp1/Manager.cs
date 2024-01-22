using Newtonsoft.Json;
using System.Net.Http.Json;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace ConsoleApp1
{
    public class Manager
    {
        string link = "http://localhost:5002/api/Categories";
        string linkProduct = "http://localhost:5002/api/Product";

        internal async Task addProduct(string? productName, int unitPrice, int unitsInStock, string? image, int? categoryId)
        {
            Product product = new Product()
            {
                ProductName = productName,
                UnitPrice = unitPrice,
                UnitsInStock = unitsInStock,
                Image = image,
                CategoryId = categoryId,
            };
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.PostAsJsonAsync(linkProduct + "/insert", product))
                {
                    if (res.IsSuccessStatusCode)
                    {
                        Console.WriteLine("Insert success");

                    }
                    else
                    {
                        Console.WriteLine("Fail");
                    }
                }
            }
        }

        internal async Task deletebyID(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.DeleteAsync(link + "/delete?categoryId=" + id))
                {
                    if (res.IsSuccessStatusCode)
                    {
                        Console.WriteLine("Delete success");

                    }
                    else
                    {
                        Console.WriteLine("Fail");
                    }
                }
            }
        }

        internal async Task deleteProduct(int productId21)
        {

            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.DeleteAsync(linkProduct + "/delete?id=" + productId21))
                {
                    if (res.IsSuccessStatusCode)
                    {
                        Console.WriteLine("Delete success");

                    }
                    else
                    {
                        Console.WriteLine("Fail");
                    }
                }
            }
        }

        //internal async Task InsertCategoryAsync(string? name)
        //{
        //    //Category category = new Category()
        //    //{
        //    //    CategoryName = name
        //    //};
        //    using (HttpClient client = new HttpClient())
        //    {
        //        using (HttpResponseMessage res = await client.PostAsync(link + "/insert?CategoryName="+name,null))
        //        {
        //            if (res.IsSuccessStatusCode)
        //            {
        //                Console.WriteLine("Add success");

        //            }
        //            else
        //            {
        //                Console.WriteLine("Fail");
        //            }
        //        }
        //    }
        //}
        //c2
        internal async Task InsertCategoryAsync(string? name)
        {
            //Category category = new Category()
            //{
            //    CategoryName = name
            //};
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.PostAsJsonAsync(link + "/insert?CategoryName=", name))
                {
                    if (res.IsSuccessStatusCode)
                    {
                        Console.WriteLine("Add success");

                    }
                    else
                    {
                        Console.WriteLine("Fail");
                    }
                }
            }
        }

        internal async Task searchById(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.GetAsync(link + "/getbyId?categoryId=" + id))
                {
                    using (HttpContent content = res.Content)
                    {
                        string data = await content.ReadAsStringAsync();
                        //Console.WriteLine(data);
                        List<Category> categories = JsonConvert.DeserializeObject<List<Category>>(data);
                        if (categories != null)
                        {
                            foreach (Category i in categories)
                            {
                                Console.WriteLine(i.CategoryId + ":" + i.CategoryName);
                            }
                        }
                        else
                        {
                            Console.WriteLine("not found");
                        }

                    }

                }
            }
        }

        internal async Task ShowList()
        {
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.GetAsync(link))
                {
                    using (HttpContent content = res.Content)
                    {
                        string data = await content.ReadAsStringAsync();
                        //Console.WriteLine(data);
                        List<Category> categories = JsonConvert.DeserializeObject<List<Category>>(data);
                        foreach (Category i in categories)
                        {
                            Console.WriteLine(i.CategoryId + ":" + i.CategoryName);
                        }
                    }

                }
            }
        }

        internal async Task showListProduct()
        {
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.GetAsync(linkProduct))
                {
                    using (HttpContent content = res.Content)
                    {
                        string data = await content.ReadAsStringAsync();
                        List<Product> product = JsonConvert.DeserializeObject<List<Product>>(data);
                        //Console.WriteLine(data);
                        foreach (Product p in product)
                        {
                            Console.WriteLine(p.ProductId + ":" + p.ProductName + ":" + p.UnitPrice + ":" + p.ProductName + ":" + p.UnitsInStock);
                        }
                    }

                }
            }
        }

        internal async Task updateCategory(int id1, string? name1)
        {
            Category category = new Category()
            {
                CategoryId = id1,
                CategoryName = name1
            };
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.PutAsJsonAsync(link + "/update", category))
                {
                    if (res.IsSuccessStatusCode)
                    {
                        Console.WriteLine("Update success");

                    }
                    else
                    {
                        Console.WriteLine("Fail");
                    }
                }
            }
        }

        internal async Task updateProduct(int? productId1, string? productName1, int unitPrice1, int unitsInStock1, string? image1, int? categoryId1)
        {
            Product product = new Product()
            {
                ProductId = productId1 ?? 0,
                ProductName = productName1,
                UnitPrice = unitPrice1,
                UnitsInStock = unitsInStock1,
                Image = image1,
                CategoryId = categoryId1,
            };
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.PutAsJsonAsync(linkProduct + "/update", product))
                {
                    if (res.IsSuccessStatusCode)
                    {
                        Console.WriteLine("Update success");

                    }
                    else
                    {
                        Console.WriteLine("Fail");
                    }
                }
            }
        }
    }
}