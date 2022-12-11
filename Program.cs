Console.Clear();
int taskNomber;
Console.WriteLine("Выбире задание \n В случае когда вы хотите завершить введите 0");
taskNomber = Convert.ToInt32(Console.ReadLine());

//task 25
int Pow(int number, int a){
    int p = 1;
    for(int i= 0; i<a; i++)
        p = p*number;
    return p;
}

//task 27
int SumDigitsInNumber(int number){
    string SNumber = Convert.ToString(number);
    int sum = 0;
    for(int i=0;i<SNumber.Length;i++){
        sum+= Convert.ToInt32(SNumber[i])-48; //-48 ASCI потому что char 
    }
    return sum;
}

//task 29
int[] InitUserArrayInt(int count){
    int[] array = new int[count];
    for(int i = 0; i<count; i++){
        Console.Write($"Введите {i+1} элемент: ");
        array[i] = int.Parse(Console.ReadLine());
    }
    return array;
}
int[] InitRandomArrayInt(int count, int min=-10, int max=10)
{   
    int[] array = new int[count];
    for (int i = 0; i < count; i++)
        array[i] = new Random().Next(min, max); // [min, max]
    Console.WriteLine($"[{string.Join(", ", array)}]");
    return array;
}


int CalculateOffset(int max, int step, int index){
    return (max+step%max + index)%max;
}
//Суперсдвиг
int[] SuperOffset(int[] array, int step){
    int n = array.Length;
    int[] new_arr = new int[n];
    for(int i = 0; i < n;i++)
        new_arr[CalculateOffset(n,step,i)] = array[i];
    return new_arr;
}


while (taskNomber != 0){
    switch(taskNomber){
        case -3:
            Console.WriteLine("Супер смещение : ");
            Console.Write("Введите кол-во элементов массива: ");
            int count_offset = Convert.ToInt32(Console.ReadLine());
            int[] array_offset =  InitRandomArrayInt(count_offset);
            Console.Write("Введите смещение: ");
            int step_offset = Convert.ToInt32(Console.ReadLine());
            array_offset = SuperOffset(array_offset, step_offset);
            Console.WriteLine($"[{string.Join(", ", array_offset)}]");
            break;
        case -2:
            Console.Write("Введите кол-во Кустов : ");
            int count_bushes = Convert.ToInt32(Console.ReadLine());
            int[] berries = new int[count_bushes];
            int  max_berries = -1;
            int[] indexs_maxs_berries = {0, 0, 0};
            for(int i=0; count_bushes>i;i++ ){
                Console.Write($"Введите кол-во ягод на {i+1} грядке: ");
                berries[i] = Convert.ToInt32(Console.ReadLine());
                if (max_berries<berries[i]){
                    indexs_maxs_berries[0] = i;
                    max_berries = berries[i];
                }
            }
            max_berries = -1;
            for(int i=0; count_bushes>i;i++ )
            if(indexs_maxs_berries[0]!=i && max_berries<berries[i]){
                indexs_maxs_berries[1] = i;
                max_berries = berries[i];
            }
            max_berries = -1;
            for(int i=0; count_bushes>i;i++ )
                if(indexs_maxs_berries[0]!=i && indexs_maxs_berries[1]!=i && max_berries<berries[i]){
                    indexs_maxs_berries[2] = i;
                    max_berries = berries[i];
                }
            int max_sum_berries = 0;
            for(int i=0; i<3;i++ )
                max_sum_berries += berries[indexs_maxs_berries[i]];
                Console.WriteLine(max_sum_berries);
            break;
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
        case 19:
            Console.Write("Введите пятизначное число : ");
            string? number_5 = Console.ReadLine();
            while(number_5.Length !=5){
                Console.Write("Введите пятизначное число : ");
                number_5 = Console.ReadLine();
            }
            if(number_5[0]==number_5[4] && number_5[1]==number_5[3])
                Console.WriteLine("Yes");
            else
                Console.WriteLine("no");
            break;
        case 21:
            Console.Write("Введите координат 1-ой точки через пробел: ");
            string[] point_a_String = Console.ReadLine().Split(" ");
            Console.Write("Введите координат 2-ой точки через пробел: ");
            string[] point_b_String = Console.ReadLine().Split(" ");
            while(point_a_String.Length != point_b_String.Length){
                Console.WriteLine("Кордиаты должны имет одинаковые кол-во точек!!!");
                Console.Write("Введите координат 1-ой точки через пробел: ");
                point_a_String = Console.ReadLine().Split(" ");
                Console.Write("Введите координат 2-ой точки через пробел: ");
                point_b_String = Console.ReadLine().Split(" ");
            }
            double sum_sqr_vector = 0;
            for(int i=0; point_a_String.Length>i;i++ ){
                double point_a = Convert.ToDouble(point_a_String[i]);
                double point_b = Convert.ToDouble(point_b_String[i]);
                sum_sqr_vector += Math.Pow(point_a-point_b,2); 
            }
            Console.WriteLine(Math.Round(
                Math.Sqrt(sum_sqr_vector),2));
            break;
        case 23:
            Console.WriteLine("Введите число : ");
            int number_qrt = Convert.ToInt32(Console.ReadLine());
            Console.Write("-> ");
            for(int i = 1; i>= number_qrt; i++)
                Console.Write($"i*i ");
            Console.WriteLine(); 
            break;
        case 25:
            Console.WriteLine("Введите число: ");
            int number_pow = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите степень: ");
            int a_pow = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(Pow(number_pow, a_pow));
            break;
        case 27:
            Console.WriteLine("Введите число: ");
            int number_sum = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(SumDigitsInNumber(number_sum));
            break;
        case 29:
            Console.WriteLine("Введите кол-во элементов: ");
            int count_item = Convert.ToInt32(Console.ReadLine());
            int[] arr = InitUserArrayInt(count_item);
            Console.WriteLine($"[{string.Join(", ", arr)}]");
            break;
        default: 
            Console.WriteLine("Ответ: 42");
            break; 
    }
    Console.WriteLine("Выбире задание \n В случае когда вы хотите завершить введите 0");
    taskNomber = Convert.ToInt32(Console.ReadLine());
}