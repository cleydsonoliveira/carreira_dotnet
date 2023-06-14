using Microsoft.EntityFrameworkCore;
using SistemaDeTarefas.Data;
using SistemaDeTarefas.Models;
using SistemaDeTarefas.Repositorios.Interfaces;

namespace SistemaDeTarefas.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly SistemaDeTarefasDBContext _sistemaDeTarefasDBContext;
        public UsuarioRepositorio(SistemaDeTarefasDBContext sistemaDeTarefasDBContext)
        {
            _sistemaDeTarefasDBContext = sistemaDeTarefasDBContext;
        }
        public async Task<List<UsuarioModel>> BuscarTodosUsuarios()
        {
            return await _sistemaDeTarefasDBContext.Usuarios.ToListAsync();
        }

        public async Task<UsuarioModel> BuscarPorId(int id)
        {
            return await _sistemaDeTarefasDBContext.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<UsuarioModel> Adicionar(UsuarioModel usuario)
        {
            await _sistemaDeTarefasDBContext.Usuarios.AddAsync(usuario);
            await _sistemaDeTarefasDBContext.SaveChangesAsync();
            return (usuario);
        }

        public async Task<UsuarioModel> Atualizar(UsuarioModel usuario, int id)
        {
            UsuarioModel usuarioPorId = await BuscarPorId(id);
            if (usuarioPorId == null)
            {
                throw new Exception($"Usuario para o id {id} não foi encontrado");
            }
            usuarioPorId.Nome = usuario.Nome;
            usuarioPorId.Email = usuario.Email;

            _sistemaDeTarefasDBContext.Usuarios.Update(usuarioPorId);
            await _sistemaDeTarefasDBContext.SaveChangesAsync();

            return (usuarioPorId);
        }
        public async Task<bool> Apagar(int id)
        {
            UsuarioModel usuarioPorId = await BuscarPorId(id);
            if (usuarioPorId == null)
            {
                throw new Exception($"Usuario para o id {id} não foi encontrado");
            }

            _sistemaDeTarefasDBContext.Usuarios.Remove(usuarioPorId);
            await _sistemaDeTarefasDBContext.SaveChangesAsync();

            return true;
        }
    }
}
