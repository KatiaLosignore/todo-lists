

namespace shared.Models.ToDoLists
{

    public record UpdateResponse(string title);

    public record UpdateRequest(Guid id, string title);

}
