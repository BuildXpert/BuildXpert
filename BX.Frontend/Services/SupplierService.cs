using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BX.Models;

namespace BX.Frontend.Services
{
    public class SupplierService
    {
        private readonly BuildXpertContext _context;

        public SupplierService(BuildXpertContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        // 🔹 Obtener todos los supplieres
        public async Task<List<Supplier>> GetSupplierAsync()
        {
            return await _context.Supplier
                .Include(p => p.Payments)
                .Include(p => p.Orders)
                .AsNoTracking() // Mejora el rendimiento al no rastrear las entidades
                .ToListAsync();
        }

        // 🔹 Obtener un supplier por ID
        public async Task<Supplier> GetSupplierByIdAsync(int id)
        {
            return await _context.Supplier
                .Include(p => p.Payments)
                .Include(p => p.Orders)
                .AsNoTracking() // Mejora el rendimiento al no rastrear las entidades
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        // 🔹 Agregar un nuevo supplier
        public async Task AddSupplierAsync(Supplier supplier)
        {
            if (supplier == null)
                throw new ArgumentNullException(nameof(supplier), "El supplier no puede ser nulo.");

            await _context.Supplier.AddAsync(supplier);
            await _context.SaveChangesAsync();
        }

        // 🔹 Actualizar un supplier existente
public async Task UpdatesupplierAsync(Supplier supplier)
{
    if (supplier == null)
        throw new ArgumentNullException(nameof(supplier), "El supplier no puede ser nulo.");

    var existingsupplier = await _context.Supplier.FindAsync(supplier.Id);
    if (existingsupplier == null)
        throw new KeyNotFoundException("supplier no encontrado.");

    // 🔹 Actualizar manualmente solo las propiedades necesarias
    existingsupplier.Name = supplier.Name;
    existingsupplier.ServiceType = supplier.ServiceType;
    existingsupplier.Contact = supplier.Contact;
    existingsupplier.Address = supplier.Address;
    existingsupplier.Status = supplier.Status;

    await _context.SaveChangesAsync();
}


        // 🔹 Eliminar un supplier
        public async Task DeletesupplierAsync(int id)
        {
            var supplier = await _context.Supplier.FindAsync(id);
            if (supplier == null)
                throw new KeyNotFoundException("supplier no encontrado.");

            _context.Supplier.Remove(supplier);
            await _context.SaveChangesAsync();
        }

        // 🔹 Obtener todos los pagos de un supplier
        public async Task<List<SupplierPayment>> GetPagosBysupplierIdAsync(int supplierId)
        {
            return await _context.SupplierPayment
                .Where(p => p.SupplierId == supplierId)
                .OrderByDescending(p => p.Date)
                .AsNoTracking() // Mejora el rendimiento al no rastrear las entidades
                .ToListAsync();
        }

        // 🔹 Registrar un nuevo pago para un supplier
        public async Task AddPagoAsync(SupplierPayment pago)
        {
            if (pago == null)
                throw new ArgumentNullException(nameof(pago), "El pago no puede ser nulo.");

            _context.SupplierPayment.Add(pago);
            await _context.SaveChangesAsync();
        }

        // 🔹 Obtener todos los pedidos de un supplier
        public async Task<List<SupplierOrder>> GetPedidosBysupplierIdAsync(int supplierId)
        {
            return await _context.SupplierOrder
                .Where(p => p.SupplierId == supplierId)
                .AsNoTracking() // Mejora el rendimiento al no rastrear las entidades
                .ToListAsync();
        }

        // 🔹 Crear un nuevo pedido con un supplier
        public async Task AddSupplierOrderAsync(SupplierOrder supplierOrders)
        {
            if (supplierOrders == null)
                throw new ArgumentNullException(nameof(supplierOrders), "El pedido no puede ser nulo.");

            _context.SupplierOrder.Add(supplierOrders);
            await _context.SaveChangesAsync();
        }

        // 🔹 Eliminar un pago
        public async Task DeleteSupplierPaymentsAsync(int id)
        {
            var pago = await _context.SupplierPayment.FindAsync(id);
            if (pago == null)
                throw new KeyNotFoundException("Pago no encontrado.");

            _context.SupplierPayment.Remove(pago);
            await _context.SaveChangesAsync();
        }

        // 🔹 Eliminar un pedido
        public async Task DeleteSupplierOrdersAsync(int id)
        {
            var pedido = await _context.SupplierOrder.FindAsync(id);
            if (pedido == null)
                throw new KeyNotFoundException("Pedido no encontrado.");

            _context.SupplierOrder.Remove(pedido);
            await _context.SaveChangesAsync();
        }
    }
}