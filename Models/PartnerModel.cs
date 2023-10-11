
using System.ComponentModel.DataAnnotations;
namespace CRMFamaV2.Models

{
    public class PartnerModel : BaseModel
    {
        [Required]
        public string PartnerName { get; set; }
        
        public string PartnerAddress { get; set; }

        public string PartnerPhone { get; set; }

        public string PartnerEmail { get; set; }

        [Required]
        public bool PartnerStatus { get; set; }

        public string PartnerDescription { get; set; }

        public string PartnerDiscount { get; set; }
    }
}

