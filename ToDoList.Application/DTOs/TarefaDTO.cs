namespace ToDoList.Application.DTOs
{
    public class TarefaDTO
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string? Descricao { get; set; }
        public bool Concluida { get; set; }
        public int TagId { get; set; }
    }
}
