﻿using DigitalKabadiApp.Core.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalKabadiApp.Core.Interfaces.Repository
{
    public interface ISmsRepository
    {
        bool SaveSmsApiResponse(SmsApi SmsApiResponse);
    }
}
