using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Http.HttpResults;

namespace PA_521.Model
{
    public class CityModel
    {
    }

    public class CityDTO
    {
        public int id { get; set; }
        public string name { get; set; }
        public int year { get; set; }
        public int population { get; set; }      
    }
}
