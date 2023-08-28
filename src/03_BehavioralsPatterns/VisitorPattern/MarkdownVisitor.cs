using System.Text;

namespace VisitorPattern
{
    // Concrete Visitor B
    public class MarkdownVisitor : IVisitor
    {
        private readonly StringBuilder builder = new();

        public void Visit(Label control)
        {
            builder.AppendLine($"**{control.Caption}**");
        }

        public void Visit(TextBox control)
        {
            builder.AppendLine($"*{control.Caption}* {control.Value}");
        }

        public void Visit(CheckBox control)
        {

        }

        public void Visit(Button control)
        {
            throw new System.NotImplementedException();
        }

        public string Output => builder.ToString();
    }

}
