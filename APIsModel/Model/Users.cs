using System;
using System.Collections.Generic;

namespace APIsModel.Model
{
    public partial class Users
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailId { get; set; }
        public int GenderId { get; set; }
        public DateTime Dob { get; set; }
        public string Password { get; set; }

        public virtual GenderTable Gender { get; set; }
    }
}
