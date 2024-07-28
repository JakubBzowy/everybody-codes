using EverybodyCodes.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EverybodyCodes.Domain.Repositories
{
    public interface ICamerasRepository
    {
        Task<IEnumerable<Camera>> GetAllCamerasAsync();
        Task<IEnumerable<Camera>> SearchForCamerasByNameAsync(string name);
    }
}
