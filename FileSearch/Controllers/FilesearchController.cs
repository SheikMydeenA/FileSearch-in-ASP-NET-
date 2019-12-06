using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FileSearch.Controllers
{
    public class FilesearchController : Controller
    {
        // GET: Filesearch
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public string FilesList(FormCollection form)
        {
            string Foldername = form["FolderName"].ToString();
            string filename = form["filename"].ToString();
            DirectoryInfo hdDirectoryInWhichToSearch = new DirectoryInfo(Foldername);
            FileInfo[] filesInDir = hdDirectoryInWhichToSearch.GetFiles("*" + filename + "*.*");
            List<string> FileList = new List<string>();
            String FileNames = string.Empty;
            foreach (FileInfo foundFile in filesInDir)
            {
                FileNames += foundFile.Name + ",";
                FileList.Add(foundFile.FullName);
                //Console.WriteLine(fullName);
            }
            FileNames = FileNames.TrimEnd();
            //FileNames=FileNames.Substring(FileNames.Length - 1);
            FileNames=string.Concat(FileNames.Reverse().Skip(1).Reverse());
            return FileNames;
            //IEnumerable<string> dirs = Directory.EnumerateDirectories(@"E:\Sheik\Projects\MobileAPIs\APIs_201805\Candidate_old\source\Web.Domain\Repositories", " * ", SearchOption.AllDirectories).Where(x => x.Contains(filename));

            //foreach (string dir in dirs)
            //{

            //    IEnumerable<string> files = Directory.EnumerateFiles(dir, "*", SearchOption.TopDirectoryOnly).Where(x => x.Contains("web"));
            //    foreach (string fil in files)
            //    {
            //        FileInfo fi = new FileInfo(fil);
            //        string ss = fi.FullName;
            //    }
            //}
            //return View();
        }
    }
}