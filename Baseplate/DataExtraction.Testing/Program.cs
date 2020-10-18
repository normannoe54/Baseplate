using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAP2000v1;
using ObjectModel;

namespace DataExtraction.Testing
{
    class Program
    {
        static void Main(string[] args)
        {
            //Attach to existing SAP2000v22 model
            cHelper myHelper = new Helper();
            cOAPI mySapObject = myHelper.GetObject("CSI.SAP2000.API.SapObject");
            cSapModel mySapModel = mySapObject.SapModel;

            //Get list of all frames
            int numbernames = 0;
            string[] names = null;
            mySapModel.FrameObj.GetNameList(ref numbernames, ref names);

            string outputname = "";

            for (int i = 0; i < numbernames; i++)
            {
                bool notselected = false;
                mySapModel.FrameObj.GetSelected(names[i], ref notselected);

                if (!notselected)
                {
                    outputname = names[i];
                    break;
                }
            }

            string point1 = "";
            string point2 = "";
            mySapModel.FrameObj.GetPoints(outputname, ref point1, ref point2);

            double x1 = 0;
            double y1 = 0;
            double z1 = 0;

            double x2 = 0;
            double y2 = 0;
            double z2 = 0;

            mySapModel.PointObj.GetCoordCartesian(point1, ref x1, ref y1, ref z1);
            mySapModel.PointObj.GetCoordCartesian(point2, ref x2, ref y2, ref z2);

            string pointname = point1;
            if (z2 < z1)
            {
                pointname = point2;
            }

            int numres = 0;
            string[] obj = null;
            string[] elm = null;
            string[] loadcase = null;
            string[] steptype = null;
            double[] stepnum = null;
            double[] f1 = null;
            double[] f2 = null;
            double[] f3 = null;
            double[] m1 = null;
            double[] m2 = null;
            double[] m3 = null;

            mySapModel.Results.JointReact(pointname, eItemTypeElm.ObjectElm, ref numres, ref obj, ref elm, ref loadcase, ref steptype, ref stepnum, ref f1, ref f2, ref f3, ref m1, ref m2, ref m3);

            List<ForceObject> exportforce = new List<ForceObject>();

            for (int j = 0; j < numres; j++)
            {
                ForceObject fobj = new ForceObject(f1[j], f2[j], f3[j], m1[j], m2[j], m3[j]);
                exportforce.Add(fobj);

            }

            string propname = "";
            string sauto = "";
            mySapModel.FrameObj.GetSection(outputname, ref propname, ref sauto);
            double fy = 0;
            double fu = 0;
            double efy = 0;
            double efu = 0;
            int sstype = 0;
            int sshys = 0;
            double strainhard = 0;
            double strainmax = 0;
            double strainrupt = 0;
            mySapModel.PropMaterial.GetOSteel(propname, ref fy, ref fu, ref efy, ref efu, ref sstype, ref sshys, ref strainhard, ref strainmax, ref strainrupt);
            Steel steel = new Steel(propname, fy);
            Column col = new Column(propname, steel);
            ExportedResults expres = new ExportedResults();
            expres._column = col;
            expres._name = outputname;
            expres._exportedforces = exportforce;
            return;
        }
    }
}
