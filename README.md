
# FrankPdf

**FrankPdf** é uma aplicação de console em C# desenvolvida para mesclar arquivos PDF e imagens (`.jpg`, `.jpeg`, `.png`, `.bmp`) em um único arquivo PDF. Após a mesclagem, os arquivos de entrada são excluídos automaticamente.

# Porque do Nome FrankPdf?
FrankPDF (de Frankenstein — junta partes diferentes)

---

## 📦 Funcionalidades

- 🔗 Mescla arquivos PDF e imagens em um único arquivo PDF.
- 🧹 Exclui automaticamente os arquivos originais após a mesclagem.
- 📄 Gera um nome de arquivo único baseado na data e um GUID.
- 🚀 Funciona diretamente via linha de comando.

---

## ⚙️ Tecnologias Utilizadas

- .NET Framework 4.7+
- [PdfSharp](https://pdfsharp.net/) — biblioteca para manipulação de PDFs.

---

## 📦 Download

Você pode baixar o executável compilado clicando no link abaixo:

👉 [Download do FranlPdf](https://github.com/mayconwisley/FrankPdf/raw/refs/heads/master/Download/FrankPdf.exe)

> Após o download, você pode executá-lo via terminal:
>
> ```bash
> FrankPdf.exe "C:\Caminho\dos\Arquivos"
> ```

## 🚀 Como Usar

### ✔️ Executável

A aplicação funciona por linha de comando com os seguintes parâmetros:

```
FrankPdf.exe <input_directory> [output_directory]
```

### ✔️ Exemplos de uso:

- 👉 **Mesclar arquivos em um diretório (salva no mesmo diretório):**
```
FrankPdf.exe C:\MeusArquivos
```
> ✅ Resultado: O PDF mesclado será salvo dentro do diretório `C:\MeusArquivos`.

- 👉 **Mesclar arquivos e salvar em outro diretório:**
```
FrankPdf.exe C:\MeusArquivos C:\PDFsGerados
```
> ✅ Resultado: O PDF mesclado será salvo dentro de `C:\PDFsGerados`.

---

## 📜 Regras e Comportamento

- 🔍 O programa busca arquivos diretamente no diretório informado (não busca em subpastas).
- 🧹 Após a mesclagem, **todos os arquivos utilizados são excluídos** (PDFs e imagens).
- 🧾 O nome do arquivo gerado segue o padrão:
```
yyyy-MM-dd_GUID.pdf
```
Exemplo:
```
2025-06-21_1a2b3c4d5e6f7g8h9i0j.pdf
```

---

## ⚠️ Cuidados Importantes

- ⚠️ Todos os arquivos do diretório de entrada são excluídos após a mesclagem.
- 💾 Verifique se o diretório de entrada contém **somente os arquivos que você deseja mesclar**.

---

## 🏗️ Estrutura do Projeto

```
FrankPdf
├── Program.cs           # Classe principal - gerencia os argumentos e inicia a mesclagem
├── MergeFiles.cs        # Responsável por mesclar PDFs e imagens
└── DeleteFiles.cs       # Responsável por excluir os arquivos após a mesclagem
```

---

## 🛠️ Como Compilar

1. Abra o projeto no **Visual Studio**.
2. Instale o pacote NuGet:
```
PdfSharp
```
3. Compile o projeto (`Build > Build Solution`).
4. O executável estará na pasta:
```
FrankPdf\bin\Release\
```

---

## 🧑‍💻 Autor

- **Maycon Wisley**  
🔗 [LinkedIn](https://www.linkedin.com/in/mayconwisley/)
