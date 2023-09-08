using DigitalOcean.API;
using DigitalOcean.API.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalOceanConnectDesktop
{
    public class DropletManager
    {
        private DigitalOceanClient client;
        public DropletManager(String Key)
        {
            client = new DigitalOceanClient(Key);
        }

        public Task<IReadOnlyList<DigitalOcean.API.Models.Responses.Droplet>> GetDroplets()
        {
            var droplets = client.Droplets.GetAll();
            return droplets;
        }

        public async void CreateDroplet(String name, String region, String size, String image)
        {
            await client.Droplets.Create(new DigitalOcean.API.Models.Requests.Droplet
            {
                Name = name,
                Region = region,
                Size = size,
                Image = image
            });
        }

        public async void DeleteDroplet(int id)
        {
            await client.Droplets.Delete(id);
        }

    }
}
