using FastEndpoints;
using shared.Models.ToDoItems;
using shared.Domain.Entities;
//using webapi.Domain.Infrastructure.Data;
using webapi.Features.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;


namespace webapi.Features.TodoItem.UpdateTodoitem
{
    public class Endpoint(ApplicationDbContext dbContext) : Endpoint<UpdateItemRequest, UpdateItemResponse>
    {
        public override void Configure()
        {
            Put("/api/todo-item/{id}");
            AllowAnonymous();
        }

        

        public override async Task HandleAsync(UpdateItemRequest req, CancellationToken ct)
        {
            // Trova l'item da aggiornare
            var item = await dbContext.Items.Include(x => x.Todolist).FirstOrDefaultAsync(x => x.Id == req.id, ct);

            if (item == null)
            {
                await SendNotFoundAsync(ct);
            }

            // Aggiorna le proprietà dell'item
            item.Update(req.title, req.isdone);

            // Salva le modifiche dell'item nel database prima di controllare lo stato della lista
            await dbContext.SaveChangesAsync(ct);

            // Ricarica gli elementi della lista dal database
            await dbContext.Entry(item.Todolist).Collection(x => x.Items).LoadAsync(ct);

            // Controlla se tutti gli item nella lista sono completati
            item.Todolist.CheckAllItemsDone();

            // Salva le modifiche nel database
            await dbContext.SaveChangesAsync(ct);

            // Invia una risposta di successo
            await SendOkAsync(ct);
        }
    }
}




//public override async Task HandleAsync(UpdateItemRequest req, CancellationToken ct)
//{
//    var item = await dbContext.Items.FirstOrDefaultAsync(x => x.Id == req.id);

//    if (item == null)
//    {
//        await SendNotFoundAsync(ct);

//    }

//    var list = await dbContext.Lists.FindAsync(item.ListaId);

//    if (list == null)
//    {
//        await SendNotFoundAsync(ct);
//    }

//    item.Text = req.title;
//    item.IsDone = req.isdone;

//    item.Update(req.title, req.isdone);

//    dbContext.Items.Update(item);
//    // controllo sui check prima di salvare
//    list.CheckAllItemsDone();
//    await dbContext.SaveChangesAsync(ct);

//    await SendOkAsync(new UpdateItemResponse(item.Text, item.IsDone), cancellation: ct);
//}



