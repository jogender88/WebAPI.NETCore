

using System;

namespace APIsModel.ViewModel
{
    public class RegisterModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailId { get; set; }
        public int GenderId { get; set; }
        public DateTime Dob { get; set; }
        public string Password { get; set; }
        public string Gender { get; set; }
    }
}
