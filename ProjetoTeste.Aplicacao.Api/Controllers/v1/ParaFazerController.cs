using Microsoft.AspNetCore.Mvc;

namespace ProjetoTeste.Aplicacao.Api.Controllers.v1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ParaFazerController : ControllerBase
    {
        private static List<string>  Nomes = new List<string> { "Marcos", "Joel" };

        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return Ok(Nomes);
        }

        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            if (id <= 0)
                return BadRequest($"Código inválido");

            if (id > Nomes.Count())
                return NotFound($"registro não encontrado");

            var nome = Nomes[id-1];

            return Ok(nome);
        }

        [HttpPost]
        public ActionResult Adicionar([FromBody] string Nome)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            Nomes.Add(Nome);

            return Created($"api/v1/ParaFazer/{Nomes.Count()}", Nomes);
        }

        [HttpPut("{id}")]
        public ActionResult AdEditar(int id, [FromBody] string NovoNome)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id <= 0)
                return BadRequest($"Código inválido");

            var nome = Nomes[id-1];

            nome = NovoNome;

            Nomes[id-1] = nome;

            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Deletar(int id)
        {
            if (id <= 0)
                return BadRequest($"Código inválido");

            if (id > Nomes.Count())
                return NotFound($"registro não encontrado");

            var nomeDeletar = Nomes[id - 1];

            Nomes = Nomes.Where(x => x != nomeDeletar).ToList();

            return Ok();

        }
    }
}
