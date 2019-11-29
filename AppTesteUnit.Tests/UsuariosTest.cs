
using AppTesteUnit.MVC.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AppTesteUnit.MVC.Repository;
using Moq;
using System;
using AppTesteUnit.MVC.Models;
using Bogus;
using System.Threading.Tasks;

namespace AppTesteUnit.Tests.UsuariosTests
{
    [TestClass]
    public class UsuariosTests
    {
        private UsuarioModel _usuarioModel;
        private UsuariosContext _usuariosContext;   // Para simular o 'Banco de Dados'
        private Mock<IUsuarios> _usuariosMock;      // Simula a Classe de 'Ações'

        private static Mock<AppTesteUnitDbContext> _context; 


        // CONSTRUTOR (Irá executar antes de "Cada Método de Teste")
        public UsuariosTests()
        {
            Faker fake = new Faker();

            _usuarioModel = new UsuarioModel
            {
                Id = fake.Random.Int(),
                Nome = fake.Random.Words(),
                DataCriacao = fake.Date.Past(),
                Saldo = fake.Random.Decimal(1,1000)
            };

            _usuariosMock = new Mock<IUsuarios>();            
            _usuariosContext = new UsuariosContext(_usuariosMock.Object);
            _context = new Mock<AppTesteUnitDbContext>();
        }


        //MÉTODOS TESTES
        [TestMethod]
        public void AdicionarNovoUsuario()
        {
            _usuariosContext.InserirUserTest(_usuarioModel);

            _usuariosMock.Verify(r => r.InserirUser(
                It.Is<UsuarioModel>(u =>
                u.Nome == _usuarioModel.Nome &&
                u.DataCriacao == _usuarioModel.DataCriacao &&
                u.Saldo == _usuarioModel.Saldo)
            ));
        }

        [DataTestMethod]
        [DataRow("")]   // Apenas primitivos
        [DataRow(null)]
        public void AdicionarNovoUsuarioNomeInvalido(String nomeInvalido)
        {
            _usuarioModel.Nome = nomeInvalido;
            _usuariosContext.InserirUserTest(_usuarioModel);

            //Assert.ThrowsException<ArgumentException>(() => new UsuarioModel());
        }

        [TestMethod]
        public void ChecarUsuarioComMesmoNome()
        {
            var usuarioJaSalvo = _usuariosContext.CarregarUserNomeTest(_usuarioModel.Nome);
            _usuariosMock.Setup(r => r.CarregarUserNome(_usuarioModel.Nome)).Returns(usuarioJaSalvo);
        }


        // CONTEXTO
        public class UsuariosContext
        {
            private readonly IUsuarios _usuarios;

            public UsuariosContext(IUsuarios usuarios) => _usuarios = usuarios;

            public void InserirUserTest(UsuarioModel usuarioModel)
            {
                var usuario = new UsuarioModel();

                usuario.Id = usuarioModel.Id;
                usuario.Nome = usuarioModel.Nome;
                usuario.DataCriacao = usuarioModel.DataCriacao;
                usuario.Saldo = usuarioModel.Saldo;

                _usuarios.InserirUser(usuario);
                //var usuarios = new Usuarios(_context.Object);
                //await usuarios.InserirUser(usuario);
                
            }

            public async Task<UsuarioModel> CarregarUserNomeTest(String nome)
            {
                return await _usuarios.CarregarUserNome(nome);
            }
        }


    }


}