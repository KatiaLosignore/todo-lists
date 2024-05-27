
using AutoMapper;
using shared.Domain.Entities;

namespace shared.Models.ToDoLists
{
    public record AllResponse(Guid Id, string Title);

    public record AllRequest(int PageSize = 10, int PageIndex = 1);


    public class ResponseProfile : Profile
    {
        public ResponseProfile()
        {
            CreateMap<Todolist, AllResponse>();
        }
    }
}
