namespace VisitorPattern
{
    // Concrete Element
    public class CheckBox : Control
    {
        public bool Value { get; set; }

        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

}
