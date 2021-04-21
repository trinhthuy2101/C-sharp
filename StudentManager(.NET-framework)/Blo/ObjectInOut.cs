using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using StudentManager.Model;
namespace StudentManager.Blo
{
    class ObjectInOut
    {
        private const string filePath = @"Student.SM";
        public static int Save(DataContext dataContext)
        {
            try
            {
                IFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream(filePath, FileMode.Create, FileAccess.Write);

                formatter.Serialize(stream, dataContext);
                stream.Close();

            }
            catch (Exception ex)
            {

                return -1;
            }
            return 1;
        }

        public static DataContext ReadData()
        {
            DataContext objnew = null;
            try
            {
                IFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                objnew = (DataContext)formatter.Deserialize(stream);
            }
            catch (Exception ex)
            {
                return null;
            }

            return objnew;
        }
    }
}
