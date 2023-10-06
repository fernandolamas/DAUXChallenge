using DauxChallengeCommon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace DauxChallengeService.Services.EncryptService
{
    public interface IEncryptService
    {
        public Task<string> EncryptAsync(IdentityViewModel identity);
    }
}
