using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectModel
{
    /// <summary>
    /// This is the serializable object that is sent to Revit and to the designer
    /// </summary>
    public class BPDesign
    {
        public ISection _column { get; set; }
        public Baseplate _bp { get; set; }
        public Foundation _fndn { get; set; }
        public ExportedResults _exres { get; set; }
    }
}
