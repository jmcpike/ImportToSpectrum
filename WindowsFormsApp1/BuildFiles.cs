using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class BuildFiles : Form
    {
        int cnt = 0;
        string from = string.Empty;
        public BuildFiles(string _from )
        {
            from = _from;
            InitializeComponent();
        }

        private void BuildFiles_FormClosing(object sender, FormClosingEventArgs e)
        {
            Screen myScreen = Screen.FromControl(this);

            Import im = new Import();
            im.StartPosition = FormStartPosition.Manual;
            im.Location = this.Location;
            im.Show();
        }

        private void btnCVS_Click(object sender, EventArgs e)
        {
            try
            {
               
                exportFile();
            cnt++;
            buildImports();
            }
            catch (Exception ex)
            {
                MessageBox.Show("btnCVS_Click " + ex.Message);
            }
         
        }
        private void buildProjectPhases()
        {

            
            string cn = ConfigurationManager.ConnectionStrings["Import"].ConnectionString;
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(cn))

            {
                try
                {

                    con.Open();
                    SqlCommand cmd = new SqlCommand(@"spGetJobNumbers", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@CreatedDate", from);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    con.Close();
                    if (dt.Rows.Count > 0)
                    {
                        insertPhases(dt, from);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Build Phases " + ex.Message);
                    con.Close();
                }
            }
        }
        private void insertPhases(DataTable dt, string from)
        {
            string Company_Code = string.Empty;
            string Job_Number = string.Empty;
            string Phase_Code = string.Empty;
            string Description = string.Empty;
            string Cost_Type = string.Empty;
            string Original_Est_Quantity = string.Empty;
            string Unit_of_Measure = string.Empty;
            string Original_Est_Cost = string.Empty;
            string Bid_Item_Number = string.Empty;
            string Alt_Phase_Code = string.Empty;
            string Work_Comp_Code = "5215";
            string Price_Method_Code = "F";
            string Phase_Cost_Center = string.Empty;
            string Current_Est_Hours = string.Empty;
            string Current_Est_Quantity = string.Empty;
            string Current_Est_Cost = string.Empty;
            string Status_Code = "A";
            int write = 0;
            string cn = ConfigurationManager.ConnectionStrings["Import"].ConnectionString;
            foreach (DataRow dtR in dt.Rows)
            {
                for (int i = 1; i < 13; i++)
                {
                    switch (i)
                    {
                        case 1:
                            Company_Code = "HTC";
                            Job_Number = dtR["Job_Number"].ToString();
                            Phase_Code = "1001";
                            Description = "Regular - Helitech EE's";
                            Cost_Type = "L";
                            Unit_of_Measure = "ea";
                            break;
                        case 2:
                            Company_Code = "HTC";
                            Job_Number = dtR["Job_Number"].ToString();
                            Phase_Code = "1002";
                            Description = "Overtime - Helitech EE's";
                            Cost_Type = "L";
                            Unit_of_Measure = "ea";
                            break;
                        case 3:
                            Company_Code = "HTC";
                            Job_Number = dtR["Job_Number"].ToString();
                            Phase_Code = "1003";
                            Description = "Travel Time";
                            Cost_Type = "L";
                            Unit_of_Measure = "ea";
                            break;
                        case 4:
                            Company_Code = "HTC";
                            Job_Number = dtR["Job_Number"].ToString();
                            Phase_Code = "1004";
                            Description = "Sales Commission";
                            Cost_Type = "L";
                            Unit_of_Measure = "ls";
                            break;
                        case 5:
                            Company_Code = "HTC";
                            Job_Number = dtR["Job_Number"].ToString();
                            Phase_Code = "1005";
                            Description = "Extra Help Labor";
                            Cost_Type = "OL";
                            Unit_of_Measure = "ls";
                            break;
                        case 6:
                            Company_Code = "HTC";
                            Job_Number = dtR["Job_Number"].ToString();
                            Phase_Code = "2006";
                            Description = "Concrete";
                            Cost_Type = "M";
                            Unit_of_Measure = "ls";
                            break;
                        case 7:
                            Company_Code = "HTC";
                            Job_Number = dtR["Job_Number"].ToString();
                            Phase_Code = "2011";
                            Description = "Misc Site Expenses";
                            Cost_Type = "O";
                            Unit_of_Measure = "ls";
                            break;
                        case 8:
                            Company_Code = "HTC";
                            Job_Number = dtR["Job_Number"].ToString();
                            Phase_Code = "3001";
                            Description = "Customer Refunds";
                            Cost_Type = "O";
                            Unit_of_Measure = "ls";
                            break;
                        case 9:
                            Company_Code = "HTC";
                            Job_Number = dtR["Job_Number"].ToString();
                            Phase_Code = "3003";
                            Description = "License & Permits";
                            Cost_Type = "O";
                            Unit_of_Measure = "ls";
                            break;
                        case 10:
                            Company_Code = "HTC";
                            Job_Number = dtR["Job_Number"].ToString();
                            Phase_Code = "3002";
                            Description = "Engineering Fees";
                            Cost_Type = "O";
                            Unit_of_Measure = "ls";
                            break;
                        case 11:
                            Company_Code = "HTC";
                            Job_Number = dtR["Job_Number"].ToString();
                            Phase_Code = "4001";
                            Description = "Equipment Rental";
                            Cost_Type = "E";
                            Unit_of_Measure = "ls";
                            break;
                        case 12:
                            Company_Code = "HTC";
                            Job_Number = dtR["Job_Number"].ToString();
                            Phase_Code = "5001";
                            Description = "Subcontractor Fees";
                            Cost_Type = "S";
                            Unit_of_Measure = "ls";
                            break;

                    }


                    using (SqlConnection con = new SqlConnection(cn))

                    {
                        try
                        {

                            con.Open();
                            SqlCommand cmd = new SqlCommand(@"spInsertTempPhases", con);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Clear();
                            cmd.Parameters.AddWithValue("@Company_Code", Company_Code);
                            cmd.Parameters.AddWithValue("@Job_Number", Job_Number);
                            cmd.Parameters.AddWithValue("@Phase_Code", Phase_Code);
                            cmd.Parameters.AddWithValue("@Description", Description);
                            cmd.Parameters.AddWithValue("@Cost_Type", Cost_Type);
                            cmd.Parameters.AddWithValue("@Original_Est_Quantity", Original_Est_Quantity);
                            cmd.Parameters.AddWithValue("@Unit_of_Measure", Unit_of_Measure);
                            cmd.Parameters.AddWithValue("@Original_Est_Cost", Original_Est_Cost);
                            cmd.Parameters.AddWithValue("@Bid_Item_Number", Bid_Item_Number);
                            cmd.Parameters.AddWithValue("@Alt_Phase_Code", Alt_Phase_Code);
                            cmd.Parameters.AddWithValue("@Work_Comp_Code", Work_Comp_Code);
                            cmd.Parameters.AddWithValue("@Price_Method_Code", Price_Method_Code);
                            cmd.Parameters.AddWithValue("@Phase_Cost_Center", Phase_Cost_Center);
                            cmd.Parameters.AddWithValue("@Current_Est_Hours", Current_Est_Hours);
                            cmd.Parameters.AddWithValue("@Current_Est_Quantity", Current_Est_Quantity);
                            cmd.Parameters.AddWithValue("@Current_Est_Cost", Current_Est_Cost);
                            cmd.Parameters.AddWithValue("@Status_Code", Status_Code);
                            cmd.ExecuteNonQuery();
                            con.Close();

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("insert Phases " + ex.Message);
                            con.Close();
                        }
                    }
                }
            }
        }
        private async void BuildFiles_LoadAsync(object sender, EventArgs e)
        {
            cnt++;
          
           await buildImports();
        }
        private async Task buildImports()
        {
            string sql = string.Empty;
            string cn = ConfigurationManager.ConnectionStrings["Import"].ConnectionString;
            switch (cnt)
            {
                case 1:
                    sql = "spImportCustomers";
                    buildProjectPhases();
                    break;
                case 2:
                    sql = "spImportProjects";
                   
                    break;
                case 3:
                    sql = "spImportPhases";
                    break;
            }
            using (SqlConnection con = new SqlConnection(cn))

            {
                try
                {
                    dgvResults.DataSource = null;
                    DataTable dt = new DataTable();
                    con.Open();
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    dgvResults.DataSource = dt;
                    con.Close();
                    ArchiveTables(cnt);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(sql + " " + ex.Message);
                    con.Close();
                }

            }

        }
        private void ArchiveTables(int i)
        {
            string sql = string.Empty;
      
                switch (i)
                {
                case 1:
                        sql = "spAchiveCustomer";
                        break;
                    case 2:
                        sql = "spAchiveProjects";
                        break;
                case 3:
                    sql = "spAchivePhases";
                    break;
            }

                string cn = ConfigurationManager.ConnectionStrings["Import"].ConnectionString;
                SqlCommand cmd;
                string procedure = string.Empty;
                using (SqlConnection con = new SqlConnection(cn))
                {
                    try
                    {
                        con.Open();
                        cmd = new SqlCommand(sql, con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    catch (Exception ex)
                    {
                        con.Close();
                    }
                }

           
        }
        private void exportFile()
        {
            if (!Directory.Exists(@"C:\TEMP\"))
            {
                Directory.CreateDirectory(@"C:\temp\");
            }
            if (!Directory.Exists(@"C:\temp\Exported CSV Files\"))
            {
                Directory.CreateDirectory(@"C:\temp\Exported CSV Files\");
            }

            string csvPath = @"C:\temp\Exported CSV Files\";
            string csvFileName = string.Empty;
            switch (cnt)
            {
                case 1:
                    csvFileName = csvPath + "customers.csv";
                    break;
                case 2:
                    csvFileName = csvPath + "jobs.csv";
                    break;
                case 3:
                    csvFileName = csvPath + "phases.csv";
                    break;
            }

            if (File.Exists(csvFileName))
            {
                try
                {
                    File.Delete(csvFileName);
                }
                catch (Exception ex)
                {

                    MessageBox.Show("It wasn't possible to write the data to the disk." + ex.Message);
                }
            }
    
               
                dgvResults .SelectAll();
            if (dgvResults.AreAllCellsSelected(true) == true)
            {
                dgvResults.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            }
            try
            {
                Clipboard.SetDataObject(dgvResults.GetClipboardContent());
            }
            catch (Exception ex)
            {

            }
            try
            {
                dgvResults.ClearSelection();
               
                string resultjobs = (string)Clipboard.GetData(DataFormats.CommaSeparatedValue);

              
                var sw = new StreamWriter(csvFileName);
                sw.WriteLine(resultjobs);
                sw.Close();
                Process.Start(csvFileName);
            }
            catch (Exception ex)
            {

            }
    

        }   
                        
               
       
    
        
    }
}
