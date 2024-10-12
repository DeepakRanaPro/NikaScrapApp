using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NikaScrapApp.Infrastructure.Repositories
{
    internal class PickUpInfoRepository
    {
        private readonly string _connectionString;
        public PickUpInfoRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

    }
}
