using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using _80_MVC_IdentityCustomize.Models.Enums;

namespace _80_MVC_IdentityCustomize.Models.VMs
{
    public class BookEditVM
    {
        public int Id { get; set; }
        [DisplayName("Kitap Adı")]
        [Required]
        public string Title { get; set; }

        [DisplayName("Yazar Adı")]
        [Required]
        public string Author { get; set; }

        [DisplayName("Kitap Durumu")]
        public Status Status { get; set; }

        [DisplayName("Açıklama")]
        public string Description { get; set; }
    }
}
