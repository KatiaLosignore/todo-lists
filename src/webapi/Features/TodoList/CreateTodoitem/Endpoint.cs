using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using shared.Models.ToDoLists;
using shared.Domain.Entities;
//using webapi.Domain.Infrastructure.Data;
using webapi.Features.Infrastructure.Data;

namespace webapi.Features.TodoList.CreateTodoitem
{
    public class Endpoint (ApplicationDbContext dbContext) : Endpoint<CreateToDoItemModelRequest, CreateToDoItemModelResponse>
    {

        public override void Configure()
        {
            Post("/api/-todo-list/{toDoListId}/todo-item");
            AllowAnonymous();
        }


        public override async Task HandleAsync(CreateToDoItemModelRequest req, CancellationToken ct)
        {
            Todolist? toDoList = await dbContext.Lists.Include(x => x.Items).FirstOrDefaultAsync(x => x.Id == req.ListaId);

            if (toDoList == null)
            {
                await SendNoContentAsync(ct);
            }
            

            Todoitem toDoItemId = toDoList.AddToDoItem(req.text);

            await dbContext.Items.AddAsync(toDoItemId, ct);

            //toDoItem.CreatedBy = "Katia";
            //toDoItem.Created = DateTime.UtcNow;
            //dbContext.Attach(toDoList.Items);
            await dbContext.SaveChangesAsync(ct);

            // Aggiorna lo stato della lista
            toDoList.CheckAllItemsDone();

            // Salvataggio dei dati nel db
            await dbContext.SaveChangesAsync(ct);


            await SendAsync(new CreateToDoItemModelResponse(toDoItemId.Id), cancellation: ct);
         

        }



    }
}
