///////////////////////////////////////////////////////////////////////////////
// Copyright (c) Microsoft Corporation. All rights reserved.
///////////////////////////////////////////////////////////////////////////////

namespace ILStubDiagnostic
{
    partial class StubHelpersApiLookupForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StubHelpersApiLookupForm));
            this.buttonClose = new System.Windows.Forms.Button();
            this.textBoxAPIName = new System.Windows.Forms.TextBox();
            this.listBoxAPIName = new System.Windows.Forms.ListBox();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.groupBoxDescription = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBoxDescription.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonClose
            // 
            this.buttonClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonClose.Location = new System.Drawing.Point(142, 266);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(75, 23);
            this.buttonClose.TabIndex = 0;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // textBoxAPIName
            // 
            this.textBoxAPIName.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBoxAPIName.Location = new System.Drawing.Point(3, 16);
            this.textBoxAPIName.Margin = new System.Windows.Forms.Padding(5);
            this.textBoxAPIName.Name = "textBoxAPIName";
            this.textBoxAPIName.Size = new System.Drawing.Size(336, 20);
            this.textBoxAPIName.TabIndex = 1;
            this.textBoxAPIName.TextChanged += new System.EventHandler(this.textBoxAPIName_TextChanged);
            // 
            // listBoxAPIName
            // 
            this.listBoxAPIName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxAPIName.FormattingEnabled = true;
            this.listBoxAPIName.HorizontalScrollbar = true;
            this.listBoxAPIName.Location = new System.Drawing.Point(3, 36);
            this.listBoxAPIName.Margin = new System.Windows.Forms.Padding(5);
            this.listBoxAPIName.Name = "listBoxAPIName";
            this.listBoxAPIName.Size = new System.Drawing.Size(336, 95);
            this.listBoxAPIName.TabIndex = 3;
            this.listBoxAPIName.SelectedIndexChanged += new System.EventHandler(this.listBoxAPIName_SelectedIndexChanged);
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxDescription.Location = new System.Drawing.Point(3, 16);
            this.textBoxDescription.Multiline = true;
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.ReadOnly = true;
            this.textBoxDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxDescription.Size = new System.Drawing.Size(333, 81);
            this.textBoxDescription.TabIndex = 4;
            // 
            // groupBoxDescription
            // 
            this.groupBoxDescription.Controls.Add(this.textBoxDescription);
            this.groupBoxDescription.Location = new System.Drawing.Point(15, 160);
            this.groupBoxDescription.Name = "groupBoxDescription";
            this.groupBoxDescription.Size = new System.Drawing.Size(339, 100);
            this.groupBoxDescription.TabIndex = 5;
            this.groupBoxDescription.TabStop = false;
            this.groupBoxDescription.Text = "Description";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listBoxAPIName);
            this.groupBox1.Controls.Add(this.textBoxAPIName);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(342, 142);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Name";
            // 
            // StubHelpersAPILookupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonClose;
            this.ClientSize = new System.Drawing.Size(366, 302);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBoxDescription);
            this.Controls.Add(this.buttonClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "StubHelpersAPILookupForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "StubHelpers API Lookup";
            this.Load += new System.EventHandler(this.StubHelpersAPILookupForm_Load);
            this.groupBoxDescription.ResumeLayout(false);
            this.groupBoxDescription.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.TextBox textBoxAPIName;
        private System.Windows.Forms.ListBox listBoxAPIName;
        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.GroupBox groupBoxDescription;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}