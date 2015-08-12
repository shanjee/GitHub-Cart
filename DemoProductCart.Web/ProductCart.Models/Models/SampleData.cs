using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;


namespace ProductCart.Models.Models
{
    public class SampleData : DropCreateDatabaseIfModelChanges<StoreEntities>
    {
        protected override void Seed(StoreEntities context)
        {
            var genres = new List<ProductCategory>
            {
                new ProductCategory { Name = "Rock" }
                //,
                //new ProductCategory { Name = "Jazz" },
                //new ProductCategory { Name = "Metal" },
                //new ProductCategory { Name = "Alternative" },
                //new ProductCategory { Name = "Disco" },
                //new ProductCategory { Name = "Blues" }
               
            };

            var artists = new List<Manufacture>
            {
                new Manufacture { Name = "AC/DC" }
                //,
                //new Manufacture { Name = "Aaron Goldberg" },
                //new Manufacture { Name = "AC/DC" },
                //new Manufacture { Name = "Accept" },
                //new Manufacture { Name = "Adrian Leaper & Doreen de Feis" },
                //new Manufacture { Name = "Aerosmith" },
                //new Manufacture { Name = "Aisha Duo" },
                //new Manufacture { Name = "Alanis Morissette" },
                //new Manufacture { Name = "Alberto Turco & Nova Schola Gregoriana" },
                //new Manufacture { Name = "Alice In Chains" },
                //new Manufacture { Name = "Amy Winehouse" }
                
            };

            new List<Product>
            {
                new Product { Title = "The Best Of Men At Work", ProductCategory = genres.Single(g => g.Name == "Rock"), Price = 8.99M , Manufacture = artists.Single(a => a.Name == "AC/DC")}                

            }.ForEach(a => context.Products.Add(a));
        }
    }
}