using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSMP.Portal.Domains;
using CSMP.Portal.Services;
using CSMP.Portal.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Omu.ValueInjecter;
using Passingwind.PagedList;

namespace CSMP.Portal.Web.Controllers
{
    public class AccountController : AppControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly ILogger<AccountController> _logger;

        public AccountController(IAccountService accountService, ILogger<AccountController> logger)
        {
            _accountService = accountService;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get([FromQuery] ListRequestDto request)
        {
            var list = _accountService.GetAll()
                .OrderByDescending(t => t.CreationTime)
                .ToPagedList(request.Page, request.PageSize);

            var result = new PagedListResultDto<AccountDto>(list.Select(t => new AccountDto() { Id = t.Id, UserName = t.UserName, DisplayName = t.DisplayName, }), list.TotalCount);

            return Ok(result);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Create([FromBody] AccountDto dto)
        {
            var entity = Mapper.Map<Account>(dto);

            if (!string.IsNullOrEmpty(dto.Password))
            {
                await _accountService.HashPasswordAsync(entity, dto.Password);
            }

            try
            {
                await _accountService.CreateAsync(entity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Create Account faild.");
                return BadRequest();
            }

            return Ok();
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Update([FromBody]AccountDto dto)
        {
            var entity = await _accountService.GetByIdAsync(dto.Id);

            if (entity == null)
                return BadRequest();

            entity.InjectFrom(dto);

            if (!string.IsNullOrEmpty(dto.Password))
            {
                await _accountService.HashPasswordAsync(entity, dto.Password);
            }

            try
            {
                await _accountService.UpdateAsync(entity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Update Account faild.");
                return BadRequest();
            }

            return Ok();
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Delete([FromQuery]int id)
        {
            try
            {
                await _accountService.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Delete Account faild.");
                return BadRequest();
            }

            return Ok();
        }

    }
}