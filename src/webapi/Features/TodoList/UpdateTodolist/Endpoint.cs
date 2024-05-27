using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using shared.Domain.Entities;
using shared.Models.ToDoLists;
using webapi.Features.Infrastructure.Data;

namespace webapi.Features.TodoList.UpdateTodolist
{
    public class Endpoint(ApplicationDbContext dbContext) : Endpoint<UpdateRequest, UpdateResponse>
    {
        public override void Configure()
        {
            Put("/api/todo-list/{id}");
            AllowAnonymous();
        }

        public override async Task HandleAsync(UpdateRequest req, CancellationToken ct)
        {
            Todolist list = await dbContext.Lists.Include(x => x.Items).FirstOrDefaultAsync(x => x.Id == req.id);

            if (list == null)
            {
                await SendNotFoundAsync(ct);
                return;
            }

            list.Title = req.title;

            dbContext.Lists.Update(list);
      
            await dbContext.SaveChangesAsync(ct);

            await SendAsync(new UpdateResponse(list.Title), cancellation: ct);
        }
    }


    
}


