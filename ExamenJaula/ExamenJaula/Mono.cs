using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExamenJaula
{
    public class Mono : Animal
    {
        private int edad;
        public Mono(string sexo, int edad)
        {
            this.edad = edad;
            this.sexo = sexo;  
        }

      

        public int GetEdad()
        {
            return edad;
        }

        public void SetEdad(int nuevaEdad)
        {
            edad = nuevaEdad;
        }

        public override void Imprime()
        {
            base.Imprime();
            Console.WriteLine($"Mono {sexo} {edad}");
        }
    }
}