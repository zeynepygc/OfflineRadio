using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OfflineRadio.Models
{
    public class RadioProgram
    {
        public string Title { get; set; }
        public string URL { get; set; }
        public TimeSpan Duration { get; set; }
        public DateTime LastDownloaded { get; set; }
        public string FilePath { get; set; }
    }
}


