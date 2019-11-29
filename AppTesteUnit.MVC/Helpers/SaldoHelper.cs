namespace AppTesteUnit.MVC.Helpers
{
    public static class SaldoHelper
    {
        public static decimal AdicionarAcrescimo(decimal valor, decimal acrescimo)
        {
            decimal Calculo = (acrescimo / 100) * valor;
            
            return valor + Calculo;
        }

        public static bool ChecarValorAcimaLimite(decimal valor, decimal limite)
        {
            if(valor > limite)
                return true;
            else
                return false;
        }
    }
}