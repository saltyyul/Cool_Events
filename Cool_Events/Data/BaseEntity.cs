using System.ComponentModel.DataAnnotations.Schema;

namespace Cool_Events.Data
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public string? CreatedById { get; set; }

        [NotMapped]
        public virtual User? CreatedBy { get; set; }

        public string? UpdatedById { get; set; }
        [NotMapped]
        public virtual User? UpdatedBy { get; set; }
    }
}
