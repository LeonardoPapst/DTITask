using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using ToDoListProject.Models;

namespace ToDoListProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefasController : ControllerBase
    {
        private readonly List<Tarefa> tarefas;

        public TarefasController(TarefasList tarefasList)
        {
            tarefas = tarefasList.tarefas;
        }

        //Obter a lista de todas as tarefas
        [HttpGet]
        public IActionResult GetTarefas()
        {
            return Ok(tarefas);
        }

        //Criar ou atualizar tarefas. Id é usado como chave
        [HttpPut]
        [Route("EnviarTarefa")]
        public IActionResult EnviarTarefa(JObject objTarefa)
        {
            var tarefa = new Tarefa(objTarefa);
            Tarefa tarefaList = null;
            if (tarefas != null)
            {
                tarefaList = tarefas.Find(t => t.Id == tarefa.Id);
            }
            
            if (tarefaList != null)
            {
                //Atualizar
                foreach (var t in tarefas)
                {
                    if (t.Id == tarefa.Id)
                    {
                        t.Descricao = tarefa.Descricao;
                        t.Feito = tarefa.Feito;
                        return Ok();
                    }
                }
            }
            else
            {
                //criar nova
                tarefas.Add(tarefa);
            }

            return Ok();
        }

        //Apagar tarefa baseado no Id
        [HttpDelete("{id}")]
        public IActionResult ApagarTarefa(int id)
        {
            var tarefaFind = tarefas.Find(t => t.Id == id);
            tarefas.Remove(tarefaFind);
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult BuscarTarefaId(int id)
        {
            var tarefaFind = tarefas.Find(t => t.Id == id);
            return Ok(tarefaFind);
        }
    }
}
