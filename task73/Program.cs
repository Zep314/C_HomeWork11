// Задача 73: Есть число N. Сколько групп M, можно получить при разбиении всех чисел на группы,
// так чтобы в одной группе все числа были взаимно просты (все числа в группе друг на друга не делятся)?
// Найдите M при заданном N и получите одно из разбиений на группы N <= 10^20.

// Например, для N = 50, M получается 6
// Группа 1: 1
// Группа 2: 2 3 5 7 11 13 17 19 23 29 31 37 41 43 47
// Группа 3: 4 6 9 10 14 15 21 22 25 26 33 34 35 38 39 46 49
// Группа 4: 8 12 18 20 27 28 30 42 44 45 50
// Группа 5: 16 24 36 40
// Группа 6: 32 48

using System;

void MyPrintMatrix(int [,] localMatrix)  // красиво печатаем матрицу
{
    for (int i=0; i<localMatrix.GetLength(0);i++)
    {
        if (localMatrix[i,0] == 0) {break;} // обрываем печать строки
        else
        {
            Console.Write($"Группа {i+1}: ");
            for (int j=0; j<localMatrix.GetLength(1);j++)
            {
                if (localMatrix[i,j] == 0) {break;}
                else
                    Console.Write($"{localMatrix[i,j],4}");
            }
            Console.WriteLine();
        }
    }
}

void ProcessMatrix(int n, int [,] localMatrix)  // делаем расчет матрицы
{
    bool flag = false;  
    for (int k = 1; k<=n; k++)  // цикл по всем числам
    {
        flag = false;
        for (int i = 0; i<localMatrix.GetLength(0); i++)  // цикл по строкам
        {
            for (int j = 0; j<localMatrix.GetLength(1); j++)
            {
                if (localMatrix[i,j] == 0)  // если нашли пустую ячеку - то заполняем ее 
                {                           // и выходим из циклов i и j
                    localMatrix[i,j]=k;
                    flag = true;
                    break;
                }
                else
                {
                   if (k % localMatrix[i,j] == 0) {break;}  // если число делится на то, что есть в матрице
                                                            // то переходим в следующую группу
                }
            }
            if (flag) {break;}  // это если заполнили свободную ячейку - чтобы перейти к след. числу
        }
    }
}

// Основная программа

Console.Write("Введите N: ");
int N = Convert.ToInt32(Console.ReadLine());

// заполняем матрицу нулями
int [,] matrix = new int [N,N];
for (int i = 0; i<matrix.GetLength(0); i++)
    for (int j = 0; j<matrix.GetLength(1); j++)
        matrix[i,j] = 0;

ProcessMatrix(N,matrix);  // расчет

int M = 0;  // считаем заполненные строки в матрице
for (int i = 0;i<matrix.GetLength(0); i++)
    if (matrix[i,0] == 0) {break;}
    else {M++;}

Console.WriteLine($"Для N={N}, будет M={M} взаимно простых групп:");

MyPrintMatrix(matrix);
