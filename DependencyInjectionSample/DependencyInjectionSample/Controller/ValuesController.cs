using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DependencyInjectionSample.Interface;
using DependencyInjectionSample.Model;
using Microsoft.AspNetCore.Mvc;

namespace DependencyInjectionSample.Controller
{
    public class ValuesController : ControllerBase
    {
        IUserInfoService _userInfoService;

        public ValuesController(IUserInfoService userInfoService)
        {
            _userInfoService = userInfoService;
        }

        [HttpGet]
        public IEnumerable<UserInfo> Get()
        {
            return _userInfoService.GetUserInfo();
        }
    }
}