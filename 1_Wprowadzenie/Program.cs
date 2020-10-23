﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_Wprowadzenie
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = @"d:\";
            ShowLargeFilesWithoutLinq(path);

            Console.ReadKey();
        }

        private static void ShowLargeFilesWithoutLinq(string path)
        {
            DirectoryInfo folder = new DirectoryInfo(path);
            FileInfo[] files = folder.GetFiles();

            Array.Sort(files, new FileInfoComparer());

            for (int i = 0; i < 5; i++)
            {
                FileInfo file = files[i];
                Console.WriteLine($"{file.Name,-70} : {file.Length,20:N0}");
            }

        }
    }
    public class FileInfoComparer : IComparer<FileInfo>
    {
        public int Compare(FileInfo x, FileInfo y)
        {
            return y.Length.CompareTo(x.Length);
        }
    }
}
