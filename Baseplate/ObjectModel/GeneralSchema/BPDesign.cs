﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectModel
{
    /// <summary>
    /// This is the serializable object that is sent to the designer
    /// </summary>
    public class BPDesign
    {
        public readonly ColumnDet _columndet;
        public readonly Baseplate _bp;
        public readonly Foundation _fndn;
        public readonly ExportedResults _exres;
        public BPDesign(ColumnDet columndet, Baseplate bp, Foundation fndn, ExportedResults exres)
        {
            columndet._section.
            _columndet = columndet;
            _bp = bp;
            _fndn = fndn;
            _exres = exres;
        }
    }
}
