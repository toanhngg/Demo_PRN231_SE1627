namespace WebAPI_Template.Models
{
    public class Students
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public Students() { }

        // ctor 
        public Students(string code, string name, int age)
        {
            Code = code;
            Name = name;
            Age = age;
        }
        public override string ToString()
        {
            return Code + "\t" + Name + "\t" + Age;
        }

    }
}
