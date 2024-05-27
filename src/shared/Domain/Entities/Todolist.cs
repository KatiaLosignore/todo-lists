using shared.Domain.Entities.Common;

namespace shared.Domain.Entities
{
    public class Todolist : AuditableBaseEntity<Guid>
    {
        public string Title { get; set; }
        public bool IsDone { get; set; }
     
        public List<Todoitem>? Items { get; private set; }


        private Todolist(Guid id, string title, bool isDone) : base(id)
        {
            Title = title;
            IsDone = isDone;
            Items = new List<Todoitem>();
        }


        public static Todolist Create(string title) 
        { 
            return new Todolist(Guid.NewGuid(), title, false);
        }


        //public void AddItem(string title)
        //{
        //    Items.Add(Todoitem.Create(title, this.Id));

        //}

        public Todoitem AddToDoItem(string text)
        {
            Todoitem item = Todoitem.Create(text, Id);
            item.CreatedBy = "Katia";
            item.Created = DateTime.UtcNow;
            Items.Add(item);
            // Aggiorna lo stato della lista
            CheckAllItemsDone();
            return item;
        }

        public void RemoveToDoItem(Todoitem item)
        {
            if (Items.Contains(item))
            {
                Items.Remove(item);
                CheckAllItemsDone(); // Ricalcola lo stato della lista
            }
        }

        public void CheckAllItemsDone()
        {

            //IsDone = Items != null && Items.Count > 0 && Items.All(item => item.IsDone);


            if (Items == null || Items.Count == 0)
            {
                IsDone = false;
            }
            else
            {
                IsDone = Items.All(item => item.IsDone);
            }

        }

    }

    


}




