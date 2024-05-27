using FastEndpoints;
using Microsoft.AspNetCore.Authorization;
using shared.Domain.Entities;
//using webapi.Domain.Infrastructure.Data;
using shared.Models.ToDoLists;
using webapi.Features.Infrastructure.Data;

namespace webapi.Features.TodoList.CreateTodolist
{
    public class Endpoint(ApplicationDbContext dbContext) : Endpoint<CreateRequest, CreateResponse>
    {
    
        public override void Configure()
        {
            Post("/api/todo-lists");
            AllowAnonymous();
        }

        public override async Task HandleAsync(CreateRequest req, CancellationToken ct)
        {
            var todolist = Todolist.Create(req.Title);
            todolist.CreatedBy = "Katia";
            todolist.Created = DateTime.UtcNow;
            await dbContext.Lists.AddAsync(todolist, ct);
            await dbContext.SaveChangesAsync(ct);

            await SendAsync(new CreateResponse(todolist.Id));
        }

    }
        
}
