using FinanzasPersonales.Domain.Entities;
using FinanzasPersonales.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanzasPersonales.Domain.Services
{
    public class TransferenciaService
    {
        private readonly ICuentaRepository _cuentaRepository;
        private readonly ITransaccionRepository _transaccionRepository;

        // Constructor que inyecta los repositorios necesarios
        public TransferenciaService(ICuentaRepository cuentaRepository, ITransaccionRepository transaccionRepository)
        {
            _cuentaRepository = cuentaRepository;
            _transaccionRepository = transaccionRepository;
        }

        // Método de transferencia entre cuentas
        public void Transferir(int cuentaOrigenId, int cuentaDestinoId, decimal monto)
        {
            // Obtener las cuentas de origen y destino
            var cuentaOrigen = _cuentaRepository.ObtenerPorId(cuentaOrigenId);
            var cuentaDestino = _cuentaRepository.ObtenerPorId(cuentaDestinoId);

            // Validar saldo suficiente en la cuenta de origen
            if (cuentaOrigen.Saldo < monto)
            {
                throw new InvalidOperationException("Saldo insuficiente en la cuenta de origen.");
            }

            // Actualizar saldos
            cuentaOrigen.ActualizarSaldo(-monto);
            cuentaDestino.ActualizarSaldo(monto);

            // Registrar las transacciones
            var transaccionOrigen = new Transaccion(cuentaOrigenId, -monto, DateTime.Now, tipoTransaccionID: 1, categoriaID: 1);
            var transaccionDestino = new Transaccion(cuentaDestinoId, monto, DateTime.Now, tipoTransaccionID: 2, categoriaID: 1);

            _transaccionRepository.Guardar(transaccionOrigen);
            _transaccionRepository.Guardar(transaccionDestino);

            // Guardar cambios en ambas cuentas
            _cuentaRepository.Actualizar(cuentaOrigen);
            _cuentaRepository.Actualizar(cuentaDestino);
        }
    }
}
