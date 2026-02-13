using System;
using System.IO;
using System.Linq;

namespace FrankPdf;

internal class Program
{
    static void Main(string[] args)
    {
        if (args.Length < 1 || args.Length > 3)
        {
            Console.WriteLine("Uso:");
            Console.WriteLine("FrankPdf <input_directory> [output_directory] [--delete-input]");
            return;
        }

        string inputDirectory = args[0];

        if (!Directory.Exists(inputDirectory))
            throw new DirectoryNotFoundException($"Diretório não encontrado: {inputDirectory}");

        string outputDirectory = inputDirectory;
        bool isDeleteFile = false;

        foreach (var arg in args.Skip(1))
        {
            if (arg.Equals("--delete-input", StringComparison.OrdinalIgnoreCase))
                isDeleteFile = true;
            else
                outputDirectory = arg;
        }

        if (!Directory.Exists(outputDirectory))
            throw new DirectoryNotFoundException($"Diretório de saída não encontrado: {outputDirectory}");

        if (isDeleteFile &&
            string.Equals(inputDirectory, outputDirectory, StringComparison.OrdinalIgnoreCase))
        {
            throw new InvalidOperationException(
                "Para usar --delete-input o diretório de saída deve ser diferente do diretório de entrada.");
        }

        string outputFile = Path.Combine(outputDirectory, "pdfMerge.pdf");

        MergeFiles.Merge(
            inputDirectory,
            outputFile,
            isDeleteFile
        );

        Console.WriteLine("Processo concluído com sucesso.");
    }
}
