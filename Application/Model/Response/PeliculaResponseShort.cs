﻿namespace Application.Model.Response
{
    public class PeliculaResponseShort
    {

        public int peliculaId { get; set; }
        public string titulo { get; set; }
        public string poster { get; set; }
        public GeneroResponse genero { get; set; }

    }
}
