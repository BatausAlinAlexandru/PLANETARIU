using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Microsoft.Data.SqlClient;

namespace LAB2
{
    public partial class Form1 : Form
    {

        private SqlConnection connection = new SqlConnection(GetConnectionString());
        DataSet ds = new DataSet();

        /// Parent setup
        SqlDataAdapter parentAdapter;
        BindingSource bsParent;
        private string parentTableName = ConfigurationManager.AppSettings["ParentTableName"];
        private List<string> parentColumnNames = new List<string>(ConfigurationManager.AppSettings["ParentColumnNames"].Split(','));
        private List<string> parentColumnTypes = new List<string>(ConfigurationManager.AppSettings["ParentColumnTypes"].Split(','));
        private List<string> parentParameters = new List<string>(ConfigurationManager.AppSettings["ParentInsertParameters"].Split(','));

        List<Label> parentLabelList = new List<Label>();
        List<TextBox> parentTextBoxList = new List<TextBox>();


        /// Child setup 
        SqlDataAdapter childAdapter;
        BindingSource bsChild;
        private string childTableName = ConfigurationManager.AppSettings["ChildTableName"];
        private List<string> childColumnNames = new List<string>(ConfigurationManager.AppSettings["ChildColumnNames"].Split(','));
        private List<string> childColumnTypes = new List<string>(ConfigurationManager.AppSettings["ChildColumnTypes"].Split(','));
        private List<string> childParameters = new List<string>(ConfigurationManager.AppSettings["ChildInsertParameters"].Split(','));

        List<Label> childLabelList = new List<Label>();
        List<TextBox> childTextBoxList = new List<TextBox>();

        public Form1()
        {
            InitializeComponent();
            labelParentName.Text = parentTableName;
            labelChildName.Text = childTableName;


            addParentInput();
            addChildInput();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                    connection.Open();

                    parentAdapter = new SqlDataAdapter(ConfigurationManager.AppSettings["SelectParentQuery"], connection);
                    parentAdapter.Fill(ds, parentTableName);

                    childAdapter = new SqlDataAdapter(ConfigurationManager.AppSettings["SelectChildQuery"], connection);
                    childAdapter.Fill(ds, childTableName);
                    
                    DataColumn parentColumn = ds.Tables[parentTableName].Columns[ConfigurationManager.AppSettings["ParentIdTable"]];
                    DataColumn childColumn = ds.Tables[childTableName].Columns[ConfigurationManager.AppSettings["ParentIdTable"]];

                    string dataRelation = ConfigurationManager.AppSettings["DataRelation"];
                    DataRelation relation = new DataRelation("RELATION", parentColumn, childColumn, false);
                    ds.Relations.Add(relation);

                    bsParent = new BindingSource();
                    bsParent.DataSource = ds.Tables[parentTableName];
                    dataGridViewParent.DataSource = bsParent;

                    bsChild = new BindingSource();
                    bsChild.DataSource = bsParent;
                    bsChild.DataMember = "RELATION";
                    dataGridViewChild.DataSource = bsChild;

                connection.Close();
                
            }
            catch (Exception ex){
                MessageBox.Show(ex.Message);
            }
        }

        private void Refresh()
        {
            try
            {

                connection.Open();

                parentAdapter.SelectCommand.Connection = connection;
                childAdapter.SelectCommand.Connection = connection;
                ds.Tables[ConfigurationManager.AppSettings["ParentTableName"]].Clear();
                ds.Tables[ConfigurationManager.AppSettings["ChildTableName"]].Clear();
                parentAdapter.Fill(ds, ConfigurationManager.AppSettings["ParentTableName"]);
                childAdapter.Fill(ds, ConfigurationManager.AppSettings["ChildTableName"]);
                connection.Close();


                for(int i = 0; i < Int32.Parse(ConfigurationManager.AppSettings["ParentNumberOfColumns"]); i++)
                    parentTextBoxList[i].Clear();

                for(int i = 0; i < Int32.Parse(ConfigurationManager.AppSettings["ChildNumberOfColumns"]) - 1; i++)
                    childTextBoxList[i].Clear();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                connection.Close();
            }
        }

