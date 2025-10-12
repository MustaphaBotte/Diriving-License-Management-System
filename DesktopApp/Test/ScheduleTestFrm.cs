using DLMS.EntitiesNamespace;
using static DLMS.EntitiesNamespace.Entities;
namespace DesktopApp.Test
{
    public partial class ScheduleTestFrm : Form
    {
        public delegate void Adding_SendSignalTorefreshTheFrid(int NewAppointmentID);
        public event Adding_SendSignalTorefreshTheFrid OnAddNewAppointment = delegate { };

        public delegate void Edited_SendSignalTorefreshTheFrid(ClsTestAppointment Appointment);
        public event Edited_SendSignalTorefreshTheFrid OnEditAppointment = delegate { };

        public ScheduleTestFrm(int Loc_DLA_ID, Entities.ClsTestType.EnTestType TestTypeID)
        {
            InitializeComponent();
            scheduleTestControl2.OnAddNewAppointment += (int NewAppointmentID) =>
            {
                OnAddNewAppointment?.Invoke(NewAppointmentID);
                this.Close();
            };
            this.scheduleTestControl2.AddNewAppointment(Loc_DLA_ID, TestTypeID);
        }
        public ScheduleTestFrm(int AppointmentID)
        {
            InitializeComponent();
            scheduleTestControl2.OnEditAppointment += (ClsTestAppointment Appointment) =>
            {
                OnEditAppointment?.Invoke(Appointment);
                this.Close();
            };
            this.scheduleTestControl2.EditAppointment(AppointmentID);
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
