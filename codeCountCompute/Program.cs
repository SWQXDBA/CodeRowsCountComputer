using System;
using System.IO;

namespace codeCountCompute
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("请输入项目路径");
            string path =  Console.ReadLine();

            Console.WriteLine(dfsDirectory(path));
           
        }

        static int dfsDirectory(string path)
        {
            int count = 0;
            string[] subDir = Directory.GetDirectories(path);
            foreach (var s in subDir)
            {
                count+= dfsDirectory(s);
            }

            string[] files = Directory.GetFiles(path);
            foreach (var file in files)
            {
                if (file.EndsWith(".cs"))
                {
                    FileStream stream = File.OpenRead(file);
                    StreamReader reader = new StreamReader(stream);
                    int subCount = 0;
                    while (!reader.EndOfStream)
                    {
                        reader.ReadLine();
                        subCount++;
                        count++;
                    }
                    stream.Close();
                    reader.Close();
                    Console.WriteLine(file.Split("\\")[file.Split("\\").Length-1]+" 行数 "+subCount);
                }

            }

            return count;

        }
    }
}