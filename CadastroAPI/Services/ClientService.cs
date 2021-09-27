using CadastroAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CadastroAPI.Services
{
    public class ClientService
    {

        private readonly IClienteRepository _clienteRepository;

        public ClientService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public JsonResult GetJsonResult()
        {
            return _clienteRepository.GetAll();
        }

        public JsonResult PostJsonResult(string nome, string cpf, DateTime datanasc, string telefoneum,string telefonedois)
        {
            return _clienteRepository.PostAll(nome, cpf, datanasc, telefoneum, telefonedois);
        }

        public JsonResult PutJsonResult(int id, string nome, string cpf, DateTime datanasc, string telefoneum, string telefonedois)
        {
            return _clienteRepository.PutAll(id, nome, cpf, datanasc, telefoneum, telefonedois);
        }

        public JsonResult DeleteJsonResult(string cpf)
        {
            return _clienteRepository.DeleteAll(cpf);
        }

    }
}
