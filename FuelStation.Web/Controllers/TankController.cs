using AutoMapper;
using FuelStation.Application.Commands.CreateTank;
using FuelStation.Application.Commands.DeleteTank;
using FuelStation.Application.Commands.UpdateTank;
using FuelStation.Application.Queries.GetDetails;
using FuelStation.Application.Queries.GetList;
using FuelStation.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace FuelStation.Web.Controllers
{
    /// <summary>
    /// API для работы с емкостями
    /// </summary>
    //[ApiVersion("1.0")]
    //[ApiVersion("2.0")]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class TankController : BaseController
    {
        private readonly IMapper _mapper;
        /// <summary>
        /// Констуктор, принимающий маппер
        /// </summary>

        public TankController(IMapper mapper) => _mapper = mapper;

        /// <summary>
        /// Получение списка емкостей
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /tank
        /// </remarks>
        /// <returns>Возвращает tankListVm</returns>
        /// <response code="200">Success</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<TankListVm>> GetAll(string? ContainTankType)
        {
            var query = new GetTankListQuery
            {
                TankType = ContainTankType
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>
        /// Получение данных об единичной емкости по ее id
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /tank/D34D349E-43B8-429E-BCA4-793C932FD580
        /// </remarks>
        /// <param name="id">tank id (guid)</param>
        /// <returns>Возвращает tankDetailsVm</returns>
        /// <response code="200">Success</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<TankDetailsVm>> Get(Guid id)
        {
            var query = new GetTankDetailsQuery
            {
                Id = id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>
        /// Создание записи о новой емкости
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// POST /tank
        /// {
        ///     TankType: "Название емкости",
        ///     TankVolume: "12 - объем емкости"
        /// }
        /// </remarks>
        /// <param name="createTankDto">CreatetankDto object</param>
        /// <returns>Возвращает id (guid)</returns>
        /// <response code="201">Success</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateTankDto createTankDto)
        {
            var command = _mapper.Map<CreateTankCommand>(createTankDto);
            var tankId = await Mediator.Send(command);
            return Ok(tankId);
        }

        /// <summary>
        /// Обновление данных о емкости
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// PUT /tank
        /// {
        ///     TankType: "Новое название емкости"
        /// }
        /// </remarks>
        /// <param name="updateTankDto">UpdatetankDto object</param>
        /// <returns>Возвращает NoContent</returns>
        /// <response code="204">Success</response>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Update([FromBody] UpdateTankDto updateTankDto)
        {
            var command = _mapper.Map<UpdateTankCommand>(updateTankDto);
            await Mediator.Send(command);
            return NoContent();
        }

        /// <summary>
        /// Удаление емкости по ее id
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// DELETE /tank/88DEB432-062F-43DE-8DCD-8B6EF79073D3
        /// </remarks>
        /// <param name="id"> Id емкости (guid)</param>
        /// <returns>Возвращает NoContent</returns>
        /// <response code="204">Success</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteTankCommand
            {
                Id = id
            };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
