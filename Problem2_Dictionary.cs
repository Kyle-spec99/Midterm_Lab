using System;
using System.Collections.Generic;

namespace Problem2
{

    struct Student
    {
        public string StudentNumber;
        public string Name;
        public string Program;
        public int YearLevel;
    }

    class Problem2_Dictionary
    {
        static void Main()
        {

            Dictionary<string, Student> studentDictionary = new Dictionary<string, Student>();

            int choice;

            do
            {

                Console.WriteLine("      STUDENT LOOKUP USING DICTIONARY");
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. Search Student");
                Console.WriteLine("3. Display All Students");
                Console.WriteLine("4. Exit");

                choice = ReadInt("\nEnter choice: ");

                if (choice == 1)
                {
                    Console.Write("\nEnter Student Number: ");
                    string number = Console.ReadLine().Trim();


                    if (studentDictionary.ContainsKey(number))
                    {
                        Console.WriteLine("Student Number already exists.");
                    }
                    else
                    {
                        Student s = new Student();
                        s.StudentNumber = number;

                        Console.Write("Enter Name: ");
                        s.Name = Console.ReadLine();

                        Console.Write("Enter Program: ");
                        s.Program = Console.ReadLine();

                        s.YearLevel = ReadYearLevel();


                        studentDictionary.Add(s.StudentNumber, s);

                        Console.WriteLine("\nStudent added successfully!");
                    }
                }
                else if (choice == 2)
                {
                    Console.Write("\nEnter Student Number to search: ");
                    string searchNumber = Console.ReadLine().Trim();

                    if (studentDictionary.TryGetValue(searchNumber, out Student found))
                    {
                        Console.WriteLine("\nStudent Found!");
                        Console.WriteLine("Student Number: " + found.StudentNumber);
                        Console.WriteLine("Name: " + found.Name);
                        Console.WriteLine("Program: " + found.Program);
                        Console.WriteLine("Year Level: " + found.YearLevel);
                    }
                    else
                    {
                        Console.WriteLine("\nStudent Number does not exist.");
                    }
                }
                else if (choice == 3)
                {
                    if (studentDictionary.Count == 0)
                    {
                        Console.WriteLine("\nNo student records found.");
                    }
                    else
                    {

                        Console.WriteLine("            STUDENT RECORDS");

                        foreach (KeyValuePair<string, Student> entry in studentDictionary)
                        {
                            Student s = entry.Value;
                            Console.WriteLine("Student Number: " + s.StudentNumber);
                            Console.WriteLine("Name: " + s.Name);
                            Console.WriteLine("Program: " + s.Program);
                            Console.WriteLine("Year Level: " + s.YearLevel);
                            Console.WriteLine();
                        }
                    }
                }
                else if (choice == 4)
                {
                    Console.WriteLine("\nProgram exited.");
                }
                else
                {
                    Console.WriteLine("Invalid choice.");
                }

            } while (choice != 4);
        }

        // (avoids crashes)
        static int ReadInt(string prompt)
        {
            int value;
            Console.Write(prompt);
            while (!int.TryParse(Console.ReadLine(), out value))
            {
                Console.Write("Invalid input. Enter a number: ");
            }
            return value;
        }


        static int ReadYearLevel()
        {
            int year = ReadInt("Enter Year Level: ");
            while (year < 1 || year > 4)
            {
                year = ReadInt("Year Level must be 1, 2, 3, or 4. Try again: ");
            }
            return year;
        }
    }
}
