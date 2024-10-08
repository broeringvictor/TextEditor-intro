// See https://aka.ms/new-console-template for more information

using System;
using System.IO; // Corrigir o namespace para trabalhar com arquivos

Menu();

static void Menu()
{
    Console.Clear();
    Console.WriteLine("1. Open File");
    Console.WriteLine("2. Edit File");
    Console.WriteLine("0. Close");
    Console.WriteLine("Choose an option: ");
    int option = int.Parse(Console.ReadLine());

    switch (option)
    {
        case 0: System.Environment.Exit(0); break;
        case 1: OpenFile(); break;
        case 2: EditFile(); break;
        default: Menu(); break; // Adicionado um fallback para opções inválidas
    }
}

static void OpenFile()
{
    Console.Clear();
    Console.WriteLine("Informe o caminho do arquivo para abrir:");
    string path = Console.ReadLine();

    if (File.Exists(path)) // Verifica se o arquivo existe
    {
        using (var file = new StreamReader(path))
        {
            string fileText = file.ReadToEnd();
            Console.WriteLine(fileText);
        }
    }
    else
    {
        Console.WriteLine("Arquivo não encontrado.");
    }

    Console.WriteLine("");
    Console.ReadLine(); // Espera o usuário pressionar Enter para continuar
    Menu();
}

static void EditFile()
{
    Console.Clear();
    Console.WriteLine("Digite o seu código aqui: -> ESC to LEAVE <- ");
    Console.WriteLine("--------------------------");

    string code = "";

    do
    {
        code += Console.ReadLine();
        code += Environment.NewLine;

    } while (Console.ReadKey(true).Key != ConsoleKey.Escape); // Captura a tecla Escape corretamente

    SaveFile(code);
}

static void SaveFile(string code)
{
    Console.Clear();
    Console.WriteLine("Você deseja salvar o seu texto? Informe o caminho do arquivo:");
    var path = Console.ReadLine();

    using (var file = new StreamWriter(path))
    {
        file.WriteLine(code); // Salva o conteúdo no arquivo
    }
    Console.WriteLine("Texto salvo com sucesso!");
    System.Environment.Exit(0); // Encerrar após salvar
}
