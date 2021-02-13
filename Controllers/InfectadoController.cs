using Api.Data.Collections;
using Api.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using System;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InfectadoController : ControllerBase
    {
        //aqui usamos injeção de dependencia
        Data.MongoDB _mongoDB;

        //a collection com os infectados
        IMongoCollection<Infectado> _infectadosCollection;

        public InfectadoController(Data.MongoDB mongoDB)
        {
            _mongoDB = mongoDB;
            _infectadosCollection = _mongoDB.DB.GetCollection<Infectado>(typeof(Infectado).Name.ToLower());
        }

        [HttpPost]
        public ActionResult SalvarInfectado([FromBody] InfectadoDto dto)
        {
            var infectado = new Infectado(dto.nascimento, dto.sexo, dto.latitude, dto.longitude);

            _infectadosCollection.InsertOne(infectado);
            
            
            return StatusCode(201, "Infectado adicionado com sucesso");
        }

        [HttpPut("{nascimento}")]
        public ActionResult AtualizarInfectado(DateTime nascimento)
        {
          //  var infectado = new Infectado(dto.nascimento, dto.sexo, dto.latitude, dto.longitude);
            var filter = Builders<Infectado>.Filter.Where(_ => _.nascimento ==nascimento);
            var update = Builders<Infectado>.Update.Set("sexo", "F");
            _infectadosCollection.UpdateOne(filter, update);
            
            
            return StatusCode(201, "Infectado atualizado com sucesso");
        }

         [HttpDelete("{nascimento}")]
        public ActionResult ApagarInfectado(DateTime nasci)
        {
           
          
           // var nasci = Convert.ToDateTime(id);
            _infectadosCollection.DeleteOne(Builders<Infectado>.Filter.Where(_ => _.nascimento ==nasci));
          //  _infectadosCollection.DeleteOne(id);
            
            return Ok("Apagado!!");
        }
       // 2000-03-05
        [HttpGet("{nascimento}")]
        public ActionResult ObterInfectadosPorData(string nascimento)
        {
            var nasci = Convert.ToDateTime(nascimento);
            var infectados = _infectadosCollection.Find(Builders<Infectado>.Filter.Where(_ => _.nascimento ==nasci));
            
            return Ok(infectados);
        }

        [HttpGet]
        public ActionResult ObterInfectados()
        {
            var infectados = _infectadosCollection.Find(Builders<Infectado>.Filter.Empty).ToList();
            
            return Ok(infectados);
        }
    }
}
