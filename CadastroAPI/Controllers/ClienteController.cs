using CadastroAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CadastroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {

        private readonly ClientService _clientService;

        public ClienteController(ClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpGet]
        public JsonResult Get()
        {
            return _clientService.GetJsonResult();

        }

        [HttpPost]
        public JsonResult Post(string nome, string cpf, DateTime datanasc, string telefoneum, string telefonedois)
        {

            return _clientService.PostJsonResult(nome, cpf, datanasc, telefoneum,telefonedois);

        }

        [HttpPut]
        public JsonResult Put(int id, string nome, string cpf, DateTime datanasc, string telefoneum, string telefonedois)
        {
            return _clientService.PutJsonResult(id, nome, cpf, datanasc, telefoneum,telefonedois);

        }

        [HttpDelete("{id}")]
        public JsonResult Delete(string cpf)
        {
            return _clientService.DeleteJsonResult(cpf);

        }

    }
}
