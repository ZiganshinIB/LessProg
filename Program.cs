Console.Clear();
int taskNomber;
Console.WriteLine("Выбире задание \n В случае когда вы хотите завершить введите 0");
taskNomber = Convert.ToInt32(Console.ReadLine());
while (taskNomber != 0){
    switch(taskNomber){
        case -1:
            Console.Clear();
            Console.Write("Введите кол-во элементов массива: ");
            int n = Convert.ToInt32(Console.ReadLine());
            int maxArray = 0;
            int minArray = 1001;
            int[] array = new int[n];
            for(int i = 0; i < array.Length; i++){
                Console.Write($"Введите {i+1} элемент массива: ");
                array[i] = Convert.ToInt32(Console.ReadLine());
                if(array[i] > maxArray)
                    maxArray = array[i];
                if (array[i]< minArray)
                    minArray = array[i];
            }
            Console.WriteLine($"[{string.Join(", ", array)}]");
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == maxArray)
                    array[i] = minArray;
            }
            Console.WriteLine($"[{string.Join(", ", array)}]");
            break;
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
            Console.WriteLine($"Максимальное число: {max}");
            break;
        case 6: 
            Console.Write("Введите число: ");
            int number_even = Convert.ToInt32(Console.ReadLine());
            if (number_even%2 == 0) Console.WriteLine("Yes");
            else Console.WriteLine("No");
            break;
        case 8: 
            Console.WriteLine("Введите число : ");
            int number_events = Convert.ToInt32(Console.ReadLine());
            Console.Write("-> ");
            int c_8 = 2;
            while(number_events>=c_8){
                Console.Write($"{c_8} ");
                c_8=c_8+2;
            }
            Console.WriteLine(); 
            break;
        case 10:
            Console.Write("Введите трёхзначное число число: ");
            int threeDigit_number = Convert.ToInt32(Console.ReadLine());
            int result = (threeDigit_number/10)%10;
            Console.WriteLine(result);
            break;
        case 13: 
            Console.Write("Введите число: ");
            int number = Convert.ToInt32(Console.ReadLine());
            int p = 100;
            int c = 2;
            if (number-p<0) Console.WriteLine("третьей цифры нет");
            else{
                while(number-p>0){
                    p = p * 10;
                    c = c +1;
                }
                int res = number/(p/1000);
                Console.Write(res%10);
            }
            break;
        case 15:
            Console.Write("Введите день недели: ");
            int day_week = Convert.ToInt32(Console.ReadLine());
            if (day_week > 7 || day_week < 1){
                Console.WriteLine("Не является днем недели");
            }else if(day_week == 7 || day_week == 6){
                Console.WriteLine("Yes");
            }else{
                Console.WriteLine("No");
            }
            break;
        case 18:
            Console.Clear();
            Console.Write("Введите четверт: ");
            int x = Convert.ToInt32(Console.ReadLine());

            while(x>4 || x <1){
                Console.Write("Введите четверт: ");
                x = Convert.ToInt32(Console.ReadLine());
            }
            string smale = "меньше";
            string big = "больше";
            switch (x){
                case 1:
                    Console.WriteLine($"X {big} 0");
                    Console.WriteLine($"Y {big} 0");
                    break;
                case 2:
                    Console.WriteLine($"X {big} 0");
                    Console.WriteLine($"Y {smale} 0");
                    break;
                case 3:
                    Console.WriteLine($"X {smale} 0");
                    Console.WriteLine($"Y {smale} 0");
                    break;
                case 4:
                    Console.WriteLine($"X {smale} 0");
                    Console.WriteLine($"Y {big} 0");
                    break;
                default:
                    Console.WriteLine("Alarm");
                    break;        
            }
            break; 
        default: 
            Console.WriteLine("Ответ: 42");
            break; 
    }
    Console.WriteLine("Выбире задание \n В случае когда вы хотите завершить введите 0");
    taskNomber = Convert.ToInt32(Console.ReadLine());
}