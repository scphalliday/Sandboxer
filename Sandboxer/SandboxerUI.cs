using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sandboxer
{
    public partial class SandboxerUI : Form
    {
        public SandboxerUI()
        {
            InitializeComponent();
            Console.SetOut(new TextBoxWriter(OutTextBox));

        }
        private void GetParams(string paramString) {
            if (paramString.Length == 0)
            {
                return;
            }
            else {
                string[] paras = paramString.Split(',');
                Sandboxer.SetParameters(paras);
            }

        }

        private void runButton_Click(object sender, EventArgs e)
        {
            Regex whiteSpace = new Regex(@"^[ ]*$");
            if (whiteSpace.IsMatch(FilePathTextBox.Text))
            {
                //file path text box in this instance would be empty, as such, invalid
                Console.WriteLine("Please input the path to your executable.");
            }
            else
            {
                string path = FilePathTextBox.Text;
                List<string> verificationFeed = new List<string>();
                verificationFeed.Add(path);
                if (!whiteSpace.IsMatch(ParametersTextBox.Text))
                {
                    //parameters handled differently with the UI, but then verified the same as with cmd input.
                    //parameters must be separated by ','
                    string[] paramsSplit = ParametersTextBox.Text.Split(',');
                    foreach (string s in paramsSplit)
                    {
                        verificationFeed.Add(s);
                    }
                }
                if (Sandboxer.VerifyArguments(verificationFeed.ToArray()))
                {

                    string[] pathAndAssembly = Sandboxer.PathSeparate(path);
                    Sandboxer.SetPathToUntrusted(pathAndAssembly[0]);
                    Sandboxer.SetUntrustedAssembly(pathAndAssembly[1]);
                    List<string> perms = new List<string>();
                    if (FileIOReadCheckbox.Checked)
                    {
                        perms.Add("io");
                    }
                    if (FileDialogCheckBox.Checked)
                    {
                        perms.Add("filedialog");
                    }
                    if (ReflectionCheckBox.Checked)
                    {
                        perms.Add("reflection");
                    }
                    if (RegistryCheckBox.Checked)
                    {
                        perms.Add("registry");
                    }
                    if (UICheckBox.Checked)
                    {
                        perms.Add("UI");
                    }
                    if (EnvironmentCheckBox.Checked)
                    {
                        perms.Add("environment");
                    }
                    if (UnrestrictedCheckBox.Checked) {
                        perms.Add("unrestricted");
                    }
                    if (SecurityCheckBox.Checked) {
                        perms.Add("security");
                    }
                    GetParams(ParametersTextBox.Text);
                    Sandboxer.SetSelectedPerms(perms.ToArray());
                    Console.WriteLine("Running code, check command prompt for output.");
                    Sandboxer.Begin();
                }
                else {
                    Console.WriteLine("Error in inputs, please try again.");
                }
            }
        }

        private void BrowseButton_Click(object sender, EventArgs e)
        {
            //code to open filediaglog can be found at;
            //https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.openfiledialog?view=windowsdesktop-6.0

            string filePath = string.Empty;
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = openFileDialog.FileName;
                    FilePathTextBox.Text = filePath;
                }
            }
        }
    }
    //the code that was used in order to redirect the console output to the UI for the sandboxer can be found at;
    //https://stackoverflow.com/questions/14802876/what-is-a-good-way-to-direct-console-output-to-text-box-in-windows-form
    public class TextBoxWriter : TextWriter
    {
        TextBox _output = null;

        public TextBoxWriter(TextBox output)
        {
            _output = output;
        }

        public override void Write(char value)
        {
            base.Write(value);
            _output.AppendText(value.ToString());
        }
        public override Encoding Encoding
        {
            get { return System.Text.Encoding.UTF8; }
        }
    }
}
