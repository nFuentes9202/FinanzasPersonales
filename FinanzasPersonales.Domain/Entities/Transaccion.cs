using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanzasPersonales.Domain.Entities
{
    public class Transaccion
    {
        public int TransaccionID { get; private set; } 
        public int CuentaID { get; private set; }       
        public decimal Monto { get; private set; }      
        public DateTime Fecha { get; private set; }     
        public int TipoTransaccionID { get; private set; } 
        public int CategoriaID { get; private set; }    
        public bool Anulado { get; private set; } = false; 

        // Constructor
        public Transaccion(int cuentaID, decimal monto, DateTime fecha, int tipoTransaccionID, int categoriaID)
        {
            CuentaID = cuentaID;
            Monto = monto;
            Fecha = fecha;
            TipoTransaccionID = tipoTransaccionID;
            CategoriaID = categoriaID;
        }

        // Método para anular una transacción
        public void Anular()
        {
            Anulado = true;
        }
    }
}
