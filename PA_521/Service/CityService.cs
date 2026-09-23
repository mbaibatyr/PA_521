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
            using (SqlConnection db = new SqlConnection(config["db"]))
            {
                //DynamicParameters p = new DynamicParameters(city);
                //int rows = db.Execute("CityInsert", p,
                //    commandType: System.Data.CommandType.StoredProcedure);
                //    
                int rows = db.Execute("CityInsert", new { p_name=city.name, 
                    p_id = city.id } ,
                    commandType: System.Data.CommandType.StoredProcedure);
                return rows.ToString();
            }
        }

        public string CityDelete(int id)
        {            
            using (SqlConnection db = new SqlConnection(config["db"]))
            {
                int rows = db.Execute("CityDelete", new { id }, 
                    commandType: System.Data.CommandType.StoredProcedure);
                return rows.ToString();
            }
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
