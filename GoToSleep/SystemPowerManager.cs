using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms.Design;
using System.Diagnostics;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using Microsoft.Recognizers.Text;
using Microsoft.Recognizers.Text.DateTime;
using System.Globalization;

namespace GoToSleep
{
    internal class SystemPowerManager
    {
        private static int TIMER_WARNING_SECONDS = 15;


        [Serializable]
        class DatetimeStringException : Exception
        {
            public DatetimeStringException(string message) : base(message) { }
            public DatetimeStringException(Exception e) : base("Conversion from string to time failed.", e) { }
        }

        [Serializable]
        class DateTimeBeforeException : DatetimeStringException
        {
            public DateTimeBeforeException() : base("The entered date was in the past.")
            {
            }
        }

        [Serializable]
        class ParseFailedException : DatetimeStringException
        {
            public ParseFailedException(Exception e) : base(e) { }
        }

        public SystemPowerManager(GoToSleep pf)
        {
            parentForm = pf;
        }
        Form parentForm;

        CountdownForm? progressPopup;

        string prepareTimeString(string s)
        {
            // make sure there are spaces between numbers and units, for the parser
            s = Regex.Replace(s, "([0-9]+)([a-zA-Z]+)", "$1 $2");
            s = Regex.Replace(s, "([a-zA-Z]+)([0-9]+)", "$1 $2");

            // replace shorthands with full names, for the parser
            s = Regex.Replace(s, "( )[hH]([ ]|$)", "$1hours$2");

            s = Regex.Replace(s, "( )[mM]([ ]|$)", "$1minutes$2");

            s = Regex.Replace(s, "( )[sS]([ ]|$)", "$1seconds$2");

            return s;
        }

        DateTime getTimeOffsetFromString(string timeString)
        {
            DateTime result;
            try
            {
                timeString = prepareTimeString(timeString);

                List<ModelResult>? results = null;

                try
                {
                    results = DateTimeRecognizer.RecognizeDateTime(timeString, CultureInfo.CurrentCulture.ToString());
                }
                catch
                {
                    //results remain null, will go into fallback
                }

                if (results == null || results.Count == 0)
                {
                    //try converting using english as fallback
                    results = DateTimeRecognizer.RecognizeDateTime(timeString, Culture.English);
                    if (results == null || results.Count == 0)
                    {
                        throw new ArgumentException();
                    }
                }

                if(results[0].Resolution["values"] == null)
                {
                    throw new ArgumentException();
                }
                result = DateTime.Parse((results[0].Resolution["values"] as List<Dictionary<string, string>>)![0]["value"]);

            }
            catch (Exception e)
            {
                throw new ParseFailedException(e);
            }

            if (result < DateTime.Now)
            {
                throw new DateTimeBeforeException();
            }

            return result;
        }

        bool confirmDate(DateTime target, string action)
        {
            if (target <= DateTime.Now.AddSeconds(TIMER_WARNING_SECONDS))
            {
                //the number will be always off by a fraction of a second, so round it up
                if (MessageBox.Show($"Are you sure you want to schedule {action} in just {Math.Ceiling((target - DateTime.Now).TotalSeconds)} seconds?", "Confirm", MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    return true;
                }
                return false;
            }
            //warning threshold not met
            return true;
        }

        public void shutdown(string timeString)
        {
            DateTime target;
            try
            {
                target = getTimeOffsetFromString(timeString);
            }
            catch (Exception)
            {
                throw;
            }

            if(!confirmDate(target,"shutdown"))
            {
                return;
            }

            progressPopup = new CountdownForm(PowerDownData.Shutdown(target), parentForm);
            progressPopup.Show();
        }

        public void suspend(string timeString)
        {
            DateTime target;
            try
            {
                target = getTimeOffsetFromString(timeString);
            }
            catch (Exception)
            {
                throw;
            }

            if (!confirmDate(target, "suspension"))
            {
                return;
            }

            progressPopup = new CountdownForm(PowerDownData.Suspend(target), parentForm);
            progressPopup.Show();
        }

        public void hibernate(string timeString)
        {
            DateTime target;
            try
            {
                target = getTimeOffsetFromString(timeString);
            }
            catch (Exception)
            {
                throw;
            }

            if (!confirmDate(target, "hibernation"))
            {
                return;
            }

            progressPopup = new CountdownForm(PowerDownData.Hibernate(target), parentForm);
            progressPopup.Show();
        }

        public void restart(string timeString)
        {
            DateTime target;
            try
            {
                target = getTimeOffsetFromString(timeString);
            }
            catch (Exception)
            {
                throw;
            }

            if (!confirmDate(target, "restart"))
            {
                return;
            }

            progressPopup = new CountdownForm(PowerDownData.Restart(target), parentForm);
            progressPopup.Show();
        }
    }
}
