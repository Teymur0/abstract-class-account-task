

namespace abstract_class_account_task
{
    internal class Group
    {
        string groupno;
        public string Groupno
        {
            get => groupno;
            set
            {
                if (CheckGroupNumber(value))
                {
                    groupno = value;
                }
                else
                {
                    Console.WriteLine("Please enter valid group numer. Example - AA000");
                }
            }

        }
        int studentlimit;
        public int Studentlimit
        {
            get => studentlimit;
            set
            {
                if (StudentLimitChecker(value))
                {

                    studentlimit = value;
                }
                else
                {
                    Console.WriteLine("Invalid value");
                }

            }
        }

        private Student[] students = new Student[0];




        public static bool CheckGroupNumber(string str)
        {
            if (str.Length != 5)
            {
                return false;
            }
            return Char.IsUpper(str[0]) && Char.IsUpper(str[1]) && Char.IsDigit(str[2]) && Char.IsDigit(str[3]) && Char.IsDigit(str[4]);

        }

        public Group(string groupno, int studentLimit)
        {
            Groupno = groupno;
            Studentlimit = studentLimit;
        }
        public Student[] AddStudent(Student student)
        {
            if (students.Length > studentlimit)
            {
                return students;
            }

            Array.Resize(ref students, students.Length + 1);

            if (students.Length <= studentlimit)
            {
                students[students.Length - 1] = student;
            }
            else
            {
                Console.WriteLine("You are reached students limit");
            }

            return students;
        }


        public  Student GetStudent(int id)
        {
            foreach (Student student in students)
            {
                if (student.Id == id)
                {
                    return student;
                }

            }
            return null;
        }

        public static bool StudentLimitChecker(int number)
        {
            return number >= 5 && number <= 18;

        }

        public Student[] GetAllStudents()
        {
            return students;
        }
    }
}
