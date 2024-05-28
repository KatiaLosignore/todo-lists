
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Threading.Tasks;




namespace WebApp.Components.Services
{
    
    public class TodoListService
    {
       
        public async Task<List<shared.Models.ToDoLists.AllResponse>> ListAllModelAsync(HttpClient httpClient)
        => await httpClient.GetFromJsonAsync<List<shared.Models.ToDoLists.AllResponse>>("https://localhost:7104/api/todo-lists") ?? [];



    }

}
