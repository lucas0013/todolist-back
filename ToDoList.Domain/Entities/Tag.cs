using ToDoList.Domain.Entities.@base;

namespace ToDoList.Domain.Entities;

public class Tag : Entity
{
    public string Nome { get; set; } = string.Empty;
    public Tarefa[]? Tarefas { get; set; }
}