        private static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["cn"].ConnectionString.ToString();
        }

        private void dataGridViewParent_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            if (rowIndex >= 0)
            {
                DataRowView rowView = (DataRowView)bsParent.Current;

                int number;
                bool itsOK = Int32.TryParse(ConfigurationManager.AppSettings["ParentNumberOfColumns"], out number);
               
                for (int i = 0; i < number; i++)
                {
                    string gigel = parentColumnTypes[i];
                    if (gigel == "INT")
                    {
                        int integer = (int)rowView[$"{parentColumnNames[i]}"];
                        parentTextBoxList[i].Text = integer.ToString();
                    }
                    else if (gigel == "VARCHAR")
                    {
                        string numeGalaxie = rowView[$"{parentColumnNames[i]}"].ToString();
                        parentTextBoxList[i].Text = numeGalaxie;
                    }
                }
            }
        }

        private void dataGridViewChild_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;

            if (rowIndex >= 0)
            {
                DataRowView rowView = (DataRowView)bsChild.Current;

                int number;
                int saved = -1;
                bool itsOK = Int32.TryParse(ConfigurationManager.AppSettings["ChildNumberOfColumns"], out number);
                if(verificareConf(parentColumnNames, childColumnNames) != -1)
                    saved = verificareConf(parentColumnNames, childColumnNames);
                
                for (int i = 0; i < number; i++)
                {
                    
                    string gigel = childColumnTypes[i];

                    if (saved != i)
                    {

                        if (gigel == "INT")
                        {
                            int integer = (int)rowView[$"{childColumnNames[i]}"];
                            childTextBoxList[i].Text = integer.ToString();
                        }
                        else if (gigel == "VARCHAR")
                        {
                            string numeGalaxie = rowView[$"{childColumnNames[i]}"].ToString();
                            childTextBoxList[i].Text = numeGalaxie;
                        }
                    }
                }
            }
        }

        private void addParentInput()
        {
            int number;
            bool itsOK = Int32.TryParse(ConfigurationManager.AppSettings["ParentNumberOfColumns"], out number);
            if(itsOK)
            {
                for(int i = 0; i < number ; i++)
                {

                    Panel panel = new Panel();
                    panel.Size = new Size(460, 66);

                    Label label = new Label();
                    label.Font = new Font(label.Font.FontFamily, 15);
                    label.TextAlign = ContentAlignment.TopCenter;
                    label.Dock = DockStyle.Top;
                    label.AutoSize = false;
                    label.Text = parentColumnNames[i];

                    TextBox textBox = new TextBox();
                    textBox.Font = new Font(textBox.Font.FontFamily, 20);
                    textBox.Dock = DockStyle.Bottom;


                    panel.Controls.Add(label);
                    panel.Controls.Add(textBox);

                    parentLabelList.Add(label);
                    parentTextBoxList.Add(textBox);


                    flowLayoutPanelParent.Controls.Add(panel);
                }
            } else
            {
                MessageBox.Show("Nu am putut lua numarul de coloane al PARENT");
            }
        }

        private void addChildInput()
        {
            int number;
            bool itsOK = Int32.TryParse(ConfigurationManager.AppSettings["ChildNumberOfColumns"], out number);
            if (itsOK)
            {
                int saved = -1;
                if (verificareConf(parentColumnNames, childColumnNames) != -1)
                {
                    saved = verificareConf(parentColumnNames, childColumnNames);
                }

                for (int i = 0; i < number; i++)
                {
                    if (saved != i)
                    {
                        Panel panel = new Panel();
                        panel.Size = new Size(460, 66);

                        Label label = new Label();
                        label.Font = new Font(label.Font.FontFamily, 15);
                        label.TextAlign = ContentAlignment.TopCenter;
                        label.Dock = DockStyle.Top;
                        label.AutoSize = false;
                        label.Text = childColumnNames[i];

                        TextBox textBox = new TextBox();
                        textBox.Font = new Font(textBox.Font.FontFamily, 20);
                        textBox.Dock = DockStyle.Bottom;


                        panel.Controls.Add(label);
                        panel.Controls.Add(textBox);

                        childLabelList.Add(label);
                        childTextBoxList.Add(textBox);


                        flowLayoutPanelChild.Controls.Add(panel);
                    }
                }
            }
            else
            {
                MessageBox.Show("Nu am putut lua numarul de coloane al CHILD");
            }
        }

        private int verificareConf(List<string> s1, List<string> s2)
        {
            for(int i = 0; i < s1.Count; i++)
            {
                for (int j = 0; j < s2.Count; j++){
                    if (s1[i] == s2[j])
                        return j;
                }
            }

            return -1;
        }

        private void buttonAddParent_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();

                string add = ConfigurationManager.AppSettings["ParentInsertQuery"];
                SqlCommand cmd = new SqlCommand(add, connection);


                for (int i = 1; i < Int32.Parse(ConfigurationManager.AppSettings["ParentNumberOfColumns"]); i++)
                {
                    if (parentColumnTypes[i] == "INT")
                    {
                        string integer = parentParameters[i];
                        cmd.Parameters.AddWithValue(integer, Int32.Parse(parentTextBoxList[i].Text));
                    }
                    else if (parentColumnTypes[i] == "VARCHAR")
                    {
                        string gg = parentParameters[i];
                        cmd.Parameters.AddWithValue(gg, parentTextBoxList[i].Text);
                    }
                }
                SqlDataAdapter daChild = new SqlDataAdapter(cmd);
                DataSet dataSet = new DataSet();
                daChild.Fill(dataSet);
                connection.Close();
                MessageBox.Show("Inserted!");
                Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                connection.Close();
            }
        }

        private void buttonUpdateParent_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();

                string add = ConfigurationManager.AppSettings["ParentUpdateQuery"];
                SqlCommand cmd = new SqlCommand(add, connection);


                for (int i = 1; i < Int32.Parse(ConfigurationManager.AppSettings["ParentNumberOfColumns"]); i++)
                {
                    if (parentColumnTypes[i] == "INT")
                    {
                        string integer = parentParameters[i];
                        cmd.Parameters.AddWithValue(integer, Int32.Parse(parentTextBoxList[i].Text));
                    }
                    else if (parentColumnTypes[i] == "VARCHAR")
                    {
                        string gg = parentParameters[i];
                        cmd.Parameters.AddWithValue(gg, parentTextBoxList[i].Text);
                    }
                }
                cmd.Parameters.AddWithValue("@id", Int32.Parse(parentTextBoxList[0].Text));

                SqlDataAdapter daChild = new SqlDataAdapter(cmd);
                DataSet dataSet = new DataSet();
                daChild.Fill(dataSet);
                connection.Close();
                MessageBox.Show("Updated!");
                Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                connection.Close();
            }
        }

        private void buttonDeleteParent_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();

                string add = ConfigurationManager.AppSettings["ParentDeleteQuery"];
                SqlCommand cmd = new SqlCommand(add, connection);

                string id = ConfigurationManager.AppSettings["ParentIdTable"];

               
                cmd.Parameters.AddWithValue("@id", Int32.Parse(parentTextBoxList[0].Text));

                SqlDataAdapter daChild = new SqlDataAdapter(cmd);
                DataSet dataSet = new DataSet();
                daChild.Fill(dataSet);
                connection.Close();
                MessageBox.Show("DELETED!");
                Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                connection.Close();
            }
        }

        private void buttonAddChild_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();

                string add = ConfigurationManager.AppSettings["ChildInsertQuery"];
                SqlCommand cmd = new SqlCommand(add, connection);


                for (int i = 1; i < Int32.Parse(ConfigurationManager.AppSettings["ChildNumberOfColumns"]) - 1; i++)
                {
                    if (childColumnTypes[i] == "INT")
                    {
                        string integer = childParameters[i];
                        cmd.Parameters.AddWithValue(integer, Int32.Parse(childTextBoxList[i].Text));
                    }
                    else if (childColumnTypes[i] == "VARCHAR")
                    {
                        string gg = childParameters[i];
                        cmd.Parameters.AddWithValue(gg, childTextBoxList[i].Text);
                    }
                }
                cmd.Parameters.AddWithValue("@idParent", Int32.Parse(parentTextBoxList[0].Text));
                SqlDataAdapter daChild = new SqlDataAdapter(cmd);
                DataSet dataSet = new DataSet();
                daChild.Fill(dataSet);
                connection.Close();
                MessageBox.Show("Inserted!");
                Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                connection.Close();
            }
        }

        private void buttonUpdateChild_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();

                string add = ConfigurationManager.AppSettings["ChildUpdateQuery"];
                SqlCommand cmd = new SqlCommand(add, connection);

                for (int i = 0; i < Int32.Parse(ConfigurationManager.AppSettings["ChildNumberOfColumns"]) - 1; i++)
                {
                    if (childColumnTypes[i] == "INT")
                    {
                        string integer = childParameters[i];
                        cmd.Parameters.AddWithValue(integer, Int32.Parse(childTextBoxList[i].Text));
                    }
                    else if (childColumnTypes[i] == "VARCHAR")
                    {
                        string gg = childParameters[i];
                        cmd.Parameters.AddWithValue(gg, childTextBoxList[i].Text);
                    }
                }
                cmd.Parameters.AddWithValue("@idParent", Int32.Parse(parentTextBoxList[0].Text));
                SqlDataAdapter daChild = new SqlDataAdapter(cmd);
                DataSet dataSet = new DataSet();
                daChild.Fill(dataSet);
                connection.Close();
                MessageBox.Show("UPDATED!");
                Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                connection.Close();
            }
        }

        private void buttonDeleteChild_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();

                string add = ConfigurationManager.AppSettings["ChildDeleteQuery"];
                SqlCommand cmd = new SqlCommand(add, connection);

                string id = ConfigurationManager.AppSettings["ChildIdTable"];


                cmd.Parameters.AddWithValue("@id", Int32.Parse(childTextBoxList[0].Text));

                SqlDataAdapter daChild = new SqlDataAdapter(cmd);
                DataSet dataSet = new DataSet();
                daChild.Fill(dataSet);
                connection.Close();
                MessageBox.Show("DELETED!");
                Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                connection.Close();
            }
        }
    }
}
