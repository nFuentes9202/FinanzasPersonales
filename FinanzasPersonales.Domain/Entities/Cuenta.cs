using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanzasPersonales.Domain.Entities
{
    public class Cuenta
    {
        public int CuentaID { get; private set; } 
        public string Nombre { get; private set; }
        public decimal Saldo { get; private set; }
        public string Moneda { get; private set; }

        // Constructor
        public Cuenta(int cuentaID, string nombre, decimal saldoInicial, string moneda)
        {
            CuentaID = cuentaID;
            Nombre = nombre;
            Saldo = saldoInicial;
            Moneda = moneda;
        }

        // Método para actualizar el saldo
        public void ActualizarSaldo(decimal monto)
        {
            Saldo += monto;
        }

        // Método para asignar un nuevo nombre
        public void AsignarNombre(string nombre)
        {
            Nombre = nombre;
        }
    }

}
