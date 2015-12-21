namespace Net.Pkcs11Admin.WinForms.Dialogs
{
    partial class DataObjectDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DataObjectDialog));
            this.ButtonSave = new System.Windows.Forms.Button();
            this.ButtonClose = new System.Windows.Forms.Button();
            this.DataObjectTabControl = new System.Windows.Forms.TabControl();
            this.TabPageHex = new System.Windows.Forms.TabPage();
            this.HexBoxContent = new Be.Windows.Forms.HexBox();
            this.LabelHex = new System.Windows.Forms.Label();
            this.TabPageText = new System.Windows.Forms.TabPage();
            this.TextBoxContent = new System.Windows.Forms.TextBox();
            this.LabelText = new System.Windows.Forms.Label();
            this.TabPageAsn1 = new System.Windows.Forms.TabPage();
            this.Asn1TreeViewContent = new Net.Asn1.Forms.TreeView.Asn1TreeView();
            this.LabelAsn1 = new System.Windows.Forms.Label();
            this.DataObjectTabControl.SuspendLayout();
            this.TabPageHex.SuspendLayout();
            this.TabPageText.SuspendLayout();
            this.TabPageAsn1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ButtonSave
            // 
            this.ButtonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ButtonSave.Location = new System.Drawing.Point(13, 315);
            this.ButtonSave.Name = "ButtonSave";
            this.ButtonSave.Size = new System.Drawing.Size(75, 23);
            this.ButtonSave.TabIndex = 2;
            this.ButtonSave.Text = "Save";
            this.ButtonSave.UseVisualStyleBackColor = true;
            this.ButtonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // ButtonClose
            // 
            this.ButtonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonClose.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.ButtonClose.Location = new System.Drawing.Point(409, 315);
            this.ButtonClose.Name = "ButtonClose";
            this.ButtonClose.Size = new System.Drawing.Size(75, 23);
            this.ButtonClose.TabIndex = 0;
            this.ButtonClose.Text = "Close";
            this.ButtonClose.UseVisualStyleBackColor = true;
            // 
            // DataObjectTabControl
            // 
            this.DataObjectTabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DataObjectTabControl.Controls.Add(this.TabPageHex);
            this.DataObjectTabControl.Controls.Add(this.TabPageText);
            this.DataObjectTabControl.Controls.Add(this.TabPageAsn1);
            this.DataObjectTabControl.Location = new System.Drawing.Point(13, 13);
            this.DataObjectTabControl.Name = "DataObjectTabControl";
            this.DataObjectTabControl.SelectedIndex = 0;
            this.DataObjectTabControl.Size = new System.Drawing.Size(471, 296);
            this.DataObjectTabControl.TabIndex = 1;
            // 
            // TabPageHex
            // 
            this.TabPageHex.Controls.Add(this.HexBoxContent);
            this.TabPageHex.Controls.Add(this.LabelHex);
            this.TabPageHex.Location = new System.Drawing.Point(4, 22);
            this.TabPageHex.Name = "TabPageHex";
            this.TabPageHex.Padding = new System.Windows.Forms.Padding(10);
            this.TabPageHex.Size = new System.Drawing.Size(463, 270);
            this.TabPageHex.TabIndex = 0;
            this.TabPageHex.Text = "Hex";
            this.TabPageHex.UseVisualStyleBackColor = true;
            // 
            // HexBoxContent
            // 
            this.HexBoxContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.HexBoxContent.ColumnInfoVisible = true;
            this.HexBoxContent.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.HexBoxContent.LineInfoVisible = true;
            this.HexBoxContent.Location = new System.Drawing.Point(13, 26);
            this.HexBoxContent.Name = "HexBoxContent";
            this.HexBoxContent.ReadOnly = true;
            this.HexBoxContent.ShadowSelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(60)))), ((int)(((byte)(188)))), ((int)(((byte)(255)))));
            this.HexBoxContent.Size = new System.Drawing.Size(437, 231);
            this.HexBoxContent.StringViewVisible = true;
            this.HexBoxContent.TabIndex = 1;
            this.HexBoxContent.VScrollBarVisible = true;
            // 
            // LabelHex
            // 
            this.LabelHex.AutoSize = true;
            this.LabelHex.Location = new System.Drawing.Point(10, 10);
            this.LabelHex.Name = "LabelHex";
            this.LabelHex.Size = new System.Drawing.Size(104, 13);
            this.LabelHex.TabIndex = 0;
            this.LabelHex.Text = "Data object content:";
            // 
            // TabPageText
            // 
            this.TabPageText.Controls.Add(this.TextBoxContent);
            this.TabPageText.Controls.Add(this.LabelText);
            this.TabPageText.Location = new System.Drawing.Point(4, 22);
            this.TabPageText.Name = "TabPageText";
            this.TabPageText.Padding = new System.Windows.Forms.Padding(10);
            this.TabPageText.Size = new System.Drawing.Size(463, 270);
            this.TabPageText.TabIndex = 1;
            this.TabPageText.Text = "Text";
            this.TabPageText.UseVisualStyleBackColor = true;
            // 
            // TextBoxContent
            // 
            this.TextBoxContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBoxContent.BackColor = System.Drawing.SystemColors.Window;
            this.TextBoxContent.Location = new System.Drawing.Point(13, 26);
            this.TextBoxContent.Multiline = true;
            this.TextBoxContent.Name = "TextBoxContent";
            this.TextBoxContent.ReadOnly = true;
            this.TextBoxContent.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.TextBoxContent.Size = new System.Drawing.Size(437, 231);
            this.TextBoxContent.TabIndex = 2;
            // 
            // LabelText
            // 
            this.LabelText.AutoSize = true;
            this.LabelText.Location = new System.Drawing.Point(10, 10);
            this.LabelText.Name = "LabelText";
            this.LabelText.Size = new System.Drawing.Size(104, 13);
            this.LabelText.TabIndex = 0;
            this.LabelText.Text = "Data object content:";
            // 
            // TabPageAsn1
            // 
            this.TabPageAsn1.Controls.Add(this.Asn1TreeViewContent);
            this.TabPageAsn1.Controls.Add(this.LabelAsn1);
            this.TabPageAsn1.Location = new System.Drawing.Point(4, 22);
            this.TabPageAsn1.Name = "TabPageAsn1";
            this.TabPageAsn1.Padding = new System.Windows.Forms.Padding(10);
            this.TabPageAsn1.Size = new System.Drawing.Size(463, 270);
            this.TabPageAsn1.TabIndex = 2;
            this.TabPageAsn1.Text = "ASN.1";
            this.TabPageAsn1.UseVisualStyleBackColor = true;
            // 
            // Asn1TreeViewContent
            // 
            this.Asn1TreeViewContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Asn1TreeViewContent.Location = new System.Drawing.Point(13, 26);
            this.Asn1TreeViewContent.Name = "Asn1TreeViewContent";
            this.Asn1TreeViewContent.Size = new System.Drawing.Size(437, 231);
            this.Asn1TreeViewContent.TabIndex = 1;
            // 
            // LabelAsn1
            // 
            this.LabelAsn1.AutoSize = true;
            this.LabelAsn1.Location = new System.Drawing.Point(10, 10);
            this.LabelAsn1.Name = "LabelAsn1";
            this.LabelAsn1.Size = new System.Drawing.Size(104, 13);
            this.LabelAsn1.TabIndex = 0;
            this.LabelAsn1.Text = "Data object content:";
            // 
            // DataObjectDialog
            // 
            this.AcceptButton = this.ButtonClose;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(497, 351);
            this.Controls.Add(this.DataObjectTabControl);
            this.Controls.Add(this.ButtonClose);
            this.Controls.Add(this.ButtonSave);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DataObjectDialog";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Data object content";
            this.DataObjectTabControl.ResumeLayout(false);
            this.TabPageHex.ResumeLayout(false);
            this.TabPageHex.PerformLayout();
            this.TabPageText.ResumeLayout(false);
            this.TabPageText.PerformLayout();
            this.TabPageAsn1.ResumeLayout(false);
            this.TabPageAsn1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ButtonSave;
        private System.Windows.Forms.Button ButtonClose;
        private System.Windows.Forms.TabControl DataObjectTabControl;
        private System.Windows.Forms.TabPage TabPageHex;
        private System.Windows.Forms.TabPage TabPageText;
        private System.Windows.Forms.TabPage TabPageAsn1;
        private System.Windows.Forms.Label LabelHex;
        private System.Windows.Forms.Label LabelText;
        private System.Windows.Forms.Label LabelAsn1;
        private Be.Windows.Forms.HexBox HexBoxContent;
        private Asn1.Forms.TreeView.Asn1TreeView Asn1TreeViewContent;
        private System.Windows.Forms.TextBox TextBoxContent;
    }
}