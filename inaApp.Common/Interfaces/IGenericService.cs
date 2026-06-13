using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inaApp.Common.Interfaces
{
    public interface IGenericService<TResponse,TCreate,TUpdate>
    {
        //Firmas de los metodos
        Task<List<TResponse>> obtenerTodosAsync();//Task xq son metodos asincronicos

        Task<TResponse> ObtenerPorIdAsync(int id);

        Task<TResponse> CrearAsync(TCreate entity);

        Task<TResponse> ActualizarAsync(int id,TUpdate entity);

        Task<bool> EliminarAsync(int id);
    }
}
