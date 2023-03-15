using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace ExamenJaula
{
    public class Loro : Animal
    {
      
        private string color;
        public Loro(string color,string sexo)
        {
            this.color = color;
            this.sexo = sexo;
        }

     

        public string GetColor()
        {
            return color;
        }

        public void SetColor(string nuevoColor)
        {
            color = nuevoColor;
        }

        public override void Imprime()
        {
            base.Imprime();
            Console.WriteLine($"Loro {sexo} {color}");
        }
    }
}