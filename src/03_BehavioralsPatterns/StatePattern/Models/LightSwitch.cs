using System;

namespace StatePattern
{
    // Abstract State
    public interface LightSwitchState
    {
        // Handle
        void Push(LightSwitch lightSwitch);
    }

    public class On : LightSwitchState
    {
        public void Push(LightSwitch lightSwitch)
        {
            lightSwitch.SetState(new Off());
        }
    }

    public class Off : LightSwitchState
    {
        public void Push(LightSwitch lightSwitch)
        {
            lightSwitch.SetState(new On());
        }
    }


    public class LightSwitch
    {
        public LightSwitchState State { get; private set; }

        public LightSwitch()
        {
            SetState(new On());
        }

        public void SetState(LightSwitchState state)
        {
            State = state;
        }

        public void Push()
        {
            State.Push(this);   
        }
    }

    //public enum LightSwitchState
    //{
    //    On,
    //    Off
    //}

}
