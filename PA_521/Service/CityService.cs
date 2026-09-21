using Dapper;
using Microsoft.Data.SqlClient;
using PA_521.Abstract;
using PA_521.Model;

namespace PA_521.Service
{
    public class CityService : ICity
    {
        IConfiguration config;
        public CityService(IConfiguration config) 
        {
            this.config = config;
        }
        public string CityAdd(CityDTO city)
        {
            throw new NotImplementedException();
        }

        public string CityDelete(int id)
        {
            throw new NotImplementedException();
        }

        public string CityEdit(CityDTO city, int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CityDTO> CityGetAll()
        {
            using (SqlConnection db = new SqlConnection(config["db"]))
            {
                return db.Query<CityDTO>("select id, name, [year], population from city order by name");
            }
        }

        public CityDTO CityGetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
