using System;
using System.Windows.Forms;


namespace RadioClient
{
    public partial class LoginForm : Form
    {
        EncryptionProvider crypter;
        RequestSender netSender;



        public AuthenticationResult Result { get; private set; } = AuthenticationResult.Denied;
        public User User { get; private set; }



        private void btnLogin_Click(object sender, EventArgs e)
        {
            var passwordEnc = crypter.EncryptString(txtPassword.Text);
            User = new User(txtUsername.Text, passwordEnc);

            var auth = new AuthenticateRequest(User);
            var authResp = netSender.SendAndRecieve<AuthenticateResponse>(auth);
            if (authResp == null)
                this.Close();

            Result = authResp.Result;

            if (Result == AuthenticationResult.Granted)
                this.Close();
            else
                MessageBox.Show("Zadané uživatelské jméne nebo heslo je chybné", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        }


        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        public LoginForm()
        {
            InitializeComponent();

            netSender = MasterContainer.GetService<RequestSender>();
            crypter = MasterContainer.GetService<EncryptionProvider>();
        }
    }
}
