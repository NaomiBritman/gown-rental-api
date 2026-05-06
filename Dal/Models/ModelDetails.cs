
namespace Dal.Models
{
    public class ModelDetails
    {
        // Use concrete types that match your database. Adjust nullability as needed.
        public int? GownId { get; set; }
        public int? ModelId { get; set; }
        public decimal? Price { get; set; }
        public int? Size { get; set; }

        // Navigation to the principal entity
        public GownModel? Model { get; set; }
    }
}