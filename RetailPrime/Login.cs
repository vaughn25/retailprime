namespace RetailPrime
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = mskPassword.Text;
            
            var inputsAreValid = ValidLoginInputs(username, password);
            if(!inputsAreValid)
            {
                MessageBox.Show("Please enter both username and password.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            
        }

        #region Private Methods
        private bool ValidLoginInputs(string username, string password) 
        {
            return !string.IsNullOrWhiteSpace(username) && !string.IsNullOrWhiteSpace(password);
        }
        #endregion Private Methods
    }
}
