using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NikaScrapApp.Core.Interfaces;
using NikaScrapApp.Core.Models.Response;
using NikaScrapApp.Core.Models.Request;
using NikaScrapApp.Core.Services;

namespace NikaScrapApplication.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class  UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService) 
        {
            _userService = userService;
        }

        [HttpPost]
        public IActionResult SetRole(SetUserRoleRequest setUserRoleRequest)
        {
            ResponseData responseData = new ResponseData();

            responseData = _userService.SetRole(setUserRoleRequest);

            return Ok(responseData);
        }

        [HttpPost]
        public IActionResult UserProfileUpdate(UserProfileUpdate userProfileUpdate)
        {
            UserProfileUpdateResponse result = new UserProfileUpdateResponse();
            result = _userService.UserProfileUpdate(userProfileUpdate);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddAddress(NikaScrapApp.Core.Models.Request.UserAddress addUesrAddress,[FromQuery] int languageId)
        {
            UserAddressResponse result = new UserAddressResponse();

            result = _userService.AddAddress(addUesrAddress, languageId);

            return Ok(result);
        }
        [HttpGet]
        public IActionResult GetAddress([FromQuery] int userId, [FromQuery] int languageId)
        {
            UserAddressResponse result = new UserAddressResponse();
            result = _userService.GetAddress(userId, languageId);

            return Ok(result);
        }


        [HttpGet]
        public IActionResult DeleteAddress([FromQuery] int addressId)
        {
            UserAddressResponse result = new UserAddressResponse();
            result = _userService.DeleteAddress(addressId);
            return Ok(result);
        }
        //[HttpPut, Authorize(Roles = "Admin,SubAdmin,Household,Organisation,Business Owner")]
        [HttpGet]
        public IActionResult SetDefaultAddress([FromQuery] int id, [FromQuery] int UserId)
        {
            UserAddressResponse result = new UserAddressResponse();
            result = _userService.SetDefaultAddress(id, UserId);

            return Ok(result);
        }
        [HttpPost]
        public IActionResult UpdateUserAddress(NikaScrapApp.Core.Models.Request.UserAddress userAddress)
        {
            UserAddressResponse result = new UserAddressResponse();
            result = _userService.UpdateUserAddress(userAddress);
            return Ok(result);
        } 
    }
}
