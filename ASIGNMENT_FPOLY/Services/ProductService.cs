using ASIGNMENT_FPOLY.IServices;
using ASIGNMENT_FPOLY.Models;
using Microsoft.EntityFrameworkCore;

namespace ASIGNMENT_FPOLY.Services
{
    public class ProductService : IProductService
    {
        ISizeService sizeService;
        IColorService colorService;
        DBShopping context;
        public ProductService()
        {
            context = new DBShopping();
            sizeService = new SizeService();
            colorService = new ColorService();
        }
        public bool CreateProduct(Product p)
        {
            try
            {
                p.CreateDate = DateTime.Now;
                context.Products.Add(p);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteProduct(Guid id)
        {
            try
            {
                var Products = context.Products.Find(id);
                context.Products.Remove(Products);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Product> GetAllProductByAction(List<string> lstColor, List<string> lstSize, string searchKeyword, string sortBy)
        {
            var products = GetAllProducts();
            if (lstColor.Count() == 0 && lstSize.Count() == 0)
            {
                products = GetAllProducts().GroupBy(item => new { item.CategoryId, item.BrandId, item.ProductName }).Select(item => item.First()).ToList();
            }
            if ((lstColor.Count() > 0 && lstSize.Count() == 0) || (lstColor.Count() == 0 && lstSize.Count() > 0))
            {
                if (lstSize.Count() == 0)
                {
                    products = products.Where(pro => sizeService.GetAllSizes().Select(s => s.SizeName).Contains(pro.Size.SizeName) && lstColor.Contains(pro.Color.NameColor)).ToList();
                }
                if (lstColor.Count() == 0)
                {
                    products = products.Where(pro => lstSize.Contains(pro.Size.SizeName) && colorService.GetAllColors().Select(x => x.NameColor).Contains(pro.Color.NameColor)).ToList();
                }
            }
            if (lstColor.Count() > 0 && lstSize.Count() > 0)
            {
                products = products.Where(pro => lstSize.Contains(pro.Size.SizeName) && lstColor.Contains(pro.Color.NameColor)).ToList();
            }
            switch (sortBy)
            {
                case "price_desc":
                    products = products.OrderBy(p => p.Price).ToList();
                    break;
                case "price_asc":
                    products = products.OrderByDescending(p => p.Price).ToList();
                    break;
                case "name_desc":
                    products = products.OrderBy(p => p.ProductName).ToList();
                    break;
                case "All":
                    products = GetAllProducts();
                    if (lstColor.Count() == 0 && lstSize.Count() == 0)
                    {
                        products = GetAllProducts().GroupBy(item => new { item.CategoryId, item.BrandId, item.ProductName }).Select(item => item.First()).ToList();
                    }
                    if ((lstColor.Count() > 0 && lstSize.Count() == 0) || (lstColor.Count() == 0 && lstSize.Count() > 0))
                    {
                        if (lstSize.Count() == 0)
                        {
                            products = products.Where(pro => sizeService.GetAllSizes().Select(s => s.SizeName).Contains(pro.Size.SizeName) && lstColor.Contains(pro.Color.NameColor)).ToList();
                        }
                        if (lstColor.Count() == 0)
                        {
                            products = products.Where(pro => lstSize.Contains(pro.Size.SizeName) && colorService.GetAllColors().Select(x => x.NameColor).Contains(pro.Color.NameColor)).ToList();
                        }
                    }
                    if (lstColor.Count() > 0 && lstSize.Count() > 0)
                    {
                        products = products.Where(pro => lstSize.Contains(pro.Size.SizeName) && lstColor.Contains(pro.Color.NameColor)).ToList();
                    }
                    if (!string.IsNullOrEmpty(searchKeyword))
                    {
                        products = products.Where(pro => pro.ProductName.Contains(searchKeyword)).ToList();
                    }
                    else
                    {
                        products = GetAllProducts();
                        if (lstColor.Count() == 0 && lstSize.Count() == 0)
                        {
                            products = GetAllProducts().GroupBy(item => new { item.CategoryId, item.BrandId, item.ProductName }).Select(item => item.First()).ToList();
                        }
                        if ((lstColor.Count() > 0 && lstSize.Count() == 0) || (lstColor.Count() == 0 && lstSize.Count() > 0))
                        {
                            if (lstSize.Count() == 0)
                            {
                                products = products.Where(pro => sizeService.GetAllSizes().Select(s => s.SizeName).Contains(pro.Size.SizeName) && lstColor.Contains(pro.Color.NameColor)).ToList();
                            }
                            if (lstColor.Count() == 0)
                            {
                                products = products.Where(pro => lstSize.Contains(pro.Size.SizeName) && colorService.GetAllColors().Select(x => x.NameColor).Contains(pro.Color.NameColor)).ToList();
                            }
                        }
                        if (lstColor.Count() > 0 && lstSize.Count() > 0)
                        {
                            products = products.Where(pro => lstSize.Contains(pro.Size.SizeName) && lstColor.Contains(pro.Color.NameColor)).ToList();
                        }
                    }
                    break;
            }
            if (!string.IsNullOrEmpty(searchKeyword))
            {
                products = products.Where(pro => pro.ProductName.IndexOf(searchKeyword, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
            }
            else
            {
                products = GetAllProducts();
                if (lstColor.Count() == 0 && lstSize.Count() == 0)
                {
                    products = GetAllProducts().GroupBy(item => new { item.CategoryId, item.BrandId, item.ProductName }).Select(item => item.First()).ToList();
                }
                if ((lstColor.Count() > 0 && lstSize.Count() == 0) || (lstColor.Count() == 0 && lstSize.Count() > 0))
                {
                    if (lstSize.Count() == 0)
                    {
                        products = products.Where(pro => sizeService.GetAllSizes().Select(s => s.SizeName).Contains(pro.Size.SizeName) && lstColor.Contains(pro.Color.NameColor)).ToList();
                    }
                    if (lstColor.Count() == 0)
                    {
                        products = products.Where(pro => lstSize.Contains(pro.Size.SizeName) && colorService.GetAllColors().Select(x => x.NameColor).Contains(pro.Color.NameColor)).ToList();
                    }
                }
                if (lstColor.Count() > 0 && lstSize.Count() > 0)
                {
                    products = products.Where(pro => lstSize.Contains(pro.Size.SizeName) && lstColor.Contains(pro.Color.NameColor)).ToList();
                }
                switch (sortBy)
                {
                    case "price_desc":
                        products = products.OrderBy(p => p.Price).ToList();
                        break;
                    case "price_asc":
                        products = products.OrderByDescending(p => p.Price).ToList();
                        break;
                    case "name_desc":
                        products = products.OrderBy(p => p.ProductName).ToList();
                        break;
                    case "All":
                        products = GetAllProducts();
                        if (lstColor.Count() == 0 && lstSize.Count() == 0)
                        {
                            products = GetAllProducts().GroupBy(item => new { item.CategoryId, item.BrandId, item.ProductName }).Select(item => item.First()).ToList();
                        }
                        if ((lstColor.Count() > 0 && lstSize.Count() == 0) || (lstColor.Count() == 0 && lstSize.Count() > 0))
                        {
                            if (lstSize.Count() == 0)
                            {
                                products = products.Where(pro => sizeService.GetAllSizes().Select(s => s.SizeName).Contains(pro.Size.SizeName) && lstColor.Contains(pro.Color.NameColor)).ToList();
                            }
                            if (lstColor.Count() == 0)
                            {
                                products = products.Where(pro => lstSize.Contains(pro.Size.SizeName) && colorService.GetAllColors().Select(x => x.NameColor).Contains(pro.Color.NameColor)).ToList();
                            }
                        }
                        if (lstColor.Count() > 0 && lstSize.Count() > 0)
                        {
                            products = products.Where(pro => lstSize.Contains(pro.Size.SizeName) && lstColor.Contains(pro.Color.NameColor)).ToList();
                        }
                        if (!string.IsNullOrEmpty(searchKeyword))
                        {
                            products = products.Where(pro => pro.ProductName.Contains(searchKeyword)).ToList();
                        }
                        else
                        {
                            products = GetAllProducts();
                            if (lstColor.Count() == 0 && lstSize.Count() == 0)
                            {
                                products = GetAllProducts().GroupBy(item => new { item.CategoryId, item.BrandId, item.ProductName }).Select(item => item.First()).ToList();
                            }
                            if ((lstColor.Count() > 0 && lstSize.Count() == 0) || (lstColor.Count() == 0 && lstSize.Count() > 0))
                            {
                                if (lstSize.Count() == 0)
                                {
                                    products = products.Where(pro => sizeService.GetAllSizes().Select(s => s.SizeName).Contains(pro.Size.SizeName) && lstColor.Contains(pro.Color.NameColor)).ToList();
                                }
                                if (lstColor.Count() == 0)
                                {
                                    products = products.Where(pro => lstSize.Contains(pro.Size.SizeName) && colorService.GetAllColors().Select(x => x.NameColor).Contains(pro.Color.NameColor)).ToList();
                                }
                            }
                            if (lstColor.Count() > 0 && lstSize.Count() > 0)
                            {
                                products = products.Where(pro => lstSize.Contains(pro.Size.SizeName) && lstColor.Contains(pro.Color.NameColor)).ToList();
                            }
                        }
                        break;
                }
            }
            return products;
        }

        public List<Product> GetAllProducts()
        {
            return context.Products.Include("Category").Include("Size").Include("Color").Include("Brand").Where(x => x.Category.Status == 1 && x.Size.Status == 1 && x.Brand.Status == 1 && x.Color.Status == 1).ToList();
        }

        public List<Product> GetAllProductsNoInclude()
        {
            return context.Products.ToList();
        }

        public Product GetProductById(Guid id)
        {
            return GetAllProducts().FirstOrDefault(p => p.Id == id);
        }
        public List<Product> GetProductsByName(string name)
        {
            return context.Products.Where(p => p.Description.Contains(name)).ToList();
        }

        public bool ReStore(Product obj)
        {
            try
            {
                obj.Brand = null;
                obj.Category = null;
                obj.Color = null;
                obj.Size = null;
                context.Products.Add(obj);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool CheckTrung(Product obj) => GetAllProducts().Any(item => item.ProductName.ToLower().Trim() == obj.ProductName.ToLower().Trim() && item.CategoryId == obj.CategoryId);

        public bool UpdateProduct(Product obj)
        {
            try
            {

                var Product = context.Products.Find(obj.Id);
                Product.ProductName = obj.ProductName;
                Product.Status = obj.Status;
                Product.Description = obj.Description;
                Product.CategoryId = obj.CategoryId;
                Product.BrandId = obj.BrandId;
                Product.ColorId = obj.ColorId;
                Product.SizeId = obj.SizeId;
                Product.Price = obj.Price;
                Product.Image = obj.Image;
                Product.AvailableQuality = obj.AvailableQuality;
                context.Products.Update(Product);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
