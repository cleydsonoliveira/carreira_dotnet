using Microsoft.EntityFrameworkCore;
using SistemaDeTarefas.Data;
using SistemaDeTarefas.Models;
using SistemaDeTarefas.Repositorios.Interfaces;

namespace SistemaDeTarefas.Repositorios
{
    public class TarefaRepositorio : ITarefaRepositorio
    {
        private readonly SistemaDeTarefasDBContext _sistemaDeTarefasDBContext;
        public TarefaRepositorio(SistemaDeTarefasDBContext sistemaDeTarefasDBContext)
        {
            _sistemaDeTarefasDBContext = sistemaDeTarefasDBContext;
        }

        public async Task<TarefaModel> BuscarPorId(int id)
        {
            return await _sistemaDeTarefasDBContext.Tarefas
                .Include(x => x.Usuario)
                .FirstOrDefaultAsync(X => X.Id == id);
        }

        public async Task<List<TarefaModel>> BuscarTodasTarefas()
        {
            return await _sistemaDeTarefasDBContext.Tarefas
                .Include(x => x.Usuario)
                .ToListAsync();
        }

        public async Task<TarefaModel> Adicionar(TarefaModel tarefa)
        {
            await _sistemaDeTarefasDBContext.Tarefas.AddAsync(tarefa);
            await _sistemaDeTarefasDBContext.SaveChangesAsync();
            return (tarefa);
        }

        public async Task<TarefaModel> Atualizar(TarefaModel tarefa, int id)
        {
            TarefaModel tarefaPorId = await BuscarPorId(id);
            if (tarefaPorId == null)
            {
                throw new Exception($"Tarefa com o id: {id} não foi encontrada");
            }
            tarefaPorId.Nome = tarefa.Nome;
            tarefaPorId.Status = tarefa.Status;
            tarefaPorId.Descricao = tarefa.Descricao;
            tarefaPorId.UsuarioId = tarefa.UsuarioId;

            _sistemaDeTarefasDBContext.Tarefas.Update(tarefaPorId);
            await _sistemaDeTarefasDBContext.SaveChangesAsync();
            return (tarefaPorId);
        }

        public async Task<bool> Apagar(int id)
        {
            TarefaModel tarefaPorId = await BuscarPorId(id);
            if (tarefaPorId == null)
            {
                throw new Exception($"Tarefa com o id: {id} não foi encontrada");
            }

            _sistemaDeTarefasDBContext.Tarefas.Remove(tarefaPorId);
            await _sistemaDeTarefasDBContext.SaveChangesAsync();

            return true;
        }
    }
}
