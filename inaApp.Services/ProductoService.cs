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

        public async Task<Producto> ActualizarAsync(int id,Producto entity)
        {
            return await _producRepository.ActualizarAsync(id,entity);
        }

        public async Task<Producto> CrearAsync(Producto entity)
        {
            return await _producRepository.CrearAsync(entity);
        }

        public async Task<bool> EliminarAsync(int id)
        {
            return await _producRepository.EliminarAsync(id);
        }

        public async Task<Producto> ObtenerPorIdAsync(int id)
        {
            return await _producRepository.ObtenerPorIdAsync(id);
        }

        public async Task<List<Producto>> obtenerTodosAsync()
        {
            return await _producRepository.obtenerTodosAsync();
        }
    }
}
