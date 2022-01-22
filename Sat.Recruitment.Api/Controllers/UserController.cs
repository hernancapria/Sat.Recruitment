﻿using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sat.Recruitment.Business;
using Sat.Recruitment.Business.Contracts;
using Sat.Recruitment.Entities;

namespace Sat.Recruitment.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        
        [HttpPost]
        [Route("/create-user")]
        public async Task<Result> CreateUser(User user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    IUserBusiness userBusiness = new UserBusiness();
                    var result = await userBusiness.CreateUser(user);
                    return result;
                }
                else
                    throw new Exception("Invalid model");


            }
            catch (Exception ex)
            {

                return new Result()
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }

        }







        // GET: User
        [HttpGet]
        public async Task<Result> Get()
        {
            // solo a fines practicos, para debugear

            int test = 1; // 1 created | 2 duplicated | 3 invalid model

            User user = new User();
            if (test == 1)
            {
                user.Name = "Ricardo";
                user.Phone = "11111111";
                user.Email = "ricardo@gmail.com";
                user.Address = "Calle 19";
                user.UserType = "Normal";
                user.Money = 120;
            }
            if (test == 2)
            {
                user.Name = "Agustina";
                user.Phone = "+349 1122354215";
                user.Email = "Agustina@gmail.com";
                user.Address = "Av. Juan G";
                user.UserType = "Normal";
                user.Money = 124;
            }
            if (test == 3)
            {
                user.Name = string.Empty;
                user.Phone = "+349 1122354215";
                user.Email = "Agustina@gmail.com";
                user.Address = "Av. Juan G";
                user.UserType = "Normal";
                user.Money = 124;
            }

            try
            {
                IUserBusiness userBusiness = new UserBusiness();
                var result = await userBusiness.CreateUser(user);
                return result;

            }
            catch (Exception ex)
            {

                return new Result()
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }



    }

}