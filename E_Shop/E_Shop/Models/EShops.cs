using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EShop.Models
{
    public class EShops
    {
        public EShops(string productType, string nameOfProducts, string kindOfProduct, string barCode, decimal priceProduct)
        {
            ProductType = productType;
            NameOfProducts = nameOfProducts;
            KindOfProduct = kindOfProduct;
            BarCode = barCode;
            PriceProduct = priceProduct;
        }

        public string ProductType { get; }

        public string NameOfProducts { get; }

        public string KindOfProduct { get; }

        public string BarCode { get; }

        public decimal PriceProduct { get; }

        public string GetInformation()
        {
            return $"{ProductType} {NameOfProducts} {KindOfProduct} {BarCode} {PriceProduct}  ";

        }

    }
}
    


