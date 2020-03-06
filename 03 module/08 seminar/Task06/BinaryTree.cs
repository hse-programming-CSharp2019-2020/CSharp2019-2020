using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task06
{
    class BTnode<valType> where valType : IComparable<valType>
    {

        public valType _val;
        int _cnt;   // число вставок элементов

        public BTnode<valType> _lchaild;   // ссылка на левый потомок
        public BTnode<valType> _rchaild;   // ссылка на правый потомок

        public BTnode(valType val)
        {
            // конструктор добавляет "лист"
            _val = val;
            _cnt = 1;
            _lchaild = _rchaild = null;
        }

        public void insert_value(valType val)
        { // добавить значение в дерево
            if (val.Equals(_val)) { _cnt++; return; }

            if (val.CompareTo(_val) < 0)
            {
                if (_lchaild == null) _lchaild = new BTnode<valType>(val);
                else _lchaild.insert_value(val);
            }
            else
            {
                if (_rchaild == null) _rchaild = new BTnode<valType>(val);
                else _rchaild.insert_value(val);
            }
        }   // insert_value


    }   // BTnode<>

    class BinaryTree<elemType> where elemType : IComparable<elemType>
    {

        BTnode<elemType> _root; // корень дерева

        public BinaryTree() { _root = null; }   // конструктор

        public void insert(elemType elem)
        { // добавить значение или узел
            if (_root == null)
                _root = new BTnode<elemType>(elem);
            else _root.insert_value(elem);
        }

        public bool Empty { get { return _root == null; } }

        void preorder(BTnode<elemType> pt)
        {
            if (pt != null)
            {
                Console.Write(pt._val + " ");
                if (pt._lchaild != null) preorder(pt._lchaild);
                if (pt._rchaild != null) preorder(pt._rchaild);
            }
        }

        public void print()
        {
            Console.Write("Дерево: ");
            preorder(_root);
            Console.WriteLine();
        }

    }   //  BinaryTree

}
