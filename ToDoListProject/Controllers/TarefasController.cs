using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using ToDoListProject.Context;
using ToDoListProject.Models;

namespace ToDoListProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefasController : ControllerBase
    {
        private readonly TarefaDatabase tarefaDb;

        public TarefasController(TarefaDatabase tarefaDb)
        {
            this.tarefaDb = tarefaDb;
        }

        //Obter a lista de todas as tarefas
        [HttpGet]
        public IActionResult GetTarefas()
        {
            return Ok(tarefaDb.GetTarefas());
        }

        //Criar ou atualizar tarefas. Id é usado como chave
        [HttpPut]
        [Route("EnviarTarefa")]
        public IActionResult EnviarTarefa(JObject objTarefa)
        {
            tarefaDb.InsereAtualizaTarefa(objTarefa);
            return Ok();
        }

        //Apagar tarefa baseado no Id
        [HttpDelete("{id}")]
        public IActionResult ApagarTarefa(int id)
        {
            tarefaDb.ApagarTarefa(id);
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult BuscarTarefaId(int id)
        {
            return Ok(tarefaDb.BuscarTarefa(id));
        }
    }
}
