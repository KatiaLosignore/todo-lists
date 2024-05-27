using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using shared.Models.ToDoLists;
using webapi.Features.Infrastructure.Data;

namespace webapi.Features.TodoList.GetById
{
    public class Endpoint(ApplicationDbContext dbContext) : Endpoint<ByIdRequest, ByIdResponse>
    {
        public override void Configure()
        {
            Get("/api/todo-list/{id}");
            AllowAnonymous();
        }

        public override async Task HandleAsync(ByIdRequest req, CancellationToken ct)
        {

            var todolist = await dbContext.Lists.Include(x => x.Items).FirstOrDefaultAsync(x => x.Id == req.id);

            if (todolist == null)
            {
                await SendNotFoundAsync(ct);
              
            }

            // Return a response
            await SendAsync(new ByIdResponse(todolist.Id, todolist.Title, todolist.IsDone, todolist.Items), cancellation: ct);

        }
    }
}
