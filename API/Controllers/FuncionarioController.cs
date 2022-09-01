using Microsoft.AspNetCore.Mvc;
using API.Models;
using System.Collections.Generic;

namespace API.Controllers
{
    [Route("api/funcionario")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        private static List<Funcionario> funcionarios = new List<Funcionario>();

        //GET: /api/funcionario/listar
        [HttpGet]
        [Route("listar")]
        public IActionResult Listar()
        {
            return Ok(funcionarios);
        }

        // POST: /api/funcionario/cadastrar
        [HttpPost]
        [Route("cadastrar")]
        public IActionResult Cadastrar([FromBody] Funcionario funcionario)
        {
            funcionarios.Add(funcionario);
            return Created("", funcionario);
        }

        //GET: /api/funcionario/buscar/{cpf}
        [HttpGet]
        [Route("buscar/{cpf}")]
        public IActionResult Buscar([FromRoute] string cpf)
        {
            for (int i = 0; i < funcionarios.Count; i++)
            {
                if (funcionarios[i].Cpf.Equals(cpf))
                {
                    return Ok(funcionarios[i]);
                }
            }
            return NotFound();
        }

        //Delete: /api/funcionario/deletar/{cpf}
        [HttpDelete]
        [Route("deletar/{cpf}")]
        public IActionResult Deletar([FromRoute] string cpf)
        {
            for (int i = 0; i < funcionarios.Count; i++)
            {
                if (funcionarios[i].Cpf.Equals(cpf))
                {
                    string nomeFuncionario = funcionarios[i].Nome;
                    funcionarios.Remove(funcionarios[i]);
                    return Ok($"Funcionario {nomeFuncionario} deletado com sucesso!");
                }
            }
            return NotFound();
        }

        //Put: /api/usuario/editar/{cpf}
        [HttpPut]
        [Route("editar/{cpf}")]
        public IActionResult Editar([FromBody] Funcionario funcionario, [FromRoute] string cpf)
        {
            for (int i = 0; i < funcionarios.Count; i++)
            {
                if (funcionarios[i].Cpf.Equals(cpf))
                {
                    funcionarios[i] = funcionario;
                    return Ok();
                }
            }
            return NotFound();
        }
    }
}