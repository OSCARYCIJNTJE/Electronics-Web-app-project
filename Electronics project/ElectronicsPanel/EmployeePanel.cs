using Electronics.DTO;
using Electronics.Logic.DomainClasses.Users;
using Electronics.Logic.FilteringChecks;
using ElectronicsPanel.Statics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Department = Electronics.DTO.Department;

namespace ElectronicsPanel
{
    public partial class EmployeePanel : Form
    {
        private readonly AdminRegistrationDTO RegisterCredentials;
        private readonly BindingSource AdminSource;
        public EmployeePanel()
        {
            InitializeComponent();
            RegisterCredentials = new AdminRegistrationDTO();
            AdminSource = new BindingSource();
            AdminSource.DataSource = RegisterCredentials;
            CmBxDepartment.DropDownStyle = ComboBoxStyle.DropDownList;
            CmBxDepartment.DataSource = Enum.GetValues(typeof(Department));
            FormClosing += Employee_Panel_FormClosing;
        }

        private void EmployeePanel_Load(object sender, EventArgs e)
        {
            TxtBxFirstName.DataBindings.Add("Text", RegisterCredentials, "FirstName");
            TxtBxLastName.DataBindings.Add("Text", RegisterCredentials, "LastName");
            TxtBxEmail.DataBindings.Add("Text", RegisterCredentials, "Email", true, DataSourceUpdateMode.OnPropertyChanged);
            TxtBxUsername.DataBindings.Add("Text", RegisterCredentials, "UserName");
            TxtBxPassword.DataBindings.Add("Text", RegisterCredentials, "Password");
            TxtBxPhoneNumber.DataBindings.Add("Text", RegisterCredentials, "PhoneNumber", true, DataSourceUpdateMode.OnPropertyChanged, 0, "N0");
            TxtBxBsn.DataBindings.Add("Text", RegisterCredentials, "BSN");
            CmBxDepartment.DataBindings.Add("SelectedItem", RegisterCredentials, "Department", true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void BtnAddEmployee_Click(object sender, EventArgs e)
        {
            AdminSource.EndEdit();
            AdminRegistrationDTO adminDTO = AdminSource.Current as AdminRegistrationDTO;

            if (adminDTO != null)
            {
                ValidationContext context = new ValidationContext(adminDTO, null, null);
                IList<ValidationResult> errors = new List<ValidationResult>();

                if (!Validator.TryValidateObject(adminDTO, context, errors, true))
                {
                    string errorText = string.Empty;
                    foreach (ValidationResult validationResult in errors)
                    {
                        errorText += validationResult.ErrorMessage + Environment.NewLine;

                    }
                    MessageBox.Show(errorText, "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void Employee_Panel_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
            FormStatics.CurrentHomePanel.Show();
        }
    }
}
