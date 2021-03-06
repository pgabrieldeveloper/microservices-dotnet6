using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using restCalculator.Model;
using restCalculator.Services;

namespace restCalculator.Controllers;

[ApiController]
[Route("[controller]")]
public class PersonController : ControllerBase
{
    
    private readonly ILogger<PersonController> _logger;
    private IPersonService _personService;
    public PersonController(ILogger<PersonController> logger, IPersonService personService)
    {
        _logger = logger;
        _personService = personService;
    }

    [HttpGet]
    public IActionResult FindAll()
    {
        return Ok(_personService.FindAll());
    }
    [HttpGet("{id}")]
    public IActionResult FindById(long id)
    {
        return Ok(_personService.FindById(id));
    }
    [HttpPost]
    public IActionResult Create([FromBody] Person person)
    {
        if (person == null) return BadRequest();
        return Ok(_personService.Create(person));
    }
    [HttpPut]
    public IActionResult Update([FromBody] Person person)
    {
        if (person == null) return BadRequest();
        return Ok(_personService.Update(person));
    }
    
    [HttpDelete("{id}")]
    public IActionResult Delete(long id)
    {
        _personService.Delete(id);
        return NoContent();
    }
    
    
}
