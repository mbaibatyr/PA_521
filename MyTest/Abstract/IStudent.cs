using MyTest.Model;

namespace MyTest.Abstract
{
    public interface IStudent
    {
        Task<Student?> GetByIdAsync(int id);        
        Task AddAsync(Student student);        
    }
}
