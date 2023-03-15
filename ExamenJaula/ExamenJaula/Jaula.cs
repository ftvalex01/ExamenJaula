using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace ExamenJaula
{
    public class Jaula
    {
        public List<Animal> jaula;
        public Jaula()
        {
            jaula = new List<Animal>();
        }

        public void Imprime()
        {
            int total = 0;
            int sexoM = 0;
            int sexoH = 0;
            int loroCount = 0;
            int monoCount = 0;
            List<Loro> loros = new List<Loro>();
            List<Mono> monos = new List<Mono>();

            foreach (Animal item in jaula)
            {
                item.Imprime();
                total++;
                if (item.sexo == "macho")
                {
                    sexoM++;
                }
                else if (item.sexo == "hembra")
                {
                    sexoH++;
                }
                if (item is Loro)
                {
                    loros.Add((Loro)item);
                    loroCount++;
                }
                else if (item is Mono)
                {
                    monos.Add((Mono)item);
                    monoCount++;
                }
            }
            Console.WriteLine($"Hay {loroCount} loros y {monoCount} monos");
            Console.WriteLine($"Hay {sexoH} hembras y {sexoM} machos");
        }

       

        public void Vacia()
        {
            jaula.Clear();
        }

        public void MeteAnimal()
        {
            Random rng = new Random();
            int tipoAnimal = rng.Next(0, 2);
            if (tipoAnimal == 0) {
                //loro
                string[] colores = { "rojo", "verde", "amarillo" };
                string[] sexo = { "hembra", "macho" };
                int colorAleatorio = rng.Next(0,3);
                int sexoAleatorio = rng.Next(0, 2);

                Loro loro = new Loro(colores[colorAleatorio], sexo[sexoAleatorio]);
                jaula.Add(loro);
            }
            else
            {
                //mono
                int[] edad = {1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,29,20};
                string[] sexo = { "hembra", "macho" };
                int edadAleatoria = rng.Next(0, 20);
                int sexoAleatorio = rng.Next(0, 2);

                Mono mono = new Mono(sexo[sexoAleatorio], edad[edadAleatoria]);
                jaula.Add(mono);
            }
        }

        public void CambiaColor(string nuevoColor)
        {
            foreach (Animal animal in jaula)
            {
                if (animal is Loro)
                {
                    Loro loro = (Loro)animal;
                    loro.SetColor(nuevoColor);
                }
            }
        }
    }
}