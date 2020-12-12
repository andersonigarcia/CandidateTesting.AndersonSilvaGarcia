using System;
using System.IO;
using System.Net;

namespace CandidateTesting.AndersonSilvaGarcia
{
    public class Log
    {
        public Log(Uri sourceUrl, string targetPath)
        {
            SourceUrl = sourceUrl;
            TargetPath = targetPath;
        }

        public Uri SourceUrl { get; set; }
        public string TargetPath { get; set; }

        private string ImportPath = string.Concat(AppDomain.CurrentDomain.BaseDirectory, Constant.archiveName);

        public bool CreateAgoraArchive()
        {
            DownloadUriFile();

            ReadFileImportedAndWriteAgora();

            return true;
        }

        private bool DownloadUriFile()
        {
            using WebClient client = new WebClient();

            client.DownloadFile(SourceUrl, Constant.archiveName);

            return true;
        }

        private void ReadFileImportedAndWriteAgora()
        {
            try
            {
                CreateArchive();

                WriteArchiveAgora();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void CreateArchive()
        {
            var newFile = File.Create(TargetPath);
            newFile.Close();
        }

        private void WriteArchiveAgora()
        {
            string line;
            string newLine = string.Empty;
            int counter = 0;

            newLine = string.Concat(newLine, Constant.Version, string.Format(Constant.Date, DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss")), Constant.Fildes);
            using StreamReader file = new StreamReader(ImportPath);
            while ((line = file.ReadLine()) != null)
            {
                newLine = string.Concat(newLine, FormatLineLogAgora(line), "\n");
                counter++;
            }
            file.Close();

            File.WriteAllText(TargetPath, newLine);
            Console.WriteLine($"File has {counter} lines.");
        }

        private string FormatLineLogAgora(string line)
        {
            var fields = line.Split("|");
            var methods = fields[3].Split("/");

            string method = methods[0].Replace("\"", "");
            string statusCode = fields[1];
            string urlPath = methods[1].Split(" ")[0];
            var timeTaken = decimal.Round(Convert.ToDecimal(fields[4].Replace(".", ",")));
            string responseCode = fields[0];
            string cacheStatus = fields[2] == "INVALIDATE" ? "REFRESH_HIT" : fields[2];

            return string.Concat(Constant.Provider, method, statusCode, " ", "/", urlPath, " ", timeTaken, " ", responseCode, " ", cacheStatus);
        }
    }
}


