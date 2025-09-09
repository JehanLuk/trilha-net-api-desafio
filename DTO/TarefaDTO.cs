using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TrilhaApiDesafio.Models;

namespace TrilhaApiDesafio.DTO;

public class TarefaDTO
{
    [Required(ErrorMessage = "A tarefa necessita de um título!")]
    [StringLength(255)]
    public string Titulo { get; set; } = default!;

    [Column(TypeName = "text")]
    public string Descricao { get; set; } = default!;

    public DateTime Data { get; set; } = DateTime.UtcNow;

    public EnumStatusTarefa Status { get; set; } = EnumStatusTarefa.Pendente;
}