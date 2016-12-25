using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IAMPM.Services.Interfaces;

namespace IAMPM.Services.Implementations
{
    public class ConfigurationService : IConfigurationService
    {
        public int MaxPlayersCount { get; }
        public int MinPlayersCount { get; }
        public int DefStartDevCardsCount { get; }
        public int DefStartProjectWorkload { get; }
        public int DefStartProjectPeriod { get; }

        public ConfigurationService()
        {
            MaxPlayersCount = 5;
            MinPlayersCount = 1;
            DefStartDevCardsCount = 4;
            DefStartProjectWorkload = 1000;
            DefStartProjectPeriod = 5;


        }
    }
}
