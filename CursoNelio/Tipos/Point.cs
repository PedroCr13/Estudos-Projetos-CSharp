using System;
using System.Collections.Generic;
using System.Text;

namespace Course
{
    struct Point //tipo valor, não é tipo referência
    {
        public double X;
        public double Y;
        public override string ToString()
        {
            return "("+ X + ", " + Y + ")";
        }
    }
}