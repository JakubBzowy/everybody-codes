using EverybodyCodes.Domain.Entities;

namespace EverybodyCodes.Application.Cameras
{
    public interface ICamerasService
    {
        Task<IEnumerable<Camera>> GetAllCamerasAsync();
        Task<IEnumerable<Camera>> SearchForCamerasByNameAsync(string name);
    }
}
