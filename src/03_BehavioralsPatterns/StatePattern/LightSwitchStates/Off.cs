namespace StatePattern.LightSwitchStates
{
    // Concrete State B
    public class Off : LightSwitchState
    {
        public Off(LightSwitch lightSwitch) : base(lightSwitch)
        {
        }

        public void Push(LightSwitch lightSwitch)
        {

        }

        public override void Push()
        {
            lightSwitch.SetState(new On(lightSwitch));
        }
    }



}
