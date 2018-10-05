using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework4
{
    public class clockEventArgs : EventArgs
    {
        
    }
    public delegate void ClockEventHander(object sender, DateTime clockTime);
    public class Clock
    {
        public event ClockEventHander Clocker;
        public void GoClock(DateTime clockTime)
        {
            while (clockTime>=DateTime.Now)
            {

            }
            if (clockTime<=DateTime.Now)
            {
                Clocker(this, clockTime);
            }
        }
    }
}
