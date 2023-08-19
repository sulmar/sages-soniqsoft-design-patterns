namespace StatePattern.LightSwitchStates
{
    // Concrete State A
    public class On : LightSwitchState
    {
        public On(LightSwitch lightSwitch) : base(lightSwitch)
        {
        }

        public override void Push()
        {
            lightSwitch.SetState(new Off(lightSwitch));
        }
    }



}
