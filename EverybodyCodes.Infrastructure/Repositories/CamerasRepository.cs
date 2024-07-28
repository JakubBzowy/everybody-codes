using EverybodyCodes.Domain.Entities;
using EverybodyCodes.Domain.Repositories;

namespace EverybodyCodes.Infrastructure.Repositories
{
    public class CamerasRepository : ICamerasRepository
    {
        private readonly string _filePath;
        public CamerasRepository(string filePath)
        {
            _filePath = filePath;
        }

        public async Task<IEnumerable<Camera>> GetAllCamerasAsync()
        {
            List<Camera> cameras = new List<Camera>();

            using (var reader = new StreamReader(_filePath))
            {
                //header line
                await reader.ReadLineAsync();

                string line;

                while ((line = await reader.ReadLineAsync()) != null)
                {
                    var cameraElements = line.Split(';');

                    if (cameraElements.Length >= 3) {
                        cameras.Add(new Camera
                        {
                            Number = ExtractNumber(cameraElements[0]),
                            Name = cameraElements[0],
                            Latitude = cameraElements[1],
                            Longitude = cameraElements[2],
                        });
                    }
                }
            }

            return cameras;
        }

        public async Task<IEnumerable<Camera>> SearchForCamerasByNameAsync(string name)
        {
            var allCameras = await GetAllCamerasAsync();
            var result = allCameras.Where(c => c.Name.Contains(name));

            return result;
        }

        private int ExtractNumber(string name)
        {
            //Not sure how extracting number should work.
            var parts = name.Split(new char[] { '-', ' ' });

            if (parts.Length >= 3)
            {
                return int.Parse(parts[2]);
            }

            return -1;
        }
    }
}
