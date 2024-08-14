using _80_MVC_IdentityCustomize.Models.Enums;

namespace _80_MVC_IdentityCustomize.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public Status Status { get; set; } = Status.Planned;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string? Description { get; set; }
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}
