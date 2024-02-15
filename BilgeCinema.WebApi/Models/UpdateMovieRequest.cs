namespace BilgeCinema.WebApi.Models
{
    public class UpdateMovieRequest
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
