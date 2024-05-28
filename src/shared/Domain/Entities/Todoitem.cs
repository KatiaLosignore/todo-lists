using System.Text.Json.Serialization;
using shared.Domain.Entities.Common;

namespace shared.Domain.Entities
{
    public class Todoitem : AuditableBaseEntity<Guid>
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public bool IsDone { get; set; }

        public Guid ListaId { get; set; }

        [JsonIgnore]
        public Todolist Todolist { get; set;  }

        private Todoitem(string text, Guid listaId, bool isDone) : base()
        {
            Text = text;
            IsDone = isDone;
            ListaId = listaId;
          
        }

        public Todoitem () { }

        public static Todoitem Create(string text, Guid ListId)
        {
            return new Todoitem(text, ListId, false);
        }

        // Implementazione del metodo Update
        public void Update(string text, bool isDone)
        {
            // aggiornamento dell'oggetto

            Text = text;
            IsDone = isDone;
        }

    }

}

