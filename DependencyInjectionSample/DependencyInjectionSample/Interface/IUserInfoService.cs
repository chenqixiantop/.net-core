using DependencyInjectionSample.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DependencyInjectionSample.Interface
{
    public interface IUserInfoService
    {
        IEnumerable<UserInfo> GetUserInfo();
    }
}
