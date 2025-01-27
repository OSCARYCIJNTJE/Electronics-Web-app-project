using Electronics.Logic.ProductsServicesFolder;

namespace ElectronicsPanel
{
    public partial class Login : Form
    {
        private readonly ComputerServices _ComputerServices;
        private readonly PhoneServices _PhoneServices;
        public Login(ComputerServices computerServices, PhoneServices phoneServices)
        {
            InitializeComponent();
            _ComputerServices = computerServices;
            _PhoneServices = phoneServices;
            FormClosing += LoginPanel_FormClosing;
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            string username = UsernameTxtBx.Text;
            string password = PasswordTxtBx.Text;
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("One of the credentials is empty");
                return;
            }

            if (username == "admin" && password == "admin")
            {
                Homepanel homepanel = new Homepanel(_ComputerServices, _PhoneServices);
                this.Hide();
                homepanel.Show();
            }
        }

        private void LoginPanel_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.ExitThread();
        }
    }
}