using System;
using StatePattern.LightSwitchStates;

namespace StatePattern
{

    // Context
    public class LightSwitch
    {
        // State
        public LightSwitchState State { get; private set; }

        public LightSwitch()
        {
            SetState(new Off(this)); // Set Initial State
        }

        public void SetState(LightSwitchState state)
        {
            State = state;
        }

        public void Push()
        {
            State.Push();   
        }
    }

   

}
