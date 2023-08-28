namespace VisitorPattern
{
    // Concrete Element
    public class Button : Control
    {
        public string ImageSource { get; set; }

        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

}
