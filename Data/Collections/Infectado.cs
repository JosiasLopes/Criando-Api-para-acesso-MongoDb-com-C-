using System;

using MongoDB.Driver.GeoJsonObjectModel;

namespace Api.Data.Collections

{
    public class Infectado{
    public Infectado (DateTime nascimento, string sexo, double latitude, double longitude) {
        this.nascimento = nascimento;
        this.sexo = sexo;
        this.localizacao = new GeoJson2DGeographicCoordinates (latitude, longitude);
    }

    
       
            public DateTime nascimento{ get; set; }
    public string sexo{get;set;}
    public GeoJson2DGeographicCoordinates localizacao{get;set;}

}
}