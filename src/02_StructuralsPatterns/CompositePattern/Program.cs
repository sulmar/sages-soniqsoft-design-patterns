namespace CompositePattern;

class Program
{
    static void Main(string[] args)
    {
        Component component = new Question("Are you developer?",
            new Question("Do you know C#?",
                new Decision("Welcome on Design Pattern in C# Course!"),
                new Decision("The Course is not for you.")
                ),
            new Decision("Have a nice day.")
            );

        component.Operation();
       
    }
}

// Abstract Component
public abstract class Component
{
    public string Content { get; set; }

    protected Component(string content)
    {
        Content = content;
    }

    public abstract void Operation();

    public bool Response => Console.ReadKey().Key == ConsoleKey.Y;
}

// Composite 
public class Question : Component
{
    public Component PositiveResponse { get; set; }
    public Component NegativeResponse { get; set; }

    public Question(string content, Component positiveResponse, Component negativeResponse)
        : base(content)
    {
        PositiveResponse = positiveResponse;
        NegativeResponse = negativeResponse;
    }

    public override void Operation()
    {
        Console.Write(Content);

        if (Response)
        {
            PositiveResponse.Operation();
        }
        else
        {
            NegativeResponse.Operation();
        }
    }
}

// Leaf
public class Decision : Component
{
    public Decision(string content) : base(content)
    {
    }

    public override void Operation()
    {
        Console.WriteLine(Content);
    }
}