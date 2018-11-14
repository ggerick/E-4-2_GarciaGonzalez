using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Arbolesss
{
    public class Nodo
    {
        public string dato;
        public Nodo hijo;
        public Nodo hermano;

        public Nodo()
        {
            dato = " ";
            hijo = null;
            hermano = null;

        }
    }

    public class Arbol
    {
        public Nodo raiz;
        public Nodo trabajo;
        public int i = 0;
        public int altura = 0, y = 0;

        public Arbol()
        {
            raiz = new Nodo();
        }

       public Nodo Insertar(string dato, Nodo INodo)
        {
            //Si no hay nodo donde insertar, lo definimos como raiz
            if(INodo == null)
            {
                raiz = new Nodo();
                raiz.dato = dato;

                //No hay hijo
                raiz.hijo = null;

                //No hay hermano
                raiz.hermano = null;
                y++;
                return raiz;
            }

            //Verificamos si no tiene hijo
            //Insertamos el dato como hijo
            if(INodo.hijo == null)
            {
                Nodo temporal = new Nodo();
                temporal.dato = dato;

                //Conectamos el nuevo como hijo
                INodo.hijo = temporal;
                y++;
                return temporal;

            }
            else//El nodo ya tiene un hijo y tenemos que insertarlo como hermano
            {
                trabajo = INodo.hijo;

                //Avanzamos hasta el último hermano 
                while(trabajo.hermano != null)
                {
                    trabajo = trabajo.hermano;
                }
                //Creamos un nodo temporal   
                Nodo temporal = new Nodo();
                temporal.dato = dato;

                //Unimos el temporal al ultimo hermano
                trabajo.hermano = temporal;
                y++;
                altura = (y - 2 / 2);
                return temporal; 
            }
        }

        public void TransversaPreOrder(Nodo INodo)
        {
            if (INodo == null)
                return;

            //Me proceseo primero a mi? 
            for (int n = 0; n < i; n++)
                Console.Write(" ");

            Console.WriteLine(INodo.dato);

            //Lueo procesamos el hijo
            if(INodo.hijo != null)
            {
                i++;
                TransversaPreOrder(INodo.hijo);
                i--;
            }

            //Si tiene hermanos, se procesan
            if (INodo.hermano != null)
                TransversaPreOrder(INodo.hermano);                
        }

        public void TransversaPostOrden(Nodo INodo)
        {
            if (INodo == null)
                return;

            //Primero se procesa al hijo
            if(INodo.hijo != null)
            {
                i++;
                TransversaPostOrden(INodo.hijo);
                i--;
            }

            //Si tengo hermanos, los procesamos
            if (INodo.hermano != null)
                TransversaPostOrden(INodo.hermano);

            //Luego hacemos un self-process
            for (int n = 0; n < i; n++)
            {
                Console.Write(" ");   
            }
            Console.WriteLine(INodo.dato);
        }

        public Nodo Buscar(string dato, Nodo INodo)
        {
            Nodo encontrado = null;
            if (INodo == null)
                return encontrado;
            if (INodo.dato.CompareTo(dato)==0)
            {
                encontrado = INodo;
                return encontrado;
            }

            //Luegose procesa al hijo
            if(INodo.hijo != null)
            {
                encontrado = Buscar(dato, INodo.hijo);

                if (encontrado != null)
                    return encontrado;
            }

            //Si tengo hermanos, se procesan
            if(INodo.hermano != null)
            {
                encontrado = Buscar(dato, INodo.hermano);
                if (encontrado != null)
                    return encontrado;
            }

            return encontrado;
        }

        public  int alturaMaxima(Nodo INodo)
        {
            if (INodo == null)
                return 0;


            int hermano = alturaMaxima(INodo.hermano);
            int hijos = alturaMaxima(INodo.hijo);

            if (hermano > hijos)          
                return hermano + 1;
            
            else
                return hijos + 1;
               
        }

        public void AArboles()//Insertar los nodos en cada arbol y impresion de éstos
        {
            Console.WriteLine("\t\tArbol 1\n");
            Nodo raiz = Insertar("E", null);
           Insertar("F", raiz);
            Nodo nodo = Insertar("A", raiz);
            Insertar("B", nodo);
            Insertar("C", nodo);
            Insertar("D", nodo);
            TransversaPreOrder(raiz);
            Console.WriteLine("La altura es: {0}", altura - 2);
            Console.WriteLine("Ruta del elemento mas largo: E -> A -> (B o C o D)");
            Console.WriteLine("El arbol tiene {0} niveles", altura-3);

            Console.WriteLine("\n\t\tArbol 2\n");
            Nodo raiz2 = Insertar("C", null);
            Insertar("D", raiz2);
            Insertar("F", raiz2);
            Insertar("G", raiz2);
            Nodo nodoA = Insertar("A", raiz2);
            Nodo nodoB = Insertar("B", nodoA);
            Insertar("E", nodoB);
            TransversaPreOrder(raiz2);
            Console.WriteLine("La altura es: 4");
            Console.WriteLine("EL arbol tiene 3 niveles");
            Console.WriteLine("Ruta del elemento mas largo: C -> A -> B -> E");

            Console.WriteLine("\n\t\tArbol 3\n");
            Nodo raiz3 = Insertar("K", null);
            Insertar("B", raiz3);
            Insertar("A", raiz3);
            Insertar("C", raiz3);
            Nodo nodoD3 = Insertar("D", raiz3);
            Nodo nodoE = Insertar("E", nodoD3);
            Insertar("F", nodoE);
            Nodo nodoG = Insertar("G", nodoE);
            Insertar("H", nodoG);
            Nodo nodoI = Insertar("I", nodoD3);
            Insertar("J", nodoI);
            TransversaPreOrder(raiz3);
            Console.WriteLine("La altura es: 5");
            Console.WriteLine("EL arbol tiene 4 niveles");
            Console.WriteLine("Ruta del elemento mas largo: K -> D -> E -> G -> H");
            Console.WriteLine("Ruta de C:\tK -> C");
            Console.WriteLine("Ruta de H:\tK -> D -> E -> G -> H");
            Console.WriteLine("Ruta de J:\tK -> D -> I -> J");
        }
    }
    class MainClass
    {
        public static void Main(string[] args)
        {
            Arbol arboles = new Arbol();
            arboles.AArboles();
        }
    }
}
