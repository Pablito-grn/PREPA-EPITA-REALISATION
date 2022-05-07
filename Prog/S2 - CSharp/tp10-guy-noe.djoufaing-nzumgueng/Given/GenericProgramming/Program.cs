using System;

namespace WWW
{
    class Program
    {
        static void Main(string[] args)
        {
            MyList<int> l = new MyList<int>();
            l.print(); //effectue uniquement un retour à la ligne.
            l.append(7);
            l.append(2);
            //l.print(); // affiche "2" suivit d'un retour à la ligne.
            l.prepend(7);
            l.prepend(0);
            l.append(1);
            l.print();
            // l.print();
            l.insert(10,4); 
            // l.insert(0, 0);
            // l.print();
            l.append(289); 
            l.print();

//   l.print();
        }
    }
}