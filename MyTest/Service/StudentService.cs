using Dapper;
using MyTest.Abstract;
using MyTest.Model;
using System.Data;

namespace MyTest.Service
{
    public class StudentService : IStudent
    {
        private readonly IDbConnection db;
        public StudentService(IDbConnection db)
        {
            this.db = db;
        }
        public async Task AddAsync(Student student)
        {
            const string sql = @"
            INSERT INTO Student (Id, Name, Age) 
            VALUES (@Id, @Name, @Age)";

            // ExecuteAsync выполняет INSERT / UPDATE / DELETE запрос
            await db.ExecuteAsync(sql, student);
        }

        public async Task<Student?> GetByIdAsync(int id)
        {
            const string sql = @"
            SELECT Id, Name, Age 
            FROM Student
            WHERE Id = @Id";

            // QueryFirstOrDefaultAsync делает запрос и автоматически маппит результат на объект Student
            return await db.QueryFirstOrDefaultAsync<Student>(sql, new { Id = id });
        }
    }
}
