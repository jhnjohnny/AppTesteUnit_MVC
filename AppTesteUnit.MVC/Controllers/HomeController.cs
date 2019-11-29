using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AppTesteUnit.MVC.Models;
using AppTesteUnit.MVC.Repository;
using AppTesteUnit.MVC.Helpers;
using AppTesteUnit.MVC.Data;

namespace AppTesteUnit.MVC.Controllers
{
    public class HomeController : Controller
    {
        private decimal _PorcentoAcrescimo = 30;
        private decimal _LimiteValor = 60M;
        private readonly AppTesteUnitDbContext _context;

        public HomeController(AppTesteUnitDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            Usuarios usuarios = new Usuarios(_context);
            
            await usuarios.InserirListaUsers();
            var usersList = await usuarios.CarregarListaUsers();

            var userAcrescimoList = usersList.Select(u => new UsuarioViewModel()
            {
                Id = u.Id,
                Nome = u.Nome,
                DataCriacao = u.DataCriacao,
                Saldo = SaldoHelper.AdicionarAcrescimo(u.Saldo,_PorcentoAcrescimo),
                AcimaLimite = SaldoHelper.ChecarValorAcimaLimite(SaldoHelper.AdicionarAcrescimo(u.Saldo,_PorcentoAcrescimo),_LimiteValor)
            });

            return View(userAcrescimoList);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
