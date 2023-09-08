using System;
using System.Collections.Generic;

namespace InterpreterPattern
{

    public class ExpressionFactory
    {
        public IExpression Create(string token) =>
            token switch
            {
                "+" => new PlusExpression(),
                "-" => new MinusExpression(),
                "*" => new MultiplyExpression(),
                _ => new NumberExpression(int.Parse(token))
            };
    }

    public class Parser
    {
        private IList<IExpression> parseTree = new List<IExpression>();

        private readonly ExpressionFactory factory;

        public Parser(ExpressionFactory factory) => this.factory = factory;

        private string[] Tokenize(string s) => s.Split(' ');

        private void Parse(string s)
        {
            var tokens = Tokenize(s);

            foreach (var token in tokens)
            {
                parseTree.Add(factory.Create(token));
            }
        }

        public int Evaluate(string s)
        {
            Parse(s);

            var context = new Context();

            foreach (var expression in parseTree)
            {
                expression.Interpret(context);
            }

            return context.Pop();
        }
    }

    // Context
    public class Context : Stack<int>
    {

    }

    // Abstract Expression
    public interface IExpression
    {
        void Interpret(Context context);
    }

    // Concrete Expression
    public class NumberExpression : IExpression
    {
        private readonly int number;
        public NumberExpression(int number) => this.number = number;
        public void Interpret(Context context) => context.Push(number);
    }

    // Concrete Expression
    public class PlusExpression : IExpression
    {
        public void Interpret(Context context) => context.Push(context.Pop() + context.Pop());
    }

    // Concrete Expression
    public class MinusExpression : IExpression
    {
        public void Interpret(Context context) => context.Push(-context.Pop() + context.Pop());
    }

    // Concrete Expression
    public class MultiplyExpression : IExpression
    {
        public void Interpret(Context context) => context.Push(context.Pop() * context.Pop());
    }




}
