using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task04
{
    interface IPublication  // интерфейс публикаций
    {
        void write();               // готовить публикацию
        void read();                // читать публикацию
        string Title { set; get; }  // название публикации
    }
    interface IBook : IPublication  // интерфейс книг
    {
        string Author { set; get; } // автор
        int Pages { set; get; }     // количество страниц
        string Publisher { get; }   // издательство
        int Year { get; set; }      // год опубликования
    }

    class Book : IBook
    {
        string title;   // название книги
        string author;  // автор
        int pages;      // количество страниц
        string publisher;   // издательство
        int year;       // год опубликования
        public string Title
        {
            set { title = value; }
            get { return title; }
        }
        public string Author
        {
            set { author = value; }
            get { return author; }
        }
        public int Pages { set { pages = value; } get { return pages; } }
        public string Publisher
        {
            set { publisher = value; }
            get { return publisher; }
        }
        public int Year { set { year = value; } get { return year; } }

        public void write() { /* операторы метода */ }
        public void read() { /* операторы метода */}
    }

    class Program
    {
        static void Main(string[] args)
        {
            Book booklet = new Book();
            booklet.Author = "Л.Н. Волгин";
            booklet.Title = @"""Принцип согласованного оптимума""";
            Console.WriteLine("Автор: {0}, Название: {1}.",
            booklet.Author, booklet.Title);
            Console.ReadKey();
        }
    }
}
