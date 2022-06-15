using Newtonsoft.Json.Linq;
using ToDoListProject.Models;

namespace ToDoListProject.Context
{
    public class TarefaDatabase
    {
        private readonly List<Tarefa> tarefasList;
        public TarefaDatabase(List<Tarefa> tarefasList)
        {
            this.tarefasList = tarefasList;
        }
        public List<Tarefa> GetTarefas()
        {
            return tarefasList;
        }
        public List<Tarefa> InsereAtualizaTarefa(JObject objTarefa)
        {
            var tarefa = new Tarefa(objTarefa);
            Tarefa tarefaFind = null;
            if (tarefasList != null)
            {
                tarefaFind = tarefasList.Find(t => t.Id == tarefa.Id);
            }

            if (tarefaFind != null)
            {
                //Atualizar
                foreach (var t in tarefasList)
                {
                    if (t.Id == tarefa.Id)
                    {
                        t.Descricao = tarefa.Descricao;
                        t.Feito = tarefa.Feito;
                    }
                }
            }
            else
            {
                //criar nova
                tarefasList.Add(tarefa);
            }
            return tarefasList;
        }

        public List<Tarefa> ApagarTarefa(int id)
        {
            var tarefaFind = tarefasList.Find(t => t.Id == id);
            tarefasList.Remove(tarefaFind);
            return tarefasList;
        }
        public Tarefa BuscarTarefa(int id)
        {
            Tarefa tarefaFind = tarefasList.Find(t => t.Id == id);
            return tarefaFind;
        }
    }
}
