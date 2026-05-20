using Microsoft.AspNetCore.Mvc;
using pharmacy.Models;
using pharmacy.Services;

namespace pharmacy.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MedicinesController : ControllerBase
    {
        private readonly MedicineService _service = new();

        private readonly ILogger<MedicinesController> _logger;

        public MedicinesController(ILogger<MedicinesController> logger)
        {
            _logger = logger;
        }

        // GET: api/medicines
        [HttpGet]
        public IActionResult Get(string? search)
        {
            var medicines = _service.GetAll();
            if(!string.IsNullOrEmpty(search))
            {
                medicines = medicines.Where(m => m.Name != null && m.Name.Contains(search, StringComparison.OrdinalIgnoreCase))
                         .ToList();
            }
            return Ok(medicines);
        }

        // POST: api/medicines
        [HttpPost]
        public IActionResult Add(Medicine med)
        {
            var list = _service.GetAll();
            med.Id = list.Count + 1;
            list.Add(med);
            _service.SaveAll(list);

            return Ok(med);
        }
    }
}
