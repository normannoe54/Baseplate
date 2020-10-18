using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ObjectModel;

namespace WPF
{
    class State
    {
        private State() { }

        private static State _instance = null;

        public static State instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new State();
                }
                return _instance;
            }
        }



        public Baseplate basePlate = new Baseplate();
        public AnchorBolt anchorBolt = new AnchorBolt();
        public BPTransfer bPTransfer = new BPTransfer();

    }
}
