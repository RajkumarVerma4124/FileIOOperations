using FileIoOperation.JSONDataFormat;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace FileIoOperation.XmlFileIOOperations
{
    /// <summary>
    /// Xml File Io Operations
    /// </summary>
    public class XmlFileOperation
    {
        //Declaring xml file path
        public static string xmlFilePath = @"E:\CODING\Coding\React Web Apps\coreAPI\Fellowship\RegularExpression\FileIoOperation\TextFilesIO\XmlData.xml";

        //Method to serialized the data into xml file from list of object          
        public static void XmlSerialize()
        {
            List<Student> students = new List<Student>()
            {
            new Student() { FName = "Raj", LName = "Verma", Address = "Mumbai", ZipCode = 987445 },
            new Student() { FName = "Yash", LName = "Verma", Address = "NaviMumbai", ZipCode = 987456 },
            new Student() { FName = "Mansi", LName = "Verma", Address = "Delhi", ZipCode = 987756 }
            };
            FileStream stream = new FileStream(xmlFilePath, FileMode.OpenOrCreate);
            XmlSerializer xml = new XmlSerializer(typeof(List<Student>));  
            xml.Serialize(stream, students);        
            stream.Close();
        }

        //Method to deserialized the data from xml file to list of object          
        public static void XmlDeSerialize()
        {
            FileStream stream = new FileStream(xmlFilePath, FileMode.OpenOrCreate);
            XmlSerializer xml = new XmlSerializer(typeof(List<Student>));
            List<Student> students = (List<Student>)xml.Deserialize(stream);
            foreach(Student student in students)
            {
                Console.WriteLine(student);
            }
            stream.Flush();
            stream.Close();
        }
    }
}
