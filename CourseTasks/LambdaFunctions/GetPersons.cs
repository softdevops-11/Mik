namespace LambdaFunctions
{
    internal class GetPersons
    {
        private readonly string name;
        private readonly int age;

        public string Name => name;

        public int Age => age;

        public GetPersons(string name, int age)
        {
            this.name = name;
            this.age = age;
        }
    }
}
