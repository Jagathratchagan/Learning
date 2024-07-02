using EmbeddedSQL.Models;

namespace EmbeddedSQL.Controllers
{
    public interface IEmployee
    {
        long Create(Employee employee);
        Employee Read(long id);
        void Update(Employee employee);
        void Delete(Employee employee);

    }
}
