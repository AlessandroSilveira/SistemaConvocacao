using System.ComponentModel.DataAnnotations;

namespace SisConv.Application.ViewModels
{
    public class RoleViewModel
    {
        [Key]
        public string Id { get; set; }
        [Required(AllowEmptyStrings = false)]
        [Display(Name = "RoleName")]
        public string Name { get; set; }
    }


}