using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using FuelStation.Application.Queries.GetList;
using FuelStation.Application.Queries.GetDetails;
using FuelStation.Application.Commands.CreateOperation;
using FuelStation.Application.Commands.UpdateOperation;
using FuelStation.Application.Commands.DeleteOperation;
using FuelStation.Web.Models;

namespace FuelStation.Web.Controllers
{
    /// <summary>
    /// API для работы с операциями
    /// </summary>
    //[ApiVersion("1.0")]
    //[ApiVersion("2.0")]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class OperationController : BaseController
    {
        private readonly IMapper _mapper;
        /// <summary>
        /// Констуктор, принимающий маппер
        /// </summary>

        public OperationController(IMapper mapper) => _mapper = mapper;

        /// <summary>
        /// Получение списка операций
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /operation
        /// </remarks>
        /// <returns>Возвращает OperationListVm</returns>
        /// <response code="200">Success</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<OperationListVm>> GetAll(string? ContainTankType, string? ContainFuelType)
        {
            var query = new GetOperationListQuery
            {
                TankType = ContainTankType,
                FuelType= ContainFuelType
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>
        /// Получение данных об единичной операции по ее id
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /operation/D34D349E-43B8-429E-BCA4-793C932FD580
        /// </remarks>
        /// <param name="id">operation id (guid)</param>
        /// <returns>Возвращает operationDetailsVm</returns>
        /// <response code="200">Success</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<OperationDetailsVm>> Get(Guid id)
        {
            var query = new GetOperationDetailsQuery
            {
                Id = id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>
        /// Создание записи о новой операции
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// POST /operation
        /// {
        /// fuelId: "8435db3f-6faa-4807-b550-854be4d08364", - код топлива
        /// tankId: "78238040-f454-4a6e-8f27-1f763c9fd75d", - код емкости
        /// inc_Exp: -6, - приход или расход
        /// operationDate: "2022-07-25T00:00:00", - дата операции
        /// }
        /// </remarks>
        /// <param name="createOperationDto">CreateOperationDto object</param>
        /// <returns>Возвращает id (guid)</returns>
        /// <response code="201">Success</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateOperationDto createOperationDto)
        {
            var command = _mapper.Map<CreateOperationCommand>(createOperationDto);
            var operationId = await Mediator.Send(command);
            return Ok(operationId);
        }

        /// <summary>
        /// Обновление данных об операциях
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// PUT /operation
        /// {
        ///     IncExp: 123456 - приход или расход
        ///     OperationDate: "2021-07-25T00:00:00" - дата операции
        /// }
        /// </remarks>
        /// <param name="updateOperationDto">UpdateOperationDto object</param>
        /// <returns>Возвращает NoContent</returns>
        /// <response code="204">Success</response>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Update([FromBody] UpdateOperationDto updateOperationDto)
        {
            var command = _mapper.Map<UpdateOperationCommand>(updateOperationDto);
            await Mediator.Send(command);
            return NoContent();
        }

        /// <summary>
        /// Удаление операции по ее id
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// DELETE /operation/88DEB432-062F-43DE-8DCD-8B6EF79073D3
        /// </remarks>
        /// <param name="id"> Id операции (guid)</param>
        /// <returns>Возвращает NoContent</returns>
        /// <response code="204">Success</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteOperationCommand
            {
                Id = id
            };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
