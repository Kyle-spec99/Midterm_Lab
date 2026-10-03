using System;
using System.Collections.Generic;

namespace Problem4
{
    // Student structure from Problem 1
    struct Student
    {
        public string StudentNumber;
        public string Name;
        public string Program;
        public int YearLevel;
    }

    // One entry in the operation history
    struct Operation
    {
        public string Action;          // "Added", "Updated", or "Deleted"
        public string StudentNumber;
        public string StudentName;
    }

    class Problem4_Stack
    {
        static void Main()
        {
            Student[] students = new Student[10];
            int studentCount = 0;

            // LIFO: the most recent operation is always on top
            Stack<Operation> operationHistory = new Stack<Operation>();

            int choice;

            do
            {

                Console.WriteLine("        STUDENT RECORD MANAGEMENT");
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. Display All Students");
                Console.WriteLine("3. Search Student");
                Console.WriteLine("4. Update Student");
                Console.WriteLine("5. Delete Student");
                Console.WriteLine("6. View Operation History");
                Console.WriteLine("7. View Last Operation");
                Console.WriteLine("8. Remove Last Operation");
                Console.WriteLine("9. Exit");

                choice = ReadInt("\nEnter choice: ");

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

                        students[studentCount].YearLevel = ReadYearLevel("Enter Year Level: ");

                        // Record the operation on the stack
                        Operation op = new Operation();
                        op.Action = "Added";
                        op.StudentNumber = students[studentCount].StudentNumber;
                        op.StudentName = students[studentCount].Name;
                        operationHistory.Push(op);

                        studentCount++;

                        Console.WriteLine("\nStudent added successfully!");
                    }
                }
                else if (choice == 2)
                {
                    if (studentCount == 0)
                    {
                        Console.WriteLine("\nNo student records found.");
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
                    Console.Write("\nEnter Student Number to search: ");
                    string searchNumber = Console.ReadLine();

                    bool found = false;

                    for (int i = 0; i < studentCount; i++)
                    {
                        if (students[i].StudentNumber == searchNumber)
                        {
                            Console.WriteLine("Student found!");
                            Console.WriteLine("Student Number: " + students[i].StudentNumber);
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
                    Console.Write("\nEnter Student Number to update: ");
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

                            students[i].YearLevel = ReadYearLevel("Enter new Year Level: ");

                            // Record the operation on the stack
                            Operation op = new Operation();
                            op.Action = "Updated";
                            op.StudentNumber = students[i].StudentNumber;
                            op.StudentName = students[i].Name;
                            operationHistory.Push(op);

                            Console.WriteLine("\nStudent updated successfully!");

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
                    Console.Write("\nEnter Student Number to delete: ");
                    string deleteNumber = Console.ReadLine();

                    bool found = false;

                    for (int i = 0; i < studentCount; i++)
                    {
                        if (students[i].StudentNumber == deleteNumber)
                        {
                            // Save the details BEFORE shifting, because the shift overwrites this slot
                            Operation op = new Operation();
                            op.Action = "Deleted";
                            op.StudentNumber = students[i].StudentNumber;
                            op.StudentName = students[i].Name;

                            for (int j = i; j < studentCount - 1; j++)
                            {
                                students[j] = students[j + 1];
                            }

                            studentCount--;

                            // Record the operation on the stack
                            operationHistory.Push(op);

                            Console.WriteLine("\nStudent deleted successfully!");

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
                    // View Operation History
                    if (operationHistory.Count == 0)
                    {
                        Console.WriteLine("\nNo operations recorded.");
                    }
                    else
                    {
                        Console.WriteLine("\nOPERATION HISTORY\n");

                        // ToArray() returns the stack top-first (newest at index 0).
                        // Loop backwards so it prints oldest -> newest like the sample output.
                        Operation[] ops = operationHistory.ToArray();

                        for (int i = ops.Length - 1; i >= 0; i--)
                        {
                            int number = ops.Length - i;
                            Console.WriteLine(number + ". " + ops[i].Action + " " + ops[i].StudentName);
                        }
                    }
                }
                else if (choice == 7)
                {
                    // View Last Operation: Peek() looks at the top WITHOUT removing it
                    if (operationHistory.Count == 0)
                    {
                        Console.WriteLine("\nNo operations recorded.");
                    }
                    else
                    {
                        Operation last = operationHistory.Peek();
                        Console.WriteLine("\nLast Operation: " + last.Action + " " + last.StudentName);
                    }
                }
                else if (choice == 8)
                {
                    // Remove Last Operation: Pop() removes the top of the stack
                    if (operationHistory.Count == 0)
                    {
                        Console.WriteLine("\nNo operations recorded.");
                    }
                    else
                    {
                        operationHistory.Pop();
                        Console.WriteLine("\nLast operation removed successfully!");
                    }
                }
                else if (choice == 9)
                {
                    Console.WriteLine("\nProgram exited.");
                }
                else
                {
                    Console.WriteLine("Invalid choice.");
                }

            } while (choice != 9);
        }

        // Keeps asking until the user types a whole number (avoids crashes)
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

        // Keeps asking until Year Level is 1, 2, 3, or 4
        static int ReadYearLevel(string prompt)
        {
            int year = ReadInt(prompt);
            while (year < 1 || year > 4)
            {
                year = ReadInt("Year Level must be 1, 2, 3, or 4. Try again: ");
            }
            return year;
        }
    }
}
