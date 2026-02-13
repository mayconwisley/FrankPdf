using PdfSharp.Drawing;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FrankPdf;

public static class MergeFiles
{
    public static void Merge(string inputDirectory, string outputFile, bool isDeleteFile)
    {
        var allowedExtensions = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
        {
            ".pdf", ".jpg", ".jpeg", ".png", ".bmp"
        };

        var inputFiles = Directory
            .EnumerateFiles(inputDirectory, "*", SearchOption.TopDirectoryOnly)
            .Where(f => allowedExtensions.Contains(Path.GetExtension(f)))
            .OrderBy(f => f)
            .ToArray();

        if (inputFiles.Length == 0)
            throw new ArgumentException("Nenhum arquivo de entrada fornecido para mesclagem.");

        if (string.IsNullOrEmpty(outputFile))
            throw new ArgumentException("O nome do arquivo de saída não pode ser nulo ou vazio.");

        try
        {
            using PdfDocument outputDocument = new();
            foreach (string file in inputFiles)
            {
                var extension = Path.GetExtension(file)?.ToLowerInvariant();
                if (extension == ".pdf")
                {
                    //Abrir arquivo PDF existente
                    using PdfDocument inputDocument = PdfReader.Open(file, PdfDocumentOpenMode.Import);
                    for (int i = 0; i < inputDocument.PageCount; i++)
                        outputDocument.AddPage(inputDocument.Pages[i]);
                }
                else if (extension == ".jpg" || extension == ".jpeg" || extension == ".png" || extension == ".bmp")
                {
                    using var image = XImage.FromFile(file);

                    var page = outputDocument.AddPage();
                    page.Width = image.PointWidth;
                    page.Height = image.PointHeight;

                    using var gfx = XGraphics.FromPdfPage(page);
                    gfx.DrawImage(image, 0, 0);
                }
            }
            outputDocument.Save(outputFile);

            if (isDeleteFile)
                foreach (var file in inputFiles)
                    File.Delete(file);
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException("Ocorreu um erro ao mesclar arquivos.", ex);
        }
    }
}
