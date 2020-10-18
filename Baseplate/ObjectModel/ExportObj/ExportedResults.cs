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
        public readonly string _name;

        /// <summary>
        /// section
        /// </summary>
        public readonly Column _column;

        /// <summary>
        /// design results
        /// </summary>
        public readonly List<ForceObject> _exportedforces;

        public ExportedResults(string name, Column column, List<ForceObject> exportedforces)
        {
            _name = name;
            _column = column;
            _exportedforces = exportedforces;
        }
    }
}
