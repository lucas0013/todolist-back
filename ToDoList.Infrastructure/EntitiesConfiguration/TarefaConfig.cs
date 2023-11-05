using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDoList.Domain.Entities;

namespace ToDoList.Infrastructure.EntitiesConfiguration
{
    public class TarefaConfig : IEntityTypeConfiguration<Tarefa>
    {
        public void Configure(EntityTypeBuilder<Tarefa> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Titulo).IsRequired();
            builder.Property(t => t.Descricao);
            builder.Property(t => t.Concluida).IsRequired();
            builder.Property(t => t.TagId);

            builder.HasOne(t => t.Tag);
        }
    }
}
