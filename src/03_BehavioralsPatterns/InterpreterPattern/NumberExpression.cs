namespace InterpreterPattern
{
    // Concrete Expression
    public class NumberExpression : IExpression
    {
        private readonly int number;
        public NumberExpression(int number) => this.number = number;
        public void Interpret(Context context) => context.Push(number);
    }




}
