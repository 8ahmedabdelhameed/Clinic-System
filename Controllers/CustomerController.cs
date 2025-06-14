using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VIPClinicAPI.Data;
using VIPClinicAPI.DTOs;
using VIPClinicAPI.Models;

namespace VIPClinicAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CustomersController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> AddCustomer(CustomerDTO dto)
        {
            var exists = await _context.Customers
                .AnyAsync(c => c.FullName == dto.FullName && c.FileNumber == dto.FileNumber && c.VisitDate.Date == dto.VisitDate.Date);

            if (exists)
                return BadRequest("Customer already exists.");

            var customer = new Customer
            {
                FullName = dto.FullName,
                FileNumber = dto.FileNumber,
                VisitDate = dto.VisitDate,
                AppointmentDate = dto.AppointmentDate,
                AppointmentTime = dto.AppointmentTime,
                ArrivalTime = dto.ArrivalTime
            };

            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();

            return Ok(customer);
        }

        [HttpGet]
        public async Task<IActionResult> GetByDate(DateTime fromDate, DateTime toDate)
        {
            var result = await _context.Customers
                .Where(c => c.VisitDate >= fromDate && c.VisitDate <= toDate)
                .ToListAsync();

            return Ok(result);
        }

        [HttpPost("{id}/services")]
        public async Task<IActionResult> AddService(int id, ServiceDTO dto)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null) return NotFound();

            var service = new Service
            {
                CustomerId = id,
                Department = dto.Department,
                ServiceName = dto.ServiceName,
                ProviderName = dto.ProviderName,
                ExecutionTime = dto.ExecutionTime,
                RatingCommunication = dto.RatingCommunication,
                RatingInstructions = dto.RatingInstructions,
                RatingResponse = dto.RatingResponse,
                RatingRespect = dto.RatingRespect,
                RatingQuality = dto.RatingQuality,
                Notes = dto.Notes,
                RatingReason = dto.RatingReason
            };

            _context.Services.Add(service);
            await _context.SaveChangesAsync();

            return Ok(service);
        }

        [HttpGet("{id}/services")]
        public async Task<IActionResult> GetServices(int id)
        {
            var services = await _context.Services
                .Where(s => s.CustomerId == id)
                .ToListAsync();

            return Ok(services);
        }
    }
}
