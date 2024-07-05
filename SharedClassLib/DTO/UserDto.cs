using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace SharedClassLib.DTO
{
    public class UserDto
    {
        public string? Id { get; set; } = string.Empty;
        [Required]
        public string Name { get; set; }=string.Empty;
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }=string.Empty ;
        [Required]
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; } = string.Empty;
        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}
