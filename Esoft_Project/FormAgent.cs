using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Esoft_Project
{
    public partial class FormAgent : Form
    {
        public FormAgent()
        {
            InitializeComponent();
            ShowAgent();
        }
        void ShowAgent()
        {
            listViewAgent.Items.Clear();
            foreach (AgentsSet agentsSet in Program.wftDb.AgentsSet)
            {
                ListViewItem item = new ListViewItem(new string[]
                    {
                        agentsSet.Id.ToString(), agentsSet.FirstName, agentsSet.MiddleName, agentsSet.LastName, agentsSet.DealShare.ToString()
                    });
                item.Tag = agentsSet;
                listViewAgent.Items.Add(item);

            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            AgentsSet agentSet = new AgentsSet();
            agentSet.FirstName = textBoxFirstName.Text;
            agentSet.MiddleName = textBoxMiddleName.Text;
            agentSet.LastName = textBoxLastName.Text;
            agentSet.DealShare = Convert.ToInt32(textBoxDealShare.Text);
            Program.wftDb.AgentsSet.Add(agentSet);
            Program.wftDb.SaveChanges();
            ShowAgent();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (listViewAgent.SelectedItems.Count == 1)
            {
                AgentsSet agentSet = listViewAgent.SelectedItems[0].Tag as AgentsSet;
                agentSet.FirstName = textBoxFirstName.Text;
                agentSet.MiddleName = textBoxMiddleName.Text;
                agentSet.LastName = textBoxLastName.Text;
                agentSet.DealShare = Convert.ToInt32(textBoxDealShare.Text);
                Program.wftDb.SaveChanges();
                ShowAgent();
            }
        }

        private void listViewAgent_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewAgent.SelectedItems.Count == 1)
            {
                AgentsSet agentSet = listViewAgent.SelectedItems[0].Tag as AgentsSet;
                textBoxFirstName.Text = agentSet.FirstName;
                textBoxMiddleName.Text = agentSet.MiddleName;
                textBoxLastName.Text = agentSet.LastName;
                textBoxDealShare.Text = Convert.ToString(agentSet.DealShare);
            }
            else
            {
                textBoxFirstName.Text = "";
                textBoxMiddleName.Text = "";
                textBoxLastName.Text = "";
                textBoxDealShare.Text = "";
            }
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (listViewAgent.SelectedItems.Count == 1)
                {
                    AgentsSet agentSet = listViewAgent.SelectedItems[0].Tag as AgentsSet;
                    Program.wftDb.AgentsSet.Remove(agentSet);
                    Program.wftDb.SaveChanges();
                    ShowAgent();
                }
                textBoxFirstName.Text = "";
                textBoxMiddleName.Text = "";
                textBoxLastName.Text = "";
                textBoxDealShare.Text = "";
            }
            catch
            {
                MessageBox.Show("Невозможно удалить, эта запись используется!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
    








