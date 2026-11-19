using System.Collections.Immutable;

string[] AllMKV = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "*.mkv", SearchOption.AllDirectories);
string[] AllAVI = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "*.avi", SearchOption.AllDirectories);
string[] AllMP4 = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "*.mp4", SearchOption.AllDirectories);

string[] MKVMP4 = AllMKV.Concat(AllMP4).ToArray();
string[] All = MKVMP4.Concat(AllAVI).ToArray();

if (All.Length == 0)
{
    Console.WriteLine("В папке нет файлов для сортировки. Нажмите любую клавишу для завершения...");
    Console.ReadLine();
    return;
}

Array.Sort(All);

Console.WriteLine("Определённые файлы:\n");

foreach (string file in All)
{
    string filename = Path.GetFileName(file);
    Console.WriteLine(filename);
}
Console.WriteLine("Для начала нажмите любую клавишу...\n");
Console.ReadLine();

Console.WriteLine("Начинаем.\n");
int number = 1;
foreach  (string file in All)
{
    string filename = Path.GetFileName(file);
    string directory = Path.GetDirectoryName(file);
    string ext = Path.GetExtension(file);
    string newname = $"Серия {number}{ext}";
    Console.WriteLine($"Файл {filename} переименован в {newname}");
    string combined = $"{directory}\\{newname}";
    System.IO.File.Move(file, combined);
    number += 1;
}