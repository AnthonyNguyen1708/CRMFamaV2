using System;
using System.ComponentModel.DataAnnotations;

namespace CRMFamaV2.Models
{
	public class AccountModel
    {
        [Required]
        public string email { get; set; }

        [Required]
        public string password { get; set; }

        public bool loginStatus { get; set; }
    }
}

