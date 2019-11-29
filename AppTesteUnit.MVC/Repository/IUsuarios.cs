
using System.Collections.Generic;
using System.Threading.Tasks;
using AppTesteUnit.MVC.Data;
using AppTesteUnit.MVC.Models;

namespace AppTesteUnit.MVC.Repository
{
    public interface IUsuarios
    {
        Task InserirListaUsers();
        Task<List<UsuarioModel>> CarregarListaUsers();


        Task InserirUser(UsuarioModel usuario);
        Task<UsuarioModel> CarregarUserNome(string nome);
        
    }
}