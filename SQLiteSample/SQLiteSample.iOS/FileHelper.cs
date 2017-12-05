using System;
using System.IO;
using Xamarin.Forms;
using SQLiteSample.iOS;

[assembly: Dependency(typeof(FileHelper))]

namespace SQLiteSample.iOS
{
    // https://developer.xamarin.com/guides/xamarin-forms/application-fundamentals/databases/

    public class FileHelper : IFileHelper
    {
        public string GetLocalFilePath(string filename)
        {
            string docFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libFolder = Path.Combine(docFolder, "..", "Library", "Databases");

            if (!Directory.Exists(libFolder))
            {
                Directory.CreateDirectory(libFolder);
            }

            return Path.Combine(libFolder, filename);
        }
    }
}
