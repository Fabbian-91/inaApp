using inaApp.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inaApp.Common.Interfaces
{
    public interface IProductoRepository
    {
        //Metodo Task para indicar que son asincronicos, terminación en Async para indicar que es asicronico
        Task<List<Producto>> ObtenerTodoAsync();

        Task<Producto> ObtenerPorIdAsync(int id);

        Task<Producto> CrearAsync(Producto producto);

        Task<Producto> ActualizarAsync(Producto producto);

        Task<bool> EliminarAsync(int id);
    }
}
