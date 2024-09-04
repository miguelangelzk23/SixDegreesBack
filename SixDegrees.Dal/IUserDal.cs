using SixDegrees.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SixDegrees.Dal
{
    public  interface IUserDal
    {
        Task<List<UserDto>> GetUsers();
    }
}
