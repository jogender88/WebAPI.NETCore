using APIsModel.Model;
using APIsModel.ViewModel;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
namespace AssignmentAPIs.services
{/// <summary>
/// 
/// </summary>
    public class HelperClass : IHelperClass
    {
        private IConfiguration _config;
        static AssignmentContext assignmentContext;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_assignmentContext"></param>
        /// <param name="config"></param>
        public HelperClass(AssignmentContext _assignmentContext, IConfiguration config)
        {
            _config = config;
            assignmentContext = _assignmentContext;
        }

        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<RegisterModel> AllUsers { get; private set; }
        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<GenderViewModel> Genders { get; private set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<RegisterModel> GetAllUsers()
        {
            try
            {
                if (assignmentContext != null)
                {
                    AllUsers = (from users in assignmentContext.Users
                                select new RegisterModel
                                {
                                    Id = users.Id,
                                    FirstName = users.FirstName,
                                    LastName = users.LastName,
                                    EmailId = users.EmailId,
                                    Gender = users.Gender.GenderType,
                                    Dob = users.Dob
                                }).ToList();
                }
                return new List<RegisterModel>(AllUsers);

            }
            catch (Exception e)
            {
                return null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool RegisterUser(RegisterModel data)
        {
            try
            {
                if (assignmentContext != null)
                {
                    Users user = new Users
                    {
                        FirstName = data.FirstName,
                        LastName = data.LastName,
                        EmailId = data.EmailId,
                        GenderId = data.GenderId,
                        Dob = data.Dob,
                        Password = data.Password,
                    };
                    assignmentContext.Users.Add(user);
                    assignmentContext.SaveChanges();
                }
                return true;
            }
            catch (Exception e)
            {

                return false;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<GenderViewModel> GetAllGender()
        {

            try
            {
                if (assignmentContext != null)
                {
                    Genders = (from gendertable in assignmentContext.GenderTable select new GenderViewModel { Id = gendertable.Id, GenderType = gendertable.GenderType }).ToList();
                }
                return new List<GenderViewModel>(Genders);

            }
            catch (Exception e)
            {
                return null;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        public Users GetUser(LoginModel login)
        {
            Users userObj = new Users();
            try
            {
                if (assignmentContext != null)
                {

                    userObj = assignmentContext.Users.FirstOrDefault(a => a.EmailId == login.EmailId && a.Password == login.password);

                    return userObj;
                }
                else
                    return null;

            }
            catch (Exception e)
            {
                return null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns></returns>
        public string GenerateJSONWebToken(Users userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[] {
        new Claim(JwtRegisteredClaimNames.Sub, userInfo.FirstName),
        new Claim(JwtRegisteredClaimNames.Email, userInfo.EmailId),
        new Claim("DateOfJoing", userInfo.Dob.ToString("yyyy-MM-dd")),
        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
    };

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              claims,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        public RegisterModel GetLoginUser(LoginModel login)
        {
            throw new NotImplementedException();
        }
    }
}
