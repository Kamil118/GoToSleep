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
        /// <summary>
        /// Static value specifying the minimum delay (in seconds) of action execution without a warning.
        /// </summary>
        /// <remarks>
        /// If user specifies time that's delayed by less than this number of seconds, ask for confirmation.
        /// Exists to protect user from typos or interpreter errors that would schedule an action
        /// that executes before user can notice the mistake and cancel it.
        /// 
        /// Selected unilaterally by a committee of 1 developers.</remarks>
        private const int TIMER_WARNING_SECONDS = 15;


        /// <summary>
        /// Base exception for when the string can't be converted into a valid <see cref="DateTime"/>object.
        /// </summary>
        [Serializable]
        abstract class DatetimeStringException : Exception
        {
            public DatetimeStringException(string message) : base(message) { }
            public DatetimeStringException(Exception e) : base("Conversion from string to time failed.", e) { }
        }

        /// <summary>
        /// The exception that is thrown when the time string is converted into a <see cref="DateTime"/> object that references
        /// a point of time in the past.
        /// </summary>
        [Serializable]
        class DateTimeBeforeException : DatetimeStringException
        {
            public DateTimeBeforeException() : base("The entered date was in the past.")
            {
            }
        }

        /// <summary>
        /// The exception that's thrown when the time string couldn't be converted into any <see cref="DateTime"/>.
        /// </summary>

        [Serializable]
        class ParseFailedException : DatetimeStringException
        {
            public ParseFailedException(Exception e) : base(e) { }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SystemPowerManager"/> class with a reference to the main window.
        /// </summary>
        /// <param name="pf"><see cref="GoToSleep"/> main window instance.</param>
        public SystemPowerManager(GoToSleep pf)
        {
            parentForm = pf;
        }
        Form parentForm;

        CountdownForm? progressPopup;


        /// <summary>
        /// Prepares an input time string to improve compatibility with Microsoft.Recognizers.Text
        /// </summary>
        /// <param name="s">Time string to be preprocessed</param>
        /// <returns>Time string modified for better compatibility with Microsoft.Recognizers.Text parser</returns>
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

        /// <summary>
        /// Converts natural language time string to Datetime object
        /// </summary>
        /// <param name="timeString">String containing natural language time definition</param>
        /// <returns>new Datetime object referencing the time specified in <paramref name="timeString"/></returns>
        /// <exception cref="ParseFailedException">Thrown when general parsing failure</exception>
        /// <exception cref="DateTimeBeforeException">Thrown when the input string references point of time in the past</exception>

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

        /// <summary>
        /// Prompts user to confirm the scheduling of action if it's scheduled to happen less than
        /// <see cref="TIMER_WARNING_SECONDS"/> in the future.
        /// </summary>
        /// <param name="target">The Datetime the action is scheduled to execute.</param>
        /// <param name="action">The name of action that is about to be scheduled.</param>
        /// <returns><see langword="true""/> if the date doesn't meet warning requirements, or the user confirmed the intent.
        /// <see langword="false"/> if the user clicked cancel or closed the prompt window.</returns>

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

        /// <summary>
        /// Displays a new <see cref="CountdownForm"/> window for scheduled shutdown action.
        /// </summary>
        /// <param name="timeString">Time string refrencing when the action should be executed.</param>
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

        /// <summary>
        /// Displays a new <see cref="CountdownForm"/> window for scheduled suspend action.
        /// </summary>
        /// <param name="timeString">Time string refrencing when the action should be executed.</param>
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

        /// <summary>
        /// Displays a new <see cref="CountdownForm"/> window for scheduled hibernate action.
        /// </summary>
        /// <param name="timeString">Time string refrencing when the action should be executed.</param>
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

        /// <summary>
        /// Displays a new <see cref="CountdownForm"/> window for scheduled restart action.
        /// </summary>
        /// <param name="timeString">Time string refrencing when the action should be executed.</param>
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
