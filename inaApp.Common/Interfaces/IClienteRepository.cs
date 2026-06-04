using inaApp.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inaApp.Common.Interfaces
{
    //Interfaz para interactuar con la bd
    public interface IClienteRepository
    {
        //Firmas de los metodos
        Task<List<Cliente>> obtenerTodosAsync();

        Task<Cliente> ObtenerPorIdAsync(int id);

        Task<Cliente> CrearAsync(Cliente cliente);

        Task<Cliente> ActualizarAsync(Cliente cliente);

        Task<bool> EliminarAsync(int id);
    }
}
