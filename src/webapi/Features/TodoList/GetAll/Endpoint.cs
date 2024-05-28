using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using shared.Domain.Entities;
using AutoMapper;
using shared.Models.ToDoLists;
using webapi.Features.Infrastructure.Data;


namespace webapi.Features.TodoList.GetAll
{
    public class Endpoint : Endpoint<AllRequest, IEnumerable<AllResponse>>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly AutoMapper.IMapper _mapper;

        public Endpoint(ApplicationDbContext dbContext, AutoMapper.IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public override void Configure()
        {
            Get("/api/todo-lists");
            AllowAnonymous();
        }



        public override async Task HandleAsync(AllRequest req, CancellationToken ct)
        {
         
            var query = _dbContext.Lists.Include(x => x.Items).AsQueryable();

            var paginatedItems = await query
                .Skip((req.PageIndex - 1) * req.PageSize)
                .Take(req.PageSize)
                .ToListAsync(ct);

            var response = _mapper.Map<IEnumerable<AllResponse>>(paginatedItems);

            await SendAsync(response);
        }



        //public override async Task HandleAsync(EmptyRequest req, CancellationToken ct)
        //{
        //    List<Todolist> lists = await dbContext.Lists.ToListAsync();
        //    List<string> titles = new();

        //    lists.ForEach(o =>
        //    {
        //        titles.Add(o.Title);
        //    });

        //    await SendAsync(new Response(titles));

        //}

    }
}



