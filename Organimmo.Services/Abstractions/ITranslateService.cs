﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Organimmo.DAL;
using Organimmo.Services.Model;

namespace Organimmo.Services.Abstractions
{
    public interface ITranslateService
    {
        Task<string> TranslateWord(string text, string translation);
    }
}
