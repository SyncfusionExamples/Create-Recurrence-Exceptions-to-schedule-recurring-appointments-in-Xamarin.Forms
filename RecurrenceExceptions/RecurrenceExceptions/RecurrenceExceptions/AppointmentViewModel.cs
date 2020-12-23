using System;
using System.Collections.ObjectModel;
using Syncfusion.SfSchedule.XForms;
using Xamarin.Forms;

namespace RecurrenceExceptions
{
    public class AppointmentViewModel
    {
        public ScheduleAppointmentCollection Appointments { get; set; } = new ScheduleAppointmentCollection();
        public DateTime MoveToDate { get; set; } = new DateTime(2017, 09, 03, 09, 0, 0);
        public Command AddExceptionDates { get; set; }
        public Command RemoveExceptionDates { get; set; }
        public Command AddExceptionAppointment { get; set; }
        public Command RemoveExceptionAppointment { get; set; }
        public AppointmentViewModel()
        {
            // Set the commands for Add/Remove the exception dates.
            this.SetUpCommands();

            // Create the new recurrence exception dates.
            var exceptionDate = new DateTime(2017, 09, 07);
            var recExcepDate2 = new DateTime(2017, 09, 03);
            var recExcepDate3 = new DateTime(2017, 09, 05);

            //Adding schedule appointment in schedule appointment collection 
            var recurrenceAppointment = new ScheduleAppointment()
            {
                Id = 1,
                StartTime = new DateTime(2017, 09, 01, 10, 0, 0),
                EndTime = new DateTime(2017, 09, 01, 12, 0, 0),
                Subject = "Occurs Daily",
                Color = Color.Blue,
                RecurrenceRule = "FREQ=DAILY;COUNT=20"
            };

            // Add RecuurenceExceptionDates to appointment.
            recurrenceAppointment.RecurrenceExceptionDates = new ObservableCollection<DateTime>()
            {
                exceptionDate,
                   recExcepDate2,
                     recExcepDate3,
            };

            //Adding schedule appointment in schedule appointment collection
            Appointments.Add(recurrenceAppointment);

        }

        /// <summary>
        /// Set up commands for Add/Remove the exception Appointments.
        /// </summary>
        private void SetUpCommands()
        {
            AddExceptionDates = new Command(TapAddExceptionDates);
            RemoveExceptionDates = new Command(TapRemoveExceptionDates);
            AddExceptionAppointment = new Command(AddRecurrenceExceptionAppointment);
            RemoveExceptionAppointment = new Command(RemoveRecurrenceExceptionAppointment);
        }

        /// <summary>
        /// Removes the recurrence exception appointment.
        /// </summary>
        /// <param name="obj">Object.</param>
        private void RemoveRecurrenceExceptionAppointment(object obj)
        {
            if (this.Appointments.Count > 1)
            {
                var exceptionAppointment = this.Appointments[1];
                this.Appointments.Remove(exceptionAppointment);
            }
        }

        /// <summary>
        /// Adds the recurrence exception appointment.
        /// </summary>
        /// <param name="obj">Object.</param>
        private void AddRecurrenceExceptionAppointment(object obj)
        {
            var recurrenceAppointment = this.Appointments[0];
            var exceptionDate = new DateTime(2017, 09, 07);

            // Add duplicate appointment to the current recurrence series
            var exceptionAppointment = new ScheduleAppointment()
            {
                StartTime = new DateTime(2017, 09, 07, 13, 0, 0),
                EndTime = new DateTime(2017, 09, 07, 14, 0, 0),
                Subject = "Meeting",
                Color = Color.Red,
                RecurrenceId = recurrenceAppointment.Id, // set the parent appointment Id to recurrence Id
                ExceptionOccurrenceActualDate = exceptionDate
            };

            this.Appointments.Add(exceptionAppointment);
        }

        /// <summary>
        /// Taps the remove exception dates.
        /// </summary>
        /// <param name="obj">Object.</param>
        private void TapRemoveExceptionDates(object obj)
        {
            // Remove recurrence exception dates.
            this.Appointments[0].RecurrenceExceptionDates.RemoveAt(0);
        }

        /// <summary>
        /// Taps the add exception dates.
        /// </summary>
        /// <param name="obj">Object.</param>
        private void TapAddExceptionDates(object obj)
        {
            // Add recurrence exception dates.
            this.Appointments[0].RecurrenceExceptionDates.Add(new DateTime(2017, 09, 04));
        }

    }
}
