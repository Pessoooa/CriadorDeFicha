using System;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using testes.Classes; 

namespace testes
{
    public class CriarFicha
    {
        public static void Criar()
        {
            Console.Clear();
            var caminhoImagem = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "img", "fichaf.jpg");
            Console.WriteLine("Qual o caminho que você irá salvar a sua ficha?");
            var caminhoFicha = Console.ReadLine();

            // Instância do personagem
            Personagem classe = null;

            Console.WriteLine("       ESCOLHA A SUA CLASSE");
            Console.WriteLine("         (1 para Paladino)");
            Console.WriteLine("         (2 para Guerreiro)");
            Console.WriteLine("         (0 para Sair)");
            string escolhaclasse = Console.ReadLine()?.ToLower();

            switch (escolhaclasse)
            {
                case "1":
                    classe = new Paladino();
                    break;
                case "2":
                    classe = new Guerreiro();
                    break;
                default:
                    Console.WriteLine("Opção inválida. Saindo...");
                    return;
            }

            if (classe == null)
            {
                Console.WriteLine("Erro ao inicializar a classe do personagem.");
                return;
            }

            // Criação do documento PDF
            Document document = new Document(PageSize.A4, 0, 0, 0, 0);
            try
            {
                PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(caminhoFicha, FileMode.Create));
                document.Open();

                // Carregar e definir imagem de fundo
                iTextSharp.text.Image background = iTextSharp.text.Image.GetInstance(caminhoImagem);
                background.SetAbsolutePosition(0, 0);
                background.ScaleToFit(document.PageSize.Width, document.PageSize.Height);
                writer.DirectContentUnder.AddImage(background);

                // Adiciona o conteúdo ao PDF
                PdfContentByte content = writer.DirectContent;
                BaseFont font = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);

                Console.WriteLine("Digite o nome do seu Personagem: ");
                var nomepersonagem = Console.ReadLine();

                Console.WriteLine("Digite o seu nome: ");
                var jogador = Console.ReadLine();

                AdicionarTexto(content, font, 14, 40, 783, nomepersonagem);
                AdicionarTexto(content, font, 12, 268, 780, jogador);
                AdicionarTexto(content, font, 12, 320, 755, classe.classe);
                // Adiciona os atributos do personagem ao PDF
                string[] atributos = { "FORCA", "DESTREZA", "CONSTITUICAO", "INTELIGENCIA", "SABEDORIA", "CARISMA", "VIDA", "MANA", "DEFESA" };
                int[] posicoesX = { 43, 100, 157, 214, 271, 328, 43, 214, 43 };
                int[] posicoesY = { 691, 691, 691, 691, 691, 691, 635, 636, 410 };

                for (int i = 0; i < atributos.Length; i++)
                {
                    string valorAtributo = classe.GetAtributo(atributos[i]).ToString("D2") ?? "N/A";
                    AdicionarTexto(content, font, 18, posicoesX[i], posicoesY[i], valorAtributo);
                }

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

        private static void AdicionarTexto(PdfContentByte content, BaseFont font, int tamanho, float x, float y, string texto)
        {
            content.BeginText();
            content.SetFontAndSize(font, tamanho);
            content.SetTextMatrix(x, y);
            content.ShowText(texto);
            content.EndText();
        }
    }
}
