using System;
using System.IO;
using AppContacts.Droid.Services;
using AppContacts.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(FileHelper))]
namespace AppContacts.Droid.Services
{
    public class FileHelper : IFileHelper
    {
        public string GetLocalFilePath(string fileName)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            return Path.Combine(path, fileName);
        }
    }
}