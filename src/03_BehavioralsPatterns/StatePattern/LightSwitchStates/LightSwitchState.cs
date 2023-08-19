namespace StatePattern.LightSwitchStates
{
    // Abstract State
    public abstract class LightSwitchState
    {
        // Context
        protected LightSwitch lightSwitch;

        protected LightSwitchState(LightSwitch lightSwitch)
        {
            this.lightSwitch = lightSwitch;
        }

        // Handle
        public abstract void Push();

    }



}
