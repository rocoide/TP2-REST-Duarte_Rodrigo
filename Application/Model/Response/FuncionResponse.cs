﻿namespace Application.Model.Response
{
    public class FuncionResponse
    {
        public int funcionId { get; set; }
        public PeliculaResponseShort pelicula { get; set; }
        public SalaResponse sala { get; set; }
        public DateTime fecha { get; set; }
        public string horario { get; set; }


    }
}
