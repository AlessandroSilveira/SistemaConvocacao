using System.ComponentModel.DataAnnotations;

namespace SisConv.Infra.CrossCutting.Identity.Model
{
    public class AddPhoneNumberViewModel
    {
        [Required]
        [Phone]
        [Display(Name = "Phone Number")]
        public string Number { get; set; }
    }
}