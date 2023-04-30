using Cool_Events.Data;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Cool_Events.Models.EventVMS
{
    public class EventVM
    {
        [Required]
        [MaxLength(64)]
        public string Name { get; set; }

        [MaxLength(255)]
        public string Description { get; set; }

        public string? ImageURL { get; set; }
        [NotMapped]
        [DisplayName("Upload file")]
        public IFormFile? ImageFile { get; set; }

        public DateTime Date { get; set; }

        public virtual ICollection<Ticket> Ticket { get; set; }
    }
}
