using Microsoft.Extensions.Configuration;

namespace CadastroAPI.Repositories
{
    public class BaseRepository
    {

        private readonly IConfiguration _clientRepository;

        public BaseRepository(IConfiguration configuration)
        {
            _clientRepository = configuration;
        }


        protected string Con
        {
            get
            {
                return _clientRepository.GetConnectionString("tablecadastro");
            }
        }









    }
}
