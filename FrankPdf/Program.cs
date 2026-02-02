using System;
using System.IO;

namespace FrankPdf;

internal class Program
{
    static void Main(string[] args)
    {
        if (args.Length == 0)
            throw new ArgumentException("Nenhum argumento fornecido. Por favor, forneça o caminho do diretório de entrada e/ou nome do arquivo de saída.");

        var name = $"{DateTime.Now:yyyy-MM-dd}_{Guid.NewGuid():N}.pdf";

        if (args.Length == 1)
        {
            // Se apenas um argumento for fornecido, assume-se que é o diretório de entrada
            var inputDirectory = args[0];
            var outputFile = Path.Combine(inputDirectory, name);

            MergeFiles.Merge(inputDirectory, outputFile);
        }
        else if (args.Length == 2)
        {
            // Se dois argumentos forem fornecidos, assume-se que o primeiro é o diretório de entrada e o segundo é o nome do arquivo de saída
            var inputDirectory = args[0];
            var outputFileName = args[1];
            var outputFile = Path.Combine(outputFileName, name);
            MergeFiles.Merge(inputDirectory, outputFile);
        }
        else
        {
            throw new ArgumentException("Número inválido de argumentos. Use: FrankPdf <input_directory> [output_file_name]");
        }
    }
}
