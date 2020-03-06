using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task06
{
    class Program 
    {
        static void Main()
        {
            BinaryTree<string> bt = new BinaryTree<string>();
            bt.insert("Me"); bt.insert("Mom");
            bt.insert("Dad"); bt.insert("Dad\\’s dad");
            bt.insert("Mom\\’s mom"); bt.insert("Dad\\’s mom");
            bt.insert("Mom\\’s dad");
            bt.print();

            BinaryTree<int> bi = new BinaryTree<int>();
            bi.insert(-4); bi.insert(9);
            bi.insert(3); bi.insert(7);
            bi.insert(-4); bi.insert(9);
            bi.print();
            Console.WriteLine("Для выхода нажмите любую клавишу!");
            Console.ReadKey(true);
        }
    }
}
