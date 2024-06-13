using System.Collections.Concurrent;

namespace abstract_class_account_task
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter user fullname: ");
            string fullName = Console.ReadLine();
            Console.Write("Enter user e-mail: ");
            string email = Console.ReadLine();
            string password;
            User user;

            while (true)
            {
                Console.Write("Enter password: ");
                password = Console.ReadLine();
                user = new User(fullName, email, password);

                if (user.PasswordChecker(password))
                {
                    Console.WriteLine("User was created.");
                    break;
                }
            }

            while (true)
            {
                Console.WriteLine("1.Show info");
                Console.WriteLine("2.Create new group");
                int command = 0;
                bool userCommand = int.TryParse(Console.ReadLine(), out command);

                if (userCommand)
                {
                    switch (command)
                    {

                        case 1:
                            user.ShowInfo();
                            break;

                        case 2:
                            enterValidGroupNumber:
                            Console.Write("Enter group number: ");
                            string grouNo = Console.ReadLine();
                            if (!Group.CheckGroupNumber(grouNo))
                            {
                                Console.WriteLine("Enter valid group number");
                                goto enterValidGroupNumber;
                            }
                            enterValidStudentLimit:
                            Console.Write("Enter student limit: ");
                            int studentLimit;
                            bool isValidLimit = int.TryParse(Console.ReadLine(), out studentLimit);
                            if (!Group.StudentLimitChecker(studentLimit))
                            {
                                Console.WriteLine("Enter number between 5 and 18");
                               goto enterValidStudentLimit;
                            }
                           
                            Group group = new(grouNo, studentLimit);



                            if (Group.CheckGroupNumber(grouNo) && Group.StudentLimitChecker(studentLimit))
                            {


                                while (true)
                                {
                                    Console.WriteLine("1. Show all students.");
                                    Console.WriteLine("2. Get student by Id.");
                                    Console.WriteLine("3. Add a student.");
                                    Console.WriteLine("0. Quit.");
                                    Console.WriteLine("-----------------------");
                                    Console.Write("Enter command number: ");

                                    int subCommand;
                                    bool isValidSubCommand = int.TryParse(Console.ReadLine(), out subCommand);


                                    if (!isValidSubCommand)
                                    {
                                        Console.WriteLine("Please enter valid command");
                                        return;
                                    }


                                    switch (subCommand)
                                    {

                                        case 0:
                                            return;


                                        case 1:

                                            Student[] students = group.GetAllStudents();

                                            if (students.Length > 0)
                                            {
                                                foreach (Student student in students)
                                                {
                                                    Console.WriteLine(student.Fullname);
                                                    Console.WriteLine(student.Point);
                                                }

                                            }
                                            else
                                            {
                                                Console.WriteLine("Students does not exsist.");
                                            }

                                            break;

                                        case 2:
                                           validStudentId:
                                            Console.Write("Enter student Id: ");

                                            int studentId;
                                            bool isValidStudentId = int.TryParse(Console.ReadLine(), out studentId);


                                            if (!isValidStudentId)
                                            {
                                                Console.WriteLine("Enter valid student id ");
                                                goto validStudentId;
                                            }

                                            Student searchedStudent = group.GetStudent(studentId);
                                            if (searchedStudent != null)
                                            {
                                                Console.WriteLine(searchedStudent.Fullname);
                                                Console.WriteLine(searchedStudent.Point);

                                            }
                                            else
                                            {
                                                Console.WriteLine("Student not found.");
                                                break;
                                            }
                                            break;
                                        case 3:
                                            Console.Write("Enter student fullname: ");
                                            string studentFullName = Console.ReadLine();
                                            Console.Write("Enter student point: ");
                                            decimal studentPoint;
                                            bool isValidStudentPoint = decimal.TryParse(Console.ReadLine(), out studentPoint);


                                            if (!isValidStudentPoint)
                                            {
                                                Console.WriteLine("Please enter a valid point.");
                                                break;
                                            }
                                            Student newStudent = new Student(studentFullName, studentPoint);
                                            group.AddStudent(newStudent);
                                            Console.WriteLine("Student was added.");
                                            break;

                                        default:
                                            Console.WriteLine("Invalid command.");
                                            break;

                                    }

                                }

                            }
                            break;
                        default:
                            Console.WriteLine("Plase enter valid command");
                            break;
                    }

                }

                else
                {
                    Console.WriteLine("Enter valid comand");
                }

            }


        }
    }
}

