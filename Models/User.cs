using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Phoenix.Domains;

namespace Phoenix.Models
{
    [Table("users")]
    [Index(nameof(Name), Name = "idx_usr_name", IsUnique = true)]
    public class User
    {
        [Key]
        [Column("usr_id")]
        [Display(Name = "Código")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Column("usr_name")]
        [Display(Name = "Nome")]
        [MinLength(3, ErrorMessage = "É necessaário pelo menos {1} caracteres!")]
        [MaxLength(20, ErrorMessage = "O campo nome suporta apenas {1} caracteres!")]
        public string? Name { get; set; }

        [Column("usr_email")]
        [Display(Name = "e-mail")]
        [MinLength(7, ErrorMessage = "É necessaário pelo menos {1} caracteres!")]
        [MaxLength(75, ErrorMessage = "O campo nome suporta apenas {1} caracteres!")]
        public string? Email { get; set; }

        [Column("usr_password")]
        [Display(Name = "Senha")]
        [MinLength(10, ErrorMessage = "É necessaário pelo menos {1} caracteres!")]
        [MaxLength(128, ErrorMessage = "O campo nome suporta apenas {1} caracteres!")]
        public string? Password { get; set; }

        [Column("pro_id")]
        [Display(Name = "Perfil")]
        [ForeignKey("Profile")]
        public int ProfileId { get; set; }

        [Column("sta_id")]
        [Display(Name = "Status")]
        [ForeignKey("Status")]
        public int StatusId { get; set; }

        [Column("usr_created")]
        [Display(Name = "Criado em")]
        public DateTime Created { get; set; }

        [Column("usr_updated")]
        [Display(Name = "Alterado em")]
        public DateTime Updated { get; set; }

        [Column("usr_deleted")]
        [Display(Name = "Inativado em")]
        public DateTime Deleted { get; set; }

        public virtual Status? Status { get; set; }

        public virtual Profile? Profile { get; set; }

    }

}
