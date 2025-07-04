using PdfSharp.Drawing;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using System;
using System.IO;
using System.Linq;

namespace FrankPdf
{
    public static class MergeFiles
    {
        public static void Merge(string inputFile, string outputFile)
        {
            var inputFiles = Directory.GetFiles(inputFile, "*.*", SearchOption.TopDirectoryOnly);
            inputFiles.OrderBy(o => o);

            if (inputFiles == null || inputFiles.Length == 0)
                throw new ArgumentException("Nenhum arquivo de entrada fornecido para mesclagem.");

            if (string.IsNullOrEmpty(outputFile))
                throw new ArgumentException("O nome do arquivo de saída não pode ser nulo ou vazio.");

            try
            {
                using (PdfDocument outputDocument = new PdfDocument())
                {
                    foreach (string file in inputFiles)
                    {
                        if (string.IsNullOrEmpty(file))
                            throw new ArgumentException("Um dos arquivos de entrada é nulo ou vazio.");

                        var extension = Path.GetExtension(file)?.ToLowerInvariant();
                        if (extension == ".pdf")
                        {
                            //Abrir arquivo PDF existente
                            using (PdfDocument inputDocument = PdfReader.Open(file, PdfDocumentOpenMode.Import))
                            {
                                for (int i = 0; i < inputDocument.PageCount; i++)
                                {
                                    var page = inputDocument.Pages[i];
                                    outputDocument.AddPage(page);
                                }
                            }
                        }
                        else if (extension == ".jpg" || extension == ".jpeg" || extension == ".png" || extension == ".bmp")
                        {
                            //Adicionar imagem ao PDF
                            var page = outputDocument.AddPage();

                            using (var image = XImage.FromFile(file))
                            {
                                using (var gfx = XGraphics.FromPdfPage(page))
                                {
                                    // Desenha a imagem no PDF
                                    gfx.DrawImage(image, 0, 0, page.Width.Point, page.Height.Point);
                                }
                            }
                        }
                        DeleteFiles.Delete(file);
                    }
                    outputDocument.Save(outputFile);
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Ocorreu um erro ao mesclar arquivos.", ex);
            }
        }
    }
}
