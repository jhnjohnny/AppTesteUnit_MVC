using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AppTesteUnit.MVC.Data;
using AppTesteUnit.MVC.Models;
using Microsoft.EntityFrameworkCore;

namespace AppTesteUnit.MVC.Repository
{
    public class Usuarios : IUsuarios
    {
        private AppTesteUnitDbContext _context;

        public Usuarios(AppTesteUnitDbContext context)
        {
            _context = context;
        }


        public async Task InserirListaUsers()
        {
            if (!await _context.Usuario.AnyAsync())
            {
                // ADICIONAR USUÁRIOS
                List<UsuarioModel> usuarioList = new List<UsuarioModel>()
                {
                    new UsuarioModel(){ Nome="Teste1", DataCriacao=DateTime.Now, Saldo = 20.5M},
                    new UsuarioModel(){ Nome="Teste2", DataCriacao=DateTime.Now.AddDays(-1), Saldo = 50M},
                    new UsuarioModel(){ Nome="Teste3", DataCriacao=DateTime.Now.AddHours(-5), Saldo = 30.55M},
                    new UsuarioModel(){ Nome="Teste4", DataCriacao=DateTime.Now.AddMinutes(-20), Saldo = 75.5M},
                    new UsuarioModel(){ Nome="Teste5", DataCriacao=DateTime.Now.AddMonths(-2), Saldo = 140M}
                };

                foreach (var usuarioAdd in usuarioList)
                {
                    _context.Add(usuarioAdd);
                }

                await _context.SaveChangesAsync();
            }
        }


        public async Task InserirUser(UsuarioModel usuario)
        {
            if (String.IsNullOrEmpty(usuario.Nome))
            {
                throw new ArgumentException();
            }

            var usuarioAdd = new UsuarioModel();

            // usuarioList.Nome = "TesteADD_InMemory";
            // usuarioList.DataCriacao = Convert.ToDateTime("01/01/2019");
            // usuarioList.Saldo = 20.5M;
            usuarioAdd.Nome = usuario.Nome;
            usuarioAdd.DataCriacao = usuario.DataCriacao;
            usuarioAdd.Saldo = usuario.Saldo;

            _context.Add(usuarioAdd);

            await _context.SaveChangesAsync();
        }


        public async Task<List<UsuarioModel>> CarregarListaUsers()
        {
            return await _context.Usuario.ToListAsync();
        }

        public async Task<UsuarioModel> CarregarUserNome(String nome)
        {
            return await _context.Usuario.FirstOrDefaultAsync(u => u.Nome == nome);
        }


    }
}