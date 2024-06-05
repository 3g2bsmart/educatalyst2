using System.Text.RegularExpressions;
using System;
using System.Collections.Generic;

namespace educatalyst
{
    internal class Program
    {
        abstract class User
        {
            public string Email;
            public string password;
            abstract public void setData(string email, string password);

        }
        class Admin : User
        {
            public override void setData(string email, string password)
            {
                this.Email = email;
                this.password = password;
            }
        }
        class Employee : User
        {
            public override void setData(string email, string password)
            {
                this.Email = email;
                this.password = password;
            }
        }

        class Student : User
        {
            public override void setData(string email, string password)
            {
                this.Email = email;
                this.password = password;
            }
        }

        class catalog
        {
            public string catalogName;
            public string catalogDescription;
            public string MadicenConponents;
            public int id;
            public catalog(string catalogName, string catalogDescription, string MadicenConponents, int id)
            {
                this.catalogName = catalogName;
                this.catalogDescription = catalogDescription;
                this.MadicenConponents = MadicenConponents;
                this.id = id;
            }

        }
        class Course
        {
            public int id;
            public string name;
            public string description;
            public int duration;
            public Course(string name, string description, int duration, int id)
            {
                this.id = id;
                this.name = name;
                this.description = description;
                this.duration = duration;
            }
        }

