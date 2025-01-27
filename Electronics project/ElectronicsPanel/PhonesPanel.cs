using Electronics.DTO.ProductsDTO;
using Electronics.Logic.Converters;
using Electronics.Logic.DomainClasses.CustomExceptions;
using Electronics.Logic.DomainClasses.Products;
using Electronics.Logic.ProductsServicesFolder;
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

namespace ElectronicsPanel
{
    public partial class PhonesPanel : Form
    {
        private PhoneServices PhoneServices;
        private PhoneDTO PhoneDto = new PhoneDTO();
        private readonly BindingSource PhoneSource = new BindingSource();
        public PhonesPanel(PhoneServices phoneServices)
        {
            InitializeComponent();
            PhoneServices = phoneServices;
            DgVPhone.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DgVPhone.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DgVPhone.MultiSelect = false;
            PhoneSource.DataSource = PhoneDto;
            var source = new BindingSource();
            try
            {
                source.DataSource = PhoneServices.GetPhones();
            }
            catch (DatabaseConnectionException ex)
            {
                if (ex.InnerException != null)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            DgVPhone.DataSource = source;
            tabPage3.Enabled = false;

            FormClosing += Phones_Panel_FormClosing;
        }

        private void PhonesPanel_Load(object sender, EventArgs e)
        {
            TxtBxCompName.DataBindings.Add("Text", PhoneDto, "Name");
            TxtBxOperatingSystem.DataBindings.Add("Text", PhoneDto, "OperatingSystem");
            TxtBxScreenSize.DataBindings.Add("Text", PhoneDto, "ScreenSizeInInches", true, DataSourceUpdateMode.OnPropertyChanged);
            TxtBxStorageCapacity.DataBindings.Add("Text", PhoneDto, "StorageCapacity", true, DataSourceUpdateMode.OnPropertyChanged);
            TxtBxStock.DataBindings.Add("Text", PhoneDto, "Stock", true, DataSourceUpdateMode.OnPropertyChanged);
            TxtBxPrice.DataBindings.Add("Text", PhoneDto, "Price", true, DataSourceUpdateMode.OnPropertyChanged);
            TxtBxManufacturer.DataBindings.Add("Text", PhoneDto, "Manufacturer");
            TxtBxModel.DataBindings.Add("Text", PhoneDto, "Model");
            TxtBxCameraQuality.DataBindings.Add("Text", PhoneDto, "CameraQualityMP", true, DataSourceUpdateMode.OnPropertyChanged);
            TxtBxSimCard.DataBindings.Add("Text", PhoneDto, "SIMCardType");
            TxtBxBioFeatures.DataBindings.Add("Text", PhoneDto, "BiometricFeatures");
            TxtBxBatteryCap.DataBindings.Add("Text", PhoneDto, "BatteryCapacitymAH", true, DataSourceUpdateMode.OnPropertyChanged);
            PbxImageAdd.DataBindings.Add("Image", PhoneDto, "Image", true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private byte[] PhoneImg { get; set; }
        private int? PhoneSerialNumber { get; set; }

        private void EmptyImage()
        {
            PhoneImg = null;
        }

        private void HoldPhoneSerialNumber(int phoneId)
        {
            PhoneSerialNumber = phoneId;
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            bool add = true;

            AddEditSettings(add);

            TxtBxCompName.Clear();
            TxtBxOperatingSystem.Clear();
            TxtBxScreenSize.Clear();
            TxtBxStorageCapacity.Clear();
            TxtBxStock.Clear();
            TxtBxPrice.Clear();
            TxtBxManufacturer.Clear();
            TxtBxModel.Clear();
            TxtBxCameraQuality.Clear();
            TxtBxSimCard.Clear();
            TxtBxBioFeatures.Clear();
            TxtBxBatteryCap.Clear();
            PbxImageAdd.Image = null;
            PbxImageAdd.Update();

            EmptyImage();
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (DgVPhone.SelectedRows.Count == 0)
            {
                MessageBox.Show("You have not selected a phone");
                return;
            }

            DataGridViewRow selectedRow = DgVPhone.SelectedRows[0];
            int serialNumber = (int)selectedRow.Cells["SerialNumber"].Value;

            Phone phone = PhoneServices.GetPhoneBySerialNumber(serialNumber);

            if (phone == null)
            {
                MessageBox.Show("Something went wrong. please try again");
                return;
            }

            HoldPhoneSerialNumber(phone.SerialNumber);

            DialogResult result = MessageBox.Show("Are you sure you want to edit this item?",
                                     "Confirmation",
                                     MessageBoxButtons.YesNo,
                                     MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                tabPage3.Enabled = true;
                TxtBxEditName.Text = phone.Name;
                TxtBxEditOs.Text = phone.OperatingSystem;
                TxtBxEditScreenSize.Text = Convert.ToString(phone.ScreenSizeInInches);
                TxtBxEditStorage.Text = Convert.ToString(phone.StorageCapacity);
                TxtBxEditStock.Text = Convert.ToString(phone.Stock);
                TxtBxEditPrice.Text = Convert.ToString(phone.Price);
                TxtBxEditManufacturer.Text = phone.Manufacturer;
                TxtBxEditModel.Text = phone.Model;
                TxtBxEditBatteryCap.Text = Convert.ToString(phone.BatteryCapacitymAh);
                TxtBxEditCameraQuality.Text = Convert.ToString(phone.CameraQualityMP);
                TxtBxEditSimCard.Text = phone.SIMCardType;
                TxtBxEditBioFeatures.Text = phone.BiometricFeatures;

                byte[] imageInBytes = phone.Image;
                Image ActualImage;

                using (MemoryStream memoryStream = new MemoryStream(imageInBytes))
                {
                    Image image = Image.FromStream(memoryStream);
                    ActualImage = image;
                }

                PbxEditImage.Image = ActualImage;

                TabPageSettings();
            }
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            RefreshList();
        }

        private void BtnImageAdd_Click(object sender, EventArgs e)
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

                    PhoneImg = imageBytes;
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

        private void RefreshList()
        {
            DgVPhone.DataSource = null;
            var source = new BindingSource();
            source.DataSource = PhoneServices.GetPhones();
            DgVPhone.DataSource = source;
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

        private void BtnEditPhone_Click(object sender, EventArgs e)
        {
            bool edit = false;

            AddEditSettings(edit);

            TabSettingClear();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            TabSettingClear();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (DgVPhone.SelectedRows.Count == 0)
            {
                MessageBox.Show("You have not selected a computer");
                return;
            }

            DataGridViewRow selectedRow = DgVPhone.SelectedRows[0];
            int serialNumber = (int)selectedRow.Cells["SerialNumber"].Value;

            Phone phone = PhoneServices.GetPhoneBySerialNumber(serialNumber);

            if (phone == null)
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
                PhoneServices.Deletephone(phone);
                MessageBox.Show("Phone has been removed");
                RefreshList();
            }
        }

        private void TabSettingClear()
        {
            TxtBxEditName.Clear();
            TxtBxEditOs.Clear();
            TxtBxEditScreenSize.Clear();
            TxtBxEditStorage.Clear();
            TxtBxEditStock.Clear();
            TxtBxEditPrice.Clear();
            TxtBxEditManufacturer.Clear();
            TxtBxEditModel.Clear();
            TxtBxEditCameraQuality.Clear();
            TxtBxEditSimCard.Clear();
            TxtBxEditBioFeatures.Clear();
            TxtBxEditBatteryCap.Clear();
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
                AddNewPhone();
            }
            else
            {
                EditPhone();
            }
        }

        private void AddNewPhone()
        {
            List<string> connectivity = new List<string>();

            string[] portBoxes = { "Wifi", "Bluetooth", "HotSpot" };

            foreach (var box in portBoxes)
            {
                connectivity.Add(box);
            }

            PhoneDTO phoneDTO = PhoneSource.Current as PhoneDTO;
            Phone GetPhone = null;

            if (phoneDTO != null)
            {
                phoneDTO.SerialNumber = SerialNumberGenerator.GenerateSerialNumber();
                phoneDTO.Connectivity = connectivity;
                phoneDTO.Image = PhoneImg;

                ValidationContext context = new ValidationContext(phoneDTO, null, null);
                IList<ValidationResult> errors = new List<ValidationResult>();
                if (!Validator.TryValidateObject(phoneDTO, context, errors, true))
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
                        GetPhone = PhoneServices.GetPhoneBySerialNumber(phoneDTO.SerialNumber);

                        if (GetPhone != null)
                        {
                            phoneDTO.SerialNumber = SerialNumberGenerator.GenerateSerialNumber();
                        }
                        else
                        {
                            i++;
                        }
                    }


                    try
                    {
                        Phone phone = PhoneConverter.ConvertToPhone(phoneDTO);
                        PhoneServices.AddPhone(phone);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                    MessageBox.Show("Phone Added");
                    PhoneSource.EndEdit();
                    PhoneSource.ResetCurrentItem();

                    RefreshList();
                }
            }
        }

        private void EditPhone()
        {
            List<string> connectivity = new List<string>();

            string[] portBoxes = { "Wifi", "Bluetooth", "HotSpot" };

            foreach (var box in portBoxes)
            {
                connectivity.Add(box);
            }

            PhoneDTO phoneDTO = new PhoneDTO();
            PhoneSource.DataSource = phoneDTO;

            TxtBxEditName.DataBindings.Add("Text", phoneDTO, "Name");
            TxtBxEditOs.DataBindings.Add("Text", phoneDTO, "OperatingSystem");
            TxtBxEditScreenSize.DataBindings.Add("Text", phoneDTO, "ScreenSizeInInches");
            TxtBxEditStorage.DataBindings.Add("Text", phoneDTO, "StorageCapacity");
            TxtBxEditStock.DataBindings.Add("Text", phoneDTO, "Stock");
            TxtBxEditPrice.DataBindings.Add("Text", phoneDTO, "Price");
            TxtBxEditManufacturer.DataBindings.Add("Text", phoneDTO, "Manufacturer");
            TxtBxEditModel.DataBindings.Add("Text", phoneDTO, "Model");
            TxtBxEditCameraQuality.DataBindings.Add("Text", phoneDTO, "CameraQualityMP");
            TxtBxEditSimCard.DataBindings.Add("Text", phoneDTO, "SIMCardType");
            TxtBxEditBioFeatures.DataBindings.Add("Text", phoneDTO, "BiometricFeatures");
            TxtBxEditBatteryCap.DataBindings.Add("Text", phoneDTO, "BatteryCapacitymAh");

            PbxEditImage.DataBindings.Add("Image", phoneDTO, "Image", true, DataSourceUpdateMode.OnPropertyChanged);

            if (PhoneImg == null)
            {
                byte[] imageBytes = ImageToByteArray(PbxEditImage.Image);
                PhoneImg = imageBytes;
            }

            PhoneDTO phoneSource = PhoneSource.Current as PhoneDTO;

            if (phoneSource != null)
            {
                phoneSource.SerialNumber = Convert.ToInt32(PhoneSerialNumber);
                phoneSource.Connectivity = connectivity;
                phoneSource.Image = PhoneImg;
                ValidationContext context = new ValidationContext(phoneSource, null, null);
                IList<ValidationResult> errors = new List<ValidationResult>();
                if (!Validator.TryValidateObject(phoneSource, context, errors, true))
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
                    Phone phone = PhoneConverter.ConvertToPhone(phoneDTO);
                    if (phone != null)
                    {
                        try
                        {
                            PhoneServices.EditPhone(phone);
                        }
                        catch (DatabaseConnectionException ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                    MessageBox.Show("Phone Edited");
                    PhoneSource.EndEdit();
                    PhoneSource.ResetCurrentItem();

                    RefreshList();
                }
            }
        }

        private void BtnImageEdit_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "jpg files (*.jpg)|*.jpg|PNG files (*.png)|*.png";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    string imageLocation = dialog.FileName;

                    PbxEditImage.Image = Image.FromFile(imageLocation);

                    byte[] imageBytes = ImageToByteArray(PbxEditImage.Image);

                    PhoneImg = imageBytes;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error has occurred: " + ex.Message);
            }
        }

        private void Phones_Panel_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
            FormStatics.CurrentHomePanel.Show();
        }
    }
}
