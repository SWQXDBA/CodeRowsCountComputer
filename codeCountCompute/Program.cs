using System;
using System.IO;
using System.Net;

namespace codeCountCompute
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("请输入项目路径");
            string path =  Console.ReadLine();
            Console.WriteLine("输入文件结尾 如.cs .java等等 扫描所有文件则直接输入all");
            string endWith =  Console.ReadLine();

            Console.WriteLine(dfsDirectory(path,endWith));
           
        }

        static int dfsDirectory(string path,string endWith)
        {
            int count = 0;
            string[] subDir = Directory.GetDirectories(path);
            foreach (var s in subDir)
            {
                count+= dfsDirectory(s,endWith);
            }

         
            string[] files = Directory.GetFiles(path);
            foreach (var file in files)
            {
                if (file.EndsWith(endWith)||endWith=="all")
                {
                    FileStream stream = File.OpenRead(file);
                    StreamReader reader = new StreamReader(stream);
                    int subCount = 0;
                    while (!reader.EndOfStream)
                    {
                        var readLine = reader.ReadLine();
                        if (!readLine.Equals("\n") || !readLine.Equals(""))
                        {
                            subCount++;
                            count++;
                        }
                        
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