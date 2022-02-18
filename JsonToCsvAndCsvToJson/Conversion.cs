using CsvHelper;
using FileIoOperation.JSONDataFormat;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileIoOperation.JsonToCsvAndCsvToJson
{
    /// <summary>
    /// MEthod to read and write data from and to json and from and to csv
    /// </summary>
    public class Conversion
    {
        //Method to use Jsonconvert serializeObject to convert object to json string data to write into the file
        public static void JsonSerialize(string jsonFilePath, List<Student> students)
        { 
            //converting the student object to json string format
            string res = JsonConvert.SerializeObject(students);
            File.WriteAllText(jsonFilePath, res);
            Console.WriteLine("Data Written Succesfully");
        }

        //Method to use Jsonconvert DeserializeObject to convert json string data to specified object to read data from the file
        public static List<Student> JsonDeSerialize()
        {
            string jsonFilePath = @"E:\CODING\Coding\React Web Apps\coreAPI\Fellowship\RegularExpression\FileIoOperation\TextFilesIO\JsonData.json";
            string res = File.ReadAllText(jsonFilePath);
            List<Student> list = JsonConvert.DeserializeObject<List<Student>>(res);
            Console.WriteLine("Data Read Succesfully");
            return list;
        }

        //Method to serialized the data into csv file from list of object          
        public static void CsvSerialize(string csvFilePath, List<Student> students)
        {
            StreamWriter streamWriter = new StreamWriter(csvFilePath);
            CsvWriter csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture);
            csvWriter.WriteRecords(students);
            Console.WriteLine("Data Written Succesfully");
            streamWriter.Flush();
            streamWriter.Close();
        }

        //Method to deserialized the data from csv file into list of object          
        public static List<Student> CsvDeSerialize()
        {
            string csvFilePath = @"E:\CODING\Coding\React Web Apps\coreAPI\Fellowship\RegularExpression\FileIoOperation\TextFilesIO\CsvData.csv";
            StreamReader streamReader = new StreamReader(csvFilePath);
            CsvReader csvReader = new CsvReader(streamReader, CultureInfo.InvariantCulture);
            List<Student> students = csvReader.GetRecords<Student>().ToList();
            Console.WriteLine("Data Read Succesfully");
            streamReader.Close();
            return students;
        }
    }
}
