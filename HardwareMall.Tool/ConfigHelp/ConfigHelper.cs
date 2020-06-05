using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using System;
using System.IO;

namespace HardwareMall.Tool
{
    public class ConfigHelper
    {
        public static IConfiguration Configuration { get; set; }
        static ConfigHelper()
        {
            Configuration = new ConfigurationBuilder()
                            .SetBasePath(Directory.GetCurrentDirectory())
                            .Add(new JsonConfigurationSource { Path = "appsettings.json", Optional = false, ReloadOnChange = true })//这样的话，可以直接读目录里的json文件，而不是 bin 文件夹下的，所以不用修改复制属性
                            .Build();
        }
    }
}
