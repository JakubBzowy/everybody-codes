using EverybodyCodes.Domain.Entities;
using EverybodyCodes.Domain.Repositories;

namespace EverybodyCodes.Application.Cameras
{
    public class CamerasService : ICamerasService
    {
        private readonly ICamerasRepository _cameraRepository;
        public CamerasService(ICamerasRepository cameraRepository)
        {
            _cameraRepository = cameraRepository;
        }
        public async Task<IEnumerable<Camera>> GetAllCamerasAsync()
        {
            var result = await _cameraRepository.GetAllCamerasAsync();

            return result;
        }

        public async Task<IEnumerable<Camera>> SearchForCamerasByNameAsync(string name)
        {
            var result = await _cameraRepository.SearchForCamerasByNameAsync(name);

            return result;
        }
    }
}
