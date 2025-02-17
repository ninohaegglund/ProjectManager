using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectManager.Data.Entities
{
    public class ProjectEntity
    {
        [Key]
        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public DateTime StartDate { get; set; } = DateTime.Now;
        public DateTime? EndDate { get; set; }

        [Required] 
        [ForeignKey("Customer")] 
        public long CustomerId { get; set; }
        public UserEntity Customer { get; set; } = null!;
    }
}
