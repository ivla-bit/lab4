//using System;
//using System.IO;

//class Program
//{
//    static void Main(string[] args)
//    {
//        Console.WriteLine("Enter the source directory path:");
//        string sourceDirectory = Console.ReadLine();

//        Console.WriteLine("Enter the target directory path:");
//        string targetDirectory = Console.ReadLine();

//        if (!Directory.Exists(sourceDirectory))
//        {
//            Console.WriteLine("Specified source directory does not exist.");
//            return;
//        }

//        if (!Directory.Exists(targetDirectory))
//        {
//            Console.WriteLine("Specified target directory does not exist. Creating directory...");
//            Directory.CreateDirectory(targetDirectory);
//        }

//        string[] files = Directory.GetFiles(sourceDirectory, "*.txt");
//        foreach (string file in files)
//        {
//            FileInfo fileInfo = new FileInfo(file);
//            if ((fileInfo.Attributes & FileAttributes.Hidden) == FileAttributes.Hidden ||
//                (fileInfo.Attributes & FileAttributes.ReadOnly) == FileAttributes.ReadOnly ||
//                (fileInfo.Attributes & FileAttributes.Archive) != FileAttributes.Archive)
//            {
//                Console.WriteLine($"Skipping file: {file}");
//                continue;
//            }

//            string destinationFile = Path.Combine(targetDirectory, Path.GetFileName(file));
//            File.Move(file, destinationFile);
//            Console.WriteLine($"Moved file: {file} -> {destinationFile}");
//        }

//        Console.WriteLine("Operation completed.");
//    }
//}
using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        string sourceDirectory;
        string targetDirectory;
        string fileExtension;

        if (args.Length == 3)
        {
            sourceDirectory = args[0];
            targetDirectory = args[1];
            fileExtension = args[2];
        }
        else
        {
            Console.WriteLine("Enter the source directory path:");
            sourceDirectory = Console.ReadLine()!;

            Console.WriteLine("Enter the target directory path:");
            targetDirectory = Console.ReadLine()!;

            Console.WriteLine("Enter the file extension:");
            fileExtension = Console.ReadLine()!;
        }

        if (!Directory.Exists(sourceDirectory))
        {
            Console.WriteLine("Specified source directory does not exist.");
            return;
        }

        if (!Directory.Exists(targetDirectory))
        {
            Console.WriteLine("Specified target directory does not exist. Creating directory...");
            Directory.CreateDirectory(targetDirectory);
        }

        string[] files = Directory.GetFiles(sourceDirectory, $"*.{fileExtension}");
        foreach (string file in files)
        {
            FileInfo fileInfo = new FileInfo(file);
            if ((fileInfo.Attributes & FileAttributes.ReadOnly) == FileAttributes.ReadOnly ||
                (fileInfo.Attributes & FileAttributes.Hidden) == FileAttributes.Hidden ||
                (fileInfo.Attributes & FileAttributes.Archive) != FileAttributes.Archive)
            {
                Console.WriteLine($"Skipping file: {file}");
                continue;
            }


            string destinationFile = Path.Combine(targetDirectory, Path.GetFileName(file));
            File.Move(file, destinationFile);
            Console.WriteLine($"Moved file: {file} -> {destinationFile}");
        }

        Console.WriteLine("Operation completed.");
    }
}
