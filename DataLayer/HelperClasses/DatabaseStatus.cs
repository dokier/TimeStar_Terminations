using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.HelperClasses
{
    public class DatabaseStatus
    {
        public string ServerName { get; set; }
        public string DatabaseName { get; set; }
        public bool ReadOnly { get; set; }
        public string StateDesc { get; set; }
        public DateTime BackupDate { get; set; }
    }
}
