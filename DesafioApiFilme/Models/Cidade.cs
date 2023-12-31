﻿using System.ComponentModel.DataAnnotations;

namespace DesafioApiFilme.Models
{
    public class Cidade
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }       

        public virtual ICollection<Endereco> Endereco { get; set; }

        public string UfId { get; set; }
        public virtual UF Uf { get; set; }
    }
}