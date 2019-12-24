using APIsModel.Model;
using APIsModel.ViewModel;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentAPIs.services
{/// <summary>
/// 
/// </summary>
    public class FakeHelperClass : IHelperClass
    {
        private readonly List<RegisterModel> _Users;
        private readonly List<GenderTable> genderTables;
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
        public FakeHelperClass()
        {
            _Users = new List<RegisterModel>()
            {
                new RegisterModel()
                {
                    Id=1,
                    FirstName= "j",
                    LastName= "jbk",
                    EmailId= "kj@gma.co",
                    Gender= "Male",
                    Dob= DateTime.Now.Date,
                    Password= "123",
                },
                new RegisterModel()
                {
                    Id=2,
                    FirstName= "Jogi",
                    LastName= "jj",
                    EmailId= "jogi@gmail.com",
                    Gender= "Male",
                    Dob= DateTime.Now.Date,
                    Password= "123",
                },
                new RegisterModel()
                {
                    Id=3,
                    FirstName= "Akhil",
                    LastName= "Jain",
                    EmailId= "akhil@gmail.com",
                    Gender= "Male",
                    Dob= DateTime.Now.Date,
                    Password= "123",
                },
                new RegisterModel()
                {
                    Id=4,
                    FirstName= "Mimansha",
                    LastName= "Aggarwal",
                    EmailId= "mimansha@gma.co",
                    Gender= "Female",
                    Dob= DateTime.Now.Date,
                    Password= "123",
                }
            };
            genderTables = new List<GenderTable>()
            {
                new GenderTable()
                {
                    Id=1,
                    GenderType="Male"
                },
                 new GenderTable()
                {
                    Id=2,
                    GenderType="Female"
                },
                  new GenderTable()
                {
                    Id=3,
                    GenderType="Others"
                }
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns></returns>
        public string GenerateJSONWebToken(Users userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ThisismySecretKey"));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[] {
            new Claim(JwtRegisteredClaimNames.Sub, userInfo.FirstName),
            new Claim(JwtRegisteredClaimNames.Email, userInfo.EmailId),
            new Claim("DateOfJoing", userInfo.Dob.ToString("yyyy-MM-dd")),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
            var token = new JwtSecurityToken("gemini",
              "gemini",
              claims,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<GenderViewModel> GetAllGender()
        {
            try
            {
                if (genderTables != null)
                {
                    Genders = genderTables.Select(a => new GenderViewModel() { GenderType = a.GenderType, Id = a.Id });
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
        /// <returns></returns>
        public List<RegisterModel> GetAllUsers()
        {
            try
            {
                if (_Users != null)
                {
                    var AllUsers = (_Users.Select(a => new RegisterModel() { Id = a.Id, FirstName = a.FirstName, LastName = a.LastName, EmailId = a.EmailId, Gender = a.Gender, Dob = a.Dob }).ToList());
                    return AllUsers;
                }
                else
                {
                    return null;
                }
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
        public RegisterModel GetLoginUser(LoginModel login)
        {
            RegisterModel userObj = new RegisterModel();
            try
            {
                if (_Users != null)
                {

                    userObj = _Users.FirstOrDefault(a => a.EmailId == login.EmailId && a.Password == login.password);

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
        /// <param name="data"></param>
        /// <returns></returns>
        public bool RegisterUser(RegisterModel data)
        {
            try
            {
                if (_Users != null)
                {
                    RegisterModel user = new RegisterModel
                    {
                        FirstName = data.FirstName,
                        LastName = data.LastName,
                        EmailId = data.EmailId,
                        GenderId = data.GenderId,
                        Dob = data.Dob,
                        Password = data.Password,
                    };
                    _Users.Add(user);
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
        /// <param name="login"></param>
        /// <returns></returns>
        public Users GetUser(LoginModel login)
        {
            throw new NotImplementedException();
        }
    }
}
