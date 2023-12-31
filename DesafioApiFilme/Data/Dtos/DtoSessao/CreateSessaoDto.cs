﻿using System.ComponentModel.DataAnnotations;

namespace DesafioApiFilme.Data.Dtos.DtoSessao
{
    public class CreateSessaoDto
    {
        [Required]
        public DateTime Horario { get; set; }

        [Required]
        public int FilmeId { get; set; }

        public int CinemaId { get; set; }
    }
}