using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace FileIoOperation.BinaryDataFormat
{
    /// <summary>
    /// Binary IO Operations
    /// </summary>
    public class BinaryIODataperations
    {
        //Method to use binary serialize to add streams of data into the file
        public static void BinarySerialize()
        {
            string binaryFilePath = @"E:\CODING\Coding\React Web Apps\coreAPI\Fellowship\RegularExpression\FileIoOperation\TextFilesIO\BinaryData.bin";
            Contact contact = new Contact() { FName="Raj", LName="Verma", Address="Mumbai", ZipCode=987456 };
            FileStream stream = new FileStream(binaryFilePath, FileMode.OpenOrCreate);
            BinaryFormatter binary = new BinaryFormatter();
            binary.Serialize(stream, contact);
            stream.Close();
        }

        //Method to use binary deserialize to read streams of data from the file
        public static void BinaryDeSerialize()
        {
            string binaryFilePath = @"E:\CODING\Coding\React Web Apps\coreAPI\Fellowship\RegularExpression\FileIoOperation\TextFilesIO\BinaryData.bin";
            FileStream stream = new FileStream(binaryFilePath, FileMode.Open);
            BinaryFormatter binary = new BinaryFormatter();
            Contact res = (Contact)binary.Deserialize(stream);
            Console.WriteLine(res);
            stream.Close();
        }
    }

    /// <summary>
    /// Created the contact class for binary serialization and deserialization
    /// </summary>
    [Serializable]
    public class Contact
    {
        //Declaring properties
        public string FName { get; set; }
        public string LName { get; set; }
        public string Address { get; set; }
        public int ZipCode { get; set; }

        //Overriding the tostring method
        public override string ToString()
        {
            return $"FirstName: {FName} \tLastName: {LName} \tAddress: {Address} \tZipCode:{ZipCode}";
        }
    }
}
