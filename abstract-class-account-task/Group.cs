

namespace abstract_class_account_task
{
    internal class Group
    {
        public string Groupno { get; set; }
        int studentlimit;
        public int Studentlimit
        {
            get => studentlimit;
            set
            {
                if (value >= 5 && value <= 18)
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




        public bool CheckGroupNumber(string str)
        {
            return Char.IsUpper(str[0]) && Char.IsLower(str[1]) && Char.IsDigit(str[2]) && Char.IsDigit(str[3]) && Char.IsDigit(str[4]);

        }

        public Student[] AddStudent( Student student)
        {
            // check length
            Array.Resize(ref students, students.Length + 1);

            if(students.Length <=5)
            {
                students[students.Length - 1] = student;
            }
            else
            {
                Console.WriteLine("You are reached students limit");
            }

            return students;
        }


        public Student GetStudents(Student searchedStudent, int id)
        {
           foreach(Student student in students)
            {
                if (student.Id==id)
                {
                    return student;
                }

            }
            return null;
        }
    }
}
