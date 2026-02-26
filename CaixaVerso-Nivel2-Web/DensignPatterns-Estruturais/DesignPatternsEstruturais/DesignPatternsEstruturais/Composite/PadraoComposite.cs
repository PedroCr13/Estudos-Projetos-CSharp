using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
    Composite: é um padrão de projeto estrutural que permite compor objetos 
    em estruturas de árvores e então trabalhar com essas estruturas como
    se elas fossem objetos individuais.
    util para representar hierarquias: estruturas de arquivos, pastas
 
    Sistema de RH contendo departamentos: um departamento pode possui outros departamentos ou pessoas
*/

namespace DesignPatternsEstruturais.Composite
{
    public interface IDepartmentComponent
    {
        decimal CalculateTotalSalary();
        string GetName();
    }

    public interface IDepartmentGroup : IDepartmentComponent
    {
        void Add(IDepartmentComponent component);
        void Remove(IDepartmentComponent component);
    }

    public class Employee : IDepartmentComponent
    { 
        public string Name { get; private set; }
        public decimal Salary { get; private set; }

        public Employee(string name, decimal salary )
        {
            Name = name;
            Salary = salary;
        }

        public decimal CalculateTotalSalary()
        {
            return Salary;
        }

        public string GetName()
        {
            return Name;
        }
    }

    public class Department : IDepartmentGroup
    { 
        private List<IDepartmentComponent> children = new List<IDepartmentComponent>();
        public string Name { get; private set; }

        public Department(string name)
        {
            Name = name;
        }

        public void Add(IDepartmentComponent component)
        {
            children.Add(component);
        }

        public void Remove(IDepartmentComponent component)
        { 
            children.Remove(component);
        }

        public decimal CalculateTotalSalary()
        {
            decimal total = 0;
            foreach (var child in children)
            {
                total += child.CalculateTotalSalary();  
            }
            return total;
        }

        public string GetName()
        {
            return Name;
        }
    }
}
