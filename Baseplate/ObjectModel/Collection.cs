using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;

namespace ObjectModel
{
    public static class Collection
    {
        public static ISection GetISectionbyName(string name)
        {
            //Collect
            List<ISection> collection = CollectISection();

            //Search and Find
            ISection output = collection.Find(x => x._name == name);

            return output;
        }


        public static List<ISection> CollectISection()
        {
            string inputdata = Properties.Resources.ResourceManager.GetString("WShape.csv");
            List<ISection> isect = new List<ISection>();
            string[] RowsArray = inputdata.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            isect.AddRange(RowsArray.Skip(1).Select(v => ObjectfromCSV<ISection>(v)).ToList());

            return isect;
        }

        public static T ObjectfromCSV<T>(string csvline)
        {
            string[] values = csvline.Split(',');
            List<object> obj = new List<object>();

            //Replace this with a get constructor approach
            ConstructorInfo[] constrInfoObj = typeof(T).GetConstructors();

            //ParameterInfo
            ParameterInfo[] paraminfo = constrInfoObj[0].GetParameters();

            //Cycle through constructors available parameters
            for (int i = 0; i < paraminfo.Count(); i++)
            {
                //convert the string to the specified units
                StringToUnitsConverter(values[i], paraminfo[i].ParameterType, ref obj);
            }

            T result = (T)Activator.CreateInstance(typeof(T), obj.ToArray());

            return result;
        }

        /// <summary>
        /// convert string in csv to units
        /// </summary>
        /// <param name="val"></param>
        /// <param name="paramtype"></param>
        /// <param name="obj"></param>
        public static void StringToUnitsConverter(string val, Type paramtype, ref List<object> obj)
        {
            //string
            if (paramtype == typeof(string))
            {
                //just as it is
                obj.Add(val);
            }
            //double
            else if (paramtype == typeof(double))
            {
                //convert to double if not empty
                obj.Add((!string.IsNullOrEmpty(val) ? System.Convert.ToDouble(val) : 0));
            }
            //Enum
            else if (paramtype.IsEnum)
            {
                var value = Enum.Parse(paramtype, val);

                if (value != null)
                {
                    obj.Add(value);
                }
            }
        }
    }
}
