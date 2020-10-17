using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAP2000v1;
using ObjectModel;
using System.Linq.Expressions;
using System.Runtime.InteropServices;

namespace DataExtraction.Testing
{
    class Program
    {
        static void Main(string[] args)
        {
            //Program starts here
            //set the following flag to true to attach to an existing instance of the program

            //otherwise a new instance of the program will be started

            bool AttachToInstance = true;



            //set the following flag to true to manually specify the path to SAP2000.exe

            //this allows for a connection to a version of SAP2000 other than the latest installation

            //otherwise the latest installed version of SAP2000 will be launched
            bool SpecifyPath = false;



            //if the above flag is set to true, specify the path to SAP2000 below

            string ProgramPath;

            ProgramPath = @"C:\Program Files\Computers and Structures\SAP2000 22\SAP2000.exe";



            //full path to the model

            //set it to the desired path of your model

            string ModelDirectory = @"C:\CSiAPIexample";

            try

            {

                System.IO.Directory.CreateDirectory(ModelDirectory);

            }

            catch (Exception ex)

            {

                Console.WriteLine("Could not create directory: " + ModelDirectory);

            }

            string ModelName = "API_1-001.sdb";

            string ModelPath = ModelDirectory + System.IO.Path.DirectorySeparatorChar + ModelName;



            //dimension the SapObject as cOAPI type

            cOAPI mySapObject = null;



            //Use ret to check if functions return successfully (ret = 0) or fail (ret = nonzero)

            int ret = 0;



            //create API helper object

            cHelper myHelper;

            try

            {

                myHelper = new Helper();

            }

            catch (Exception ex)

            {

                Console.WriteLine("Cannot create an instance of the Helper object");

                return;

            }





            if (AttachToInstance)

            {

                //attach to a running instance of SAP2000

                try

                {

                    //get the active SapObject

                    mySapObject = myHelper.GetObject("CSI.SAP2000.API.SapObject");

                }

                catch (Exception ex)

                {

                    Console.WriteLine("No running instance of the program found or failed to attach.");

                    return;

                }

            }

            else

            {

                if (SpecifyPath)

                {

                    //'create an instance of the SapObject from the specified path

                    try

                    {

                        //create SapObject

                        mySapObject = myHelper.CreateObject(ProgramPath);

                    }

                    catch (Exception ex)

                    {

                        Console.WriteLine("Cannot start a new instance of the program from " + ProgramPath);
                        return;

                    }
                }

                else

                {

                    //create an instance of the SapObject from the latest installed SAP2000
                    try
                    {
                        //create SapObject
                        mySapObject = myHelper.CreateObjectProgID("CSI.SAP2000.API.SapObject");
                    }

                    catch (Exception ex)
                    {
                        Console.WriteLine("Cannot start a new instance of the program.");
                        return;
                    }
                }

                //start SAP2000 application

                ret = mySapObject.ApplicationStart();

            }

            //create SapModel object
            cSapModel mySapModel;      
            mySapModel = mySapObject.SapModel;

            eUnits test = mySapModel.GetDatabaseUnits();

            //mySapModel.FrameObj.GetSelected;
            bool selected = false;
            string name = "183";
            ret = mySapModel.FrameObj.GetSelected(name, ref selected);

            

            if (selected)
            {
                string point1 = "";
                string point2 = "";
                mySapModel.FrameObj.GetPoints(name, ref point1, ref point2);

                double x1 = 0;
                double y1 = 0;
                double z1 = 0;

                double x2 = 0;
                double y2 = 0;
                double z2 = 0;

                mySapModel.PointObj.GetCoordCartesian(point1, ref x1, ref y1, ref z1);
                mySapModel.PointObj.GetCoordCartesian(point1, ref x2, ref y2, ref z2);

                //Get Load Cases 
                int loadCaseNumber = 0;
                string[] loadCaseNames= { "" };

                //check version of the method
                mySapModel.LoadCases.GetNameList_1(ref loadCaseNumber,ref loadCaseNames);
                foreach(string i in loadCaseNames)
                {
                    if("env" in i)
                        {

                    }
                }

                //Get Forces
                double Fx = 0;
                double Fy = 0;
                double Fz = 0;
                double Mx = 0;
                double My = 0;
                double Mz = 0;
                int ResultNumber = 1;
                string frameResult = " ";
                string stepType = "";
                string stepNum = "";
 

                // Check z coordinate

                if (z1<z2)
                {
                    mySapModel.Results.FrameJointForce(name, mySapModel.FrameObj, ref ResultNumber, ref frameResult, point1, LoadCase, ref stepType, ref stepNum, ref Fx, ref Fy, ref Fz, ref Mx, ref My, ref Mz);


                }
                if(z)
                {
                    //use this to get reactions -> mySapModel.Results
                }


                //here check z or check if restrained
                //mySapModel.PointObj.GetConstraint( )



                List<ForceObject> exportforce = new List<ForceObject>();
                ForceObject fobj = new ForceObject(1, 1, 1, 1, 1, 1,name);
                exportforce.Add(fobj);
            }

            


            //Get frame thats selected
            //Find base point
            //Get results from base point
            //If results = nothing throw message to user that selection is wrong
            //Else get base point reactions

            ////initialize model
            //ret = mySapModel.InitializeNewModel((eUnits.kip_in_F));

            ////create new blank model

            //ret = mySapModel.File.NewBlank();



        }
    }
}
