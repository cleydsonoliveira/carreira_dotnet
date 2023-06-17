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


public static class TarefaModelEndpoints
{
	public static void MapTarefaModelEndpoints (this IEndpointRouteBuilder routes)
    {
        routes.MapGet("/api/TarefaModel", () =>
        {
            return new [] { new TarefaModel() };
        })
        .WithName("GetAllTarefaModels")
        .Produces<TarefaModel[]>(StatusCodes.Status200OK);

        routes.MapGet("/api/TarefaModel/{id}", (int id) =>
        {
            //return new TarefaModel { ID = id };
        })
        .WithName("GetTarefaModelById")
        .Produces<TarefaModel>(StatusCodes.Status200OK);

        routes.MapPut("/api/TarefaModel/{id}", (int id, TarefaModel input) =>
        {
            return Results.NoContent();
        })
        .WithName("UpdateTarefaModel")
        .Produces(StatusCodes.Status204NoContent);

        routes.MapPost("/api/TarefaModel/", (TarefaModel model) =>
        {
            //return Results.Created($"//api/TarefaModels/{model.ID}", model);
        })
        .WithName("CreateTarefaModel")
        .Produces<TarefaModel>(StatusCodes.Status201Created);

        routes.MapDelete("/api/TarefaModel/{id}", (int id) =>
        {
            //return Results.Ok(new TarefaModel { ID = id });
        })
        .WithName("DeleteTarefaModel")
        .Produces<TarefaModel>(StatusCodes.Status200OK);
    }
}}
