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
            Hibernate,
            Restart
        };

        public PowerDownType actionType { get; }

        public DateTime when { get; }

        public Action onCountdownEnd { get; }


        // Private constructor to enforce actionType and Action consistency
        private PowerDownData(PowerDownType _type, DateTime _when, Action action)
        {
            actionType = _type;
            when = _when;
            onCountdownEnd = action;
        }

        /// <summary>
        /// Creates PowerDownData for Shutdown action scheduled at specified time
        /// </summary>
        /// <param name="when">The date and time when the action is supposed to trigger</param>
        /// <returns>A new PowerDownData configured for Shutdown</returns>
        public static PowerDownData Shutdown(DateTime when)
        {
            return new PowerDownData(PowerDownType.Shutdown, when, () => {
                var psi = new ProcessStartInfo("shutdown", "/s /t 0");
                psi.CreateNoWindow = true;
                psi.UseShellExecute = false;
                Process.Start(psi);
            });
        }

        /// <summary>
        /// Creates PowerDownData for Restart action scheduled at specified time
        /// </summary>
        /// <param name="when">The date and time when the action is supposed to trigger</param>
        /// <returns>A new PowerDownData configured for Restart</returns>
        public static PowerDownData Restart(DateTime when)
        {
            return new PowerDownData(PowerDownType.Restart, when, () => {
                var psi = new ProcessStartInfo("shutdown", "/r /t 0");
                psi.CreateNoWindow = true;
                psi.UseShellExecute = false;
                Process.Start(psi);
            });
        }

        /// <summary>
        /// Creates PowerDownData for Suspend action scheduled at specified time
        /// </summary>
        /// <param name="when">The date and time when the action is supposed to trigger</param>
        /// <returns>A new PowerDownData configured for Suspend</returns>
        public static PowerDownData Suspend(DateTime when)
        {
            return new PowerDownData(PowerDownType.Suspend, when, () => {
                Application.SetSuspendState(PowerState.Suspend, false, false);
            });
        }

        /// <summary>
        /// Creates PowerDownData for Hibernate action scheduled at specified time
        /// </summary>
        /// <param name="when">The date and time when the action is supposed to trigger</param>
        /// <returns>A new PowerDownData configured for Hibernate</returns>
        public static PowerDownData Hibernate(DateTime when)
        {
            return new PowerDownData(PowerDownType.Hibernate, when, () => {
                Application.SetSuspendState(PowerState.Hibernate, false, false);
            });
        }
    }
}
