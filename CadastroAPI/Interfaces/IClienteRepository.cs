using Microsoft.AspNetCore.Mvc;
using System;

namespace CadastroAPI.Interfaces
{
    public interface IClienteRepository
    {
        JsonResult GetAll();
        JsonResult PostAll(string nome, string cpf, DateTime datanasc, string telefoneum, string telefonedois);
        JsonResult PutAll(int id, string nome, string cpf, DateTime datanasc, string telefoneum, string telefonedois);
        JsonResult DeleteAll(string cpf);
    }
}
