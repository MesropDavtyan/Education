using System;
using System.Collections;
using System.Collections.Generic;

namespace IsSymmetric
{
    class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Employee(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }

    class Employees : IEnumerable, IEnumerator
    {
        int position = -1;
        List<Employee> employees = new List<Employee>();
        public void AddEmployee(Employee employee)
        {
            employees.Add(employee);
        }

        public object Current => employees[position];

        public IEnumerator GetEnumerator()
        {
            return this;
        }

        public bool MoveNext()
        {
            if (position < employees.Count - 1)
            {
                position++;
                return true;
            }
            return false;
        }

        public void Reset()
        {
            position = -1;
        }
    }

    class MainClass
    {
        public static void Main(string[] args)
        {
            //Solution solution = new Solution();
            //TreeNode root = new TreeNode(1,
            //    new TreeNode(2,
            //        new TreeNode(4), new TreeNode(3)),
            //    new TreeNode(2,
            //        new TreeNode(3), new TreeNode(4)));

            //Console.WriteLine(solution.IsSymmetric(root));

            Employees employees = new Employees();

            employees.AddEmployee(new Employee(1, "Aram"));
            employees.AddEmployee(new Employee(2, "Mesrop"));
            employees.AddEmployee(new Employee(3, "Gurgen"));

            foreach (Employee employee in employees)
            {
                Console.WriteLine("Employee Id : {0}, Employee Name : {1}", employee.Id, employee.Name);
            }

            employees.Reset();
            while (employees.MoveNext())
            {
                Employee curr = (Employee)employees.Current;
                Console.WriteLine("{0} : {1}", curr.Id, curr.Name);
            }
        }
    }
}
