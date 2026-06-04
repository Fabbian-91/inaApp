using inaApp.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inaApp.Common.Interfaces
{
    public interface IGenericService<E>
    {
        //Firmas de los metodos
        Task<List<E>> obtenerTodosAsync();

        Task<E> ObtenerPorIdAsync(int id);

        Task<E> CrearAsync(E entidad);

        Task<E> ActualizarAsync(E entidad);

        Task<bool> EliminarAsync(int id);
    }
}
