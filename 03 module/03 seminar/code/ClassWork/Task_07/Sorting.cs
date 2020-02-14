using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_07
{
    public delegate void SortHandler(long cn, int si, int kl);
    class Sorting
    { // класс сортировки массивов    
        int[] arr;   // ссылка на массив
        public long count; // счетчик выполненных обменов при сортировке
        public event SortHandler onSort; // объявление события
        public Sorting(int[] ls)
        { // конструктор            
            count = 0; arr = ls;
        }
        public void Sort()
        {// сортировка с посылкой извещений         
            int temp;
            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                    if (arr[i] > arr[j])
                    {
                        temp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = temp;
                        count++;
                    }
                if (onSort != null) // сортировка не завершена
                    onSort(count, arr.Length, i); // генерация события
            }
        }
    }

}
