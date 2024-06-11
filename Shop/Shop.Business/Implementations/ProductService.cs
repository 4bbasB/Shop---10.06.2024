using Shop.Business.Dtos;
using Shop.Business.Interfaces;
using Shop.Core.Models;
using Shop.Data.DAL;

namespace Shop.Business.Implementations;

public class ProductService : IProductService
{
    void IProductService.Create(ProductCreateDto productCreateDto)
    {
        Product product = new Product(productCreateDto.Name, productCreateDto.CostPrice, productCreateDto.SalePrice) { Name = productCreateDto.Name, CostPrice = productCreateDto.CostPrice, SalePrice = productCreateDto.SalePrice};
        ShopDATABASE.Products.Add(product);
    }

    void IProductService.Delete(int id)
    {
        Product? wantedProduct = ShopDATABASE.Products.Find(x => x.Id == id);

        if (wantedProduct is null)
            throw new NullReferenceException("Product not found!");

        ShopDATABASE.Products.Remove(wantedProduct);
    }

    ProductGetDto IProductService.Get(int id)
    {
        Product? wantedProduct = ShopDATABASE.Products.Find(x => x.Id == id);

        if (wantedProduct is null)
            throw new NullReferenceException("Product not found!");

        return new ProductGetDto(wantedProduct.Id, wantedProduct.Name, wantedProduct.SalePrice);
    }

    List<ProductGetDto> IProductService.GetAll()
    {
        return ShopDATABASE.Products.Select(product => new ProductGetDto(product.Id, product.Name, product.SalePrice)).ToList();
    }
}
