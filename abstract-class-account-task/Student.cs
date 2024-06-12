

namespace abstract_class_account_task
{
    internal class Student
    {
        private static int _id=0;
        public int Id { get; set; }

        public string Fullname { get; set; }
        public decimal Point { get; set; }

        public Student(string fullName , decimal point)
        {
            Id = ++_id;
            Fullname = fullName;
            Point = point;
        }


        public void StudentInfo()
        {
            Console.WriteLine($"");
        }
    }
}
