using CsvHelper;
using FileIoOperation.JSONDataFormat;
using FileIoOperation.JsonToCsvAndCsvToJson;
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
    /// Read And Write From And To Json And Csv File Program
    /// </summary>
    public class JsonCsvDataOperations
    {
        //Calling the method to read data from csv and write into json
        public static void ReadFromCsvWriteIntoJson()
        {
            string csvDataFromJson = @"E:\CODING\Coding\React Web Apps\coreAPI\Fellowship\RegularExpression\FileIoOperation\TextFilesIO\JsonData.Json";
            List<Student> students = Conversion.CsvDeSerialize();
            Conversion.JsonSerialize(csvDataFromJson, students);
        }

        //Calling the method to read data from json and write into csv
        public static void ReadFromJsonWriteIntoCsv()
        {
            string jsonDataFromCsv = @"E:\CODING\Coding\React Web Apps\coreAPI\Fellowship\RegularExpression\FileIoOperation\TextFilesIO\CsvData.csv";
            List<Student> students = Conversion.JsonDeSerialize();
            Conversion.CsvSerialize(jsonDataFromCsv, students);
        }
    }
}
