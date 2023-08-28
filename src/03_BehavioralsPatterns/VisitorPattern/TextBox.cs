namespace VisitorPattern
{
    // Concrete Element
    public class TextBox : Control
    {
        public string Value { get; set; }

        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

}
