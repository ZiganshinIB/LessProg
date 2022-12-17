Console.Clear();
int taskNomber;
Console.WriteLine("Выбире задание \n В случае когда вы хотите завершить введите 0");
taskNomber = Convert.ToInt32(Console.ReadLine());

//Частые переменные
int count, number;
int[] IntArray;

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
    Console.Write("Вы хотите ввести число через пробел?\n Если да нажмите Y:");
    string? simbol = Console.ReadLine();
    if (simbol=="y" || simbol=="Y"){
        return Console.ReadLine().Split(" ").Select(x => int.Parse(x)).ToArray();
    }
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
double[] InitRandomArrayDouble(int count, double min=-10, double max=10)
{   
    double[] array = new double[count];
    for (int i = 0; i < count; i++){
        array[i] = new Random().NextDouble()*(max-min)+min; // (min, max)
    }
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

// Гипотеза Гольдбаха
int[] getSimpleNumber(int end=999){
    int[] simpleArray = new int[end];
    simpleArray[0]=2;
    int cursor = 1;
    for(int i = 3; i<=end;i++){
        foreach(int SimpleNumber in simpleArray){
            if (SimpleNumber==0){
                simpleArray[cursor] = i;
                cursor++;
                break;
            }else if(i%SimpleNumber==0) break;
        }
    }
    // Костыл который работает только с C# 8
    return simpleArray[0..(cursor)];
}
void getGoldbahResult(int number){
    int[] simpleArray = getSimpleNumber(number);
    foreach(int simpleNumber1 in simpleArray){
        foreach(int simpleNumber2 in simpleArray){
            if ((number - simpleNumber1) == simpleNumber2){
                Console.WriteLine($"{simpleNumber1} {simpleNumber2}");
                return;
            }
        }
    }
    Console.WriteLine("если вы тут, то это Чушь Гольдбаха");
}


// Статистика
void TaskStatistika(){
    Console.Write("Введите кол-во дней: ");
    int count= Convert.ToInt32(Console.ReadLine());
    int[] dayArray = InitUserArrayInt(count);
    int[] gootDayArray = new int[dayArray.Length];
    int[] badDayArray = new int[dayArray.Length];
    int score = 0;
    for (int i =0; i<dayArray.Length;i++){
        int day = dayArray[i];
        if(day%2==0){
            gootDayArray[i] = day;
            score++;
        }else{
            badDayArray[i] = day;
            score--;
        }
    }
    for(int i =0; i<gootDayArray.Length;i++)
        if(gootDayArray[i]>0) Console.Write($"{gootDayArray[i]} ");   
    Console.WriteLine();
    for(int i =0; i<badDayArray.Length;i++)
        if(badDayArray[i]>0) Console.Write($"{badDayArray[i]} ");   
    Console.WriteLine();
    if(score>0) Console.WriteLine("Yes");
    else Console.WriteLine("No");
}

//task 34 
int CountElementsIsEven(int[] array){
    int count =0;
    for(int i =0;i<array.Length; i++)
        if ((array[i] %2) ==0)
            count++;
    return count;
}
//task 34 
void ProcedurEffectCountElementsIsEven(int countElement, int min=100, int max=999){
    int[] array = new int[countElement];
    int count = 0;
    for (int i = 0; i < count; i++){
        int valueItem = new Random().Next(min, max);
        array[i] = valueItem;
        if (valueItem%2==0) count++;    
    }
    Console.WriteLine($"[{string.Join(", ", array)}]");
    Console.WriteLine(count);
}

//task 36
int SumElementsIsNotEven(int[] array){
    int sum =0;
    for(int i =1;i<array.Length; i+=2)
        sum+=array[i];
    return sum;
}
//task 36
void ProcedurEffectSumElementsIsNotEven(int countElement, int min=-10, int max=10){
    int[] array = new int[countElement];
    int sum = 0;
    for (int i = 0; i < count; i++){
        int valueItem = new Random().Next(min, max);
        array[i] = valueItem;
        if (i%2==1) sum+=valueItem;    
    }
    Console.WriteLine($"[{string.Join(", ", array)}]");
    Console.WriteLine(sum);
}

//task 38
double RangeMinMax(double[] array){
    double min = array[0];
    double max = array[0];
    for(int i=1; i<array.Length; i++)
        if(array[i]<min)       min = array[i];
        else if (array[i]>max) max = array[i];
    return max-min;
}
void ProcedurEffectRangeMinMax(int count, double min=-10, double max=10){
    double minItem, maxItem,valueItem;
    valueItem = new Random().NextDouble()*(max-min)+min;
    maxItem = valueItem;
    minItem = valueItem;
    Console.Write($"[{valueItem}");
    for (int i = 1; i < count; i++){
        valueItem = new Random().NextDouble()*(max-min)+min; // (min, max)
        if(valueItem<minItem)       minItem = valueItem;
        else if (valueItem>maxItem) maxItem = valueItem;
        Console.Write($", {valueItem}");
    }
    Console.Write($"]\n{maxItem-minItem}\n");
}

// task 41
int countPositiv(int[] array){
    count = 0;
    foreach (int item in array) if(item>0) count++;
    return count;
}
void ProcedurEffectCountPositivElement(){
    Console.Write("Введите число: ");
    int m = Convert.ToInt32(Console.ReadLine());
    count = 0;
    for(int i =0; i<m;i++){
        Console.Write($"Введите {i+1} элемент: ");
        int element = Convert.ToInt32(Console.ReadLine());
        if(element>0) count++;
    }
    Console.WriteLine(count);
}

// task 43
double[] getIntersection(double k1, double b1, double k2, double b2){
    double x = (b2 - b1)/(k1-k2);
    double y = k1*x+b1;
    double[] result = {x,y};
    return result;
}

while (taskNomber != 0){
    switch(taskNomber){
        case -5:
            TaskStatistika();
            break;
        case -4:
            Console.WriteLine("Гипотеза Гольдбаха : ");
            Console.Write("Введите число: ");
            number = Convert.ToInt32(Console.ReadLine());
            getGoldbahResult(number);
            break;
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
            number = Convert.ToInt32(Console.ReadLine());
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
        case 34:
            Console.WriteLine("Введите кол-во элементов: ");
            count = Convert.ToInt32(Console.ReadLine());
            IntArray  = InitRandomArrayInt(count,100,999);
            Console.WriteLine(CountElementsIsEven(IntArray));
            break;
        case 36:
            Console.WriteLine("Введите кол-во элементов: ");
            count = Convert.ToInt32(Console.ReadLine());
            IntArray  = InitRandomArrayInt(count,-10,10);
            Console.WriteLine(SumElementsIsNotEven(IntArray));
            break;
        case 38:
            Console.WriteLine("Введите кол-во элементов: ");
            count = Convert.ToInt32(Console.ReadLine());
            ProcedurEffectRangeMinMax(count);
            break;
        case 41:
            ProcedurEffectCountPositivElement();
            break;
        case 43:
            Console.Write("Введите k1= ");
            double k1 = Convert.ToDouble(Console.ReadLine());
            Console.Write("Введите b1= ");
            double b1 = Convert.ToDouble(Console.ReadLine());
            Console.Write("Введите k2= ");
            double k2 = Convert.ToDouble(Console.ReadLine());
            Console.Write("Введите b2= ");
            double b2 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine($"({string.Join("; ",getIntersection(k1,b1,k2,b2))})");
            break; 
        default: 
            Console.WriteLine("Ответ: 42");
            break; 
    }
    Console.WriteLine("Выбире задание \n В случае когда вы хотите завершить введите 0");
    taskNomber = Convert.ToInt32(Console.ReadLine());
}