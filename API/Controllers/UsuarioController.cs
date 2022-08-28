using Microsoft.AspNetCore.Mvc;
using API.Models;
using System.Collections.Generic;

namespace API.Controllers
{
    [Route("api/usuario")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private static List<Usuario> usuarios = new List<Usuario>();

        //GET: /api/usuario/listar
        [HttpGet]
        [Route("listar")]
        public IActionResult Listar()
        {
            return Ok(usuarios);
        }

        // POST: /api/usuario/cadastrar
        [HttpPost]
        [Route("cadastrar")]
        public IActionResult Cadastrar([FromBody] Usuario usuario)
        {
            usuarios.Add(usuario);
            return Created("", usuario);
        }

        //GET: /api/usuario/buscar/{cpf}
        [HttpGet]
        [Route("buscar/{cpf}")]
        public IActionResult Buscar([FromRoute] string cpf)
        {
            for (int i = 0; i < usuarios.Count; i++)
            {
                if (usuarios[i].Cpf.Equals(cpf))
                {
                    return Ok(usuarios[i]);
                }
            }
            return NotFound();
        }

        //Delete: /api/usuario/deletar/{cpf}
        [HttpDelete]
        [Route("deletar/{cpf}")]
        public IActionResult Deletar([FromRoute] string cpf)
        {
            for (int i = 0; i < usuarios.Count; i++)
            {
                if (usuarios[i].Cpf.Equals(cpf))
                {
                    string nomeFuncionario = usuarios[i].Nome;
                    usuarios.Remove(usuarios[i]);
                    return Ok($"Usuario {nomeFuncionario} deletado com sucesso!");
                }
            }
            return NotFound();
        }

        //Put: /api/usuario/editar/{cpf}
        [HttpPut]
        [Route("editar/{cpf}")]
        public IActionResult Editar([FromBody] Usuario usuario, [FromRoute] string cpf)
        {
            for (int i = 0; i < usuarios.Count; i++)
            {
                if (usuarios[i].Cpf.Equals(cpf))
                {
                    usuarios[i] = usuario;
                    return Ok();
                }
            }
            return NotFound();
        }
    }
}