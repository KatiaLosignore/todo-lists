
using shared.Domain.Entities;

namespace shared.Models.ToDoLists
{

    public record ByIdResponse(Guid id, string text, bool isdone, List<Todoitem> items);

    public record ByIdRequest(Guid id);

}
