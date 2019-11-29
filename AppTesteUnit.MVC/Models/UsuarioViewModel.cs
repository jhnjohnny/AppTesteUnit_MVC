using System;

namespace AppTesteUnit.MVC.Models
{
    public class UsuarioViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataCriacao { get; set; }
        public decimal Saldo { get; set; }
        public bool AcimaLimite { get; set; }
    }
    
}