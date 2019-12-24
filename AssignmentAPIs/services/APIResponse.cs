using APIsModel.Model;
using APIsModel.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssignmentAPIs.services
{/// <summary>
/// 
/// </summary>
    public class APIResponse
    {/// <summary>
     /// 
     /// </summary>
        public int StatusCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Users user { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Token { get; set; }
    }
    /// <summary>
    /// 
    /// </summary>
    public class APIUnauthorizedResponse
    {/// <summary>
     /// 
     /// </summary>
        public int StatusCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ErrorMEssage { get; set; }
    }
    /// <summary>
    /// 
    /// </summary>
    public class GetUserResponse
    {
        /// <summary>
        /// 
        /// </summary>
        public int StatusCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<RegisterModel> Data { get; set; }
    }
    /// <summary>
    /// 
    /// </summary>
    public class GetGenderResponse
    {
        /// <summary>
        /// 
        /// </summary>
        public int StatusCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<GenderViewModel> Data { get; set; }
    }
}
