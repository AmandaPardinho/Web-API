﻿using System.ComponentModel.DataAnnotations;

namespace DesafioApiFilme.Models
{
    public class Genero
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        public virtual ICollection<Filme> Filmes { get; set; }
    }
}
