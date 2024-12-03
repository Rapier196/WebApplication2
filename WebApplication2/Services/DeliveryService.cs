using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.Models;
using System;

namespace WebApplication2.Services
{
    public class DeliveryService
    {
        // Используем ApplicationDbContext, который у тебя существует
        private readonly ApplicationDbContext _context;

        public DeliveryService(ApplicationDbContext context)
        {
            _context = context;
        }

        // CRUD операции:

        // Получение всех доставок
        public async Task<IEnumerable<Delivery>> GetAllAsync()
        {
            return await _context.Delivery.ToListAsync();
        }

        // Получение доставки по Id
        public async Task<Delivery> GetByIdAsync(int id)
        {
            return await _context.Delivery.FindAsync(id);
        }

        // Создание новой доставки
        public async Task CreateAsync(Delivery delivery)
        {
            // Check if the delivery with the same Id already exists
            var existingDelivery = await _context.Delivery.AsNoTracking().FirstOrDefaultAsync(e => e.Id == delivery.Id);
            if (existingDelivery != null)
            {
                // If the delivery exists, update it instead of creating a new one
                await UpdateAsync(delivery);
                return;
            }

            // Create a new delivery
            _context.Delivery.Add(delivery);
            await _context.SaveChangesAsync();
        }


        // Обновление информации о доставке
        public async Task UpdateAsync(Delivery delivery)
        {
            var existingDelivery = await _context.Delivery.FindAsync(delivery.Id);
            if (existingDelivery == null)
            {
                throw new Exception("Delivery not found");
            }

            existingDelivery.DeliveryId = delivery.DeliveryId;
            existingDelivery.ServiceStatus = delivery.ServiceStatus;
            existingDelivery.DeliveryStatus = delivery.DeliveryStatus;
            existingDelivery.SendingFrom = delivery.SendingFrom;
            existingDelivery.SendingWhere = delivery.SendingWhere;

            // If the Id is changed, update it
            if (existingDelivery.Id != delivery.Id)
            {
                existingDelivery.Id = delivery.Id;
            }

            await _context.SaveChangesAsync();
        }


        // Удаление доставки по Id
        public async Task DeleteAsync(int id)
        {
            var delivery = await _context.Delivery.FindAsync(id);
            if (delivery != null)
            {
                _context.Delivery.Remove(delivery);
                await _context.SaveChangesAsync();
            }
        }
    }
}
