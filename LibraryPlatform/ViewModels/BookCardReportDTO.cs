using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryPlatform.ViewModels
{
    public class BookCardReportDTO
    {
            public BookCardReportDTO() { }
            public int НомерЧитательскогоБилета { get; set; }
            public string ФИО { get; set; }
            public string Телефон { get; set; }
            public string Адрес { get; set; }
            public DateTime ДатаВыдачи { get; set; }
            public DateTime ДатаВозврата { get; set; }
    }
}
