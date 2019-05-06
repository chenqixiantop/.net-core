using DependencyInjectionSample.Interface;
using DependencyInjectionSample.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DependencyInjectionSample.Service
{
    public class UserInfoService : IUserInfoService
    {
        public IEnumerable<UserInfo> GetUserInfo()
        {
            //模拟db获取数据
            return new List<UserInfo>
            {
                new UserInfo{Id = 1,Name = "Emrys"},
                new UserInfo{Id = 2,Name = "梅林"}
            };
        }
    }
}
