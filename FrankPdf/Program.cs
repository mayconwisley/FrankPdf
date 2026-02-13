using System;
using System.IO;
using System.Linq;

namespace FrankPdf;

internal class Program
{
    static void Main(string[] args)
    {
        if (args.Length < 1 || args.Length > 2)
        {
            Console.WriteLine("Uso:");
            Console.WriteLine("FrankPdf <input_directory> [output_directory]");
            return;
        }

        string inputDirectory = args[0];

        if (!Directory.Exists(inputDirectory))
            throw new DirectoryNotFoundException($"Diretório não encontrado: {inputDirectory}");

        string outputDirectory = inputDirectory;

        foreach (var arg in args.Skip(1))
        {
            outputDirectory = arg;
        }

        if (!Directory.Exists(outputDirectory))
            throw new DirectoryNotFoundException($"Diretório de saída não encontrado: {outputDirectory}");


        string outputFile = Path.Combine(outputDirectory, "pdfMerge.pdf");

        MergeFiles.Merge(
            inputDirectory,
            outputFile
        );

        Console.WriteLine("Processo concluído com sucesso.");
    }
}
