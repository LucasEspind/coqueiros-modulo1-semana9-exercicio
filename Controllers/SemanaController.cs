using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using modulo1_Semana09.Context;
using modulo1_Semana09.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Intrinsics.X86;

namespace modulo1_Semana09.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SemanaController : ControllerBase
    {
        private readonly SemanaContext _semanaContext;

        public SemanaController(SemanaContext semanaContext)
        {
            _semanaContext = semanaContext;
        }

        [HttpPost("Salvar")]
        public ActionResult Salvar([FromBody] SemanaModel semanaModel)
        {
            if (semanaModel.Id > 0)
            {
                return BadRequest();
            }
            else 
            {
                _semanaContext.Semana.Add(semanaModel);
                _semanaContext.SaveChanges();
                return Ok();
            }
        }
        [HttpPut("Alterar")]
        public ActionResult Alterar([FromBody] SemanaModel semana)
        {
            foreach (var item in _semanaContext.Semana)
            {
                if (item.Id == semana.Id)
                {
                    
                    item.Id = semana.Id;
                    item.AplicadoConteudo = semana.AplicadoConteudo;
                    item.DataSemana = semana.DataSemana;
                    item.Conteudo = semana.Conteudo;
                    _semanaContext.Semana.Update(item);
                    _semanaContext.SaveChanges();
                    return Ok();
                }
            }
            return BadRequest();
        }

        [HttpDelete("Deletar")]
        public ActionResult Deletar(int id)
        {
            var existente = _semanaContext.Semana.Find(id);
            if (existente != null)
            {
                _semanaContext.Semana.Remove(existente);
                _semanaContext.SaveChanges();
                return Ok("Id excluido com sucesso");
            }
            return BadRequest("Id inexistente!");
        }

        [HttpGet("MostrarTodos")]
        public ActionResult MostrarTodos()
        {
            if (_semanaContext == null) 
            {
                return BadRequest();
            }
            return Ok(_semanaContext.Semana);
        }
        [HttpGet("MostrarId")]
        public ActionResult MostrarId(int id)
        {
            var semanaId = _semanaContext.Semana.Find(id);
            if (semanaId == null)
            {
                return BadRequest();
            }
            return Ok(semanaId);
        }
    }
}
