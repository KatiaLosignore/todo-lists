using FastEndpoints;
using shared.Models.ToDoItems;
using shared.Domain.Entities;
//using webapi.Domain.Infrastructure.Data;
using webapi.Features.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace webapi.Features.TodoItem.DeleteTodoitem
{
    public class Endpoint(ApplicationDbContext dbContext) : Endpoint<DeleteItemRequest, EmptyResponse>
    {
        public override void Configure()
        {
            Delete("/api/todo-item/{id}");
            AllowAnonymous();
        }

        public override async Task HandleAsync(DeleteItemRequest req, CancellationToken ct)
        {

            // Trova l'item da aggiornare
            Todoitem item = await dbContext.Items.Include(x => x.Todolist).FirstOrDefaultAsync(x => x.Id == req.id);

            //var item = await dbContext.Items.FirstOrDefaultAsync(x => x.Id == req.Id);
            //var list = await dbContext.Lists.FindAsync(item.ListaId);


            if (item == null)
            {
                await SendNotFoundAsync(ct);
            }

            var todolist = item.Todolist;

            // Rimuovi l'item dalla lista
            todolist.RemoveToDoItem(item);

            // Rimuovi l'item dal database
            dbContext.Items.Remove(item);


            // Salva le modifiche dell'eliminazione dell'item nel database
            await dbContext.SaveChangesAsync(ct);

            // Ricarica gli elementi della lista dal database
            await dbContext.Entry(todolist).Collection(x => x.Items).LoadAsync(ct);

            // Controlla se tutti gli item rimanenti nella lista sono completati
            todolist.CheckAllItemsDone();

            // Salva le modifiche della lista nel database
            await dbContext.SaveChangesAsync(ct);

            // Return a response
            await SendNoContentAsync(cancellation: ct);
        }
          
       
    }
}


  