using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace GoToSleep
{
    public class PowerDownData
    {
        public enum PowerDownType
        {
            Shutdown,
            Suspend,
            Hibernate
        };

        public PowerDownType actionType { get; }

        public DateTime when { get; }

        public delegate void Action();

        public Action onCountdownEnd { get; }


        private PowerDownData(PowerDownType _type, DateTime _when, Action action)
        {
            actionType = _type;
            when = _when;
            onCountdownEnd = action;
        }
        public static PowerDownData Shutdown(DateTime when)
        {
            return new PowerDownData(PowerDownType.Shutdown, when, () => {
                var psi = new ProcessStartInfo("shutdown", "/s /t 0");
                psi.CreateNoWindow = true;
                psi.UseShellExecute = false;
                Process.Start(psi);
            });
        }

        public static PowerDownData Restart(DateTime when)
        {
            return new PowerDownData(PowerDownType.Shutdown, when, () => {
                var psi = new ProcessStartInfo("shutdown", "/r /t 0");
                psi.CreateNoWindow = true;
                psi.UseShellExecute = false;
                Process.Start(psi);
            });
        }
        public static PowerDownData Suspend(DateTime when)
        {
            return new PowerDownData(PowerDownType.Suspend, when, () => {
                Application.SetSuspendState(PowerState.Suspend, false, false);
            });
        }
        public static PowerDownData Hibernate(DateTime when)
        {
            return new PowerDownData(PowerDownType.Hibernate, when, () => {
                Application.SetSuspendState(PowerState.Hibernate, false, false);
            });
        }
    }
}
