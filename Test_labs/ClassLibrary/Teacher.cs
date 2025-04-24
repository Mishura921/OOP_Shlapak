namespace ClassLibrary
{
    public class Teacher : PersonBase
    {
        public Student Bedolaga { get; set; }

        public Teacher(string firstName, string lastName, int age, string kafedra) : base(firstName, lastName, age)
        {
            Kafedra = kafedra;
        }

        public string Kafedra
        {
            get; set;
        }

        public string ToString()
        {
            return base.ToString() + $"Работаю на {Kafedra}. ";
        }

        public override string DoSomeWork()
        {
            return "Я не пью ПиВо =(";
        }

    }
}
