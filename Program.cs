using System;

namespace ProyectoAlgebra
{
    class Program
    {
        static void Main(string[] args)
        {
            //Ingresando columnas y filas:
            Console.WriteLine("******Programa para resolver matrices por el método Gauss-Jordan******");
            Console.WriteLine("-Ingrese el número de filas: ");
            int fila = Validar();
            Console.WriteLine("-Ingrese el número de columnas: ");
            int columna = Validar();
            //Creando la matriz:
            float[,] matriz = new float[fila, columna];
            //Llenando la matriz
            matriz = LlenarMatriz(matriz);
            //Resolviendo por Gauss-Jordan;
            matriz = GaussJordan(matriz);

        }

        public static int Validar()
        {
            int numero = 0;
            bool siNo = true;
            while (siNo)
            {
                try
                {
                    numero = Convert.ToInt32(Console.ReadLine());
                    siNo = false;
                }
                catch
                {
                    Console.WriteLine("¡Favor de introducir solo números!");
                    siNo = true;
                }
            }
            return numero;
        }

        public static float[,] LlenarMatriz(float[,] matriz)
        {
            //Llenado de la matriz:
            for (int i = 0; i < matriz.GetLength(0); i++)
            {
                for (int j = 0; j < matriz.GetLength(1); j++)
                {
                    Console.WriteLine("Introduce el número de la posicion (" + (i + 1) + "," + (j + 1) + ")");
                    matriz[i, j] = Validar();
                }

            }
            Console.WriteLine("Los datos se han guardado con éxito");
            Console.WriteLine("Tu matriz es: ");
            //Imprimiendo la matriz:
            Imprimir(matriz);
            return matriz;
        }

        public static void Imprimir(float[,] matriz)
        {
            //Imprimimos la  matriz:
            for (int i = 0; i < matriz.GetLength(0); i++)
            {
                for (int j = 0; j < matriz.GetLength(1); j++)
                {
                    Console.Write(matriz[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        public static float[,] GaussJordan(float[,] matriz)
        {
            float constante;
            float pivote;

            //Resolvemos por Gauss-Jordan:
            for (int i = 0; i < matriz.GetLength(0); i++) //Ciclo que nos ayuda a encontrar el pivote y recorre las filas
            {
                //Nuestro pivote sera cuando i=i ejemplo: 0,0 1,1 2,2:
                pivote = matriz[i, i];

                //Una vez encontrado el pivote, dividimos el renglón entre el pivote para lograr 1 en la matriz:
                for (int j = 0; j < matriz.GetLength(1); j++)//Recorre las columnas
                {
                    matriz[i, j] = matriz[i, j] / pivote;
                }

                Console.WriteLine("********");

                for (int k = 0; k < matriz.GetLength(0); k++)//Para recorrer las filas de la matriz
                {
                    //Decimos que k=filas, i=columnas (elegimos i, porque es donde está la columna de nuestro pivote)
                    constante = -1 * matriz[k, i]; //i es estática, porque solo nos movemos entre filas

                    for (int j = 0; j < matriz.GetLength(1); j++)//Para recorrer columnas
                    {
                        if (k != i) //Condición para realizar operaciones elementales y evitar alterar nuestro pivote
                        {
                            //reglón pivote  //renglón que queremos eliminar 
                            matriz[k, j] = (constante * matriz[i, j]) + matriz[k, j];
                        }
                        if (matriz[k, j] == -0)
                        {
                            matriz[k, j] = 0;
                        }

                    }

                }
                Imprimir(matriz);
            }
            return matriz;
        }

    }
}
