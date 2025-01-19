using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using exo_revisions.API.DTOs;
using exo_revisions.API.Mappers;
using exo_revisions.BLL.Interfaces;
using exo_revisions.BLL.Models;

namespace exo_revisions.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ShippingAddressController : ControllerBase
{
    private readonly IShippingAddressService _shippingAddressService;
    public ShippingAddressController(IShippingAddressService shippingAddressService)
    {
        _shippingAddressService = shippingAddressService;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<ShippingAddressDTO>))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult GetAll()
    {
        try
        {
            IEnumerable<ShippingAddressDTO> shippingAddresses = _shippingAddressService.GetAll().Select(sa => sa.ToDTO());
            return Ok(shippingAddresses);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ShippingAddressDTO))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult GetById(int id)
    {
        try
        {
            ShippingAddressDTO? shippingAddress = _shippingAddressService.GetById(id)?.ToDTO();
            if (shippingAddress == null)
            {
                return NotFound("ShippingAddress Not Found");
            }
            return Ok(shippingAddress);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ShippingAddressDTO))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult Create([FromBody] ShippingAddressCreateDTO shippingAddress)
    {
        int resultId = _shippingAddressService.Create(shippingAddress.ToModel());
        if (resultId > 0)
        {
            return CreatedAtAction(nameof(GetById), new {id = resultId}, shippingAddress);
        }
        return StatusCode(StatusCodes.Status500InternalServerError);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ShippingAddressUpdateDTO))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult Update(int id, [FromBody] ShippingAddressUpdateDTO shippingAddress)
    {
        try
        {
            return Ok(_shippingAddressService.Delete(id));
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}

