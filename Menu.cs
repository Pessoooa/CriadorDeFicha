namespace CriadorDeFicha;

public class Menu
{
    public static void Opcoes()
    {
        Console.Clear();
        Console.BackgroundColor = ConsoleColor.Black;
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("*=================================*");
        Console.WriteLine("|        CRIADOR DE FICHA         |");
        Console.WriteLine("*=================================*");
        Console.WriteLine(" ");
        Console.WriteLine("   SELECIONE O QUE DESEJA FAZER:");
        Console.WriteLine(" ");
        Console.WriteLine("        1 - Criar Ficha");
        Console.WriteLine("        2 - Upar Ficha");
        Console.WriteLine("        0 - Sair");
        
        var opcao = int.Parse(Console.ReadLine());
        switch (opcao)
        {
            case 1: Novaficha.Criar();
                break;
            case 2: Console.WriteLine("Upar Ficha");
                break;
            case 0: Environment.Exit(0); 
                break;
            default: Menu.Opcoes(); 
                break;
        }
    }
}