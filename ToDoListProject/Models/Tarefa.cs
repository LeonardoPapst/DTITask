using Newtonsoft.Json.Linq;

namespace ToDoListProject.Models
{
    public class Tarefa
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public bool Feito { get; set; }
        public Tarefa(JObject objTarefa)
        {
            Id = (int)objTarefa["Id"];
            Descricao = objTarefa["Descricao"].ToString();
            Feito = (bool)objTarefa["Feito"];
        }
        public Tarefa()
        {}
    }
}
