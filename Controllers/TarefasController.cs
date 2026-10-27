using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RippelStoreControllerApi.Models;

namespace RippelStoreControllerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefasController : ControllerBase
    {
        private static List<TarefaModel> tarefas = new List<TarefaModel>();

        [HttpGet]
        public ActionResult<List<TarefaModel>> GetAllTarefas()
        {
            return Ok(tarefas);
        }

        [HttpGet("{id}")]
        public ActionResult<TarefaModel> GetTarefaById(int id)
        {
            var tarefa = tarefas.FirstOrDefault(t => t.Id == id);

            if (tarefa == null)
                return NotFound();

            return Ok(tarefa);
        }

        [HttpPost]
        public ActionResult<TarefaModel> CreateTarefa(CriarTarefaDto tarefa)
        {
            if (string.IsNullOrEmpty(tarefa.name))
            {
                return BadRequest("Nome é obrigatório");
            }

            if (string.IsNullOrEmpty(tarefa.description))
            {
                return BadRequest("Descrição é obrigatória");
            }

            var novaTarefa = new TarefaModel
            {
                Id = tarefas.Count == 0 ? 1 : tarefas.Max(t => t.Id) + 1,
                name = tarefa.name,
                description = tarefa.description
            };

            tarefas.Add(novaTarefa);

            return CreatedAtAction(nameof(GetTarefaById), new { id = novaTarefa.Id }, novaTarefa);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTarefa(int id)
        {
            var tarefa = tarefas.FirstOrDefault(item => item.Id == id);
            if (tarefa == null)
            {
                return BadRequest("Item não encontrado para o Id informado");
            }

            return Ok($"Item {tarefa.name} deletado com sucesso!");
        }
    }
}