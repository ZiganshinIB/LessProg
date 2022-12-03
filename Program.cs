Console.Clear();
int taskNomber = 42;
Console.WriteLine("Выбире задание \n В случае когда вы хотите завершить введите 0");

while (taskNomber != 0){
    taskNomber = Convert.ToInt32(Console.ReadLine());

    switch(taskNomber){
        case 1: 
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
            break;
        case 2: break;
        case 3: break;
        case 4: break;
        default: 
            Console.WriteLine("Ответ: 42");
            break;
}
}
