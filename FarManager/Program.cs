using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace FarManager
{

    class Layer 
    {
        public DirectoryInfo dir
        {
            get;
            set;
        }
        public int pos
        {
            get;
            set;
        }
        public List<FileSystemInfo> content
        {
            get;
            set;
        }

        public Layer(DirectoryInfo dir, int pos)
        {
            this.dir = dir;
            this.pos = pos;
            this.content = new List<FileSystemInfo>();

            content.AddRange(this.dir.GetDirectories());
            content.AddRange(this.dir.GetFiles());
        }
        private static string Indent(int len) { return new string('\t', Math.Max(len, 0)); }

        public void PrintInfo()
        {
            //Console.BackgroundColor = ConsoleColor.Blue;
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.White;

            int cnt = 0;

            foreach (DirectoryInfo d in dir.GetDirectories())
            {
                if (cnt == pos)
                {
                    Console.BackgroundColor = ConsoleColor.Cyan;
                }
                else Console.BackgroundColor = ConsoleColor.Black;

                Console.WriteLine(d.Name);
                cnt++;
            }
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            foreach (FileInfo f in dir.GetFiles())
            {
                if (cnt == pos)
                {
                    Console.BackgroundColor = ConsoleColor.Cyan;
                }
                else Console.BackgroundColor = ConsoleColor.Black;

                //Console.WriteLine(f.Name + "\t\t " + f.Length + "bytes");
                FileInfo curFileInfo = new FileInfo(f.FullName);
                string indentForRender = Indent(5 - ((int)(f.Name.Length / 8)));
                string fileSize = indentForRender + "<DIR>";
                if (curFileInfo.Exists) fileSize = indentForRender + curFileInfo.Length.ToString() + " bytes";
                Console.WriteLine(f.Name + fileSize);

                cnt++;
            }
        }

        public FileSystemInfo GetCurrentObject()
        {
            return content[pos];
        }

        public void SetNewPosition(int d)
        {
            if (d > 0)
            {
                pos++;   
            }
            else
            {
                pos--;
            }

            if (pos >= content.Count)
            {
                pos = 0;
            } else if(pos < 0)
            {
                pos = content.Count - 1;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            F3();
        }

        private static void F3()
        {

            Stack<Layer> history = new Stack<Layer>();
            history.Push(new Layer
            (
                new DirectoryInfo(@"C:\Users\ernaz\Desktop\univer\3_semestr\algo"),
                0
            ));
            int pos = 0;

            bool escape = false;

            //DirectoryInfo dir = new DirectoryInfo(@"C:\Users\ernaz\Desktop\univer\3_semestr\algo
            

            while (!escape)
            {
                Console.Clear();

                history.Peek().PrintInfo();
                ConsoleKeyInfo consoleKeyInfo = Console.ReadKey(true);
                
                switch(consoleKeyInfo.Key) 
                {
                    case ConsoleKey.Enter:
                        if(history.Peek().GetCurrentObject().GetType() == typeof(DirectoryInfo))
                        {
                            history.Push(new Layer(history.Peek().GetCurrentObject() as DirectoryInfo, 0));
                            //Console.WriteLine(history.Peek().GetCurrentObject());
                        } else if(history.Peek().GetCurrentObject().GetType() == typeof(FileInfo))
                        {
                            //System.Diagnostics.ProcessStartInfo pInfo = new System.Diagnostics.ProcessStartInfo();
                            string fs = history.Peek().GetCurrentObject().FullName;
                            //Process.Start(fs);

                            Process.Start(new ProcessStartInfo(fs) { UseShellExecute = true });


                            //System.Diagnostics.ProcessStartInfo p = new System.Diagnostics.ProcessStartInfo(fs);
                            //System.Diagnostics.Process.Start(p);

                            //p.StartInfo = new ProcessStartInfo(fs)
                            //{
                            //    UseShellExecute = true
                            //};
                            //p.Start();
                        }
                        break;
                    case ConsoleKey.UpArrow:
                        history.Peek().SetNewPosition(-1);
                        break;
                    case ConsoleKey.DownArrow:
                        history.Peek().SetNewPosition(1);
                        break;
                    case ConsoleKey.Escape:
                        escape = true;
                        break;
                    case ConsoleKey.Delete:
                        string fileToDelete = history.Peek().GetCurrentObject().FullName;
                        File.Delete(fileToDelete);
                        Console.WriteLine("${fileToDelete } is deleted");
                        break;
                    case ConsoleKey.Backspace:
                        history.Pop();
                        break;
                }

                //Console.WriteLine(consoleKeyInfo.KeyChar); //outputs input char
            }
        }

        private static void F2()
        {
            while (true)
            {
                ConsoleKeyInfo consoleKeyInfo = Console.ReadKey();
                if (consoleKeyInfo.Key == ConsoleKey.Escape) break;

                Console.WriteLine(consoleKeyInfo.KeyChar); //outputs input char
            }
        }

        private static void F1()
        {
            ConsoleKeyInfo consoleKeyInfo = Console.ReadKey();
            Console.WriteLine(consoleKeyInfo.Key.ToString()); //outputs input 
        }
    }
}
