namespace Register
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            Resicle();
            var result = Validate();
            if (result)
            {
                result = ValidateUserName();
                if (result)
                {
                    result = PasswordSecure();
                    if (result)
                    {
                        result = ValidateEmail();
                        if (result)
                        {
                            lblSuccess.Text = "اطلاعات با موفقیت ثبت شد";
                        }
                    }
                }

            }
        }

        private bool Validate()
        {
            bool flag = true;
            if (txtFullName.Text == "")
            {
                lblFullNameError.Text = "لطفا نام و نام خانوادگی را وارد کنید ";
                flag = false;
            }
            if (txtUsername.Text == "")
            {
                lblUserNameError.Text = "لطفا نام کاربری را وارد کنید ";
                flag = false;
            }
            if (txtEmail.Text == "")
            {
                lblEmailError.Text = "لطفا ایمیل را وارد کنید ";
                flag = false;
            }
            if (txtPassword.Text == "")
            {
                lblPasswordError.Text = "لطفا پسورد را وارد کنید ";
                flag = false;
            }
            if (txtConfirmPassword.Text == "")
            {
                lblConfirmError.Text = "لطفا تکرار کلمه عبور را وارد کنید ";
                flag = false;
            }

            return flag;
        }

        private void Resicle()
        {
            lblConfirmError.Text = "";
            lblPasswordError.Text = "";
            lblEmailError.Text = "";
            lblFullNameError.Text = "";
            lblUserNameError.Text = "";
        }

        private void txtFullName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private bool PasswordSecure()
        {
            if (txtPassword.Text.Length < 8 || txtPassword.Text.Length > 16)
            {
                lblPasswordError.Text = "پسورد باید بین 8 تا 16 کارکتر باشد";
                return false;
            }

            if (txtPassword.Text != txtConfirmPassword.Text)
            {
                lblConfirmError.Text = "کلمه های عبور با هم مغایرت دارند";
                return false;
            }

            return true;
        }

        private bool ValidateEmail()
        {
            string email = txtEmail.Text;

            System.Text.RegularExpressions.Regex expr = new System.Text.RegularExpressions.Regex(@"^[a-zA-Z][\w\.-]{2,28}[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$");

            if (expr.IsMatch(email))
                return true;

            else
            {
                lblEmailError.Text = "ایمیل معتبر نمیباشد";
                return false;
            }
        }

        private bool ValidateUserName()
        {
            if (!txtUsername.Text.Any(char.IsDigit))
            {
                lblUserNameError.Text = "نام کاربری باید شامل عدد و حروف باشد";
                return false;
            }
            if (!txtUsername.Text.Any(char.IsLetter))
            {
                lblUserNameError.Text = "نام کاربری باید شامل عدد و حروف باشد";
                return false;
            }

            return true;
        }
    }
}