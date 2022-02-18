using CsvHelper;
using FileIoOperation.JSONDataFormat;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileIoOperation.CsvFileOperations
{
    /// <summary>
    /// Csv Io Operations Program
    /// </summary>
    public class CsvDataOperations
    {
        //Declaring csv file path
        public static string csvFilePath = @"E:\CODING\Coding\React Web Apps\coreAPI\Fellowship\RegularExpression\FileIoOperation\TextFilesIO\CsvData.csv";

        //Method to serialized the data into csv file from list of object          
        public static void CsvSerialize()
        {
            List<Student> students = new List<Student>()
            {
            new Student() { FName = "Raj", LName = "Verma", Address = "Mumbai", ZipCode = 987445 },
            new Student() { FName = "Yash", LName = "Verma", Address = "NaviMumbai", ZipCode = 987456 },
            new Student() { FName = "Mansi", LName = "Verma", Address = "Delhi", ZipCode = 987756 }
            };
            StreamWriter streamWriter = new StreamWriter(csvFilePath);
            CsvWriter csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture);
            csvWriter.WriteRecords(students);
            streamWriter.Flush(); 
            streamWriter.Close();
        }

        //Method to deserialized the data from csv file into list of object          
        public static void CsvDeSerialize()
        {
            StreamReader streamReader = new StreamReader(csvFilePath);
            CsvReader csvReader = new CsvReader(streamReader, CultureInfo.InvariantCulture);
            List<Student> res = csvReader.GetRecords<Student>().ToList();
            foreach(Student student in res)
            {
                Console.WriteLine(student);
            }
            streamReader.Close();
        }
    }
}
