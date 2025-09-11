using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M2Corte2025.FormationFred.Services.Core
{
    public static class StringExtensions
    {
        public static String? GetConfigValueFor(this string key, String sectionName= "ApplicationSettings")
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional:false, reloadOnChange: true).Build();

            return builder.GetSection(sectionName)[key]?.ToString();
        }
    }
}
