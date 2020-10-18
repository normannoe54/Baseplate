using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectModel
{
    public class ExportedResults
    {
        /// <summary>
        /// uuid extracted data
        /// </summary>
        public string _name { get; set; }

        /// <summary>
        /// section
        /// </summary>
        public Column _column { get; set; }

        /// <summary>
        /// design results
        /// </summary>
        public List<ForceObject> _exportedforces { get; set; }
    }
}
