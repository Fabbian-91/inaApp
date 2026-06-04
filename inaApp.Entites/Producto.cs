using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inaApp.Entites
{

    //Niveles accesos
    //public: cualquier clase puede acceder a este miembro
    //private: solo la clase que lo define puede acceder a este miembro
    //protected: solo la clase que lo define y las clases derivadas pueden acceder a este miembro
    //internal: solo las clases dentro del mismo ensamblado pueden acceder a este miembro
    public class Producto
    {
        //Propiedades de la clase
        public int Id { get;}

        public string Nombre { get; set; }
        
        public decimal Precio { get; set; }

        public int Stock { get; set; }

        public string Descripcion { get; set; }

        public bool Estado { get; set; }
    }
}
