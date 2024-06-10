using Shop.Business.Dtos;

namespace Shop.Business.Interfaces;

public interface IProductService
{
    void Create(ProductCreateDto productCreateDto);
    void Delete(int id);
    ProductGetDto Get(int id);
    List<ProductGetDto> GetAll();
}
