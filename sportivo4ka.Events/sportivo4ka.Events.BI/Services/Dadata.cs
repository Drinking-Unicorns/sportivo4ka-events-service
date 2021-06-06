using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sportivo4ka.Events.BI.Interfaces;
using sportivo4ka.Events.BI.Options;
using sportivo4ka.Events.Data.Base;
using AutoMapper;
using Dadata;
using Dadata.Model;

namespace sportivo4ka.Events.BI.Services
{
    public class Dadata : IDadata
    {
        private readonly IMapper _mapper;
        private readonly DadataConfig _config;

        public Dadata(IMapper mapper, DadataConfig config)
        {
            _mapper = mapper;
            _config = config;
        }

        public async Task<string> GetAddressAsync(Cords cords)
        {
            var api = new SuggestClientAsync(_config.Token);
            var result = await api.Geolocate(lat: cords.Lat, lon: cords.Lng);

            return result.suggestions.Any() ? result.suggestions[0].value : null;
        }

        public string GetAddress(Cords cords)
        {
            var api = new SuggestClientAsync(_config.Token);
            var result = Task.Run(async () => await api.Geolocate(lat: cords.Lat, lon: cords.Lng)).Result;

            return result.suggestions.Any() ? result.suggestions[0].value : null;
        }

        public Cords GetCoordinates(string address)
        {
            var api = new CleanClientAsync(_config.Token, _config.Secret);
            var result = Task.Run(async () => await api.Clean<Address>(address)).Result;

            if (int.TryParse(result.qc_geo, out int qc_geo) && qc_geo < 3)
                return _mapper.Map<Cords>(result);

            return null;
        }

        public async Task<Cords> GetCoordinatesAsync(string address)
        {
            var api = new CleanClientAsync(_config.Token, _config.Secret);
            var result = await api.Clean<Address>(address);

            if(int.TryParse(result.qc_geo, out int qc_geo) && qc_geo < 3)
                return _mapper.Map<Cords>(result);

            return null;
        }
    }
}
