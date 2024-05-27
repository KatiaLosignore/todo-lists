using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shared.Models.ToDoLists
{
    public record CreateToDoItemModelRequest(string text, Guid ListaId);
    public record CreateToDoItemModelResponse(Guid id);

}
