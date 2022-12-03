Console.Clear();
int taskNomber = 42;
Console.WriteLine("Выбире задание \n В случае когда вы хотите завершить введите 0");

while (taskNomber != 0){
    taskNomber = Convert.ToInt32(Console.ReadLine());

    switch(taskNomber){
        case 2: 
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
        case 4:
            Console.Write("Введите число 1 число : ");
            int n_1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите число 2 число: ");
            int n_2 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите число 3 число: ");
            int n_3 = Convert.ToInt32(Console.ReadLine());
            int max = n_1;
            if (n_2>max) max = n_2;
            if (n_3>max) max = n_3;
            break;
        case 6: break;
        case 8: break;
        default: 
            Console.WriteLine("Ответ: 42");
            break;
    }
}
