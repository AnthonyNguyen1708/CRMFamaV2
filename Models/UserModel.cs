using System.ComponentModel.DataAnnotations;
namespace CRMFamaV2.Models
{
	public class UserModel : BaseModel
	{
        [Required]
		public string first_name { get; set; }

        [Required]
        public string last_name { get; set; }

        public string? hint { get; set; }

        public string email { get; set; }

        [Required]
        public string password { get; set; }

        public string? username { get; set; }

        public string? address { get; set; }

        public string? phone { get; set; }

        public DateTime? birthday { get; set; }

        [Required]
        public bool status { get; set; }

        [Required]
        public bool remember { get; set; }

        public string? avatar { get; set; }

        public string? about { get; set; }

        [Required]
        public byte gender { get; set; }

        public byte role_id { get; set; }
    }
}


