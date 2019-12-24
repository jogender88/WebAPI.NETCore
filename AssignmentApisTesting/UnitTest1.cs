using NUnit.Framework;
using AssignmentAPIs.Controllers;
using AssignmentAPIs.services;
using APIsModel.Model;
using Microsoft.Extensions.Configuration;
using APIsModel.ViewModel;
using System.Collections.Generic;
using System;
using System.Linq;

namespace AssignmentApisTesting
{
    public class Tests
    {
        //[SetUp]
        //public void Setup()
        //{
        //}

        //[Test]
        //public void Test1()
        //{
        //    Assert.Pass();
        //}
        UsersController _controller;
        IHelperClass _service;
        private List<RegisterModel> _Users;
        private List<GenderTable> genderTables;

        public Tests()
        {
            _service = new FakeHelperClass();
            _controller = new UsersController(_service);
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
            Id = 1,
                    GenderType = "Male"
                },
                 new GenderTable()
        {
            Id = 2,
                    GenderType = "Female"
                },
                  new GenderTable()
        {
            Id = 3,
                    GenderType = "Others"
                }
    };
        }
        [Test]
        public void GetAllUsers_ShouldReturnAllUsers()
        {
            var testUsers = GetTestUsers();

            var result = _controller.GetUsers();
            Assert.AreEqual(testUsers.Count, result.Data.Count);
        }
        [Test]
        public void GetAllGender_ShouldReturnAllGender()
        {
            var testGenders = GetTestGeders();

            var result = _controller.GetGender();
            Assert.AreEqual(testGenders.Count, result.Data.Count);
        }
        [Test]
        public void GetLoginUser_ShouldReturnLoginUser()
        {
            LoginModel login = new LoginModel
            {
                EmailId = "jogi@gmail.com",
                password = "12"
            };
            var testLoginUser = GetTestLoginUser(login);
            var result = _controller.GetUser(login);
            Assert.AreEqual(testLoginUser, result);
        }

        private List<RegisterModel> GetTestUsers()
        {
            return _Users;
        }
        private List<GenderTable> GetTestGeders()
        {
            return genderTables;
        }

        private RegisterModel GetTestLoginUser(LoginModel login)
        {
            RegisterModel userObj = new RegisterModel();

            if (_Users != null)
            {
                userObj = _Users.FirstOrDefault(a => a.EmailId == login.EmailId && a.Password == login.password);
                return userObj;
            }
            else
                return null;
        }
    }
}