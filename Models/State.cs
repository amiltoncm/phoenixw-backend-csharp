﻿using Microsoft.EntityFrameworkCore;
using Phoenix.Domains;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace Phoenix.Models
{
    [Table("states")]
    [Index(nameof(Name), Name = "idx_ste_name", IsUnique = false)]
    public class State
    {
        [Key]
        [Column("ste_id")]
        [Display(Name = "ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Column("ste_code")]
        [Display(Name = "Código")]
        public int Code { get; set; }

        [Column("ste_name")]
        [Display(Name = "Nome")]
        [MinLength(3, ErrorMessage = "É necessário pelo menos {1} caracteres!")]
        [MaxLength(50, ErrorMessage = "O campo nome suporta apenas {1} caracteres!")]
        public string? Name { get; set; }

        [Column("ste_abbreviation")]
        [Display(Name = "Sigla")]
        [MinLength(3, ErrorMessage = "É necessário pelo menos {1} caracteres!")]
        [MaxLength(3, ErrorMessage = "O campo sigla suporta apenas {1} caracteres!")]
        public string? Abbreviation { get; set; }

        [Column("cnt_id")]
        [Display(Name = "ID País")]
        [ForeignKey("Country")]
        public int CountryId { get; set; }

        [Column("sta_id")]
        [Display(Name = "ID Status")]
        [ForeignKey("Status")]
        public int StatusId { get; set; }

        [Column("ste_created")]
        [Display(Name = "Criado em")]
        public DateTime Created { get; set; }

        [Column("ste_updated")]
        [Display(Name = "Atualizado em")]
        public DateTime Updated { get; set; }

        public virtual Status? Status { get; set; }

        public virtual Country? Country { get; set; }
    }
}
