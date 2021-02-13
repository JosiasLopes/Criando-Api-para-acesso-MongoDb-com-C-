using System;

namespace Api.Models
{
    public class InfectadoDto
    {
        //para cada endpoint é necessario um model
         public DateTime nascimento { get; set; }
        public string sexo { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
    }
}