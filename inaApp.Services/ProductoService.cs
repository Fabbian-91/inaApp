using inaApp.Common.Interfaces;
using inaApp.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inaApp.Services
{
    public class ProductoService : IGenericService<Producto>
    {

        //Implementar a inyección de dependecias

        private readonly IGenericRepository<Producto> _producRepository;

        public ProductoService(IGenericRepository<Producto> productRepo)
        {
            this._producRepository = productRepo;
        }

        public Task<Producto> ActualizarAsync(Producto entity)
        {
            throw new NotImplementedException();
        }

        public async Task<Producto> CrearAsync(Producto entity)
        {
            return await _producRepository.CrearAsync(entity);
        }

        public async Task<bool> EliminarAsync(int id)
        {
            return await _producRepository.EliminarAsync(id);
        }

        public Task<Producto> ObtenerPorIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Producto>> obtenerTodosAsync()
        {
            return await _producRepository.obtenerTodosAsync();
        }
    }
}
