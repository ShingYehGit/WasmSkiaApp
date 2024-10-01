using SqlData;
using System.ComponentModel.DataAnnotations;

namespace WasmSkiaApp.Models
{

    public class EdAspUser : Cosmos<EdAspUser>
    {

        public int CoinTypeIdx { get; set; } = 0;

        [Required]
        public string? Gender { get; set; } = string.Empty;
        [Required]
        public string? Language { get; set; } = string.Empty;//English / Traditional Chinese / Simplifed Chinese
        [Required]
        public string? AccountName { get; set; } = string.Empty;
        [Required]
        [MaxLength(20)]
        public string? Email { get; set; } = string.Empty;
        [Required]
        public string? Password { get; set; } = string.Empty;
        [Required]
        public string? PhoneNumber { get; set; } = string.Empty;
        [Required]
        public string? UserName { get; set; } = string.Empty;
        [Required]
        public DateTime BirthDate { get; set; }
        [Required]
        public DateTime StartDate { get; set; } = DateTime.UtcNow;

        public decimal AnualTotal { get; set; } = 0.0M;//
        public decimal EarnBonus { get; set; } = 0.0M;//free charge quantity

    }

}
