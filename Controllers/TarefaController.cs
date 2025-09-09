using Microsoft.AspNetCore.Mvc;
using TrilhaApiDesafio.Context;
using TrilhaApiDesafio.Models;
using TrilhaApiDesafio.DTO;
using Microsoft.EntityFrameworkCore;

namespace TrilhaApiDesafio.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TarefaController : ControllerBase
    {
        private readonly OrganizadorContext _context;

        public TarefaController(OrganizadorContext context)
        {
            _context = context;
        }

        [HttpGet("ObterId/{id:int}")]
        public async Task<IActionResult> ObterPorId(int id)
        {
            // TODO: Buscar o Id no banco utilizando o EF
            // TODO: Validar o tipo de retorno. Se não encontrar a tarefa, retornar NotFound,
            // caso contrário retornar OK com a tarefa encontrada

            var tarefa = await _context.Tarefas.FindAsync(id);
            if (tarefa == null) return NotFound();
            return Ok(tarefa);
        }

        [HttpGet("ObterTodos")]
        public async Task<IActionResult> ObterTodos()
        {
            // TODO: Buscar todas as tarefas no banco utilizando o EF

            var tarefas = await _context.Tarefas.ToListAsync();
            return Ok(tarefas);
        }

        [HttpGet("ObterPorTitulo")]
        public async Task<IActionResult> ObterPorTitulo(string titulo)
        {
            // TODO: Buscar  as tarefas no banco utilizando o EF, que contenha o titulo recebido por parâmetro
            // Dica: Usar como exemplo o endpoint ObterPorData

            var tarefas = await _context.Tarefas
                .Where(x => x.Titulo.Contains(titulo))
                .ToListAsync();
            return Ok(tarefas);
        }

        [HttpGet("ObterPorData")]
        public async Task<IActionResult> ObterPorData(DateTime data)
        {
            var tarefa = await _context.Tarefas
                .Where(x => x.Data.Date == data.Date)
                .ToListAsync();
            return Ok(tarefa);
        }

        [HttpGet("ObterPorStatus")]
        public async Task<IActionResult> ObterPorStatus(EnumStatusTarefa status)
        {
            // TODO: Buscar  as tarefas no banco utilizando o EF, que contenha o status recebido por parâmetro
            // Dica: Usar como exemplo o endpoint ObterPorData

            var tarefa = await _context.Tarefas
                .Where(x => x.Status == status)
                .ToListAsync();
            return Ok(tarefa);
        }

        [HttpPost("CriarTarefa")]
        public async Task<IActionResult> Criar([FromBody] TarefaDTO dto)
        {
            var tarefa = new Tarefa
            {
                Titulo = dto.Titulo,
                Descricao = dto.Descricao,
                Status = dto.Status,
                Data = dto.Data
            };

            if (tarefa.Data == DateTime.MinValue)
            return BadRequest(new { Erro = "A data da tarefa não pode ser vazia" });

            // TODO: Adicionar a tarefa recebida no EF e salvar as mudanças (save changes)

            _context.Tarefas.Add(tarefa);

            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(ObterPorId), new { id = tarefa.Id }, tarefa);
        }

        [HttpPut("AtualizarTarefa{id}")]
        public async Task<IActionResult> Atualizar(int id, [FromBody] TarefaDTO dto)
        {
            var tarefaBanco = await _context.Tarefas.FindAsync(id);

            if (tarefaBanco == null)
                return NotFound();

            if (dto.Data == DateTime.MinValue)
                return BadRequest(new { Erro = "A data da tarefa não pode ser vazia" });

            tarefaBanco.Titulo = dto.Titulo;
            tarefaBanco.Descricao = dto.Descricao;
            tarefaBanco.Status = dto.Status;
            tarefaBanco.Data = dto.Data;
            
            // TODO: Atualizar as informações da variável tarefaBanco com a tarefa recebida via parâmetro
            // TODO: Atualizar a variável tarefaBanco no EF e salvar as mudanças (save changes)

        await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("DeletarId/{id}")]
        public async Task<IActionResult> Deletar(int id)
        {
            var tarefaBanco = await _context.Tarefas.FindAsync(id);

            if (tarefaBanco == null)
                return NotFound();

            // TODO: Remover a tarefa encontrada através do EF e salvar as mudanças (save changes)

            _context.Tarefas.Remove(tarefaBanco);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
