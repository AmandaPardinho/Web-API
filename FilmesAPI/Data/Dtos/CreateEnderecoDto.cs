﻿using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.Dtos
{
    public class CreateEnderecoDto
    {
        [Required]
        public string Logradouro { get; set; }

        [Required]
        public int Numero { get; set; }
    }
}
