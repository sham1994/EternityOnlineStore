using System.Collections.Generic;
using System.IO;
using System.Linq;
using EternityStore.Data.Model;
using Newtonsoft.Json;

namespace EternityStore.Data.Repository
{
    public static class Seed
    {
        public static void SeedUsers(DataContext context)
        {
            if(!context.Users.Any())
            {
                var userData = System.IO.File.ReadAllText(@"../EternityStore.Data/Repository/UserSeedData.json");
                //+ Path.DirectorySeparatorChar.ToString()
                var users = JsonConvert.DeserializeObject<List<User>>(userData);
                foreach(var user in users)
                {
                    CreatePasswordHash("password", out byte[] passwordhash, out byte[] passwordSalt);

                    user.PasswordHash = passwordhash;
                    user.PasswordSalt = passwordSalt;
                    user.Username = user.Username.ToLower();
                    context.Users.Add(user);

                }

                context.SaveChanges();
            }
        }
        public static void SeedProductCategories(DataContext context)
        {
            if(!context.ProductCategories.Any())
            {
                //var categoryData = System.IO.File.ReadAllText(@"../Repository/ProductCategorySeedData.json");
                var categoryData = System.IO.File.ReadAllText(@"../EternityStore.Data/Repository/ProductCategorySeedData.json");
                var categories = JsonConvert.DeserializeObject<List<ProductCategory>>(categoryData);
            foreach(var category in categories)
            {
                context.ProductCategories.Add(category);
            }
            context.SaveChanges();
            }
            
        }
        public static void SeedProducts(DataContext context)
        {
            if(!context.Products.Any())
            {
            var productData = System.IO.File.ReadAllText(@"../EternityStore.Data/Repository/ProductSeedData.json");
            var products = JsonConvert.DeserializeObject<List<Product>>(productData);
            foreach(var product in products)
            {
                context.Products.Add(product);
            }
            context.SaveChanges();
            }
            
        }


        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using var hmac = new System.Security.Cryptography.HMACSHA512();
            passwordSalt = hmac.Key;
            //converts password to byte array
            passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        }
    }
}