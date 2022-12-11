﻿using Microsoft.EntityFrameworkCore;
using Phoenix.Domains;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace Phoenix.Models
{
    [Table("accounts")]
    [Index(nameof(Name), Name = "idx_acc_name", IsUnique = true)]
    public class Account
    {
        [Key]
        [Column("acc_id")]
        [Display(Name = "ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Column("acc_name")]
        [Display(Name = "Nome")]
        [MinLength(3, ErrorMessage = "É necessário pelo menos {1} caracteres!")]
        [MaxLength(75, ErrorMessage = "O campo nome suporta apenas {1} caracteres!")]
        public string? Name { get; set; }

        [Column("bnk_id")]
        [Display(Name = "Banco")]
        [ForeignKey("Banks")]
        public int BankId { get; set; }

        [Column("acc_created")]
        [Display(Name = "Criado em")]
        public DateTime Created { get; set; }

        [Column("acc_updated")]
        [Display(Name = "Atualizado em")]
        public DateTime Updated { get; set; }

        [Column("sta_id")]
        [Display(Name = "Status")]
        [ForeignKey("Status")]
        public int StatusId { get; set; }

        [Display(Name = "Banco")]
        public virtual Bank ? Bank { get; set; }

        [Display(Name = "Status")]
        public virtual Status ? Status { get; set; }

    }

}

