using Electronics.Logic.ProductsServicesFolder;
using ElectronicsPanel.Statics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ElectronicsPanel
{
    public partial class Homepanel : Form
    {
        private readonly ComputerServices _ComputerServices;
        private readonly PhoneServices _PhoneServices;
        public static Homepanel originalHomepanel;

        public Homepanel(ComputerServices computerServices, PhoneServices phoneServices)
        {
            InitializeComponent();
            _ComputerServices = computerServices;
            _PhoneServices = phoneServices;
            FormClosing += Homepanel_FormClosing;
            FormStatics.CurrentHomePanel = this;
        }

        private void ComputerPanelBtn_Click(object sender, EventArgs e)
        {
            ComputersPanel computersPanel = new ComputersPanel(_ComputerServices);
            this.Hide();
            computersPanel.Show();
        }

        private void PhonePanelBtn_Click(object sender, EventArgs e)
        {
            PhonesPanel phonesPanel = new PhonesPanel(_PhoneServices);
            this.Hide();
            phonesPanel.Show();
        }

        private void Homepanel_FormClosing(object sender, FormClosingEventArgs e)
        {
            Login loginForm = new Login(_ComputerServices, _PhoneServices);
            this.Dispose();
            loginForm.Show();
        }

        private void EmployeePanelBtn_Click(object sender, EventArgs e)
        {
            EmployeePanel employeePanel = new EmployeePanel();
            this.Hide();
            employeePanel.Show();
        }
    }
}
