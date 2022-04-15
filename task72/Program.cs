// Задача 72: Заданы 2 массива: info и data. В массиве info 
// хранятся двоичные представления нескольких чисел (без разделителя). 
// В массиве data хранится информация о количестве бит, которые занимают числа из массива info. 
// Напишите программу, которая составит массив десятичных представлений чисел массива data с учётом 
// информации из массива info.

// Пример:
// входные данные:

// data = {0, 1, 1, 1, 1, 0, 0, 0, 1 } info = {2, 3, 3, 1 }

// выходные данные:1, 7, 0, 1

// Комментарий: первое число занимает 2 бита (01 -> 1); второе число занимает 3 бита (111 -> 7); 
// третье число занимает 3 бита (000 -> 0; четвёртое число занимает 1 бит (1 -> 1)

using System;

void PrintArray(int [] local_array)  // красивая печать одномерного массива
{
  Console.Write("[");
  for(int i=0;i<local_array.Length - 1;i++)
  {
      Console.Write($"{local_array[i]:d}; ");
  }
  Console.WriteLine($"{local_array[local_array.Length - 1 ]:d}]");
}


const int size_info = 10; // Столько чисел будет в результате

int [] info = new int [size_info];  

Random rnd = new Random();
int size_data = 0;

for (int i = 0; i < info.Length; i++)  // 
{
    info[i] = rnd.Next(1,5); // числа будут от 1 до 4 бит
    size_data += info[i];
}

int [] data = new int[size_data];

for (int i = 0; i < data.Length; i++)  // заполняем массив с данными
{
    data[i] = rnd.Next(0,2);
}

int [] ProcessArray()  // возвращаем 10-чный массив в соответствии с info[] по data[]
{
    int [] ret = new int [info.Length];
    int j = 0;  // тут храним позицию, с которой начинается текущее число в data[]
    for (int i = 0; i < info.Length; i++)
    {
        for (int k=0; k < info[i]; k++)
        {
            ret[i] += (int)Math.Pow(2,k)*data[j+info[i]-k-1];   // степень двойки умножаем на текущий бит 
        }                                                       // в обратном порядке
        j += info[i];
    }
    return ret;
}

Console.WriteLine("Массив с данными:");
PrintArray(data);
Console.WriteLine("Массив с информацией:");
PrintArray(info);
int [] rezult = ProcessArray();
Console.WriteLine("Итоговый результат:");
PrintArray(rezult);
