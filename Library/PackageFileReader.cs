using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageFileReader.Library
{
    public class PackageFileReader
    {
        private Stream _stream;
        private StreamReader _reader;

        public PackageFileReader(string FileData)
        {
            _stream = new MemoryStream(Encoding.UTF8.GetBytes(FileData));
            _reader = new StreamReader(_stream);
        }

        public List<PackageModel> ReadPackages() 
        {
            List<PackageModel> packageModels = new List<PackageModel>();
            int i = 0;
            PackageModel packageModel = new PackageModel();
            while (true)
            {
                String line = _reader.ReadLine();
                if (line == null)
                {
                    break;
                }

                var lineSplit = line.Split(':');

                if (lineSplit[0] == "Package")
                {
                    packageModel.Name = lineSplit[1];
                }

                if (lineSplit[0] == "Filename")
                {
                    packageModel.Url = lineSplit[1];
                    packageModels.Add(packageModel);
                    packageModel = new PackageModel();
                }

            }
            return packageModels;
        }

    }
}
