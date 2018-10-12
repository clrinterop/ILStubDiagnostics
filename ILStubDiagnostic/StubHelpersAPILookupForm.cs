using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ILStubDiagnostic
{
    public partial class StubHelpersApiLookupForm : Form
    {
        public StubHelpersApiLookupForm()
        {
            InitializeComponent();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void StubHelpersAPILookupForm_Load(object sender, EventArgs e)
        {
            UpdateAPIList("");
        }

        private void textBoxAPIName_TextChanged(object sender, EventArgs e)
        {
            UpdateAPIList(textBoxAPIName.Text);
            textBoxDescription.Text = "";
        }

        private void UpdateAPIList(string name)
        {
            listBoxAPIName.Items.Clear();
            StubHelpersAPIDictionary dictionary = StubHelpersAPIDictionary.GetInstance();
            List<string> nameList = dictionary.GetKeysContaining(name);
            listBoxAPIName.Items.AddRange(nameList.ToArray());
        }

        private void listBoxAPIName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxAPIName.SelectedItem != null)
            {
                string APIName = listBoxAPIName.SelectedItem.ToString();
                StubHelpersAPIDictionary dictionary = StubHelpersAPIDictionary.GetInstance();
                string description;
                if (dictionary.TryGetValue(APIName, out description))
                {
                    textBoxDescription.Text = description;
                }
            }
        }
    }
}
