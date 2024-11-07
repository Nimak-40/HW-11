
using HW_11.Entities;

namespace HW_11.Dapper;

public interface IDapperRepository
{
    int Add(Product product);
    List<Product> GetAll();
    Product GetById(int id);  
    bool Update(Product product);  
    bool Delete(int id);  
}
