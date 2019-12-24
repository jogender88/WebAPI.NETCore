using APIsModel.Model;
using APIsModel.ViewModel;
using System.Collections.Generic;

namespace AssignmentAPIs.services
{/// <summary>
/// 
/// </summary>
    public interface IHelperClass
    {/// <summary>
     /// 
     /// 
     /// </summary>
     /// <returns></returns>
        List<RegisterModel> GetAllUsers();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="users"></param>
        /// <returns></returns>
        bool RegisterUser(RegisterModel users);
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        List<GenderViewModel> GetAllGender();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        RegisterModel GetLoginUser(LoginModel login);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        Users GetUser(LoginModel login);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns></returns>
        string GenerateJSONWebToken(Users userInfo);

    }
}
