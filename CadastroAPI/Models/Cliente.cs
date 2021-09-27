using System;

namespace CadastroAPI.Models
{
    public class Cliente
    {
        public int id { get; set; }
        public string nome { get; set; }
        public int cpf { get; set; }
        public int idade { get; set; }
        public DateTime datanasc { get; set; }
        public string telefone { get; set; }



    }
}
