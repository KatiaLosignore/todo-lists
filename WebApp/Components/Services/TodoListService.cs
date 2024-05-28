using shared.Domain.Entities;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;


namespace WebApp.Components.Services
{
    
    public class TodoListService
    {
        //private readonly HttpClient _httpClient;

        //public TodoService(HttpClient httpClient)
        //{
        //    _httpClient = httpClient;
        //}

        //public async Task<List<Todolist>> GetTodoListsAsync()
        //{
        //    return await _httpClient.GetFromJsonAsync<List<Todolist>>("api/todo");
        //}

        public async Task<List<shared.Models.ToDoLists.AllResponse>> ListAllModelAsync(HttpClient httpClient)
        => await httpClient.GetFromJsonAsync<List<shared.Models.ToDoLists.AllResponse>>("https://localhost:7104/api/todo-list/") ?? [];



    }

}
