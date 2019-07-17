using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSMP.Portal.Domains;
using CSMP.Portal.Services;
using CSMP.Portal.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Passingwind.PagedList;

namespace CSMP.Portal.Web.Controllers
{
    public class SecurityTokenController : AppControllerBase
    {
        private readonly ISecurityTokenService _securityTokenService;

        public SecurityTokenController(ISecurityTokenService securityTokenService)
        {
            _securityTokenService = securityTokenService;
        }

        [HttpGet]
        public IActionResult Get([FromQuery] ListRequestDto request)
        {
            var list = _securityTokenService.GetAll()
                .OrderByDescending(t => t.CreationTime)
                .ToPagedList(request.Page, request.PageSize);

            var result = new PagedListResultDto<SecurityTokenDto>(list.Select(t => new SecurityTokenDto() { Id = t.Id, Expired = t.Expired, Token = t.Token }), list.TotalCount);

            return Ok(result);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Create([FromBody]SecurityTokenCreateDto dto)
        {
            var entity = new SecurityToken()
            {
                Token = Guid.NewGuid().ToString("N"),
            };

            switch (dto.Period)
            {
                case SecurityTokenCreateDto.ValidityPeriod.Day_1: entity.Expired = DateTime.Now.AddDays(1); break;
                case SecurityTokenCreateDto.ValidityPeriod.Week_1: entity.Expired = DateTime.Now.AddDays(7); break;
                case SecurityTokenCreateDto.ValidityPeriod.Month_1: entity.Expired = DateTime.Now.AddMonths(1); break;
                case SecurityTokenCreateDto.ValidityPeriod.Year_1: entity.Expired = DateTime.Now.AddYears(1); break;
            }

            await _securityTokenService.CreateAsync(entity);

            return Ok();
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Delete([FromQuery]int id)
        {
            await _securityTokenService.DeleteAsync(id);

            return Ok();
        }
    }
}