namespace MyPagination.Model
{
    public class User
    {
        public int id { get; set; }
        public DateTime? created { get; set; }
        public string? last_name { get; set; }
        public string? first_name { get; set; }
        public DateTime? date_birth { get; set; }
        public string? email { get; set; }
        public int TotalCount { get; set; }
    }
}
