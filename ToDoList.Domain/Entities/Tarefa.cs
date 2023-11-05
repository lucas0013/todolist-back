using ToDoList.Domain.Entities.@base;

namespace ToDoList.Domain.Entities;
public class Tarefa : Entity
{
    public string Titulo { get; set; } = string.Empty;
    public string? Descricao { get; set; }
    public bool Concluida { get; set; }

    public int? TagId { get; set; }
    public Tag? Tag { get; set; }
}
