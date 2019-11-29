using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AppTesteUnit.Tests
{
    [TestClass]
    public class SaldoHelperTest
    {
        public SaldoHelperTest()    // Irá executar antes de "Cada Método de Teste"
        {            
        }

        [TestInitialize]
        public void Inicializar()   // Executa na inicialização da ClasseTest
        {
            
        }

        [TestMethod]
        public void AdicionarAcrescimo()
        {
            decimal Valor = 100M;
            decimal Porcent = 30;
            
            decimal Result = MVC.Helpers.SaldoHelper.AdicionarAcrescimo(Valor,Porcent);

            Assert.AreEqual(130,Result);   //if(result != 130M) Assert.Fail(); 
            //Assert.Fail();       
        }


        [TestMethod]
        public void ChecarValorAcimaLimite()
        {
            decimal Valor = 150M;
            decimal Limite = 100M;

            bool Result = MVC.Helpers.SaldoHelper.ChecarValorAcimaLimite(Valor,Limite);
              
            Assert.IsTrue(Result);          
        } 

        [TestMethod]
        public void ChecarValorAcimaLimite_QuandoAbaixo()
        {
            decimal Valor = 50M;
            decimal Limite = 100M;
            
            bool Result = MVC.Helpers.SaldoHelper.ChecarValorAcimaLimite(Valor,Limite);

            Assert.AreEqual(false,Result);            
        }



        // [DataTestMethod]
        // [DataRow("100","30","130")] // Apenas primitivos
        // [DataRow("100","50","150")]
        // [DataRow("100","100","200")]
        // //[DataRow("100","-30","80")]
        // public void AdicionarAcrescimo(string valor, string porcent, string resultSucess)
        // {
        //     decimal Valor = Convert.ToDecimal(valor);
        //     decimal Porcent = Convert.ToDecimal(porcent);

        //     decimal ResultMethod = MVC.Helpers.SaldoHelper.AdicionarAcrescimo(Valor,Porcent);

        //     Assert.AreEqual(Convert.ToDecimal(resultSucess),ResultMethod);    
        // }



        //[TestInitialize]    // Executa ao inciar

        //[TestCleanup]       // Executa por último

    }
}
