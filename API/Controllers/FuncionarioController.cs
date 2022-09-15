using Microsoft.AspNetCore.Mvc;
using API.Models;
using System.Collections.Generic;
using System.Linq;

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
            Funcionario funcionario = funcionarios.FirstOrDefault(funcionarioCadastrado => funcionarioCadastrado.Cpf.Equals(cpf));

            return funcionario != null ? Ok(funcionario) : NotFound();
        }

        //Delete: /api/funcionario/deletar/{cpf}
        [HttpDelete]
        [Route("deletar/{cpf}")]
        public IActionResult Deletar([FromRoute] string cpf)
        {
            // Funcionario funcionario = funcionarios.FirstOrDefault(funcionarioCadastrado => funcionarioCadastrado.Cpf.Equals(cpf));

            // if(funcionario != null){
            //     funcionarios.Remove(funcionario);
            //     return Ok(funcionario);
            // }
            // return NotFound();

            foreach (Funcionario funcionarioCadastrado in funcionarios)
            {
                string nomeFuncionario = funcionarioCadastrado.Nome;
                funcionarios.Remove(funcionarioCadastrado);
                return Ok($"Funcionario {nomeFuncionario} deletado com sucesso!");
            }
            return NotFound();
        }

        //Patch: /api/funcionario/editar
        // [Route("editar/{cpf}")]
        [HttpPatch]
        [Route("editar")]
        public IActionResult Editar([FromBody] Funcionario funcionario)
        {

            Funcionario funcionarioBuscado = funcionarios.FirstOrDefault(funcionarioBuscado => funcionarioBuscado.Cpf.Equals(funcionario.Cpf));

            if (funcionarioBuscado != null)
            {
                funcionarioBuscado.Nome = funcionario.Nome;
                return Ok(funcionario);
            }
            return NotFound();

            // for (int i = 0; i < funcionarios.Count; i++)
            // {
            //     if (funcionarios[i].Cpf.Equals(cpf))
            //     {
            //         funcionarios[i] = funcionario;
            //         return Ok();
            //     }
            // }
            // return NotFound();
        }
    }
}