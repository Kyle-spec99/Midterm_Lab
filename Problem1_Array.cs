using System;

namespace Problem1
{
    struct Student
    {
        public string StudentNumber;
        public string Name;
        public string Program;
        public int YearLevel;
    }

    class Problem1_Array
    {
        static void Main()
        {
            Student[] students = new Student[10];
            int studentCount = 0;

            int choice;

            do
            {

                Console.WriteLine("        STUDENT RECORD MANAGEMENT");
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. Display All Students");
                Console.WriteLine("3. Search Student");
                Console.WriteLine("4. Update Student");
                Console.WriteLine("5. Delete Student");
                Console.WriteLine("6. Exit");

                Console.Write("\nEnter choice: ");
                choice = int.Parse(Console.ReadLine());

                if (choice == 1)
                {
                    if (studentCount >= 10)
                    {
                        Console.WriteLine("Cannot add more than 10 students.");
                    }
                    else
                    {
                        Console.Write("\nEnter Student Number: ");
                        students[studentCount].StudentNumber = Console.ReadLine();

                        Console.Write("Enter Name: ");
                        students[studentCount].Name = Console.ReadLine();

                        Console.Write("Enter Program: ");
                        students[studentCount].Program = Console.ReadLine();

                        Console.Write("Enter Year Level: ");
                        students[studentCount].YearLevel = int.Parse(Console.ReadLine());

                        studentCount++;

                        Console.WriteLine("\nStudent added successfully!");
                    }
                }
                else if (choice == 2)
                {
                    if (studentCount == 0)
                    {
                        Console.WriteLine("No student records found.");
                    }
                    else
                    {

                        Console.WriteLine("            STUDENT RECORDS");


                        for (int i = 0; i < studentCount; i++)
                        {
                            Console.WriteLine("Student Number: " + students[i].StudentNumber);
                            Console.WriteLine("Name: " + students[i].Name);
                            Console.WriteLine("Program: " + students[i].Program);
                            Console.WriteLine("Year Level: " + students[i].YearLevel);
                            Console.WriteLine();
                        }
                    }
                }
                else if (choice == 3)
                {
                    Console.Write("Enter Student Number to search: ");
                    string searchNumber = Console.ReadLine();

                    bool found = false;

                    for (int i = 0; i < studentCount; i++)
                    {
                        if (students[i].StudentNumber == searchNumber)
                        {
                            Console.WriteLine("Student found!");
                            Console.WriteLine("Name: " + students[i].Name);
                            Console.WriteLine("Program: " + students[i].Program);
                            Console.WriteLine("Year Level: " + students[i].YearLevel);

                            found = true;
                            break;
                        }
                    }

                    if (!found)
                    {
                        Console.WriteLine("Student not found.");
                    }
                }
                else if (choice == 4)
                {
                    Console.Write("Enter Student Number to update: ");
                    string updateNumber = Console.ReadLine();

                    bool found = false;

                    for (int i = 0; i < studentCount; i++)
                    {
                        if (students[i].StudentNumber == updateNumber)
                        {
                            Console.Write("Enter new Name: ");
                            students[i].Name = Console.ReadLine();

                            Console.Write("Enter new Program: ");
                            students[i].Program = Console.ReadLine();

                            Console.Write("Enter new Year Level: ");
                            students[i].YearLevel = int.Parse(Console.ReadLine());

                            Console.WriteLine("Student updated successfully!");

                            found = true;
                            break;
                        }
                    }

                    if (!found)
                    {
                        Console.WriteLine("Student not found.");
                    }
                }
                else if (choice == 5)
                {
                    Console.Write("Enter Student Number to delete: ");
                    string deleteNumber = Console.ReadLine();

                    bool found = false;

                    for (int i = 0; i < studentCount; i++)
                    {
                        if (students[i].StudentNumber == deleteNumber)
                        {
                            for (int j = i; j < studentCount - 1; j++)
                            {
                                students[j] = students[j + 1];
                            }

                            studentCount--;

                            Console.WriteLine("Student deleted successfully!");

                            found = true;
                            break;
                        }
                    }

                    if (!found)
                    {
                        Console.WriteLine("Student not found.");
                    }
                }
                else if (choice == 6)
                {
                    Console.WriteLine("\nProgram exited.");
                }
                else
                {
                    Console.WriteLine("Invalid choice.");
                }

            } while (choice != 6);
        }
    }
}
