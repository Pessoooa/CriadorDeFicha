using System;
using System.IO;
using System.Net.Sockets;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace CriadorDeFicha
{
    public class Novaficha
    {
        public static void Criar()
        {
            Console.Clear();
            var caminhoImagem = @"C:\Users\willi\OneDrive\Área de Trabalho\ProjetosCsharp\CriadorDeFicha\img\fichaf.jpg";
            var caminhoFicha = @"C:\Users\willi\OneDrive\Área de Trabalho\Nova pasta\teste\fichapronta.pdf";
            
            // Cria o documento PDF
            Document document = new Document(PageSize.A4, 0, 0, 0, 0);
            try
            {
                // Define o arquivo de saída para o PDF
                PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(caminhoFicha, FileMode.Create));
                document.Open();

                // Carrega a imagem de fundo
                iTextSharp.text.Image background = iTextSharp.text.Image.GetInstance(caminhoImagem);

                // Ajusta a posição e tamanho da imagem
                background.SetAbsolutePosition(0, 0); // Posição no canto inferior esquerdo
                background.ScaleToFit(document.PageSize.Width, document.PageSize.Height);

                // Adiciona a imagem como fundo
                PdfContentByte canvas = writer.DirectContentUnder;
                canvas.AddImage(background);

                // Adiciona conteúdo sobre a imagem
                PdfContentByte content = writer.DirectContent;
                BaseFont font = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                Console.WriteLine("Digite o nome do seu Personagem: ");
                var personagem = Console.ReadLine();
                content.BeginText();
                content.SetFontAndSize(font, 14); // Define fonte e tamanho
                content.SetTextMatrix(40, 783); // Define a posição (x = 200, y = 700)
                content.ShowText(personagem); // Texto a ser exibido
                content.EndText();
                
                Console.WriteLine("Digite o seu nome: ");
                var jogador = Console.ReadLine();
                content.BeginText();
                content.SetFontAndSize(font, 12); // Define fonte e tamanho
                content.SetTextMatrix(268, 780); // Define a posição (x = 200, y = 700)
                content.ShowText(jogador); // Texto a ser exibido
                content.EndText();
                
                Console.WriteLine("Ficha gerada com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao criar a ficha: {ex.Message}");
            }
            finally
            {
                document.Close();
            }
        }
    }
}