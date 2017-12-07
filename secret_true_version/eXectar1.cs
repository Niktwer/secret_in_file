using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
using System.Resources;
using System.Reflection;

namespace secret_true_version
{
    class EXEStarter
    {
        string con_out;

        public string Start(string filename, string arguments, bool waitforexit)
        {
            using (Process MyProc = new Process())
            {
                con_out = "";
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();

                startInfo.FileName = filename;
                startInfo.Arguments = arguments;
                startInfo.CreateNoWindow = true;
                startInfo.UseShellExecute = false;
                startInfo.RedirectStandardOutput = true;
                process.StartInfo = startInfo;
                process.Start();
                con_out = process.StandardOutput.ReadToEnd();
                if (waitforexit)
                    process.WaitForExit();
                return con_out;
            }
        }

        private bool Is64BitSystem
        {
            get
            {
                return Directory.Exists(Environment.ExpandEnvironmentVariables(@"%windir%\SysWOW64"));
            }
        }

        public string TypeOs(DateTime dt)
        {

            string name_file = dt.ToString("hhmm") + Properties.Resources.file;
            string full_name_file = Environment.CurrentDirectory + "//" + name_file;

            if (System.IO.File.Exists(full_name_file))
            {
                File.Delete(@full_name_file);//знищуемо файл
            }



            if (!System.IO.File.Exists(full_name_file))
            {
                //string tempExeName = Path.Combine(Directory.GetCurrentDirectory(), name_file);
                using (FileStream fsDst = new FileStream(full_name_file, FileMode.CreateNew, FileAccess.Write))
                {
                    if (Is64BitSystem == true)
                    {
                        byte[] bytes = Properties.Resources._7za_64;
                        fsDst.Write(bytes, 0, bytes.Length);
                    }
                    else
                    {
                        byte[] bytes = Properties.Resources._7za_32;
                        fsDst.Write(bytes, 0, bytes.Length);
                    }


                }


                if (System.IO.File.Exists(full_name_file))

                { return full_name_file; }

                else

                { return null; }


            }
            else

            { return null; }


        }





        public string command(string args, bool waitforexit)
        {
            //1  
            string con_out = "";
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = args;
            process.StartInfo = startInfo;
            process.Start();
            if (waitforexit)
                process.WaitForExit();
            return con_out;
        }

        public string mess(int num, string con)
        {
            string an = "";

            switch (num)
            {
                case 0:
                    an = an + " " + con;
                    break;

                case 1:
                    an = an + " " + con;
                    break;
                case 2:
                    an = an + " " + con;
                    break;
                case 3:
                    an = an + " " + con;
                    break;
                case 4:
                    an = an + " " + con;
                    break;


                default:
                    an = an + " " + con;
                    break;

            }

            return an;


        }

        public void copy(string path_old, string path_new)
        {
            if (!File.Exists(path_new))
            {
                // This statement ensures that the file is created,
                // but the handle is not kept.
                using (FileStream fs = File.Create(path_new)) { }

            }

            // Ensure that the target does not exist.
            if (File.Exists(path_new))
                File.Delete(path_new);

            // Copy the file.
            File.Copy(path_old, path_new);
            //Console.WriteLine("{0} was moved to {1}.", path, path2);

        }
        public static bool create_folder(string catalog)
        {
            if (!System.IO.Directory.Exists(Environment.CurrentDirectory + "\\" + catalog))
            {
                string folderName = '@' + Environment.CurrentDirectory + "\\";
                string pathString = System.IO.Path.Combine(Environment.CurrentDirectory + "\\", catalog);
                System.IO.Directory.CreateDirectory(pathString);
                return false;
            }
            else { return true; }

        }

        public static bool delete_folder(string catalog)
        {
            DirectoryInfo dir = new DirectoryInfo(Environment.CurrentDirectory + "\\" + catalog);

            if (dir.Exists == true)
            {
                dir.Delete(true);
                return true;
            }
            else { return false; }

        }

        public bool exist_local(string path, string local)
        {
            if (path != local)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        /*System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/C copy /b Img100.jpg + secret.7zrar Ima2.jpg";
            process.StartInfo = startInfo;
            process.Start();*/

        public string assembly()
        {
            System.Reflection.Assembly assem = System.Reflection.Assembly.GetEntryAssembly();
            AssemblyName assemName = assem.GetName();
            Version ver_ = assemName.Version;
            return ver_.ToString();

        }

        public string[] Disk()
        {
            string[] Property_disk = new string[2];
            DriveInfo[] allDrives = DriveInfo.GetDrives();
            foreach (DriveInfo disk in allDrives)
            {
                if (disk.Name.ToString() == Environment.CurrentDirectory.Remove(3))
                {
                    Property_disk[0] = disk.VolumeLabel.ToString();
                    Property_disk[1] = disk.TotalFreeSpace.ToString();
                }
            }
            return new string[] { Property_disk[0], Property_disk[1] };
        }
        public void read_write_file(bool read_write)
        {
            switch (read_write)
            {
                case true:
                    {

                        break; }
                case false:
                    {

                        break; }
            }


        }
    }
}
