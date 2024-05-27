using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shared.Models.ToDoItems
{
    public record UpdateItemResponse(string title, bool isdone);

    public record UpdateItemRequest(Guid id, string title, bool isdone);
}
