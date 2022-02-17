using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileIoOperation.JSONDataFormat
{
    /// <summary>
    /// JSON IO Operations
    /// </summary>
    public class JsonIODataOpertions
    {
        //Method to use Jsonconvert serializeObject to convert object to json string data to write into the file
        public static void JsonSerialize()
        {
            string jsonFilePath = @"E:\CODING\Coding\React Web Apps\coreAPI\Fellowship\RegularExpression\FileIoOperation\TextFilesIO\JsonData.json";
            List<Student> students = new List<Student>()
            {
                new Student() { FName = "Raj", LName = "Verma", Address = "Mumbai", ZipCode = 987445 },
                new Student() { FName = "Yash", LName = "Verma", Address = "NaviMumbai", ZipCode = 987456 },
                new Student() { FName = "Mansi", LName = "Verma", Address = "Delhi", ZipCode = 987756 }
            };
            //converting the student object to json string format
            string res =  JsonConvert.SerializeObject(students);
            File.WriteAllText(jsonFilePath, res);
        }

        //Method to use Jsonconvert DeserializeObject to convert json string data to specified object to read data from the file
        public static void JsonDeSerialize()
        {
            string jsonFilePath = @"E:\CODING\Coding\React Web Apps\coreAPI\Fellowship\RegularExpression\FileIoOperation\TextFilesIO\JsonData.json";
            string res = File.ReadAllText(jsonFilePath);
            List<Student> list =  JsonConvert.DeserializeObject<List<Student>>(res);
            foreach (Student student in list)
            {
                Console.WriteLine(student);
            }
        }
    }

    /// <summary>
    /// Created the student class for json conversion
    /// </summary>
    [Serializable]
    public class Student
    {
        //Declaring properties
        public string FName { get; set; }
        public string LName { get; set; }
        public string Address { get; set; }
        public int ZipCode { get; set; }

        //Overriding the tostring method
        public override string ToString()
        {;
            return $"FirstName : {FName} \tLastName : {LName} \tAddress : {Address} \tZipCode : {ZipCode}";
        }
    }
}
