Console.Clear();
Console.Write("Введите число a: ");
int a = Convert.ToInt32(Console.ReadLine());
Console.Write("Введите число b: ");
int b = Convert.ToInt32(Console.ReadLine());

if (a > b){
    Console.WriteLine($"max = {a}");
    Console.WriteLine($"min = {b}");
}else if (a < b){
    Console.WriteLine($"max = {b}");
    Console.WriteLine($"min = {a}");
}else    Console.WriteLine($"{a} = {b}");

