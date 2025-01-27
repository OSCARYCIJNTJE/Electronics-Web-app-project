using Electronics.DTO.ProductsDTO;
using Electronics.Logic.Converters;
using Electronics.Logic.DomainClasses.CustomExceptions;
using Electronics.Logic.DomainClasses.Products;
using Electronics.Logic.ProductsServicesFolder;
using ElectronicsPanel.Statics;
using Microsoft.Identity.Client.Extensions.Msal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ElectronicsPanel
{
    public partial class ComputersPanel : Form
    {
        private ComputerServices ComputerServices;
        private ComputerDTO ComputerDto = new ComputerDTO();
        private readonly BindingSource ComputerSource = new BindingSource();
        public ComputersPanel(ComputerServices computerServices)
        {
            InitializeComponent();
            ComputerServices = computerServices;
            DgVComputer.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DgVComputer.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DgVComputer.MultiSelect = false;
            ComputerSource.DataSource = ComputerDto;
            var source = new BindingSource();
            try
            {
                source.DataSource = ComputerServices.GetComputers();
            }
            catch (DatabaseConnectionException ex)
            {
                if (ex.InnerException != null)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            DgVComputer.DataSource = source;
            tabPage3.Enabled = false;
            FormClosing += Computers_Panel_FormClosing;
        }

        private void ComputersPanel_Load(object sender, EventArgs e)
        {
            TxtBxCompName.DataBindings.Add("Text", ComputerDto, "Name");
            TxtBxModel.DataBindings.Add("Text", ComputerDto, "Model");
            TxtBxOperatingSystem.DataBindings.Add("Text", ComputerDto, "OperatingSystem");
            TxtBxScreenSize.DataBindings.Add("Text", ComputerDto, "ScreenSizeInInches", true, DataSourceUpdateMode.OnPropertyChanged);
            TxtBxStorageCapacity.DataBindings.Add("Text", ComputerDto, "StorageCapacity", true, DataSourceUpdateMode.OnPropertyChanged);
            TxtBxStock.DataBindings.Add("Text", ComputerDto, "Stock", true, DataSourceUpdateMode.OnPropertyChanged);
            TxtBxPrice.DataBindings.Add("Text", ComputerDto, "Price", true, DataSourceUpdateMode.OnPropertyChanged);
            TxtBxProcessor.DataBindings.Add("Text", ComputerDto, "Processor");
            TxtBxRam.DataBindings.Add("Text", ComputerDto, "RAM", true, DataSourceUpdateMode.OnPropertyChanged);
            TxtBxKeyboardType.DataBindings.Add("Text", ComputerDto, "KeyboardType");
            TxtBxMouseType.DataBindings.Add("Text", ComputerDto, "MouseType");
            TxtBxPowerSource.DataBindings.Add("Text", ComputerDto, "PowerSource");
        }

        private byte[] CompImage { get; set; }
        private int? CompSerialNumber { get; set; }
        private Image HoldIMage {  get; set; }

        private void EmptyImage()
        {
            CompImage = null;
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            bool add = true;

            AddEditSettings(add);

            TxtBxCompName.Clear();
            TxtBxModel.Clear();
            TxtBxOperatingSystem.Clear();
            TxtBxScreenSize.Clear();
            TxtBxStorageCapacity.Clear();
            TxtBxStock.Clear();
            TxtBxPrice.Clear();
            TxtBxProcessor.Clear();
            TxtBxRam.Clear();
            TxtBxKeyboardType.Clear();
            TxtBxMouseType.Clear();
            TxtBxPowerSource.Clear();
            PbxImageAdd.Image = null;
            PbxImageAdd.Update();

            EmptyImage();
        }

        private void BtnAddImage_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "jpg files (*.jpg)|*.jpg|PNG files (*.png)|*.png";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    string imageLocation = dialog.FileName;

                    PbxImageAdd.Image = Image.FromFile(imageLocation);

                    byte[] imageBytes = ImageToByteArray(PbxImageAdd.Image);

                    CompImage = imageBytes;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error has occurred: " + ex.Message);
            }
        }

        private byte[] ImageToByteArray(Image image)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                return ms.ToArray();
            }
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            RefreshList();
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (DgVComputer.SelectedRows.Count == 0)
            {
                MessageBox.Show("You have not selected a computer");
                return;
            }

            DataGridViewRow selectedRow = DgVComputer.SelectedRows[0];
            int serialNumber = (int)selectedRow.Cells["SerialNumber"].Value;

            Computer computer = ComputerServices.GetComputerBySerialNumber(serialNumber);

            if (computer == null)
            {
                MessageBox.Show("Something went wrong. please try again");
                return;
            }

            HoldComputerSerialNumber(computer.SerialNumber);

            DialogResult result = MessageBox.Show("Are you sure you want to edit this item?",
                                     "Confirmation",
                                     MessageBoxButtons.YesNo,
                                     MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                tabPage3.Enabled = true;
                TxtBxEditName.Text = computer.Name;
                TxtBxEditModel.Text = computer.Model;
                TxtBxEditOs.Text = computer.OperatingSystem;
                TxtBxEditScreenSize.Text = Convert.ToString(computer.ScreenSizeInInches);
                TxtBxEditStorage.Text = Convert.ToString(computer.StorageCapacity);
                TxtBxEditStock.Text = Convert.ToString(computer.Stock);
                TxtBxEditPrice.Text = Convert.ToString(computer.Price);
                TxtBxEditProcessor.Text = computer.Processor;
                TxtBxEditRam.Text = Convert.ToString(computer.RAM);
                TxtBxEditKeyboardType.Text = computer.KeyboardType;
                TxtBxEditMouseType.Text = computer.MouseType;
                TxtBxEditPowerSource.Text = computer.PowerSource;

                byte[] imageInBytes = computer.Image;
                Image ActualImage;

                using (MemoryStream memoryStream = new MemoryStream(imageInBytes))
                {
                    Image image = Image.FromStream(memoryStream);
                    ActualImage = image;
                }

                HoldIMage = ActualImage;

                PbxEditImage.Image = ActualImage;

                TabPageSettings();
            }
        }

        private void HoldComputerSerialNumber(int serialNumber)
        {
            CompSerialNumber = serialNumber;
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (DgVComputer.SelectedRows.Count == 0)
            {
                MessageBox.Show("You have not selected a computer");
                return;
            }

            DataGridViewRow selectedRow = DgVComputer.SelectedRows[0];
            int serialNumber = (int)selectedRow.Cells["SerialNumber"].Value;

            Computer computer = ComputerServices.GetComputerBySerialNumber(serialNumber);

            if (computer == null)
            {
                MessageBox.Show("Something went wrong. please try again");
                return;
            }

            DialogResult result = MessageBox.Show("Are you sure you want to Delete this item?",
                                     "Confirmation",
                                     MessageBoxButtons.YesNo,
                                     MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    ComputerServices.DeleteComputer(computer);
                }
                catch (DatabaseConnectionException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                MessageBox.Show("Computer has been removed");
                RefreshList();
            }
        }

        private void RefreshList()
        {
            DgVComputer.DataSource = null;
            var source = new BindingSource();
            source.DataSource = ComputerServices.GetComputers();
            DgVComputer.DataSource = source;
        }

        private void TabPageSettings()
        {
            if (tabPage1.Enabled && tabPage2.Enabled)
            {
                tabPage1.Enabled = false;
                tabPage2.Enabled = false;
            }
            else
            {
                tabPage1.Enabled = true;
                tabPage2.Enabled = true;
            }

        }

        private void BtnEditImage_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "jpg files (*.jpg)|*.jpg|PNG files (*.png)|*.png";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    string imageLocation = dialog.FileName;

                    PbxEditImage.Image = null;

                    PbxEditImage.Image = Image.FromFile(imageLocation);

                    byte[] imageBytes = ImageToByteArray(PbxEditImage.Image);

                    CompImage = imageBytes;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error has occurred: " + ex.Message);
            }
        }

        private void BtnCancelEdit_Click(object sender, EventArgs e)
        {
            TabSettingClear();
        }

        private void BtnEditComputer_Click(object sender, EventArgs e)
        {
            bool edit = false;

            AddEditSettings(edit);

            TabSettingClear();
        }

        private void TabSettingClear()
        {
            TxtBxEditName.Clear();
            TxtBxEditModel.Clear();
            TxtBxEditOs.Clear();
            TxtBxEditScreenSize.Clear();
            TxtBxEditStorage.Clear();
            TxtBxEditStock.Clear();
            TxtBxEditPrice.Clear();
            TxtBxEditProcessor.Clear();
            TxtBxEditRam.Clear();
            TxtBxEditKeyboardType.Clear();
            TxtBxEditMouseType.Clear();
            TxtBxEditPowerSource.Clear();

            PbxEditImage.Image = null;
            PbxEditImage.Update();

            EmptyImage();

            TabPageSettings();

            tabPage3.Enabled = false;
        }

        private void AddEditSettings(bool add)
        {
            if (add)
            {
                AddNewComputer();
            }
            else
            {
                EditComputer();
            }
        }

        private void AddNewComputer()
        {
            List<string> ports = new List<string>();

            string[] portBoxes = { "Ethernet", "USB", "USB-C" };

            foreach (var box in portBoxes)
            {
                ports.Add(box);
            }

            ComputerDTO computerDTO = ComputerSource.Current as ComputerDTO;

            Computer GetComputer = null;

            if (computerDTO != null)
            {
                computerDTO.SerialNumber = SerialNumberGenerator.GenerateSerialNumber();
                computerDTO.Ports = ports;
                computerDTO.Image = CompImage;

                ValidationContext context = new ValidationContext(computerDTO, null, null);
                IList<ValidationResult> errors = new List<ValidationResult>();
                if (!Validator.TryValidateObject(computerDTO, context, errors, true))
                {
                    string errorText = string.Empty;
                    foreach (ValidationResult validationResult in errors)
                    {
                        errorText += validationResult.ErrorMessage + Environment.NewLine;
                    }
                    MessageBox.Show(errorText, "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    int i = 0;
                    while (i < 1)
                    {
                        GetComputer = ComputerServices.GetComputerBySerialNumber(computerDTO.SerialNumber);

                        if (GetComputer != null)
                        {
                            computerDTO.SerialNumber = SerialNumberGenerator.GenerateSerialNumber();
                        }
                        else
                        {
                            i++;
                        }
                    }

                    Computer computer = ComputerConverter.ConvertToComputer(computerDTO);

                    try
                    {
                        ComputerServices.AddComputer(computer);
                    }
                    catch (DatabaseConnectionException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                    MessageBox.Show("Computer Added");
                    ComputerSource.EndEdit();
                    ComputerSource.ResetCurrentItem();

                    RefreshList();
                }
            }
        }

        private void EditComputer()
        {
            List<string> ports = new List<string>();

            string[] portBoxes = { "Ethernet", "USB", "USB-C" };

            foreach (var box in portBoxes)
            {
                ports.Add(box);
            }

            ComputerDTO computerDTO = new ComputerDTO();
            ComputerSource.DataSource = computerDTO;

            TxtBxEditName.DataBindings.Add("Text", computerDTO, "Name");
            TxtBxEditModel.DataBindings.Add("Text", computerDTO, "Model");
            TxtBxEditOs.DataBindings.Add("Text", computerDTO, "OperatingSystem");
            TxtBxEditScreenSize.DataBindings.Add("Text", computerDTO, "ScreenSizeInInches", true, DataSourceUpdateMode.OnPropertyChanged);
            TxtBxEditStorage.DataBindings.Add("Text", computerDTO, "StorageCapacity", true, DataSourceUpdateMode.OnPropertyChanged);
            TxtBxEditStock.DataBindings.Add("Text", computerDTO, "Stock", true, DataSourceUpdateMode.OnPropertyChanged);
            TxtBxEditPrice.DataBindings.Add("Text", computerDTO, "Price", true, DataSourceUpdateMode.OnPropertyChanged);
            TxtBxEditProcessor.DataBindings.Add("Text", computerDTO, "Processor");
            TxtBxEditRam.DataBindings.Add("Text", computerDTO, "RAM", true, DataSourceUpdateMode.OnPropertyChanged);
            TxtBxEditKeyboardType.DataBindings.Add("Text", computerDTO, "KeyboardType");
            TxtBxEditMouseType.DataBindings.Add("Text", computerDTO, "MouseType");
            TxtBxEditPowerSource.DataBindings.Add("Text", computerDTO, "PowerSource");
            PbxEditImage.DataBindings.Add("Image", computerDTO, "Image", true, DataSourceUpdateMode.OnPropertyChanged);

            if (CompImage == null)
            {
                byte[] imageBytes;
                if (PbxEditImage.Image != null)
                {
                    imageBytes = ImageToByteArray(PbxEditImage.Image);
                }
                else
                {
                    imageBytes = ImageToByteArray(HoldIMage);
                }
                CompImage = imageBytes;
            }

            ComputerDTO fromSource = ComputerSource.Current as ComputerDTO;

            if (fromSource != null)
            {
                fromSource.SerialNumber = Convert.ToInt32(CompSerialNumber);
                fromSource.Ports = ports;
                fromSource.Image = CompImage;

                ValidationContext context = new ValidationContext(fromSource, null, null);
                IList<ValidationResult> errors = new List<ValidationResult>();
                if (!Validator.TryValidateObject(fromSource, context, errors, true))
                {
                    string errorText = string.Empty;
                    foreach (ValidationResult validationResult in errors)
                    {
                        errorText += validationResult.ErrorMessage + Environment.NewLine;
                    }
                    MessageBox.Show(errorText, "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    Computer computer = ComputerConverter.ConvertToComputer(computerDTO);

                    if (computer != null)
                    {
                        try
                        {
                            ComputerServices.EditComputer(computer);
                        }
                        catch (DatabaseConnectionException ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }

                    MessageBox.Show("Computer Edited");
                    ComputerSource.EndEdit();
                    ComputerSource.ResetCurrentItem();

                    RefreshList();
                }
            }
        }

        private void Computers_Panel_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
            FormStatics.CurrentHomePanel.Show();
        }
    }
}
