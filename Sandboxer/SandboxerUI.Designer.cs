
namespace Sandboxer
{
    partial class SandboxerUI
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.FilePathOfExeText = new System.Windows.Forms.Label();
            this.FilePathTextBox = new System.Windows.Forms.TextBox();
            this.titleText = new System.Windows.Forms.Label();
            this.permissionsLabel = new System.Windows.Forms.Label();
            this.runButton = new System.Windows.Forms.Button();
            this.FileIOReadCheckbox = new System.Windows.Forms.CheckBox();
            this.ParametersLabel = new System.Windows.Forms.Label();
            this.ParametersTextBox = new System.Windows.Forms.TextBox();
            this.FileDialogCheckBox = new System.Windows.Forms.CheckBox();
            this.ReflectionCheckBox = new System.Windows.Forms.CheckBox();
            this.RegistryCheckBox = new System.Windows.Forms.CheckBox();
            this.UICheckBox = new System.Windows.Forms.CheckBox();
            this.EnvironmentCheckBox = new System.Windows.Forms.CheckBox();
            this.MoreInfoLabel = new System.Windows.Forms.Label();
            this.BrowseButton = new System.Windows.Forms.Button();
            this.OpenFile = new System.Windows.Forms.OpenFileDialog();
            this.OutTextBox = new System.Windows.Forms.TextBox();
            this.UnrestrictedCheckBox = new System.Windows.Forms.CheckBox();
            this.SecurityCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // FilePathOfExeText
            // 
            this.FilePathOfExeText.AutoSize = true;
            this.FilePathOfExeText.Location = new System.Drawing.Point(12, 53);
            this.FilePathOfExeText.Name = "FilePathOfExeText";
            this.FilePathOfExeText.Size = new System.Drawing.Size(79, 13);
            this.FilePathOfExeText.TabIndex = 0;
            this.FilePathOfExeText.Text = "File path of exe";
            // 
            // FilePathTextBox
            // 
            this.FilePathTextBox.Location = new System.Drawing.Point(97, 50);
            this.FilePathTextBox.Name = "FilePathTextBox";
            this.FilePathTextBox.Size = new System.Drawing.Size(340, 20);
            this.FilePathTextBox.TabIndex = 1;
            // 
            // titleText
            // 
            this.titleText.AutoSize = true;
            this.titleText.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleText.Location = new System.Drawing.Point(10, 9);
            this.titleText.Name = "titleText";
            this.titleText.Size = new System.Drawing.Size(173, 25);
            this.titleText.TabIndex = 2;
            this.titleText.Text = "Software Sandbox";
            // 
            // permissionsLabel
            // 
            this.permissionsLabel.AutoSize = true;
            this.permissionsLabel.Location = new System.Drawing.Point(12, 119);
            this.permissionsLabel.Name = "permissionsLabel";
            this.permissionsLabel.Size = new System.Drawing.Size(258, 13);
            this.permissionsLabel.TabIndex = 3;
            this.permissionsLabel.Text = "Permission Selection (Defaulted minimum - Execution)";
            // 
            // runButton
            // 
            this.runButton.Location = new System.Drawing.Point(443, 201);
            this.runButton.Name = "runButton";
            this.runButton.Size = new System.Drawing.Size(75, 23);
            this.runButton.TabIndex = 4;
            this.runButton.Text = "Run exe";
            this.runButton.UseVisualStyleBackColor = true;
            this.runButton.Click += new System.EventHandler(this.runButton_Click);
            // 
            // FileIOReadCheckbox
            // 
            this.FileIOReadCheckbox.AutoSize = true;
            this.FileIOReadCheckbox.Location = new System.Drawing.Point(12, 144);
            this.FileIOReadCheckbox.Name = "FileIOReadCheckbox";
            this.FileIOReadCheckbox.Size = new System.Drawing.Size(61, 17);
            this.FileIOReadCheckbox.TabIndex = 5;
            this.FileIOReadCheckbox.Text = "File I/O";
            this.FileIOReadCheckbox.UseVisualStyleBackColor = true;
            // 
            // ParametersLabel
            // 
            this.ParametersLabel.AutoSize = true;
            this.ParametersLabel.Location = new System.Drawing.Point(13, 85);
            this.ParametersLabel.Name = "ParametersLabel";
            this.ParametersLabel.Size = new System.Drawing.Size(60, 13);
            this.ParametersLabel.TabIndex = 6;
            this.ParametersLabel.Text = "Parameters";
            // 
            // ParametersTextBox
            // 
            this.ParametersTextBox.Location = new System.Drawing.Point(97, 82);
            this.ParametersTextBox.Name = "ParametersTextBox";
            this.ParametersTextBox.Size = new System.Drawing.Size(340, 20);
            this.ParametersTextBox.TabIndex = 7;
            // 
            // FileDialogCheckBox
            // 
            this.FileDialogCheckBox.AutoSize = true;
            this.FileDialogCheckBox.Location = new System.Drawing.Point(12, 168);
            this.FileDialogCheckBox.Name = "FileDialogCheckBox";
            this.FileDialogCheckBox.Size = new System.Drawing.Size(75, 17);
            this.FileDialogCheckBox.TabIndex = 8;
            this.FileDialogCheckBox.Text = "File Dialog";
            this.FileDialogCheckBox.UseVisualStyleBackColor = true;
            // 
            // ReflectionCheckBox
            // 
            this.ReflectionCheckBox.AutoSize = true;
            this.ReflectionCheckBox.Location = new System.Drawing.Point(12, 191);
            this.ReflectionCheckBox.Name = "ReflectionCheckBox";
            this.ReflectionCheckBox.Size = new System.Drawing.Size(74, 17);
            this.ReflectionCheckBox.TabIndex = 9;
            this.ReflectionCheckBox.Text = "Reflection";
            this.ReflectionCheckBox.UseVisualStyleBackColor = true;
            // 
            // RegistryCheckBox
            // 
            this.RegistryCheckBox.AutoSize = true;
            this.RegistryCheckBox.Location = new System.Drawing.Point(132, 144);
            this.RegistryCheckBox.Name = "RegistryCheckBox";
            this.RegistryCheckBox.Size = new System.Drawing.Size(64, 17);
            this.RegistryCheckBox.TabIndex = 10;
            this.RegistryCheckBox.Text = "Registry";
            this.RegistryCheckBox.UseVisualStyleBackColor = true;
            // 
            // UICheckBox
            // 
            this.UICheckBox.AutoSize = true;
            this.UICheckBox.Location = new System.Drawing.Point(132, 168);
            this.UICheckBox.Name = "UICheckBox";
            this.UICheckBox.Size = new System.Drawing.Size(37, 17);
            this.UICheckBox.TabIndex = 11;
            this.UICheckBox.Text = "UI";
            this.UICheckBox.UseVisualStyleBackColor = true;
            // 
            // EnvironmentCheckBox
            // 
            this.EnvironmentCheckBox.AutoSize = true;
            this.EnvironmentCheckBox.Location = new System.Drawing.Point(132, 191);
            this.EnvironmentCheckBox.Name = "EnvironmentCheckBox";
            this.EnvironmentCheckBox.Size = new System.Drawing.Size(85, 17);
            this.EnvironmentCheckBox.TabIndex = 12;
            this.EnvironmentCheckBox.Text = "Environment";
            this.EnvironmentCheckBox.UseVisualStyleBackColor = true;
            // 
            // MoreInfoLabel
            // 
            this.MoreInfoLabel.AutoSize = true;
            this.MoreInfoLabel.Location = new System.Drawing.Point(9, 211);
            this.MoreInfoLabel.Name = "MoreInfoLabel";
            this.MoreInfoLabel.Size = new System.Drawing.Size(278, 13);
            this.MoreInfoLabel.TabIndex = 13;
            this.MoreInfoLabel.Text = "More information about permissions is found in the manual";
            // 
            // BrowseButton
            // 
            this.BrowseButton.Location = new System.Drawing.Point(443, 50);
            this.BrowseButton.Name = "BrowseButton";
            this.BrowseButton.Size = new System.Drawing.Size(75, 20);
            this.BrowseButton.TabIndex = 17;
            this.BrowseButton.Text = "Browse";
            this.BrowseButton.UseVisualStyleBackColor = true;
            this.BrowseButton.Click += new System.EventHandler(this.BrowseButton_Click);
            // 
            // OpenFile
            // 
            this.OpenFile.FileName = "openFileDialog1";
            // 
            // OutTextBox
            // 
            this.OutTextBox.Location = new System.Drawing.Point(12, 230);
            this.OutTextBox.Multiline = true;
            this.OutTextBox.Name = "OutTextBox";
            this.OutTextBox.Size = new System.Drawing.Size(506, 202);
            this.OutTextBox.TabIndex = 18;
            // 
            // UnrestrictedCheckBox
            // 
            this.UnrestrictedCheckBox.AutoSize = true;
            this.UnrestrictedCheckBox.Location = new System.Drawing.Point(253, 167);
            this.UnrestrictedCheckBox.Name = "UnrestrictedCheckBox";
            this.UnrestrictedCheckBox.Size = new System.Drawing.Size(83, 17);
            this.UnrestrictedCheckBox.TabIndex = 19;
            this.UnrestrictedCheckBox.Text = "Unrestricted";
            this.UnrestrictedCheckBox.UseVisualStyleBackColor = true;
            // 
            // SecurityCheckBox
            // 
            this.SecurityCheckBox.AutoSize = true;
            this.SecurityCheckBox.Location = new System.Drawing.Point(253, 144);
            this.SecurityCheckBox.Name = "SecurityCheckBox";
            this.SecurityCheckBox.Size = new System.Drawing.Size(64, 17);
            this.SecurityCheckBox.TabIndex = 20;
            this.SecurityCheckBox.Text = "Security";
            this.SecurityCheckBox.UseVisualStyleBackColor = true;
            // 
            // SandboxerUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(530, 444);
            this.Controls.Add(this.SecurityCheckBox);
            this.Controls.Add(this.UnrestrictedCheckBox);
            this.Controls.Add(this.OutTextBox);
            this.Controls.Add(this.BrowseButton);
            this.Controls.Add(this.MoreInfoLabel);
            this.Controls.Add(this.EnvironmentCheckBox);
            this.Controls.Add(this.UICheckBox);
            this.Controls.Add(this.RegistryCheckBox);
            this.Controls.Add(this.ReflectionCheckBox);
            this.Controls.Add(this.FileDialogCheckBox);
            this.Controls.Add(this.ParametersTextBox);
            this.Controls.Add(this.ParametersLabel);
            this.Controls.Add(this.FileIOReadCheckbox);
            this.Controls.Add(this.runButton);
            this.Controls.Add(this.permissionsLabel);
            this.Controls.Add(this.titleText);
            this.Controls.Add(this.FilePathTextBox);
            this.Controls.Add(this.FilePathOfExeText);
            this.Name = "SandboxerUI";
            this.Text = "SandboxerUI";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label FilePathOfExeText;
        private System.Windows.Forms.TextBox FilePathTextBox;
        private System.Windows.Forms.Label titleText;
        private System.Windows.Forms.Label permissionsLabel;
        private System.Windows.Forms.Button runButton;
        private System.Windows.Forms.CheckBox FileIOReadCheckbox;
        private System.Windows.Forms.Label ParametersLabel;
        private System.Windows.Forms.TextBox ParametersTextBox;
        private System.Windows.Forms.CheckBox FileDialogCheckBox;
        private System.Windows.Forms.CheckBox ReflectionCheckBox;
        private System.Windows.Forms.CheckBox RegistryCheckBox;
        private System.Windows.Forms.CheckBox UICheckBox;
        private System.Windows.Forms.CheckBox EnvironmentCheckBox;
        private System.Windows.Forms.Label MoreInfoLabel;
        private System.Windows.Forms.Button BrowseButton;
        private System.Windows.Forms.OpenFileDialog OpenFile;
        public static System.Windows.Forms.TextBox OutputTextBox;
        private System.Windows.Forms.TextBox OutTextBox;
        private System.Windows.Forms.CheckBox UnrestrictedCheckBox;
        private System.Windows.Forms.CheckBox SecurityCheckBox;
    }
}