using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using shared.Models.ToDoLists;
using shared.Domain.Entities;
using webapi.Features.Infrastructure.Data;

namespace webapi.Features.TodoList.DeleteTodolist
{
    public class Endpoint (ApplicationDbContext dbContext) : Endpoint<DeleteRequest, EmptyResponse>
    {
        public override void Configure()
        {
            Delete("/api/todo-lists/{id}");
            AllowAnonymous();
        }


        public override async Task HandleAsync(DeleteRequest req, CancellationToken ct)
        {
            Todolist list = await dbContext.Lists.FindAsync(req.Id);

            if (list == null)
            {
                await SendNotFoundAsync(ct);
                return;
            }

            dbContext.Remove(list);
            await dbContext.SaveChangesAsync();

            // Return a response
            await SendNoContentAsync(cancellation: ct);
        }
    }
}
