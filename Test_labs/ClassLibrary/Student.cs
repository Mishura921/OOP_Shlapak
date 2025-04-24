namespace ClassLibrary
{
    public class Student : PersonBase
    {
        public Student(string firstName, string lastName, int age, string group) : base(firstName, lastName, age)
        {
            Group = group;
            _minAge = 16;
            _maxAge = 40;
        }

        public string Group
        {
            get; set;
        }

        public string ToString()
        {
            return base.ToString() + $"Учусь в группе {Group}.";
        }

        public override string DoSomeWork()
        {
            return "Я пью ПиВо!!!11";
        }
    }
}
