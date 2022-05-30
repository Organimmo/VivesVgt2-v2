using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Organimmo.Services.Model;

namespace Organimmo.SDK.Contract
{
    public interface  ITranslateAPI
    {
        Task<RootDto> Get(int id);
    }
}
