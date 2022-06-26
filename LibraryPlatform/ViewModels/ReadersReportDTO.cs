using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryPlatform.ViewModels
{
    public class ReadersReportDTO
    {
        public string НомерЭкземпляра { get; set; }
        public string НазваниеКниги { get; set; }

        public string Автор { get; set; }

        public string Издатель { get; set; }

        public DateTime ДатаВыдачи { get; set; }
        public DateTime ДатаВозврата { get; set; }

        public string Возвращена { get; set; }
    }
}
