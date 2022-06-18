using eTuristickaAgencija.API.Database;
using eTuristickaAgencija.API.Helper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace eTuristickaAgencija.API
{
    public class SetupService
    {

        public  void Init(TuristickaAgencijaContext context)
        {
            context.Database.Migrate();
            

        }
    }
}
