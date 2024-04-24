using Microsoft.AspNetCore.Mvc;

namespace AutanticationWebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class AccountController : ControllerBase
{
    private readonly JwtTokenHandler _jwtTokenHandler;

    public AccountController(JwtTokenHandler jwtTokenHandler)
    {
        _jwtTokenHandler = jwtTokenHandler;
    }

  //Autenticate  methode  by AutenticationRequest and return AutenticationResponse
    [HttpPost]
    [Route("Autenticate")]
    public ActionResult<AutenticationResponse?> Autenticate([FromBody] AutenticationRequest request)
    {
       var response = _jwtTokenHandler.GenerateToken(request);
        if (response == null)
        {
            return Unauthorized();
            
        }
        return response;


    }

}
