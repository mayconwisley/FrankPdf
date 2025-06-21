using System;
using System.IO;

namespace FrankPdf
{
	public static class DeleteFiles
	{
		public static void Delete(string inputFile)
		{
			if (string.IsNullOrEmpty(inputFile))
				throw new ArgumentException("O nome do arquivo de entrada não pode ser nulo ou vazio.");

			if (!File.Exists(inputFile))
				throw new FileNotFoundException($"O arquivo especificado não existe: {inputFile}");

			try
			{
				if (File.Exists(inputFile))
					File.Delete(inputFile);
				else
					throw new FileNotFoundException("Arquivo não encontrado.", inputFile);

			}
			catch (Exception ex)
			{
				throw new Exception($"Erro ao excluir o arquivo: {ex.Message}", ex);
			}
		}
	}
}
