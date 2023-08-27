using VCipherClsLib;
using System.Text;
Console.WriteLine("VCipher v1.0 Vendetta Programs");

static int Program()
{
    Console.WriteLine("Выберите действие: \n[1]Зашифровать\n[2]Дешифровать");
    ConsoleKeyInfo key = Console.ReadKey();
    if (key.KeyChar == '1')
    {
        string str;
        Console.WriteLine("\nВведите текст для зашифровки");
        str = Console.ReadLine();
        Tuple<string, string> tuple = VCipher.Vernam(str);
        Console.WriteLine($"Зашифрованное сообщение:\n{tuple.Item1}\nКлюч (храните ключ надежно!):\n{tuple.Item2}");
        Console.ReadKey();
    }
    else if (key.KeyChar == '2')
    {
        string s;
        string k;
        Console.WriteLine("\nВведите текст для расшифровки");
        s = Console.ReadLine();
        Console.WriteLine("Введите ключ шифрования");
        k = Console.ReadLine();
        string result;
        result = VCipher.UnVernam(s, k);
        Console.WriteLine($"Расшифрованный текст:\n{result}");
        Console.ReadKey();
    }
    else
    {
        Console.WriteLine("Вы должны нажать 1 или 2!");
        Program();
    }
    return 0;
}

Program();