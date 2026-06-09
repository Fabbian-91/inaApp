using inaApp.Common.Interfaces;
using inaApp.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inaApp.Services
{
    public class ClienteService : IGenericService<Cliente>
    {
        //Inyección de dependeciaas
        private readonly IGenericRepository<Cliente> _clienteRepo;

        public ClienteService(IGenericRepository<Cliente> clienteRepo)
        {
            this._clienteRepo = clienteRepo;  
        }

        public Task<Cliente> ActualizarAsync(int id, Cliente entity)
        {
            throw new NotImplementedException();
        }

        public Task<Cliente> CrearAsync(Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public Task<bool> EliminarAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Cliente> ObtenerPorIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Cliente>> obtenerTodosAsync()
        {
            //Viajar a la capa repository
            return await _clienteRepo.obtenerTodosAsync();
        }
    }
}
