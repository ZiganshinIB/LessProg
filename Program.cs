Console.Clear();
int taskNomber;
Console.WriteLine("Выбире задание \n В случае когда вы хотите завершить введите 0");
taskNomber = Convert.ToInt32(Console.ReadLine());

//Частые переменные
int count, number, n, m;
int[] IntArray;
int[,] intMatrix2D;

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
double[] InitUserArrayDouble(int count){
    Console.Write("Вы хотите ввести число через пробел?\n Если да нажмите Y:");
    string? simbol = Console.ReadLine();
    if (simbol=="y" || simbol=="Y"){
        return Console.ReadLine().Split(" ").Select(x => double.Parse(x)).ToArray();
    }
    double[] array = new double[count];
    for(int i = 0; i<count; i++){
        Console.Write($"Введите {i+1} элемент: ");
        array[i] = double.Parse(Console.ReadLine());
    }
    return array;
}
double[] InitUserArrayDoubleWithLabel(int count, string[] texts){
    Console.Write("Вы хотите ввести число через пробел?\n Если да нажмите Y:");
    string? simbol = Console.ReadLine();
    if (simbol=="y" || simbol=="Y"){
        return Console.ReadLine().Split(" ").Select(x => double.Parse(x)).ToArray();
    }
    double[] array = new double[count];
    for(int i = 0; i<count; i++){
        Console.Write($"Введите {texts[i]}: ");
        array[i] = double.Parse(Console.ReadLine());
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
string OffsetStr(string str, int step){
    int n = str.Length;
    char[] newStr = str.ToCharArray();
    for(int i = 0; i < n;i++)
       newStr[CalculateOffset(n,step,i)] = str[i];
    return string.Join("",newStr);
}
string replaceSimbol(string str, int targetFrom, int targetTo){
    char[] newStr = str.ToCharArray();
    char temp = newStr[targetFrom];
    newStr[targetFrom] = newStr[targetTo];
    newStr[targetTo] = temp;
    return string.Join("",newStr);
}
int Factor(int n){
    int p=1;
    for (int i=1; i<=n;i++) p*=i;
    return p;
}
string DelElement(string str, int targert){
    char[] newCharArr = new char[str.Length-1];
    int j =0;
    for(int i =0;i<newCharArr.Length;i++,j++){
        if(i == targert) j++;
        newCharArr[i] = str[j];
    }
    return new string(newCharArr);
}
// Перестановка 
void makePermutations(string str,string str2=""){
    if(str.Length==0)
        Console.WriteLine("Bag");
    if(str2==""){
        for(int i = 0; i<str.Length;i++){
            string strWithOutI = DelElement(str,i);
            makePermutations(strWithOutI,str[i].ToString());
        }
    }else if(str.Length>1){
        for(int i = 0; i<str.Length;i++){
            string strWithOutI = DelElement(str,i);
            makePermutations(strWithOutI,$"{str[i].ToString()}{str2}");
        }
    }else{
        Console.WriteLine($"{str}{str2}");
        return;
    }
}
//S Треугольника
double AreaTriangle(double[] points){
    double result = 0.5*((points[2]-points[0])*(points[5]-points[1])-(points[4]-points[0])*(points[3]-points[1]));
    if (result<0) result*=-1;
    return result;
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

// Task 47
double[,] InitMatrixRandomeDouble(int rows, int cols, double min=-10, double max=10)
{
    double[,] doubleMatrix = new double[rows,cols];
    for (int i = 0; i < rows; i++)
        for (int j = 0; j < cols; j++)
            doubleMatrix[i,j] = new Random().NextDouble()*(max-min)+min;        
    return doubleMatrix;
}
double[,] InitMatrixUserDouble(int rows, int cols)
{
    double[,] doubleMatrix = new double[rows,cols];
    for (int i = 0; i < rows; i++)
        for (int j = 0; j < cols; j++){
            Console.Write($"Введите  элемент ({i}{j}): ");
            doubleMatrix[i,j] = Convert.ToDouble(Console.ReadLine());        
        }
    return doubleMatrix;
}
void WriteMatrixDouble(double[,] matrix){
    for (int i = 0; i < matrix.GetLength(0); i++){
        for (int j = 0; j < matrix.GetLength(1); j++)
            Console.Write($"{matrix[i,j]} \t");
        Console.WriteLine();
    }
}

// Task 47
int[,] InitMatrixRandomeInt(int rows, int cols, int min=-10, int max=10)
{
    int[,] intMatrix = new int[rows,cols];
    for (int i = 0; i < rows; i++)
        for (int j = 0; j < cols; j++)
            intMatrix[i,j] = new Random().Next(min, max);        
    return intMatrix;
}
int[,] InitMatrixUserInt(int rows, int cols)
{
    int[,] intMatrix = new int[rows,cols];
    for (int i = 0; i < rows; i++)
        for (int j = 0; j < cols; j++){
            Console.Write($"Введите  элемент ({i}{j}): ");
            intMatrix[i,j] = Convert.ToInt32(Console.ReadLine());        
        }
    return intMatrix;
}
void WriteMatrixInt(int[,] matrix){
    for (int i = 0; i < matrix.GetLength(0); i++){
        for (int j = 0; j < matrix.GetLength(1); j++)
            Console.Write($"{matrix[i,j]} \t");
        Console.WriteLine();
    }
}
// Task 50
void GetElementIntMatrix(int[,] matrix, int row, int col){
    if(matrix.GetLength(0)>row && matrix.GetLength(0)>col)
        Console.WriteLine(matrix[row, col]);
    else
        Console.WriteLine($"{row} {col} -> такой позиции в массиве нет");
}
void GetElementDoubleMatrix(double[,] matrix, int row, int col){
    if(matrix.GetLength(0)>row && matrix.GetLength(0)>col)
        Console.WriteLine(matrix[row, col]);
    else
        Console.WriteLine($"{row} {col} -> такой позиции в массиве нет");
}
// Task 52
void SumColsFromMatrix(int[,] matrix){
    for (int j = 0; j < matrix.GetLength(1); j++){
        int sum = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
            sum+=matrix[i,j];
        Console.Write($"{sum} \t");
    }
}
// task 54
void SortRowMatrix(int[,] matrix){
    for(int i = 0; i<matrix.GetLength(0); i++){
        for(int j = 0; j < matrix.GetLength(1); j++){
            int min = matrix[i,0];
            int index_min = 0;
            for(int k = 0; k<matrix.GetLength(1)-j; k++){
                if(min > matrix[i,k]){
                    min = matrix[i, k];
                    index_min = k;
                }
            }
            matrix[i, index_min] = matrix[i, matrix.GetLength(1)-1 -j];
            matrix[i, matrix.GetLength(1)-1-j] = min;
        }  
    }
}
//task 56
int minSumRowMatrix(int[,] matix){
    int minSum = 0;
    int index_min_sum_row=0;
    for(int j =0; j< matix.GetLength(1); j++){
        minSum += matix[0,j];
    }
    if(matix.GetLength(1) > 1)
    for(int i =1;i < matix.GetLength(0);i++){
        int sumRow = 0;
        for(int j =0; j< matix.GetLength(1); j++){
            sumRow += matix[i,j];
        }
        if(minSum> sumRow){ 
            minSum=sumRow;
            index_min_sum_row = i;    
        }
    }
    return index_min_sum_row;
}
// task 58
int[,] MultMatrixs(int[,] matrix1, int[,] matrix2){
    int[,] Multimatrix = new int[matrix1.GetLength(0), matrix2.GetLength(1)];
    if(matrix1.GetLength(1) == matrix2.GetLength(0)){
        for(int i = 0; i < matrix1.GetLength(0); i++){
            for(int j = 0; j<matrix2.GetLength(1); j++){
                int sum = 0;
                for(int k=0; k < matrix1.GetLength(1); k++){
                    sum += matrix1[i,k] * matrix2[k,j];
                }
                Multimatrix[i,j] = sum;
            }
        }
    }else{
        Console.WriteLine("Матрица не по размеру");
    }
    return Multimatrix;
}
// task 60
void MatrixTask60(int height, int length, int width){
    if((height*length*width)< 90 && height>0 && length>0 && width>0){
        int number = 10;
        for(int i = 0; i<height; i++){
            for(int j = 0; j<length; j++){
                for(int k =0; k<width; k++){
                    Console.WriteLine($"{number} ({i},{j},{k})");
                    number++;
                }
            }
        }
    }else Console.WriteLine("Не могу построить!");  
}

// Task 62
bool IsBorderLeft(int[] border, int[] current){
    return border[0]+1>= current[1]; 
}
bool IsBorderRight(int[] border, int[] current){
    return border[1]-1<= current[1]; 
}
bool IsBorderUp(int[] border, int[] current){
    return border[2]+1>= current[0]; 
}
bool IsBorderBottom(int[] border, int[] current){
    return border[3]-1<= current[0]; 
}
void moveRight(int[,] matrix, int[] current, int count){
    current[1] += 1;
    matrix[current[0], current[1]] = count;
}
void moveBottom(int[,] matrix, int[] current, int count){
    current[0] += 1;
    matrix[current[0], current[1]] = count;
}
void moveLeft(int[,] matrix, int[] current, int count){
    current[1] -= 1;
    matrix[current[0], current[1]] = count;
}
void moveUp(int[,] matrix, int[] current, int count){
    current[0] -= 1;
    matrix[current[0], current[1]] = count;
}
int[,] GetSpiralMatrix(int row, int col){
    int[] border = {-1, col, -1, row}; // Левая Правая Верх Низ - Стены
    bool flag = true;
    int[] current = {0,0};
    int[,] matrix = new int[row,col];
    int count = 0;
    matrix[0,0] = count;
    while(flag){
        while(!IsBorderRight(border,current)){
            Console.WriteLine($"({current[0]} , {current[1]}) ");
            count++;
            moveRight(matrix,current,count);
        }
        border[2] += 1;
        while(!IsBorderBottom(border,current)){
            count++;
            moveBottom(matrix,current,count);
        }
        border[1] -= 1;
        while(!IsBorderLeft(border,current)){
            count++;
            moveLeft(matrix,current,count);
        }
        border[3] -= 1;
        while(!IsBorderUp(border,current)){
            count++;
            moveUp(matrix,current,count);
        }
        border[0] += 1;
        flag = !(IsBorderRight(border,current) && IsBorderBottom(border,current) && IsBorderLeft(border,current) && IsBorderUp(border,current));
    }
    return matrix;
}

// task 61 Pascal
int[] NextStepPascal(int[] step){
    int[] nextStep = new int[step.Length+1];
    nextStep[0] =1;
    if(step.Length==0) return nextStep;
    nextStep[step.Length] = 1;
    for(int i=1; i<step.Length;i++){
        nextStep[i] = step[i-1]+step[i];
    }
    return nextStep;
}
void PrintStepPascal(int[] arr){
    Console.Write(arr[0]);
    for(int i =1; i<arr.Length; i++){
        Console.Write($" {arr[i]}");
    }
}
void PrintPascal(int rank){
    int[] step = new int[0]; 
    for(int i =0; i<rank; i++){
        for(int k =0; k<rank-i-1; k++){
            Console.Write(" ");
        }
        int[] newStep = NextStepPascal(step);
        step = newStep;

        PrintStepPascal(step);
        for(int k =0; k<rank-i-1; k++){
            Console.Write(" ");
        }
        Console.WriteLine();
    }
}
// task 64
string ReversePrintNumbers(int start , int end)
{
    if (start == end)
    {
        Console.Write(start);
        return start.ToString();
    }
    string s = ReversePrintNumbers(start+1, end);
    Console.Write($", {start}");
    return $"{s}, {end}";
}
//task 66
int Sum_Range(int start, int end){
    if (end== start) return start;
    return end + Sum_Range(start, end-1);    
}

//task 68 
int FunctionAkkerman(int m, int n){
    if(m==0) return n+1;
    if(n==0) return FunctionAkkerman(m-1,1);
    return(FunctionAkkerman(m-1, FunctionAkkerman(m, n-1)));
}

// "Транспонирование"
int[,] IntMTransport(int[,] matrix){
    int[,] intMatrix=new int[matrix.GetLength(0),matrix.GetLength(1)];
    for (int i = matrix.GetLength(0)-1, j=0; i >=0; i--,j++){
        for(int k=0;k<matrix.GetLength(1);k++){
            intMatrix[j,k] = matrix[i,k];
            Console.Write($"{matrix[i,k]} \t");
        }
        Console.WriteLine();    
    }
    return intMatrix;
}
// Машина  Негатив
void Negative(){
    Console.WriteLine("Введите размер матрицы: ");
    int[] size = Console.ReadLine().Split(" ").Select(x=>int.Parse(x)).ToArray();
    Console.WriteLine($"{size[0]} {size[1]}");
    Console.Write("Запольнить случайно? (Y-да): ");
    string simbol = Console.ReadLine();
    if(simbol=="y"||simbol=="Y"){
        char[,] charArr= new char[size[0], size[1]];
        char[,] negativeCharArr=new char[size[0], size[1]];
        for(int i=0;i<size[0];i++){
            for(int j=0;j<size[1];j++){
                double flag = new Random().NextDouble();
                if (flag > 0.5) charArr[i,j] = 'B';
                else charArr[i,j] = 'W';
                Console.Write(charArr[i,j]);
                flag = new Random().NextDouble();
                if (flag > 0.5) negativeCharArr[i,j] = 'B';
                else negativeCharArr[i,j] = 'W';
            }
            Console.WriteLine();
        }
        Console.WriteLine();
        // Negative
        int countNegative = 0; 
        for(int i=0;i<size[0];i++){
            for(int j=0;j<size[1];j++){
                Console.Write(negativeCharArr[i,j]);
                if(charArr[i,j]==negativeCharArr[i,j]) countNegative++;
            }
            Console.WriteLine();
        }
        Console.WriteLine();
        Console.WriteLine(countNegative);
    }else{
        char[,] charArr= new char[size[0], size[1]];
        char[,] negativeCharArr=new char[size[0], size[1]];
        for(int i=0;i<size[0];i++){
            for(int j=0;j<size[1];j++){
                Console.Write($"Введите элемент ({i},{j}) матрицы: ");
                charArr[i,j]=Convert.ToChar(Console.ReadLine());
            }
            Console.WriteLine();
        }
        Console.WriteLine();
        for(int i=0;i<size[0];i++){
            for(int j=0;j<size[1];j++){
                Console.Write(charArr[i,j]);
            }
            Console.WriteLine();
        }
        // Input Negative
        int countNegative=0;
        for(int i=0;i<size[0];i++){
            for(int j=0;j<size[1];j++){
                Console.Write($"Введите негативный элемент ({i},{j}) матрицы: ");
                negativeCharArr[i,j]=Convert.ToChar(Console.ReadLine());
                if(charArr[i,j]==negativeCharArr[i,j]) countNegative++;
            }
            Console.WriteLine();
        }
        Console.WriteLine();
        for(int i=0;i<size[0];i++){
            for(int j=0;j<size[1];j++){
                Console.Write(negativeCharArr[i,j]);
            }
            Console.WriteLine();
        }
        Console.WriteLine();
        Console.WriteLine(countNegative);
        
    }
}

// Допник
int[,] RainingMatrix(int n, int m){
    int[,] arr = new int[n,m];
    int i = 0;
    int j = 0;
    for(int k=0; k<n*m;k++){
        if(j<0 || i >= n){
            j = i+1+j;
            i = 0;
        }
        if(j >= m){
            i = j-m+1;
            j = m-1;
        }
        Console.WriteLine($"a[{i} {j}] = {k}; {n} {m}");
        arr[i,j] = k;
        i++; j--;
    }
    return arr; 
}


while (taskNomber != 0){
    switch(taskNomber){
        case -10:
            Console.WriteLine("Дождик : ");
            Console.Write("Введите кол-во строк (n) = ");
            n = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите кол-во стольбцов (m) = ");
            m = Convert.ToInt32(Console.ReadLine());
            int[,] matrix_rain = RainingMatrix(n, m);
            WriteMatrixInt(matrix_rain);
            break;
        case -9:
            Negative();
            break; 
        case -8:
            Console.WriteLine("Транспонирование : ");
            Console.Write("Введите кол-во строк (n) = ");
            n = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите кол-во стольбцов (m) = ");
            m = Convert.ToInt32(Console.ReadLine());
            int[,] matrix_norm = InitMatrixRandomeInt(n, m);
            WriteMatrixInt(matrix_norm);
            int[,] matrix_trans = IntMTransport(matrix_norm);
            WriteMatrixInt(matrix_trans);
            break;
        case -7:
            string[] laebels = {"x1","y1","x2","y2","x3","y3"};
            double[] points = InitUserArrayDoubleWithLabel(6,laebels);
            Console.WriteLine(AreaTriangle(points));
            break;
        case -6:
            Console.Write("Введите символы (1<n<9) ");
            string str = Console.ReadLine();
            makePermutations(str,"");
            break;
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
            n = Convert.ToInt32(Console.ReadLine());
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
        case 47:
            Console.Write("Введите кол-во строк (n) = ");
            n = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите кол-во стольбцов (m) = ");
            m = Convert.ToInt32(Console.ReadLine());
            int[,] IntMatrix = InitMatrixRandomeInt(n, m);
            WriteMatrixInt(IntMatrix);
            break; 
        case 50:
            Console.Write("Введите кол-во строк (n) = ");
            n = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите кол-во стольбцов (m) = ");
            m = Convert.ToInt32(Console.ReadLine());
            int[,] matrix = InitMatrixRandomeInt(n, m);
            Console.Write("Введите координаты  (i, j) через пробел = ");
            int[] cordinate  = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();
            GetElementIntMatrix(matrix,cordinate[0], cordinate[1]);
            break; 
        case 52:
            Console.Write("Введите кол-во строк (n) = ");
            n = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите кол-во стольбцов (m) = ");
            m = Convert.ToInt32(Console.ReadLine());
            int[,] matrix_ = InitMatrixRandomeInt(n, m);
            WriteMatrixInt(matrix_);
            SumColsFromMatrix(matrix_);
            break; 
        case 54:
            Console.WriteLine("Task 54");
            Console.Write("Введите размер матрицы: ");
            int[] size_54 = Console.ReadLine().Split(" ").Select(x => int.Parse(x)).ToArray();
            intMatrix2D = InitMatrixRandomeInt(size_54[0], size_54[1]);
            Console.WriteLine("Входная матрица: ");
            WriteMatrixInt(intMatrix2D);
            SortRowMatrix(intMatrix2D);
            Console.WriteLine("Итоговая матрица");
            WriteMatrixInt(intMatrix2D);
            break;
        case 56:
            Console.WriteLine("Task 56 Задайте прямоугольный двумерный массив.\n Напишите программу, которая будет находить строку с наименьшей суммой элементов.");
            Console.Write("Введите размер матрицы: ");
            int[] size_56 = Console.ReadLine().Split(" ").Select(x => int.Parse(x)).ToArray();
            intMatrix2D = InitMatrixRandomeInt(size_56[0], size_56[1]);
            Console.WriteLine("Входная матрица: ");
            WriteMatrixInt(intMatrix2D);
            Console.Write("Ответ: ");
            Console.WriteLine(minSumRowMatrix(intMatrix2D));
            break;
        case 58:
            Console.WriteLine("Task 58 Задайте две матрицы.\nНапишите программу, которая будет находить произведение двух матриц.");
            Console.Write("Введите размер 1 матрицы: ");
            int[] size_58 = Console.ReadLine().Split(" ").Select(x => int.Parse(x)).ToArray();
            int[,] intMatrix2D_1 = InitMatrixRandomeInt(size_58[0], size_58[1]);
            Console.WriteLine(" матрица 1: ");
            WriteMatrixInt(intMatrix2D_1);
            Console.Write("Введите размер 2 матрицы: ");
            size_58 = Console.ReadLine().Split(" ").Select(x => int.Parse(x)).ToArray();
            int[,] intMatrix2D_2 = InitMatrixRandomeInt(size_58[0], size_58[1]);
            Console.WriteLine(" матрица 2: ");
            WriteMatrixInt(intMatrix2D_2);
            Console.WriteLine("Результат: ");
            WriteMatrixInt(MultMatrixs(intMatrix2D_1, intMatrix2D_2));
            break;
        case 60:
            Console.WriteLine("Task 60 .Сформируйте трёхмерный массив из неповторяющихся двузначных чисел.\n Напишите программу, которая будет построчно выводить массив, добавляя индексы каждого элемента.");
            Console.Write("Введите количество строк: ");
            int height = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите количество стольбцов: ");
            int length = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите количество Масивов: ");
            int width = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Результат");
            MatrixTask60(height,length,width);
            break;
        case 61:
            Console.WriteLine("Task 61 .Вывести первые N строк треугольника Паскаля.\n Сделать вывод в виде равнобедренного треугольника.");
            Console.Write("Введите N: ");
            count = Convert.ToInt32(Console.ReadLine());
            PrintPascal(count);
            break;
        case 62:
            Console.WriteLine("Напишите программу, которая заполнит спирально массив.");
            Console.Write("Введите размер матрицы: ");
            int[] size_62 = Console.ReadLine().Split(" ").Select(x => int.Parse(x)).ToArray();
            WriteMatrixInt(GetSpiralMatrix(size_62[0], size_62[1]));
            break;
        case 64:
            Console.Write("Введите M ");
            int start_64 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите N ");
            int end_64 = Convert.ToInt32(Console.ReadLine());
            ReversePrintNumbers(start_64, end_64);
            Console.WriteLine();
            break;
        case 66:
            Console.Write("Введите M ");
            int start_66 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите N ");
            int end_66 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(Sum_Range(start_66, end_66));
            break;
        case 68:
            Console.Write("Введите M ");
            int m_68 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите N ");
            int n_68 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(FunctionAkkerman(m_68, n_68));
            break;
        default: 
            Console.WriteLine("Ответ: 42");
            break; 
    }
    Console.WriteLine("Выбире задание \n В случае когда вы хотите завершить введите 0");
    taskNomber = Convert.ToInt32(Console.ReadLine());
}