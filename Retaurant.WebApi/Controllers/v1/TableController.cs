﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Core.Application.Enums;
using Restaurant.Core.Application.Interfaces.Services;
using Restaurant.Core.Application.ViewModels.Orders;
using Restaurant.Core.Application.ViewModels.Tables;

namespace Retaurant.WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class TableController : BaseApiController
    {
        private readonly ITableService _tableService;
        private readonly IOrderService _orderService;

        public TableController(ITableService tableService, IOrderService orderService)
        {
            _tableService = tableService;
            _orderService = orderService;
        }

        [Authorize(Roles = "Admin, SuperAdmin")]
        [HttpPost("Create")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post(SaveTableViewModel vm)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(vm);
                }

                vm.Status = (int)TableStatus.Available;

                var table = await _tableService.Add(vm);
                if (table == null)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, table);
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [Authorize(Roles = "Admin,SuperAdmin")]
        [HttpPut("Update/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SaveTableViewModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Put(int id, SaveTableViewModel vm)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(vm);
                }

                vm.Id = id;

                vm.Id = id;
                await _tableService.Update(vm, id);

                return Ok(vm);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }


        [Authorize(Roles = "Admin, Waiter, SuperAdmin")]
        [HttpGet("GetAll")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TableViewModel))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get()
        {
            try
            {
                List<TableViewModel> tables = await _tableService.GetAllViewModel();

                if (tables.Count == 0)
                    return NotFound();

                return Ok(tables);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [Authorize(Roles = "Admin,Waiter,SuperAdmin")]
        [HttpGet("GetById/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TableViewModel))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var table = await _tableService.GetByIdViewModel(id);

                if (table == null)
                    return NotFound();

                return Ok(table);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }


        [Authorize(Roles = "Waiter, SuperAdmin")]
        [HttpGet("GetTableOrders/{tableId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(OrderViewModel))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetTableOrders(int tableId)
        {
            try
            {
                var table = await _tableService.GetByIdViewModel(tableId);

                if (table == null)
                {
                    ModelState.AddModelError("tableNotExists", $"No existe una mesa con el id {tableId}");
                    return NotFound(ModelState);
                }

                var orders = await _orderService.GetOrdersTable(tableId);

                if (orders.Count == 0)
                {
                    ModelState.AddModelError("ordersNotExists", $"No existen ordenes en proceso para la mesa con el id {tableId}");
                    return NotFound(ModelState);
                }

                return Ok(orders);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [Authorize(Roles = "Waiter, SuperAdmin")]
        [HttpPut("ChangeStatus")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ChangeStatus([FromQuery] int tableId, [FromQuery] int status)
        {
            try
            {
                await _tableService.ChangeTableStatus(tableId, status);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
