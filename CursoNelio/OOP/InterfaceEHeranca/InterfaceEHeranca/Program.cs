using System;
using Curso.Model;
using Curso.Model.Entities;
using Curso.Model.Enums;
using Curso.Model.Entities;

namespace Curso.Aula
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IShape s1 = new Circle() { Radius = 2.0, Color = ColorShape.White };
            IShape s2 = new Rectangle() { Width = 3.5, Height = 4.2, Color = ColorShape.black };
            Console.WriteLine(s1);
            Console.WriteLine(s2);
        }
    }
}

