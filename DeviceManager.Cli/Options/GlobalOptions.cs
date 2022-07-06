using CommandLine;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeviceManager.Cli.Options
{
    public class GlobalOptions
    {
        [Option('v', "verbose", Required = false, Default = false, HelpText = "Verbose option provides additional details")]
        public bool Verbose { get; set; }
        [Option('c', "connection", Required = true, HelpText ="Database Connection String")]
        public string ConnectionString { get; set; }
    }
}
