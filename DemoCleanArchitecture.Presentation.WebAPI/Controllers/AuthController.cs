using DemoCleanArchitecture.ApplicationCore.Interfaces.Services;
using DemoCleanArchitecture.Domain.Exceptions;
using DemoCleanArchitecture.Domain.Modeles;
using DemoCleanArchitecture.Presentation.WebAPI.Dto.Input;
using DemoCleanArchitecture.Presentation.WebAPI.Tools;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoCleanArchitecture.Presentation.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMemberService _memberService;
        private readonly TokenTool _tokenTool;

        public AuthController(IMemberService memberService,TokenTool tokenTool)
        {
            _memberService = memberService;
            _tokenTool = tokenTool;
        }

        [HttpPost("register")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Register(MemberCredentialInputDTO memberCredentialInputDTO)
        {
            try
            {
                Member member = _memberService.Register(memberCredentialInputDTO.Email, memberCredentialInputDTO.Password);
                string token = _tokenTool.Generate(new TokenTool.Data()
                {
                    Id = member.Id,
                    Role = member.Role
                });

                return Ok(new
                {
                    token
                });

            }
            catch(MemberAuthException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Login(MemberCredentialInputDTO memberCredentialInputDTO)
        {
            try
            {
                Member member = _memberService.Login(memberCredentialInputDTO.Email,memberCredentialInputDTO.Password);
                string token = _tokenTool.Generate(new TokenTool.Data()
                {
                    Id = member.Id,
                    Role = member.Role
                });

                return Ok(new
                {
                    token
                });
            }
            catch (MemberAuthException ex)
            {
                return BadRequest("Bad credentials");
            }
        }
    }
}
