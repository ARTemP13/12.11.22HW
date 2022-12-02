using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // все гуд 
            Console.ReadKey();
            Employees employees1 = new Employees("Ильшат", StatusEmployees.TeamLeader);
            Employees employees2 = new Employees("Владимир", StatusEmployees.Developer);
            Employees employees3 = new Employees("Дмитрий", StatusEmployees.Developer);
            Employees employees4 = new Employees("Аркадий", StatusEmployees.Developer);
            Employees employees5 = new Employees("Игорь", StatusEmployees.Developer);
            Employees employees6 = new Employees("Георгий", StatusEmployees.Developer);
            Employees employees7 = new Employees("Маша", StatusEmployees.Developer);
            Employees employees8 = new Employees("Катя", StatusEmployees.Developer);
            Employees employees9 = new Employees("Антон", StatusEmployees.Developer);
            Employees employees10 = new Employees("Илья", StatusEmployees.Developer);

            List<string> EMPL = new List<string>();
            EMPL.Add(employees2.name);
            EMPL.Add("Дмитрий");
            EMPL.Add("Аркадий");
            EMPL.Add("Игорь");
            EMPL.Add("Георгий");
            EMPL.Add("Маша");
            EMPL.Add("Катя");
            EMPL.Add("Антон");
            EMPL.Add("Илья");
            List<Employees> employees = new List<Employees>();
            employees.Add(employees1);
            employees.Add(employees2);
            employees.Add(employees3);
            employees.Add(employees4);
            employees.Add(employees5);
            employees.Add(employees6);
            employees.Add(employees7);
            employees.Add(employees8);
            employees.Add(employees9);
            employees.Add(employees10);
                


            Project Project1 = new Project();
            Project1.status = StatusProject.Project;
            Console.WriteLine("Введите описание проекта: ");
            Project1.description = Console.ReadLine();
            Console.WriteLine("Введите сроки дедлайна: ");
            Project1.deadline = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Введите инициатора проекта: ");
            Project1.employer = Console.ReadLine();
            Project1.ProjectManager = employees1;
            Console.WriteLine("Количество задач в проекте?");
            int n = int.Parse(Console.ReadLine());

            List<Report> tasks = new List<Report>();
            List<Tasks> Task = new List<Tasks>();
            List<string> emloyeername = new List<string>(); 

            int j = 1;
            for (int i = 0; i < n; i++)
            {
                Tasks task1 = new Tasks();
                Report report = new Report();
                if (j == 1)
                {
                    Console.WriteLine("Введите описание задачи");
                    task1.description = Console.ReadLine();
                    Console.WriteLine("Введите дедлайн работы: ");
                    task1.deadline = DateTime.Parse(Console.ReadLine());
                    task1.employer = employees1;
                    
                    j = 1;
                }
                j = 1;
                Console.WriteLine("Введите кому дать задачу(введите номер работника начиная с 0)");
                EMPL.ForEach(Console.WriteLine);
                int m = int.Parse(Console.ReadLine());
                task1.status = Status.assigned;
                Console.WriteLine(EMPL[m] + ":\nПринять задачу - 0\nДелегировать задачу - 1\nОтказаться от задачи - 2");
                int y = int.Parse(Console.ReadLine());
                switch (y)
                {
                    case 0:
                        task1.employees = employees[m];
                        Console.WriteLine("Задача добавлена работнику: " + EMPL[m]);
                        task1.status = Status.work;
                        emloyeername.Add(EMPL[m]);
                        tasks.Add(report);
                        Task.Add(task1);
                        break;
                    case 1:
                        Console.WriteLine("Кому хочешь делегировать задачу?");
                        int empl = int.Parse(Console.ReadLine());
                        task1.employees = employees[empl];
                        task1.status = Status.work;
                        emloyeername.Add(EMPL[m]);
                        tasks.Add(report);
                        Task.Add(task1);
                        Console.WriteLine("Задача добавлена работнику: " + EMPL[empl]);

                        break;
                    case 2:
                        
                        Console.WriteLine(EMPL[m] + " не взял задачу!");
                        Console.WriteLine("Удалить задачу - 0\nДать задачу другому - 1");
                        int t = int.Parse(Console.ReadLine());
                        if(t == 0)
                        {
                            i--;
                            Console.WriteLine("Задача удалена");
                        }
                        else
                        {
                            i--;
                            j--;
                        }

                        break;

                }

            }
            Project1.status = StatusProject.Execution;
            int k = 0;
            int[] kol = new int[n];
            for (int i = 0; i < n; i++)
            {
                kol[i] = -1;
            }    
            int l = 0;
            while ((n-k) != 0)
            {
                
                for (int i = 0; i < n-k; i++)
                {
                   
                    Console.WriteLine(emloyeername[i] + ", напишите отчет");
                    tasks[i].text = Console.ReadLine();
                    tasks[i].employees = tasks[i].employees;
                    tasks[i].deadline = DateTime.Now;
                    Task[i].status = Status.check;
                }
                int g = 0;
                for (int i = 0; i < n-k; i++)
                {
                    Console.WriteLine($"Текст отчета: {tasks[i].text}\nДата выполнения: {tasks[i].deadline}\nКем выполнен отчет: {emloyeername[i]}");
                    Console.WriteLine("Принять отчет - 0\nОтправить на доработку - 1");
                    int q = int.Parse(Console.ReadLine());
                    switch (q)
                    {
                        case 0:
                            Task[i].status = Status.done;
                            Task.RemoveAt(i);
                            kol[l] = i;
                            l++;
                            g++;
                            Console.WriteLine("Отчет принят");
                            break;
                        case 1:
                            
                            Task[i].status = Status.work;
                            Console.WriteLine("Отчет не принят");
                            break;
                    }
                }
                k += g;
            }
            Project1.status = StatusProject.Close;
            Console.WriteLine("Проект выполнен и закрыт!!!");
            Console.ReadKey();
        }
    }
}
