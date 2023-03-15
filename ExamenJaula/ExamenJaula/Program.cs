using ExamenJaula;
using System.IO;

internal class Program
{
    private static void Main(string[] args)
    {
        Jaula jaula= new Jaula();
        bool salir = false;

        String path = "";
        String filename = "Jaula.txt";
        do
        {
            Console.WriteLine("\n--- MENÚ ---");
            Console.WriteLine("1. Listado de animales");
            Console.WriteLine("2. Meter Animal");
            Console.WriteLine("3. Vaciar la jaula");
            Console.WriteLine("4. Cambiar color");
            Console.WriteLine("5. Guardar jaula");
            Console.WriteLine("6. Cargar jaula");
            Console.WriteLine("7. Salir");
            Console.Write("Introduce una opción: ");

            int opcion = int.Parse(Console.ReadLine());
            Console.WriteLine();

            switch( opcion)
            {
                case 1:
                    jaula.Imprime();
                    break;
                case 2:
                    jaula.MeteAnimal();
                    Console.WriteLine("\nAnimal añadido a la jaula");
                    break;
                case 3:
                    jaula.Vacia();
                    Console.WriteLine("\nJaula vaciada");
                    break;
                case 4:
                    Random rng = new Random();
                    string[] colores = { "rojo", "verde", "amarillo" };
                    int colorAleatorio = rng.Next(0, 3);
                    jaula.CambiaColor(colores[colorAleatorio]);
                    Console.WriteLine("\nLoro cambiado de color");
                    break;
                case 5:
                    if (File.Exists(path + filename))
                    {
                        StreamWriter archivo = new StreamWriter(path + filename);
                        foreach (Animal item in jaula.jaula)
                        {
                            if (item is Loro)
                            {
                                archivo.WriteLine($"Loro;{item .sexo} {(item as Loro).GetColor()} ");

                            }
                            else
                            {
                                archivo.WriteLine($"Mono;{item.sexo} {(item as Mono).GetEdad()} ");

                            }

                        }
                        archivo.Flush();
                        archivo.Close();

                    }
                    else
                    {
                        Console.WriteLine("El archivo " + filename + " no existe");
                    }
                    break;
                case 6:
                    if (File.Exists(path + filename))
                    {
                        StreamReader archivo = new StreamReader(path + filename);
                        string linea;
                        while ((linea = archivo.ReadLine()) != null)
                        {
                            string[] datos = linea.Split(';');
                            string tipoAnimal = datos[0];
                            string[] atributos = datos[1].Split(' '); // Separar sexo y atributo extra
                            string sexo = atributos[0];
                            Animal animal;
                            if (tipoAnimal == "Loro")
                            {
                                string color = atributos[1].Trim(); // Obtener atributo extra (color)
                                animal = new Loro(sexo, color);
                            }
                            else
                            {
                                int edad = int.Parse(atributos[1].Trim()); // Obtener atributo extra (edad)
                                animal = new Mono(sexo, edad);
                            }
                            jaula.jaula.Add(animal);
                        }
                        archivo.Close();
                        Console.WriteLine("Archivo cargado exitosamente.");
                    }
                    else
                    {
                        Console.WriteLine("El archivo " + filename + " no existe");
                    }
                    break;
                case 7:
                    salir = true;
                    break;

            }
        } while (!salir);
    }
}