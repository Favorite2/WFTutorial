using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Esoft_Project
{
    public partial class FormDemand : Form
    {
        public FormDemand()
        {
            InitializeComponent();
            ShowAgents();
            ShowClients();
            ShowDemandSet();
            comboBoxType.SelectedIndex = 0;
        }
        void ShowDemandSet()
        {
            listViewDemand_Apartment.Items.Clear();
            listViewDemand_House.Items.Clear();
            listViewDemand_Land.Items.Clear();
            foreach (DemandSet demand in Program.wftDb.DemandSet)
            {
                if (demand.Type == 0)
                {
                    ListViewItem item = new ListViewItem(new string[]
                    {
                        demand.IdAgent.ToString(), demand.IdClient.ToString(), demand.Type.ToString(), demand.MinPrice.ToString(), demand.MaxPrice.ToString(), demand.MinArea.ToString(), demand.MaxArea.ToString(), demand.MinRooms.ToString(), demand.MaxRooms.ToString(), demand.MinFloor.ToString(), demand.MaxFloor.ToString()
                    });
                    item.Tag = demand;
                    listViewDemand_Apartment.Items.Add(item);
                }
                else if (demand.Type == 1)
                {
                    ListViewItem item = new ListViewItem(new string[]
                    {
                        demand.IdAgent.ToString(), demand.IdClient.ToString(), demand.Type.ToString(), demand.MinPrice.ToString(), demand.MaxPrice.ToString(), demand.MinArea.ToString(), demand.MaxArea.ToString(), demand.MinFloors.ToString(), demand.MaxFloors.ToString()
                    });
                    item.Tag = demand;
                    listViewDemand_House.Items.Add(item);
                }
                else
                {
                    ListViewItem item = new ListViewItem(new string[]
                    {
                         demand.IdAgent.ToString(), demand.IdClient.ToString(), demand.Type.ToString(), demand.MinPrice.ToString(), demand.MaxPrice.ToString(), demand.MinArea.ToString(), demand.MaxArea.ToString()
                    });
                    item.Tag = demand;
                    listViewDemand_Land.Items.Add(item);
                }
            }
            listViewDemand_Apartment.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            listViewDemand_House.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            listViewDemand_Land.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }
        void ShowAgents()
        {
            comboBoxAgents.Items.Clear();
            foreach (AgentsSet agentSet in Program.wftDb.AgentsSet)
            {
                string[] item = { agentSet.Id.ToString() + ".", agentSet.FirstName, agentSet.MiddleName, agentSet.LastName };
                comboBoxAgents.Items.Add(string.Join(" ", item));
            }
        }
        void ShowClients()
        {
            comboBoxClients.Items.Clear();
            foreach (ClientsSet clientsSet in Program.wftDb.ClientsSet)
            {
                string[] item = { clientsSet.Id.ToString() + ".", clientsSet.FirstName, clientsSet.MiddleName, clientsSet.LastName };
                comboBoxClients.Items.Add(string.Join(" ", item));
            }
        }

        private void comboBoxType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxType.SelectedIndex == 0)
            {
                listViewDemand_Apartment.Visible = true;
                textBoxMaxRooms.Visible = true;
                textBoxMinRooms.Visible = true;
                textBoxMinFloor.Visible = true;
                textBoxMaxFloor.Visible = true;
                labelMinRooms.Visible = true;
                labelMaxRooms.Visible = true;
                labelMinFloor.Visible = true;
                labelMaxFloor.Visible = true;

                listViewDemand_House.Visible = false;
                listViewDemand_Land.Visible = false;
                textBoxMinFloors.Visible = false;
                textBoxMaxFloors.Visible = false;
                labelMinFloors.Visible = false;
                labelMaxFloors.Visible = false;

                textBoxMaxPrice.Text = "";
                textBoxMinPrice.Text = "";
                textBoxMinFloor.Text = "";
                textBoxMaxFloor.Text = "";
                textBoxMinRooms.Text = "";
                textBoxMaxRooms.Text = "";
                textBoxMinArea.Text = "";
                textBoxMaxArea.Text = "";
            }
            else if (comboBoxType.SelectedIndex == 1)
            {
                listViewDemand_House.Visible = true;
                textBoxMinFloors.Visible = true;
                textBoxMaxFloors.Visible = true;
                labelMinFloors.Visible = true;
                labelMaxFloors.Visible = true;

                listViewDemand_Apartment.Visible = false;
                listViewDemand_Land.Visible = false;
                textBoxMinFloor.Visible = false;
                textBoxMaxFloor.Visible = false;
                textBoxMaxRooms.Visible = false;
                textBoxMinRooms.Visible = false;
                labelMinFloor.Visible = false;
                labelMaxFloor.Visible = false;
                labelMinRooms.Visible = false;
                labelMaxRooms.Visible = false;

                textBoxMaxPrice.Text = "";
                textBoxMinPrice.Text = "";
                textBoxMinArea.Text = "";
                textBoxMaxArea.Text = "";
                textBoxMinFloors.Text = "";
                textBoxMaxFloors.Text = "";
            }
            else if (comboBoxType.SelectedIndex == 2)
            {
                listViewDemand_Land.Visible = true;

                listViewDemand_Apartment.Visible = false;
                listViewDemand_House.Visible = false;
                textBoxMinFloor.Visible = false;
                textBoxMaxFloor.Visible = false;
                textBoxMaxRooms.Visible = false;
                textBoxMinRooms.Visible = false;
                labelMinFloor.Visible = false;
                labelMaxFloor.Visible = false;
                labelMinRooms.Visible = false;
                labelMaxRooms.Visible = false;
                textBoxMinFloors.Visible = false;
                textBoxMaxFloors.Visible = false;
                labelMinFloors.Visible = false;
                labelMaxFloors.Visible = false;

                textBoxMaxPrice.Text = "";
                textBoxMinPrice.Text = "";
                textBoxMinArea.Text = "";
                textBoxMaxArea.Text = "";
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            DemandSet demand = new DemandSet();
            demand.IdAgent = Convert.ToInt32(comboBoxAgents.SelectedItem.ToString().Split('.')[0]);
            demand.IdClient = Convert.ToInt32(comboBoxClients.SelectedItem.ToString().Split('.')[0]);
            demand.MaxPrice = Convert.ToInt64(textBoxMaxPrice.Text);
            demand.MinPrice = Convert.ToInt64(textBoxMinPrice.Text);
            demand.MaxArea = Convert.ToDouble(textBoxMaxArea.Text);
            demand.MinArea = Convert.ToDouble(textBoxMinArea.Text);
            if (comboBoxType.SelectedIndex == 0)
            {
                demand.Type = 0;
                demand.IdAgent = Convert.ToInt32(comboBoxAgents.SelectedItem.ToString().Split('.')[0]);
                demand.IdClient = Convert.ToInt32(comboBoxClients.SelectedItem.ToString().Split('.')[0]);
                demand.MinFloor = Convert.ToInt32(textBoxMinFloor.Text);
                demand.MaxFloor = Convert.ToInt32(textBoxMaxFloor.Text);
                demand.MinRooms = Convert.ToInt32(textBoxMinFloor.Text);
                demand.MaxRooms = Convert.ToInt32(textBoxMinFloor.Text);
            }
            else if (comboBoxType.SelectedIndex == 1)
            {
                demand.Type = 1;
                demand.IdAgent = Convert.ToInt32(comboBoxAgents.SelectedItem.ToString().Split('.')[0]);
                demand.IdClient = Convert.ToInt32(comboBoxClients.SelectedItem.ToString().Split('.')[0]);
                demand.MinFloors = Convert.ToInt32(textBoxMinFloors.Text);
                demand.MaxFloors = Convert.ToInt32(textBoxMaxFloors.Text);
            }
            else
            {
                demand.Type = 2;
            }
            Program.wftDb.DemandSet.Add(demand);
            Program.wftDb.SaveChanges();
            ShowDemandSet();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (comboBoxType.SelectedIndex == 0)
            {
                if (listViewDemand_Apartment.SelectedItems.Count == 1)
                {
                    DemandSet demand = listViewDemand_Apartment.SelectedItems[0].Tag as DemandSet;
                    demand.IdAgent = Convert.ToInt32(comboBoxAgents.SelectedItem.ToString().Split('.')[0]);
                    demand.IdClient = Convert.ToInt32(comboBoxClients.SelectedItem.ToString().Split('.')[0]);
                    demand.MinPrice = Convert.ToInt64(textBoxMinPrice.Text);
                    demand.MaxPrice = Convert.ToInt64(textBoxMaxPrice.Text);
                    demand.MinArea = Convert.ToDouble(textBoxMinArea.Text);
                    demand.MaxArea = Convert.ToDouble(textBoxMaxArea.Text);
                    demand.MinFloor = Convert.ToInt32(textBoxMinFloor.Text);
                    demand.MaxFloor = Convert.ToInt32(textBoxMaxFloor.Text);
                    demand.MinRooms = Convert.ToInt32(textBoxMinFloor.Text);
                    demand.MaxRooms = Convert.ToInt32(textBoxMinFloor.Text);
                    Program.wftDb.SaveChanges();
                    ShowDemandSet();
                }
            }
            else if (comboBoxType.SelectedIndex == 1)
            {
                if (listViewDemand_House.SelectedItems.Count == 1)
                {
                    DemandSet demand = listViewDemand_House.SelectedItems[0].Tag as DemandSet;
                    demand.IdAgent = Convert.ToInt32(comboBoxAgents.SelectedItem.ToString().Split('.')[0]);
                    demand.IdClient = Convert.ToInt32(comboBoxClients.SelectedItem.ToString().Split('.')[0]);
                    demand.MinPrice = Convert.ToInt64(textBoxMinPrice.Text);
                    demand.MaxPrice = Convert.ToInt64(textBoxMaxPrice.Text);
                    demand.MinArea = Convert.ToDouble(textBoxMinArea.Text);
                    demand.MaxArea = Convert.ToDouble(textBoxMaxArea.Text);
                    demand.MinFloors = Convert.ToInt32(textBoxMinFloors.Text);
                    demand.MaxFloors = Convert.ToInt32(textBoxMaxFloors.Text);
                    Program.wftDb.SaveChanges();
                    ShowDemandSet();
                }
            }
            else
            {
                if (listViewDemand_Land.SelectedItems.Count == 1)
                {
                    DemandSet demand = listViewDemand_Land.SelectedItems[0].Tag as DemandSet;
                    demand.IdAgent = Convert.ToInt32(comboBoxAgents.SelectedItem.ToString().Split('.')[0]);
                    demand.IdClient = Convert.ToInt32(comboBoxClients.SelectedItem.ToString().Split('.')[0]);
                    demand.MinPrice = Convert.ToInt64(textBoxMinPrice.Text);
                    demand.MaxPrice = Convert.ToInt64(textBoxMaxPrice.Text);
                    demand.MinArea = Convert.ToDouble(textBoxMinArea.Text);
                    demand.MaxArea = Convert.ToDouble(textBoxMaxArea.Text);
                    Program.wftDb.SaveChanges();
                    ShowDemandSet();
                }
            }
        }

        private void listViewDemand_Apartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewDemand_Apartment.SelectedItems.Count == 1)
            {
                DemandSet demand = listViewDemand_Apartment.SelectedItems[0].Tag as DemandSet;
                textBoxMaxPrice.Text = demand.MaxPrice.ToString();
                textBoxMinPrice.Text = demand.MinPrice.ToString();
                textBoxMinFloor.Text = demand.MinFloor.ToString();
                textBoxMaxFloor.Text = demand.MaxFloor.ToString();
                textBoxMinRooms.Text = demand.MinRooms.ToString();
                textBoxMaxRooms.Text = demand.MaxRooms.ToString();
                textBoxMinArea.Text = demand.MinArea.ToString();
                textBoxMaxArea.Text = demand.MaxArea.ToString();
            }
            else
            {
                textBoxMaxPrice.Text = "";
                textBoxMinPrice.Text = "";
                textBoxMinFloor.Text = "";
                textBoxMaxFloor.Text = "";
                textBoxMinRooms.Text = "";
                textBoxMaxRooms.Text = "";
                textBoxMinArea.Text = "";
                textBoxMaxArea.Text = "";
            }
        }

        private void listViewDemand_House_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewDemand_House.SelectedItems.Count == 1)
            {
                DemandSet demand = listViewDemand_House.SelectedItems[0].Tag as DemandSet;
                textBoxMaxPrice.Text = demand.MaxPrice.ToString();
                textBoxMinPrice.Text = demand.MinPrice.ToString();
                textBoxMinFloors.Text = demand.MinFloors.ToString();
                textBoxMaxFloors.Text = demand.MaxFloors.ToString();
                textBoxMinArea.Text = demand.MinArea.ToString();
                textBoxMaxArea.Text = demand.MaxArea.ToString();
            }
            else
            {
                textBoxMaxPrice.Text = "";
                textBoxMinPrice.Text = "";
                textBoxMinFloors.Text = "";
                textBoxMaxFloors.Text = "";
                textBoxMinArea.Text = "";
                textBoxMaxArea.Text = "";
            }
        }

        private void listViewDemand_Land_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewDemand_Land.SelectedItems.Count == 1)
            {
                DemandSet demand = listViewDemand_Land.SelectedItems[0].Tag as DemandSet;
                textBoxMaxPrice.Text = demand.MaxPrice.ToString();
                textBoxMinPrice.Text = demand.MinPrice.ToString();
                textBoxMinArea.Text = demand.MinArea.ToString();
                textBoxMaxArea.Text = demand.MaxArea.ToString();
            }
            else
            {
                textBoxMaxPrice.Text = "";
                textBoxMinPrice.Text = "";
                textBoxMinArea.Text = "";
                textBoxMaxArea.Text = "";
            }
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxType.SelectedIndex == 0)
                {
                    if (listViewDemand_Apartment.SelectedItems.Count == 1)
                    {
                        DemandSet demand = listViewDemand_Apartment.SelectedItems[0].Tag as DemandSet;
                        Program.wftDb.DemandSet.Remove(demand);
                        Program.wftDb.SaveChanges();
                        ShowDemandSet();
                    }
                    textBoxMaxPrice.Text = "";
                    textBoxMinPrice.Text = "";
                    textBoxMinFloor.Text = "";
                    textBoxMaxFloor.Text = "";
                    textBoxMinRooms.Text = "";
                    textBoxMaxRooms.Text = "";
                    textBoxMinArea.Text = "";
                    textBoxMaxArea.Text = "";
                }
                else if (comboBoxType.SelectedIndex == 1)
                {
                    if (listViewDemand_House.SelectedItems.Count == 1)
                    {
                        DemandSet demand = listViewDemand_House.SelectedItems[0].Tag as DemandSet;
                        Program.wftDb.DemandSet.Remove(demand);
                        Program.wftDb.SaveChanges();
                        ShowDemandSet();
                    }
                    textBoxMaxPrice.Text = "";
                    textBoxMinPrice.Text = "";
                    textBoxMinFloors.Text = "";
                    textBoxMaxFloors.Text = "";
                    textBoxMinArea.Text = "";
                    textBoxMaxArea.Text = "";
                }
                else
                {
                    if (listViewDemand_Land.SelectedItems.Count == 1)
                    {
                        DemandSet demand = listViewDemand_Land.SelectedItems[0].Tag as DemandSet;
                        Program.wftDb.DemandSet.Remove(demand);
                        Program.wftDb.SaveChanges();
                        ShowDemandSet();
                    }
                    textBoxMaxPrice.Text = "";
                    textBoxMinPrice.Text = "";
                    textBoxMinArea.Text = "";
                    textBoxMaxArea.Text = "";
                }
            }
            catch
            {
                MessageBox.Show("Невозможно удалить, эта запись используется", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