        static void Main(string[] args)
        {
            //Admin data
            List<Admin> AdminList = new List<Admin>();
            Admin admin1 = new Admin();
            admin1.setData("ahmedezzat@gmail.com", "12345");
            Admin admin2 = new Admin();
            admin2.setData("MARINA@gmail.com", "54321");
            AdminList.Add(admin1);
            AdminList.Add(admin2);

            //Employee data
            List<Employee> EmployeeList = new List<Employee>();
            Employee employee1 = new Employee();
            employee1.setData("ahmed@gmail.com", "7777");
            Employee employee2 = new Employee();
            employee2.setData("marina@gmail.com", "5555");
            EmployeeList.Add(employee1);
            EmployeeList.Add(employee2);

            //student
            List<Student> StudentList = new List<Student>();
            Student student1 = new Student();
            student1.setData("mark@gmail.com", "3333");
            Student student2 = new Student();
            student2.setData("mariem@gmail.com", "4444");
            StudentList.Add(student1);
            StudentList.Add(student2);

            //catloge
            List<catalog> catlogeList = new List<catalog>();
            //course
            List<Course> courseList = new List<Course>();
            while (true)
            {
                // main menu
                Console.WriteLine("Welcome to educatalyst ");
                Console.WriteLine("1- sign up");
                Console.WriteLine("2- Login");
                int P = int.Parse(Console.ReadLine());
                //sign up
                if (P == 1)
                {
                    Console.WriteLine("1- sign up as admin");
                    Console.WriteLine("2- sign up as Employee ");
                    Console.WriteLine("3- sign up as student");
                    int mm = int.Parse(Console.ReadLine());

                    Console.WriteLine("please Enter Email");
                    string Email = Console.ReadLine();
                    Console.WriteLine("please Enter Password");
                    string Password = Console.ReadLine();


                    string Emailpattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
                    string passwordpattern = @".{4,}";

                    if (Regex.IsMatch(Email, Emailpattern) && Regex.IsMatch(Password, passwordpattern))
                    {
                        //as admin
                        if (mm == 1)
                        {
                            Admin admin3 = new Admin();
                            admin3.setData(Email, Password);
                            AdminList.Add(admin3);
                            Console.WriteLine("you add admin successfuly");
                        }
                        // as employee
                        else if (mm == 2)
                        {
                            Employee emp3 = new Employee();
                            emp3.setData(Email, Password);
                            EmployeeList.Add(emp3);
                            Console.WriteLine("you add employee successfuly");
                        }
                        // as student

                        else if (mm == 3)
                        {
                            Student student3 = new Student();
                            student3.setData(Email, Password);
                            StudentList.Add(student3);
                            Console.WriteLine("you add student successfuly");
                        }
                    }
                    else
                    {
                        Console.WriteLine("wrong data");
                        continue;
                    }



                }
                //LOG IN
                else if (P == 2)
                {
                    Console.WriteLine("1- login as Admin");
                    Console.WriteLine("2- Login as Employee");
                    Console.WriteLine("3- login as student");

                    int x = int.Parse(Console.ReadLine());
                    //admin
                    if (x == 1)
                    {
                        // check  Admin login
                        Console.WriteLine("please Enter Email");
                        string Email = Console.ReadLine();
                        Console.WriteLine("please Enter Password");
                        string password = Console.ReadLine();
                        int login = 0;
                        foreach (var admin in AdminList)
                        {
                            if (admin.Email == Email && admin.password == password)
                            {
                                login = 1;
                            }
                        }
                        if (login == 1)
                        {   //admin menu
                            Console.WriteLine("1- Add cataloge");
                            Console.WriteLine("2- view cataloge");
                            Console.WriteLine("3- Search cataloge");
                            Console.WriteLine("4- delete cataloge");
                            Console.WriteLine("5- Add Course");
                            Console.WriteLine("6- Delete Course");
                            Console.WriteLine("7- Search Course");
                            Console.WriteLine("8- View Course");
                            Console.WriteLine("9- View information");
                            int l = int.Parse(Console.ReadLine());

                            switch (l)
                            {
                                case 1:
                                    Console.WriteLine("add cataloge id");
                                    int id = int.Parse(Console.ReadLine());
                                    Console.WriteLine("add catolge name");
                                    string name = Console.ReadLine();
                                    Console.WriteLine("add catolge description");
                                    string description = Console.ReadLine();
                                    Console.WriteLine("add medcinie component");
                                    string component = Console.ReadLine();

                                    catalog catlogedata = new catalog(name, description, component, id);
                                    catlogeList.Add(catlogedata);
                                    Console.WriteLine("you add cataloge successfully");
                                    break;

                                case 2:
                                    foreach (var cat in catlogeList)
                                    {
                                        Console.WriteLine("cataloge ID is " + cat.id);
                                        Console.WriteLine("cataloge name is " + cat.catalogName);
                                        Console.WriteLine("cataloge Description is " + cat.catalogDescription);
                                        Console.WriteLine("cataloge component is " + cat.MadicenConponents);
                                    }
                                    break;


                                case 3:
                                    Console.WriteLine("enter ID to search ");
                                    int searchId = int.Parse(Console.ReadLine());
                                    int searchResult = 0;
                                    foreach (var search in catlogeList)
                                    {

                                        if (searchId == search.id)
                                        {
                                            Console.WriteLine("we found cataloge");
                                            Console.WriteLine("catloge id is " + search.id);
                                            Console.WriteLine("catloge name is " + search.catalogName);
                                            Console.WriteLine("catloge Description is " + search.catalogDescription);
                                            Console.WriteLine("catloge Component is " + search.MadicenConponents);
                                            searchResult = 1;
                                        }

                                    }
                                    if (searchResult == 0)
                                    {
                                        Console.WriteLine("we cannot find this catloge");
                                    }
                                    break;

                                case 4:
                                    Console.WriteLine("Enter id to delete");
                                    int DeletedID = int.Parse(Console.ReadLine());

                                    int deleteResult = 0;
                                    int deleteResult1 = 0;

                                    foreach (var Delete in catlogeList)
                                    {
                                        if (DeletedID == Delete.id)
                                        {
                                            Console.WriteLine("you deleted successfully");
                                            deleteResult1 = 1;
                                            break;

                                        }
                                        deleteResult++;
                                    }


                                    if (deleteResult1 == 0)
                                    {
                                        Console.WriteLine("we cannot find this id");
                                    }
                                    else
                                    {
                                        catlogeList.RemoveAt(deleteResult);
                                    }

                                    break;

                                case 5:
                                    Console.WriteLine("add course id");
                                    int id1 = int.Parse(Console.ReadLine());
                                    Console.WriteLine("add course name");
                                    string name1 = Console.ReadLine();
                                    Console.WriteLine("add coursee description");
                                    string description1 = Console.ReadLine();
                                    Console.WriteLine("add course duration");
                                    int duration = int.Parse(Console.ReadLine());

                                    Course coursedata = new Course(name1, description1, duration, id1);
                                    courseList.Add(coursedata);
                                    Console.WriteLine("you add course successfully");
                                    break;
                                case 6:

                                    Console.WriteLine("Enter id to delete");
                                    int DeletedID1 = int.Parse(Console.ReadLine());

                                    int deleteResult11 = 0;
                                    int deleteResult111 = 0;

                                    foreach (var Delete in courseList)
                                    {
                                        if (DeletedID1 == Delete.id)
                                        {
                                            Console.WriteLine("you deleted successfully");
                                            deleteResult111 = 1;
                                            break;

                                        }
                                        deleteResult11++;
                                    }
                                    if (deleteResult111 == 0)
                                    {
                                        Console.WriteLine("we cannot find this id");
                                    }
                                    else
                                    {
                                        courseList.RemoveAt(deleteResult11);
                                    }
                                    break;
                                case 7:
                                    Console.WriteLine("enter ID to search ");
                                    int searchId1 = int.Parse(Console.ReadLine());
                                    int searchResult1 = 0;
                                    foreach (var search in courseList)
                                    {

                                        if (searchId1 == search.id)
                                        {
                                            Console.WriteLine("we found course");
                                            Console.WriteLine("course id is " + search.id);
                                            Console.WriteLine("course name is " + search.name);
                                            Console.WriteLine("course Description is " + search.description);
                                            Console.WriteLine("ccourse Component is " + search.duration);
                                            searchResult = 1;
                                        }

                                    }
                                    if (searchResult1 == 0)
                                    {
                                        Console.WriteLine("we cannot find this course");
                                    }
                                    break;
                                case 8:
                                    foreach (var co in courseList)
                                    {
                                        Console.WriteLine("we found course");
                                        Console.WriteLine("course id is " + co.id);
                                        Console.WriteLine("course name is " + co.name);
                                        Console.WriteLine("course Description is " + co.description);
                                        Console.WriteLine("course  duration  is " + co.duration);
                                    }
                                    break;
                            }


                        }
                        else
                        {
                            Console.WriteLine("wrong data");
                            continue;
                        }



                    }
                    else if (x == 2)
                    {
                        // check Employee login
                        Console.WriteLine("please Enter Email");
                        string Email = Console.ReadLine();
                        Console.WriteLine("please Enter Password");
                        string password = Console.ReadLine();
                        int login = 0;
                        foreach (var employee in EmployeeList)
                        {
                            if (employee.Email == Email && employee.password == password)
                            {
                                login = 1;
                            }
                        }
                        if (login == 1)
                        {
                            Console.WriteLine("1- Search cataloge");
                            Console.WriteLine("2- View cataloge");
                            Console.WriteLine("3- send feedback");
                            int k = int.Parse(Console.ReadLine());
                            switch (k)
                            {
                                case 1:
                                    Console.WriteLine("enter ID to search ");
                                    int searchId = int.Parse(Console.ReadLine());
                                    int searchResult = 0;
                                    foreach (var search in catlogeList)
                                    {

                                        if (searchId == search.id)
                                        {
                                            Console.WriteLine("we found cataloge");
                                            Console.WriteLine("catloge id is " + search.id);
                                            Console.WriteLine("catloge name is " + search.catalogName);
                                            Console.WriteLine("catloge Description is " + search.catalogDescription);
                                            Console.WriteLine("catloge Component is " + search.MadicenConponents);
                                            searchResult = 1;
                                        }

                                    }
                                    if (searchResult == 0)
                                    {
                                        Console.WriteLine("we cannot find this catloge");
                                    }
                                    break;
                                case 2:
                                    foreach (var cat in catlogeList)
                                    {
                                        Console.WriteLine("cataloge ID is " + cat.id);
                                        Console.WriteLine("cataloge name is " + cat.catalogName);
                                        Console.WriteLine("cataloge Description is " + cat.catalogDescription);
                                        Console.WriteLine("cataloge component is " + cat.MadicenConponents);
                                    }
                                    break;
                                case 3:
                                    Console.WriteLine("write your feedback");
                                    string feedback = Console.ReadLine();
                                    Console.WriteLine("thank you ");
                                    break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("wrong data");
                            continue;
                        }
                    }


                    else if (x == 3)
                    {
                        Console.WriteLine("please Enter Email");
                        string Email = Console.ReadLine();
                        Console.WriteLine("please Enter Password");
                        string password = Console.ReadLine();
                        int login = 0;
                        foreach (var student in StudentList)
                        {
                            if (student.Email == Email && student.password == password)
                            {
                                login = 1;
                            }
                        }
                        if (login == 1)
                        {
                            //student manue
                            Console.WriteLine("1- Search course");
                            Console.WriteLine("2- View course");
                            Console.WriteLine("3- send feedback");
                            int k = int.Parse(Console.ReadLine());
                            switch (k)
                            {
                                case 1:
                                    Console.WriteLine("enter ID to search ");
                                    int searchId = int.Parse(Console.ReadLine());
                                    int searchResult = 0;
                                    foreach (var search in courseList)
                                    {

                                        if (searchId == search.id)
                                        {
                                            Console.WriteLine("we found course");
                                            Console.WriteLine("ccourse id is " + search.id);
                                            Console.WriteLine("course name is " + search.name);
                                            Console.WriteLine("course Description is " + search.description);
                                            Console.WriteLine("course duration is " + search.duration);
                                            searchResult = 1;
                                        }

                                    }
                                    if (searchResult == 0)
                                    {
                                        Console.WriteLine("we cannot find this catloge");
                                    }
                                    break;
                                case 2:
                                    foreach (var co in courseList)
                                    {
                                        Console.WriteLine("we found course");
                                        Console.WriteLine("course id is " + co.id);
                                        Console.WriteLine("course name is " + co.name);
                                        Console.WriteLine("course Description is " + co.description);
                                        Console.WriteLine("course  duration  is " + co.duration);
                                    }

                                    break;
                                case 3:
                                    Console.WriteLine("write your feedback");
                                    string feedback = Console.ReadLine();
                                    Console.WriteLine("thank you ");
                                    break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("wrong data");
                            continue;
                        }

                    }

                    else
                    {
                        Console.WriteLine("1- exit");
                        Console.WriteLine("2- try again");
                        int y = int.Parse(Console.ReadLine());
                        if (y == 2)
                        {
                            continue;
                        }
                        else
                        {
                            Environment.Exit(0);
                        }
                    }
                }



            }
        }
    }
}
