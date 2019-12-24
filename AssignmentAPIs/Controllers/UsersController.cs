using System;
using APIsModel.ViewModel;
using AssignmentAPIs.services;
using Microsoft.AspNetCore.Mvc;

namespace AssignmentAPIs.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    [Route("[controller]")]

    public class UsersController : ControllerBase
    {
        IHelperClass helperClass;
        /// <summary>
        /// Constructor Dependency Injection 
        /// </summary>
        /// <param name="_helperClass"></param>
        public UsersController(IHelperClass _helperClass)
        {
            helperClass = _helperClass;
        }
        /// <summary>
        /// Method for getting All the users from Users Table
        /// </summary>
        /// <returns>Return IAction Result with All Users data</returns>
        [HttpGet]
        //[Microsoft.AspNetCore.Authorization.Authorize]
        [services.Authorize()]
        [Route("GetUsers")]
        public GetUserResponse GetUsers()
        {
            GetUserResponse response = new GetUserResponse();
            try
            {
                var users = helperClass.GetAllUsers();
                if (users == null)
                {
                    return response = new GetUserResponse
                    {
                        StatusCode = 201,
                        Data = users,
                    };
                }
                return response = new GetUserResponse
                {
                    StatusCode = 200,
                    Data = users,
                };
            }
            catch (Exception e)
            {
                return response = new GetUserResponse
                {
                    StatusCode = 201,
                    Data = null,
                };
            }
        }
        /// <summary>
        /// Method for getting Gender from gender table
        /// </summary>
        /// <returns>Returns Gender object </returns>
        [HttpGet]
        [Route("GetGender")]
        public GetGenderResponse GetGender()
        {
            GetGenderResponse response = new GetGenderResponse();
            try

            {
                var gender = helperClass.GetAllGender();
                if (gender == null)
                {
                    return response = new GetGenderResponse
                    {
                        StatusCode = 201,
                        Data = null,
                    }; ;
                }
                return response = new GetGenderResponse
                {
                    StatusCode = 200,
                    Data = gender,
                };
            }
            catch (Exception e)
            {
                return response = new GetGenderResponse
                {
                    StatusCode = 201,
                    Data = null,
                }; ;
            }
        }
        /// <summary>
        /// Method for register new user
        /// Takes parameter of type Users Model
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Register")]
        public IActionResult Register([FromBody]RegisterModel model)
        {
            try
            {

                var users = helperClass.RegisterUser(model);
                if (User == null)
                {
                    return NotFound();
                }
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
        /// <summary>
        /// Method for Get Login user details
        /// Takes Login model Type object as Parameter
        /// </summary>
        /// <param name="model"></param>
        /// <returns>Returns APIResponse object</returns>
        [HttpPost]
        [Route("Login")]
        public APIResponse GetUser([FromBody]LoginModel model)
        {
            APIResponse response = new APIResponse();
            try
            {
                var user = helperClass.GetUser(model);

                if (user != null)
                {
                    var tokenString = helperClass.GenerateJSONWebToken(user);
                    response = new APIResponse
                    {
                        StatusCode = 200,
                        user = user,
                        Token = tokenString
                    };
                    return response;

                }
                else
                {
                    response = new APIResponse
                    {
                        StatusCode = 404,
                        user = null,
                        Token = null
                    };
                    return response;
                }
            }
            catch (Exception e)
            {
                response = new APIResponse
                {
                    StatusCode = 401,
                    user = null,
                    Token = null
                };
                return response;
            }
        }

    }
}