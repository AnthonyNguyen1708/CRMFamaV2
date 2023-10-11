
using System.ComponentModel.DataAnnotations;

namespace CRMFamaV2.Models
{
    public class BaseModel
    {
        [Key]
        public int Id { get; set; }

        public DateTime? CreatedDateTime { get; set; } = DateTime.Now;

        public DateTime? UpdateDateTime { get; set; }
    }
}

