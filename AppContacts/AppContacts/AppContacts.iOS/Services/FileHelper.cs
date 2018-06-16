using System;
using System.IO;
using AppContacts.iOS.Services;
using AppContacts.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(FileHelper))]
namespace AppContacts.iOS.Services
{
    public class FileHelper : IFileHelper
    {
        public string GetLocalFilePath(string fileName)
        {
            string docFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libFolder = Path.Combine(docFolder, "..", "DataBases");
            if (!Directory.Exists(libFolder))
            {
                Directory.CreateDirectory(libFolder);
            }
            return Path.Combine(libFolder, fileName);
        }
    }
}