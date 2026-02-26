using Curso.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Curso.Model.Enums;

namespace Curso.Model.Entities
{
    abstract class AbstractShape : IShape
    {
        public ColorShape Color { get; set; }

        public abstract double Area();             
    }
}
