namespace InterpreterPattern
{
    // Concrete Expression
    public class PlusExpression : IExpression
    {
        public void Interpret(Context context) => context.Push(context.Pop() + context.Pop());
    }




}
