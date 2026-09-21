using PA_521.Abstract;

namespace PA_521.Service
{
    public class WorkService : IStudent
    {
        public string GetConcat(string a, string b)
        {
            return $"{a} ------- {b}";
        }

        public int GetSum(int a, int b)
        {
            return a + b + 10;
        }
    }
}
