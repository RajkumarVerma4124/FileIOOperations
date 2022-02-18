using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using FileIoOperation.BinaryDataFormat;
using FileIoOperation.JSONDataFormat;
using FileIoOperation.XmlFileIOOperations;
using FileIoOperation.CsvFileOperations;
using FileIoOperation.JsonToCsvAndCsvToJson;

namespace FileIoOperation
{
    /// <summary>
    /// File Input Output Operations Program
    /// </summary>
    public class Program
    {
        //Declaring default file path
        public static string path = @"E:\CODING\Coding\React Web Apps\coreAPI\Fellowship\RegularExpression\FileIoOperation\TextFilesIO\TextFile.txt";

        //Main entry of the program
        public static void Main(string[] args)
        {
            //Displaying the welcome message
            Console.WriteLine("Welcome To The File IO Operataions");
            try
            {
                while (true)
                {
                    Console.WriteLine("1: Check File Exist \n2: ReadLineByLine \n3: ReadAllText \n4: Copy File Content \n5: Delete File \n6: Stream Data Reader"+
                                      "\n7: Stream Data Write \n8: Binary Serialization \n9: Binary Deserialization \n10: Json Serialization \n11: Json Deserialization \n12: Read Given File"+
                                      "\n13: Xml Read And Write Operations \n14: Csv Read And Write Operations \n15: Read Data From Csv And Write Into Json \n16: Read Data From Json And Write Into Csv \n17: Exit");
                    Console.Write("Enter a choice from above : ");
                    bool flag = int.TryParse(Console.ReadLine(), out int choice);
                    if (flag)
                    {
                        switch (choice)
                        {
                            case 1:
                                //Define the path of the file to check if its exist or not
                                bool res = IsFileExists(path);
                                if (res)
                                    Console.WriteLine("File Exists");
                                else
                                    Console.WriteLine("File Doesn't Exist");
                                break;
                            case 2:
                                //Calling the method to read the file line by line 
                                ReadLineByLine(path);
                                break;
                            case 3:
                                //Calling the method to read all text in a single string from given file
                                ReadAllTextFromFile(path);
                                break;
                            case 4:
                                //Calling the method to copy the file to another file
                                Console.Write("Enter a name for the file : ");
                                CopyFileContent(path, Console.ReadLine());
                                break;
                            case 5:
                                //Calling the method to delete the file from given path
                                Console.Write("Enter a name for the file you want ot delete : ");
                                DeleteFile(Console.ReadLine());
                                break;
                            case 6:
                                //Calling the method to use streamreader that reads the data from file using stream
                                ReadFromStreamReader(path);
                                break;
                            case 7:
                                //Method to use streamwriter that writes the data into file using stream
                                Console.Write("Enter a line you want to add into string : ");
                                WriteUsingStreamWriter(path, Console.ReadLine());
                                break;
                            case 8:
                                //Calling the binary serialize method
                                BinaryIODataperations.BinarySerialize();
                                break;
                            case 9:
                                //Calling the binary deserialize method
                                BinaryIODataperations.BinaryDeSerialize();
                                break;
                            case 10:
                                //Calling the json serialize method
                                JsonIODataOpertions.JsonSerialize();
                                break;
                            case 11:
                                //Calling the json deserialize method
                                JsonIODataOpertions.JsonDeSerialize();
                                break;
                            case 12:
                                //Calling the method to read the file line by line 
                                Console.Write("Enter a name of the file you want to read : ");
                                ReadFileLineByLine(Console.ReadLine());
                                break;
                            case 13:
                                //Calling the method to read and write the csv file 
                                CsvDataOperations.CsvSerialize();
                                CsvDataOperations.CsvDeSerialize();
                                break;
                            case 14:
                                //Calling the method to read and write the xml file 
                                XmlFileOperation.XmlSerialize();
                                XmlFileOperation.XmlDeSerialize();
                                break;
                            case 15:
                                //Calling the method to read data from csv and write into json
                                JsonCsvDataOperations.ReadFromCsvWriteIntoJson();
                                break;
                            case 16:
                                //Calling the method to read data from json and write into csv
                                JsonCsvDataOperations.ReadFromJsonWriteIntoCsv();
                                break;
                            case 17:
                                //For exiting the console
                                Environment.Exit(0);
                                break;
                            default:
                                Console.WriteLine("Enter right choice");
                                continue;
                        }
                    }
                    else
                        Console.WriteLine("Enter some input value");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }

        //Method to check the file exist on a given path or not
        public static bool IsFileExists(string path)
        {
            if(File.Exists(path))
                return true;
            else
                return false;
        }

        //Method to read the file line by line if file exist
        public static void ReadLineByLine(string path)
        {
            if (IsFileExists(path))
            {
                string[] linesStr = File.ReadAllLines(path);
                foreach (string line in linesStr)
                    Console.WriteLine(line);
            }
        }

        //Method to read given file line by line if file exist
        public static void ReadFileLineByLine(string fileName)
        {
            string destPath = $"E:\\CODING\\Coding\\React Web Apps\\coreAPI\\Fellowship\\RegularExpression\\FileIoOperation\\TextFilesIO\\{fileName}.txt";
            if (IsFileExists(destPath))
            {
               string[] linesStr =  File.ReadAllLines(path);
                foreach(string line in linesStr)
                    Console.WriteLine(line);
            }
        }

        //Method to read all text in a single string from given file
        public static void ReadAllTextFromFile(string path)
        {
            if (IsFileExists(path))
            {
                string textStr = File.ReadAllText(path);
                Console.WriteLine(textStr);
            }
        }

        //Method to copy the file to another file
        public static void CopyFileContent(string path, string fileName)
        {
            string destPath = $"E:\\CODING\\Coding\\React Web Apps\\coreAPI\\Fellowship\\RegularExpression\\FileIoOperation\\TextFilesIO\\{fileName}.txt";
            if (IsFileExists(path) && IsFileExists(destPath))
                DeleteFile(fileName);
            else
                File.Copy(path, destPath);
        }

        //Method to delete the file from given path
        public static void DeleteFile(string fileName)
        {
            string destPath = $"E:\\CODING\\Coding\\React Web Apps\\coreAPI\\Fellowship\\RegularExpression\\FileIoOperation\\TextFilesIO\\{fileName}.txt";
            if (IsFileExists(destPath))
            {
                File.Delete(destPath);
                Console.WriteLine("The existed file with given name is deleted");
            }
        }

        //Method to use streamreader that reads the data from file using stream
        public static void ReadFromStreamReader(string path)
        {
            string line = "";
            if (IsFileExists(path))
            {
                StreamReader sr = File.OpenText(path);
                while((line=sr.ReadLine())!=null)
                {
                    Console.WriteLine(line);
                }
                sr.Close();
            }
        }

        //Method to use streamwriter that writes the data into file using stream
        public static void WriteUsingStreamWriter(string path, string userStr)
        {
            if (IsFileExists(path))
            {
                StreamWriter sw = File.AppendText(path);
                sw.WriteLine("\n"+userStr);
                sw.Close();
                ReadAllTextFromFile(path);
            }
        }
    }
}
