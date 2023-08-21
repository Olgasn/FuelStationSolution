using AutoMapper;
using FuelStation.Application.Commands.CreateFuel;
using FuelStation.Application.Commands.DeleteFuel;
using FuelStation.Application.Commands.UpdateFuel;
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
    public class FuelController : BaseController
    {
        private readonly IMapper _mapper;
        /// <summary>
        /// Конструктор, принимающий маппер
        /// </summary>

        public FuelController(IMapper mapper) => _mapper = mapper;

        /// <summary>
        /// Получение списка видов топлива
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /Fuel
        /// </remarks>
        /// <returns>Возвращает FuelListVm</returns>
        /// <response code="200">Success</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<FuelListVm>> GetAll(string? ContainFuelType)
        {
            var query = new GetFuelListQuery
            {
                FuelType = ContainFuelType
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>
        /// Получение данных об одном виде топлива по его id
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /Fuel/D34D349E-43B8-429E-BCA4-793C932FD580
        /// </remarks>
        /// <param name="id">Fuel id (guid)</param>
        /// <returns>Возвращает FuelDetailsVm</returns>
        /// <response code="200">Success</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<FuelDetailsVm>> Get(Guid id)
        {
            var query = new GetFuelDetailsQuery
            {
                Id = id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>
        /// Создание записи о новом топливе
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// POST /Fuel
        /// {
        ///     FuelType: "Название топлива",
        ///     FuelDensity: "2 - плотность топлива"
        /// }
        /// </remarks>
        /// <param name="createFuelDto">CreateFuelDto object</param>
        /// <returns>Возвращает id (guid)</returns>
        /// <response code="201">Success</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateFuelDto createFuelDto)
        {
            var command = _mapper.Map<CreateFuelCommand>(createFuelDto);
            var FuelId = await Mediator.Send(command);
            return Ok(FuelId);
        }

        /// <summary>
        /// Обновление данных о топливе
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// PUT /Fuel
        /// {
        ///     FuelType: "Новое название топлива"
        /// }
        /// </remarks>
        /// <param name="updateFuelDto">UpdateFuelDto object</param>
        /// <returns>Возвращает NoContent</returns>
        /// <response code="204">Success</response>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Update([FromBody] UpdateFuelDto updateFuelDto)
        {
            var command = _mapper.Map<UpdateFuelCommand>(updateFuelDto);
            await Mediator.Send(command);
            return NoContent();
        }

        /// <summary>
        /// Удаление топлива по его id
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// DELETE /Fuel/88DEB432-062F-43DE-8DCD-8B6EF79073D3
        /// </remarks>
        /// <param name="id"> Id топлива (guid)</param>
        /// <returns>Возвращает NoContent</returns>
        /// <response code="204">Success</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteFuelCommand
            {
                Id = id
            };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
