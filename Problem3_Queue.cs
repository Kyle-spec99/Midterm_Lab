using System;
using System.Collections.Generic;

namespace Problem3
{
    struct StudentRequest
    {
        public string StudentNumber;
        public string StudentName;
        public string RequestType;
    }

    class Problem3_Queue
    {
        static void Main()
        {

            Queue<StudentRequest> requestQueue = new Queue<StudentRequest>();

            int choice;

            do
            {

                Console.WriteLine("STUDENT REQUEST QUEUE");
                Console.WriteLine("1. Add Request");
                Console.WriteLine("2. View Pending Requests");
                Console.WriteLine("3. Process Request");
                Console.WriteLine("4. Exit");

                choice = ReadInt("\nEnter choice: ");

                if (choice == 1)
                {
                    StudentRequest request = new StudentRequest();

                    Console.Write("\nEnter Student Number: ");
                    request.StudentNumber = Console.ReadLine();

                    Console.Write("Enter Student Name: ");
                    request.StudentName = Console.ReadLine();

                    Console.Write("Enter Request Type: ");
                    request.RequestType = Console.ReadLine();

                    requestQueue.Enqueue(request);

                    Console.WriteLine("\nRequest added successfully!");
                }
                else if (choice == 2)
                {
                    if (requestQueue.Count == 0)
                    {
                        Console.WriteLine("\nNo pending requests.");
                    }
                    else
                    {

                        Console.WriteLine("            PENDING REQUESTS");

                        int position = 1;

                        // foreach on a Queue goes from the front (oldest) to the back (newest)
                        foreach (StudentRequest r in requestQueue)
                        {
                            Console.WriteLine(position + ". " + r.StudentNumber + " | " + r.StudentName + " | " + r.RequestType);
                            position++;
                        }
                    }
                }
                else if (choice == 3)
                {
                    if (requestQueue.Count == 0)
                    {
                        Console.WriteLine("\nNo pending requests to process.");
                    }
                    else
                    {
                        StudentRequest processed = requestQueue.Dequeue();

                        Console.WriteLine("\nProcessing request...");
                        Console.WriteLine("Student Number: " + processed.StudentNumber);
                        Console.WriteLine("Student Name: " + processed.StudentName);
                        Console.WriteLine("Request Type: " + processed.RequestType);
                        Console.WriteLine("Request processed successfully!");
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
    }
}
