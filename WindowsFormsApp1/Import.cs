using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Import : Form
    {
        public Import()
        {
            InitializeComponent();
        }


        private void Import_FormClosing(object sender, FormClosingEventArgs e)
        {
            Screen myScreen = Screen.FromControl(this);

            Main_Menu mm = new Main_Menu();
            mm.StartPosition = FormStartPosition.Manual;
            mm.Location = this.Location;
            mm.Show();

        }

        private void Import_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
        }

        private void dtpFrom_ValueChanged(object sender, EventArgs e)
        {
            string from = dtpFrom.Value.ToShortDateString();

            getCustomers(from);
            getProjects(from);
           // buildProjectPhases();
        }
        private void getCustomers(string fromDate)
        {
            DataTable dt = new DataTable();
            string cn = ConfigurationManager.ConnectionStrings["Import"].ConnectionString;


            using (SqlConnection con = new SqlConnection(cn))

            {
                try
                {

                    con.Open();
                    SqlCommand cmd = new SqlCommand("spNewCustomers", con);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@approvalDate", fromDate);
                    cmd.Parameters.AddWithValue("@company_code", "HTC");
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    dgvJobs.DataSource = dt;
                    con.Close();
                    lblCustomerCount.Text = dt.Rows.Count.ToString();
                    lblCustomerCount.Refresh();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("getCustomers " + ex.Message);
                    con.Close();
                }

            }
        }

        private void getProjects(string fromDate)
        {
            DataTable dt = new DataTable();
            string cn = ConfigurationManager.ConnectionStrings["Import"].ConnectionString;


            using (SqlConnection con = new SqlConnection(cn))

            {
                try
                {

                    con.Open();
                    SqlCommand cmd = new SqlCommand("spNewProjects", con);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@approvalDate", fromDate);
                    cmd.Parameters.AddWithValue("@company_code", "HTC");
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    dgvProjects.DataSource = dt;
                    con.Close();
                    lblProjectsCount.Text = dt.Rows.Count.ToString();
                    lblProjectsCount.Refresh();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("getProjects " + ex.Message);
                    con.Close();
                }

            }
        }

        private void Import_Load(object sender, EventArgs e)
        {

        }


        private void btnCreateImport_Click(object sender, EventArgs e)
        {
            ArchiveTables();
            buildCustomers();
            buildJobs();
            Screen myScreen = Screen.FromControl(this);
            this.Hide();
            BuildFiles bf = new BuildFiles(dtpFrom.Value.ToShortDateString());
            bf.StartPosition = FormStartPosition.Manual;
            bf.Location = this.Location;
            bf.Show();

        }
        private void ArchiveTables()
        {
            string sql = string.Empty;
            for (int i = 0; i < 1; i++)
            {
                switch (i)
                {
                    case 0:
                        sql = "spAchiveCustomer";
                    break;
                    case 1:
                        sql = "spAchiveProjects";
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
                    //   cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    catch (Exception ex)
                    {
                        con.Close();
                    }
                }

            }
        }

        private void buildCustomers()
        {
            string Company_Code = string.Empty;
            string customer_Code = string.Empty;
            string Name = string.Empty;
            string parts = string.Empty;
            string Alpha_Sort = string.Empty;
            string Type = string.Empty;
            string Address_1 = string.Empty;
            string Address_2 = string.Empty;
            string City = string.Empty;
            string State = string.Empty;
            string Zip_Code = string.Empty;
            string Phone = string.Empty;
            string Fax_Phone = string.Empty;
            string Contact_1 = string.Empty;
            string Contact_2 = string.Empty;
            string Contact_3 = string.Empty;
            string Salesperson = string.Empty;
            int Terms_Code = 0;
            decimal Standard_Retention_Percent = 0;
            string Taxable_Flag = string.Empty;
            string Sales_Tax_Code = string.Empty;
            string Resale_Number = string.Empty;
            string Resale_Exp_Date = string.Empty;
            string Statement_Flag = string.Empty;
            string Finance_Charge_Tran_Code = string.Empty;
            string Finance_Charge = string.Empty;
            string Price_Level_Material = string.Empty;
            string Price_Level_Labor = string.Empty;
            string Credit_Limit = string.Empty;
            string Date_Created = string.Empty;
            string Customer_Email = string.Empty;
            string Markup_Code = string.Empty;
            string UDF1 = string.Empty;
            string UDF2 = string.Empty;
            string UDF3 = string.Empty;
            string UDF4 = string.Empty;
            string UDF5 = string.Empty;
            string UDF6 = string.Empty;
            string UDF7 = string.Empty;
            string UDF8 = string.Empty;
            string UDF9 = string.Empty;
            string UDF10 = string.Empty;
            string UDF11 = string.Empty;
            string UDF12 = string.Empty;
            string UDF13 = string.Empty;
            string UDF14 = string.Empty;
            string UDF15 = string.Empty;
            string UDF16 = string.Empty;
            string UDF17 = string.Empty;
            string UDF18 = string.Empty;
            string UDF19 = string.Empty;
            string UDF20 = string.Empty;
            string _phone = string.Empty;
            string alpha1 = string.Empty;
            string alpha2 = string.Empty;
            #region "Get Datagrid Data" 
            if (dgvJobs.Rows.Count > 0)
            {
                var _customer_Code = GetCustomerCode();
                #region "Insert Customers"
                if (_customer_Code != "none")
                {
                    try
                    {


                        foreach (DataGridViewRow r in dgvJobs.Rows)
                        {
                            string cn = ConfigurationManager.ConnectionStrings["Import"].ConnectionString;
                            using (SqlConnection con = new SqlConnection(cn))
                            {
                                try
                                {
                                    if (r.Cells["CustomerId"].Value != null)
                                    {

                                        if (r.Cells["LastName"].Value.ToString().Length < 1)
                                        {
                                            Contact_1 = "";
                                        }
                                        else
                                        {
                                            try
                                            {
                                                Contact_1 = (r.Cells["FirstName"].Value.ToString()).Trim() + " " + (r.Cells["LastName"].Value.ToString()).Trim();
                                                Name = (r.Cells["FirstName"].Value.ToString()).Trim() + " " + (r.Cells["LastName"].Value.ToString()).Trim();
                                            }
                                            catch
                                            {
                                                Contact_1 = "";
                                            }
                                        }

                                        if (Contact_1.Length > 20)
                                        {
                                            Contact_1 = Contact_1.Substring(0, 20);
                                        }
                                        try
                                        {
                                            if (r.Cells["CompanyName"].Value.ToString().Length < 1)
                                            {
                                                alpha1 = (r.Cells["FirstName"].Value.ToString()).Trim().Substring(0, 4);
                                                alpha2 = (r.Cells["LastName"].Value.ToString()).Trim().Substring(0, 3);

                                                Alpha_Sort = alpha2 + alpha1;
                                            }
                                            else
                                            {
                                                Alpha_Sort = (r.Cells["CompanyName"].Value.ToString()).Trim().Substring(0, 7);
                                            }
                                        }
                                        catch
                                        {

                                        }
                                        Company_Code = "HTC";
                                        Type = "RCD";
                                        try
                                        {
                                            Address_1 = (r.Cells["MailingAddress"].Value.ToString()).Trim();
                                            if (Address_1.Length > 30)
                                            {
                                                Address_1 = Address_1.Substring(0, 30);
                                            }
                                        }
                                        catch
                                        {

                                        }
                                        try
                                        {
                                            if ((r.Cells["MailingAddress2"].Value.ToString()).Trim().Length > 1)
                                            {
                                                Address_2 = (r.Cells["MailingAddress2"].Value.ToString()).Trim().Substring(0, 30);
                                            }
                                            else
                                            {
                                                Address_2 = string.Empty;
                                            }
                                        }
                                        catch
                                        {

                                        }
                                        try
                                        {
                                            City = (r.Cells["MailingCity"].Value.ToString()).Trim();
                                        }
                                        catch
                                        {

                                        }
                                        try
                                        {
                                            State = (r.Cells["MailingState"].Value.ToString()).Trim();
                                        }
                                        catch
                                        {

                                        }

                                        try
                                        {
                                            Zip_Code = (r.Cells["MailingZip"].Value.ToString()).Trim();
                                        }
                                        catch
                                        {

                                        }
                                        try
                                        {
                                            Phone = (r.Cells["Phone"].Value.ToString()).Trim();
                                        }
                                        catch
                                        {

                                        }

                                        Terms_Code = 1;
                                        Taxable_Flag = "N";
                                        Sales_Tax_Code = "NT";
                                        Date_Created = DateTime.Now.ToShortDateString();

                                        try
                                        {
                                            Customer_Email = (r.Cells["Email"].Value.ToString()).Trim();
                                        }
                                        catch
                                        {

                                        }
                                        #endregion

                                        customer_Code = _customer_Code.Trim().PadLeft(7, '0');
                                        customer_Code = "RCD" + customer_Code;
                                        try
                                        {


                                            con.Open();
                                            SqlCommand cmd = new SqlCommand(@"spInsertTempCustomer", con);

                                            cmd.CommandType = CommandType.StoredProcedure;
                                            cmd.Parameters.Clear();
                                            cmd.Parameters.AddWithValue("@Company_Code", Company_Code);
                                            cmd.Parameters.AddWithValue("@Customer_Code", customer_Code);
                                            cmd.Parameters.AddWithValue("@Name", Name);
                                            cmd.Parameters.AddWithValue("@Type", Type);
                                            cmd.Parameters.AddWithValue("@Alpha_Sort", Alpha_Sort);
                                            cmd.Parameters.AddWithValue("@Address_1", Address_1);
                                            cmd.Parameters.AddWithValue("@Address_2", Address_2);
                                            cmd.Parameters.AddWithValue("@City", City);
                                            cmd.Parameters.AddWithValue("@State", State);
                                            cmd.Parameters.AddWithValue("@Zip_Code", Zip_Code);
                                            cmd.Parameters.AddWithValue("@Phone", Phone);
                                            cmd.Parameters.AddWithValue("@Terms_Code", Terms_Code);
                                            cmd.Parameters.AddWithValue("@Standard_Retention_Percent", Standard_Retention_Percent);
                                            cmd.Parameters.AddWithValue("@Taxable_Flag", Taxable_Flag);
                                            cmd.Parameters.AddWithValue("@Sales_Tax_Code", Sales_Tax_Code);
                                            cmd.Parameters.AddWithValue("@Date_Created", Date_Created);
                                            cmd.Parameters.AddWithValue("@Customer_Email", Customer_Email);
                                            cmd.Parameters.AddWithValue("@Contact_1", Contact_1);
                                            cmd.Parameters.AddWithValue("@Customerid", int.Parse(r.Cells["CustomerId"].Value.ToString()));
                                            cmd.Parameters.AddWithValue("@Fax_Phone", Fax_Phone);
                                            cmd.Parameters.AddWithValue("@Contact_2", Contact_2);
                                            cmd.Parameters.AddWithValue("@Contact_3", Contact_3);
                                            cmd.Parameters.AddWithValue("@Salesperson", Salesperson);
                                            cmd.Parameters.AddWithValue("@Resale_Number", Resale_Number);
                                            cmd.Parameters.AddWithValue("@Resale_Exp_Date", Resale_Exp_Date);
                                            cmd.Parameters.AddWithValue("@Statement_Flag", Statement_Flag);
                                            cmd.Parameters.AddWithValue("@Finance_Charge_Tran_Code", Finance_Charge_Tran_Code);
                                            cmd.Parameters.AddWithValue("@Finance_Charge", Finance_Charge);
                                            cmd.Parameters.AddWithValue("@Price_Level_Material", Price_Level_Material);
                                            cmd.Parameters.AddWithValue("@Price_Level_Labor", Price_Level_Labor);
                                            cmd.Parameters.AddWithValue("@Credit_Limit", Credit_Limit);
                                            cmd.Parameters.AddWithValue("@Markup_Code", Markup_Code);
                                            cmd.Parameters.AddWithValue("@UDF1", UDF11);
                                            cmd.Parameters.AddWithValue("@UDF2", UDF2);
                                            cmd.Parameters.AddWithValue("@UDF3", UDF3);
                                            cmd.Parameters.AddWithValue("@UDF4", UDF4);
                                            cmd.Parameters.AddWithValue("@UDF5", UDF5);
                                            cmd.Parameters.AddWithValue("@UDF6", UDF6);
                                            cmd.Parameters.AddWithValue("@UDF7", UDF7);
                                            cmd.Parameters.AddWithValue("@UDF8", UDF8);
                                            cmd.Parameters.AddWithValue("@UDF9", UDF9);
                                            cmd.Parameters.AddWithValue("@UDF10", UDF10);
                                            cmd.Parameters.AddWithValue("@UDF11", UDF11);
                                            cmd.Parameters.AddWithValue("@UDF12", UDF12);
                                            cmd.Parameters.AddWithValue("@UDF13", UDF13);
                                            cmd.Parameters.AddWithValue("@UDF14", UDF14);
                                            cmd.Parameters.AddWithValue("@UDF15", UDF15);
                                            cmd.Parameters.AddWithValue("@UDF16", UDF16);
                                            cmd.Parameters.AddWithValue("@UDF17", UDF17);
                                            cmd.Parameters.AddWithValue("@UDF18", UDF18);
                                            cmd.Parameters.AddWithValue("@UDF19", UDF19);
                                            cmd.Parameters.AddWithValue("@UDF20", UDF20);
                                            int custId = int.Parse(r.Cells["CustomerId"].Value.ToString());
                                            cmd.ExecuteNonQuery();
                                            updateCustomerXRef(customer_Code, custId);
                                            updateProductTypeTable(100, (int.Parse(_customer_Code)));
                                            _customer_Code = (int.Parse(_customer_Code) + 1).ToString();


                                        }
                                        catch (Exception ex)
                                        {
                                            MessageBox.Show("Insert Failed " + ex.Message);
                                        }
                                    }
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("error in DataReader " + ex.Message);
                                    con.Close();
                                }

                            }
                        }

                    }
                    catch
                    {
                    }
                }

            }
            #endregion
        }
        private void updateProductTypeTable(int typeId, int cnt)
        {
            string cn = ConfigurationManager.ConnectionStrings["Import"].ConnectionString;
            SqlCommand cmd;
            string procedure = string.Empty;
            using (SqlConnection con = new SqlConnection(cn))
            {
                try
                {
                    con.Open();
                    cmd = new SqlCommand(@"spUpdateSpectrumProductType", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@typeId", typeId);
                    cmd.Parameters.AddWithValue("@count", cnt);
                   // cmd.ExecuteNonQuery();
                    con.Close();
                }
                catch (Exception ex)
                {
                    con.Close();
                }
            }

        }
        private void updateCustomerXRef(string customer_code, int custId)
        {

            string cn = ConfigurationManager.ConnectionStrings["Import"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cn))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(@"spUpdateCustomerXRef", con);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@customer_code", customer_code);
                    cmd.Parameters.AddWithValue("@custId", custId);
                    cmd.Parameters.AddWithValue("@createdDate", dtpFrom.Value.ToShortDateString());
                   // cmd.ExecuteNonQuery();
                    con.Close();
                }
                catch (Exception ex)
                {
                    con.Close();
                }
            }
        }

        public async void buildJobs()
        {
            #region "define Vars"
            string from = dtpFrom.Value.ToShortDateString();
            string Company_Code = string.Empty;
            string Job_Description = string.Empty;
            string JobNumber = string.Empty;
            string Division = string.Empty;
            string Address_1 = string.Empty;
            string City = string.Empty;
            string State = string.Empty;
            string Zip_Code = string.Empty;
            string Estimator = string.Empty;
            string Job_Type = string.Empty;
            string Taxable_Flag = string.Empty;
            string Work_Comp_Code = string.Empty;
            string Price_Method_Code = string.Empty;
            string Work_State_Tax_Code = string.Empty;
            string Work_County_Tax_Code = string.Empty;
            string Work_Local_Tax_Code = string.Empty;
            string Original_Contract = string.Empty;
            string Create_Date = string.Empty;
            string Cost_Center = string.Empty;
            string Standard_Phase_Category = string.Empty;
            string Status_Code = string.Empty;
            string COTG_InvoiceNumber = string.Empty;
            string customer_code = string.Empty;
            string JobCode = string.Empty;
            string Address_2 = string.Empty;
            string Phone = "";
            string Fax_Phone = string.Empty;
            string Job_Site_Phone = string.Empty;
            string Superintendent = string.Empty;
            string Project_Manager = string.Empty;
            string Contract_Number = string.Empty;
            string Tax_Class_Code = string.Empty;
            string Total_Units = string.Empty;
            string Unit_of_Measure = string.Empty;
            string Certified_Flag = string.Empty;
            string Wage_Rate_Level = string.Empty;
            string Est_Start_Date = string.Empty;
            string Est_Complete_Date = string.Empty;
            string Start_Date = string.Empty;
            string Complete_Date = string.Empty;
            string WO_Site = string.Empty;
            string Latitude = string.Empty;
            string Longitude = string.Empty;
            string Track_Davis_Bacon = string.Empty;
            string Track_Prevailing_Wage = string.Empty;
            string UDF1 = string.Empty;
            string UDF2 = string.Empty;
            string UDF3 = string.Empty; 
            string UDF4 = string.Empty;
            string UDF5 = string.Empty;
            string UDF6 = string.Empty;
            string UDF7 = string.Empty;
            string UDF8 = string.Empty;
            string UDF9 = string.Empty;
            string UDF10 = string.Empty;
            string UDF11 = string.Empty;
            string UDF12 = string.Empty;
            string UDF13 = string.Empty;
            string UDF14 = string.Empty;
            string UDF15 = string.Empty;
            string UDF16 = string.Empty;
            string UDF17 = string.Empty;
            string UDF18 = string.Empty;
            string UDF19 = string.Empty;
            string UDF20 = string.Empty;
            string Master_Job = string.Empty;
            string Bill_From_Master = string.Empty;
            string Phase_Display_Code = string.Empty;
            string Major_Group_Start = string.Empty;
            string Major_Group_End = string.Empty;
            string Minor_Group_Start = string.Empty;
            string Minor_Group_End = string.Empty;
            int bidamount = 0;
            string[] results  ;
            string[] taxCodes;
            string _office;
            #endregion
            if (dgvProjects.Rows.Count > 0)
            {

                #region "Insert Job"


                try
                {
                  
                    string _projectTypeId = string.Empty;
                    string _shortName = string.Empty;
                    string _count = string.Empty;
                    string _costCode = string.Empty;
                    string _jobNumber = string.Empty;
                    string cnt = string.Empty;
                    int charLen = 0;
                   // string _
                    foreach (DataGridViewRow r in dgvProjects.Rows)
                    {
                        try
                        {
                            _projectTypeId = r.Cells["ProjectTypeId"].Value.ToString();
                            results =   GetJobCode(_projectTypeId); // Method to get jobNumber and costCode
                            _jobNumber = results[0];
                            _costCode = results[1];
                        }
                        catch (Exception e)
                        {
                           // MessageBox.Show("Method to get jobNumber and costCode " + e.Message);
                        }

                        _shortName = r.Cells["ProjectShortName"].Value.ToString().Trim();
                        charLen = _shortName.Length;
                        _jobNumber = _jobNumber.Trim();
                        JobNumber = _jobNumber.PadLeft(10-charLen, '0');
                        JobNumber = _shortName + JobNumber;
                        Company_Code = r.Cells["Company_Code"].Value.ToString().Trim();
                        Job_Description = r.Cells["ProjectShortName"].Value.ToString().Trim();
                        Division = "RCD";
                        Address_1= r.Cells["JobAddress1"].Value.ToString().Trim();
                        Address_2 = r.Cells["JobAddress2"].Value.ToString().Trim();
                        City= r.Cells["JobCity"].Value.ToString().Trim();
                        State= r.Cells["JobState"].Value.ToString().Trim();
                        Zip_Code = r.Cells["jobZip"].Value.ToString().Trim();
                        Estimator= r.Cells["EstSpectrumId"].Value.ToString().Trim();
                        Superintendent = r.Cells["SoldBySpectrumId"].Value.ToString().Trim();
                        customer_code= GetCustomer_Code(r.Cells["CustomerId"].Value.ToString()); // Method to get customer_code
                        Contract_Number= r.Cells["ProjectId"].Value.ToString().Trim();
                        Job_Type = r.Cells["ProjectShortName"].Value.ToString().Trim();
                        Taxable_Flag = "N";
                        Work_Comp_Code = "5215";
                        Price_Method_Code = "F";
                        Original_Contract = r.Cells["ProjectTotal"].Value.ToString().Trim();
                        Create_Date = from;
                        Standard_Phase_Category = "10";
                        Status_Code = "A";
                        //Taxes
                        taxCodes = GetTaxCode(r.Cells["jobZip"].Value.ToString()); // Method to get local and county tax codes
                        Work_State_Tax_Code = r.Cells["jobState"].Value.ToString().Trim();
                        Work_County_Tax_Code = taxCodes[0];
                        Work_Local_Tax_Code = taxCodes[1];

                        _office = GetOffice(r.Cells["jobZip"].Value.ToString()); // Method to get office codes
                        Cost_Center = _office + _costCode;
                      
                  
                    string cn = ConfigurationManager.ConnectionStrings["Import"].ConnectionString;
                    using (SqlConnection con = new SqlConnection(cn))

                    {
                        try
                        {

                            con.Open();
                            SqlCommand cmd = new SqlCommand(@"spInsertTempProjects", con);

                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Clear();
                            cmd.Parameters.AddWithValue("@Company_Code", Company_Code);
                            cmd.Parameters.AddWithValue("@Job_Number", JobNumber);
                            cmd.Parameters.AddWithValue("@Job_Description", Job_Description);
                            cmd.Parameters.AddWithValue("@Division", Division);
                            cmd.Parameters.AddWithValue("@Address_1", Address_1);
                            cmd.Parameters.AddWithValue("@Address_2", Address_2);
                            cmd.Parameters.AddWithValue("@City", City);
                            cmd.Parameters.AddWithValue("@State", State);
                            cmd.Parameters.AddWithValue("@Zip_Code", Zip_Code);
                            cmd.Parameters.AddWithValue("@Phone", Phone);
                            cmd.Parameters.AddWithValue("@Fax_Phone", Fax_Phone);
                            cmd.Parameters.AddWithValue("@Job_Site_Phone", Job_Site_Phone);
                            cmd.Parameters.AddWithValue("@Superintendent", Superintendent);
                            cmd.Parameters.AddWithValue("@Estimator", Estimator);
                            cmd.Parameters.AddWithValue("@Project_Manager", Project_Manager);
                            cmd.Parameters.AddWithValue("@Customer_Code", customer_code);
                            cmd.Parameters.AddWithValue("@Contract_Number", Contract_Number);
                            cmd.Parameters.AddWithValue("@Job_Type", Job_Type);
                            cmd.Parameters.AddWithValue("@Tax_Class_Code", Tax_Class_Code);
                            cmd.Parameters.AddWithValue("@Taxable_Flag", Taxable_Flag);
                            cmd.Parameters.AddWithValue("@Total_Units", Total_Units);
                            cmd.Parameters.AddWithValue("@Unit_of_Measure", Unit_of_Measure);
                            cmd.Parameters.AddWithValue("@Certified_Flag", Certified_Flag);
                            cmd.Parameters.AddWithValue("@Work_Comp_Code", Work_Comp_Code);
                            cmd.Parameters.AddWithValue("@Wage_Rate_Level", Wage_Rate_Level);
                            cmd.Parameters.AddWithValue("@Price_Method_Code", Price_Method_Code);
                            cmd.Parameters.AddWithValue("@Est_Start_Date", Est_Start_Date);
                            cmd.Parameters.AddWithValue("@Est_Complete_Date", Est_Complete_Date);
                            cmd.Parameters.AddWithValue("@Start_Date", Start_Date);
                            cmd.Parameters.AddWithValue("@Complete_Date", Complete_Date);
                            cmd.Parameters.AddWithValue("@Work_State_Tax_Code", Work_State_Tax_Code);
                            cmd.Parameters.AddWithValue("@Work_County_Tax_Code", Work_County_Tax_Code);
                            cmd.Parameters.AddWithValue("@Work_Local_Tax_Code", Work_Local_Tax_Code);
                            cmd.Parameters.AddWithValue("@Original_Contract", Original_Contract);
                            cmd.Parameters.AddWithValue("@WO_Site", WO_Site);
                            cmd.Parameters.AddWithValue("@Latitude", Latitude);
                            cmd.Parameters.AddWithValue("@Longitude", Longitude);
                            cmd.Parameters.AddWithValue("@Track_Davis_Bacon", Track_Davis_Bacon);
                            cmd.Parameters.AddWithValue("@Track_Prevailing_Wage", Track_Prevailing_Wage);
                            cmd.Parameters.AddWithValue("@Create_Date", Create_Date);
                            cmd.Parameters.AddWithValue("@UDF1", UDF1);
                            cmd.Parameters.AddWithValue("@UDF2", UDF2);
                            cmd.Parameters.AddWithValue("@UDF3", UDF3);
                            cmd.Parameters.AddWithValue("@UDF4", UDF4);
                            cmd.Parameters.AddWithValue("@UDF5", UDF5);
                            cmd.Parameters.AddWithValue("@UDF6", UDF6);
                            cmd.Parameters.AddWithValue("@UDF7", UDF7);
                            cmd.Parameters.AddWithValue("@UDF8", UDF8);
                            cmd.Parameters.AddWithValue("@UDF9", UDF9);
                            cmd.Parameters.AddWithValue("@UDF10", UDF10);
                            cmd.Parameters.AddWithValue("@UDF11", UDF11);
                            cmd.Parameters.AddWithValue("@UDF12", UDF12);
                            cmd.Parameters.AddWithValue("@UDF13", UDF13);
                            cmd.Parameters.AddWithValue("@UDF14", UDF14);
                            cmd.Parameters.AddWithValue("@UDF15", UDF15);
                            cmd.Parameters.AddWithValue("@UDF16", UDF16);
                            cmd.Parameters.AddWithValue("@UDF17", UDF17);
                            cmd.Parameters.AddWithValue("@UDF18", UDF18);
                            cmd.Parameters.AddWithValue("@UDF19", UDF19);
                            cmd.Parameters.AddWithValue("@UDF20", UDF20);
                            cmd.Parameters.AddWithValue("@Cost_Center", Cost_Center);
                            cmd.Parameters.AddWithValue("@Master_Job", Master_Job);
                            cmd.Parameters.AddWithValue("@Bill_From_Master", Bill_From_Master);
                            cmd.Parameters.AddWithValue("@Standard_Phase_Category", Standard_Phase_Category);
                            cmd.Parameters.AddWithValue("@Phase_Display_Code", Phase_Display_Code);
                            cmd.Parameters.AddWithValue("@Major_Group_Start", Major_Group_Start);
                            cmd.Parameters.AddWithValue("@Major_Group_End", Major_Group_End);
                            cmd.Parameters.AddWithValue("@Minor_Group_Start", Minor_Group_Start);
                            cmd.Parameters.AddWithValue("@Minor_Group_End", Minor_Group_End);
                            cmd.Parameters.AddWithValue("@Status_Code", Status_Code);
                            cmd.ExecuteNonQuery(); 
                            con.Close();
                                updateProjectXRef(customer_code, r.Cells["customerId"].Value.ToString().Trim(), r.Cells["ProjectId"].Value.ToString().Trim(),JobNumber );
                                updateProductTypeTable(int.Parse(_projectTypeId), (int.Parse(_jobNumber )+1));
                            }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Insert into RCD_Projects " + ex.Message);
                            con.Close();
                        }

                    }
                    }

                }
                catch (Exception ex)
                {

                }
                #endregion
            }

        }

        private void updateProjectXRef(string customer_code, string custId, string projectId, string jobNumber)
        {
            string from = dtpFrom.Value.ToShortDateString();
            string cn = ConfigurationManager.ConnectionStrings["Import"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cn))

            {
                try
                {

                    con.Open();
                    SqlCommand cmd = new SqlCommand(@"spUpdateProjectXref", con);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@customer_code", customer_code);
                    cmd.Parameters.AddWithValue("@custId", custId);
                    cmd.Parameters.AddWithValue("@projectId", projectId);
                    cmd.Parameters.AddWithValue("@jobNumber", jobNumber);
                    cmd.Parameters.AddWithValue("@CreatedDate", from);
                  //  cmd.ExecuteNonQuery();
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("updateProjectXRef " + ex.Message);
                    con.Close();
                }
            }
        }

        private static string GetCustomerCode()
        {
            string cn = ConfigurationManager.ConnectionStrings["Import"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cn))

            {
                try
                {

                    con.Open();
                    SqlCommand cmd = new SqlCommand(@"spGetCodeCount", con);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@typeId", 100);

                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        var result = (dr["count"].ToString());
                        return result;

                        con.Close();
                    }
                    else
                    {
                        return "none";
                    }

                }
                catch (Exception ex)
                {
                    return "none";
                    con.Close();
                }
            }
        }

        public static string[] GetJobCode(string _projectTypeId)
        {
            var r1 = "";
            var r2 ="";
            int projectTypeId = int.Parse(_projectTypeId);
            string cn = ConfigurationManager.ConnectionStrings["Import"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cn))

            {
                //try
                //{

                    con.Open();
                    SqlCommand cmd = new SqlCommand(@"spGetCodeCount", con);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@typeId", projectTypeId);

                    SqlDataReader dr = cmd.ExecuteReader();
                    //string count = string.Empty;
                    //string costCode = string.Empty;
                    if (dr.Read())
                    {
                  r1 = dr["count"].ToString();
                   r2 = dr["CostCode"].ToString();
                          con.Close();
                    }
                    else
                    {
                        
                    }
                string[] myStrings = new string[] { r1, r2 };
                return myStrings;
                  
                }
               // catch (Exception ex)
              //  {
                   
                //    con.Close();
               // }
            }

        private static  string[] GetTaxCode(string zipcode)
        {
            var r1 = "";
            var r2 = "";
            string cn = ConfigurationManager.ConnectionStrings["Import"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cn))

            {
                try
                {

                    con.Open();
                    SqlCommand cmd = new SqlCommand(@"spGetTaxCodes", con);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@zip", zipcode);

                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        r1 = dr["local"].ToString();
                        r2 = dr["county"].ToString();

                        con.Close();
                    }
                    else
                    {
                        
                    }

                }
                catch (Exception ex)
                {
                  con.Close();
                }

                string[] myStrings = new string[] { r1, r2 };
                return myStrings;
            }
        }
        private static string GetOffice(string zipcode)
        {
            var r = "";
           
            string cn = ConfigurationManager.ConnectionStrings["Import"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cn))

            {
                try
                {

                    con.Open();
                    SqlCommand cmd = new SqlCommand(@"spGetOffice", con);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@zip", zipcode);

                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        r = dr["Office"].ToString();
                       con.Close();
                    }
                    else
                    {

                    }

                }
                catch (Exception ex)
                {
                    con.Close();
                }

                
                return r;
            }
        }
        private static string GetCustomer_Code(string customerId)
        {
            var r = "";
            int _customerId = int.Parse(customerId);
            string cn = ConfigurationManager.ConnectionStrings["Import"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cn))

            {
                try
                {

                    con.Open();
                    SqlCommand cmd = new SqlCommand(@"spGetCustomer_Code", con);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@customerId", _customerId);

                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        r = dr["customer_code"].ToString();
                        con.Close();
                    }
                    else
                    {

                    }

                }
                catch (Exception ex)
                {
                    con.Close();
                }


                return r;
            }
        }
        private void buildProjectPhases()
        {
          
            string from = dtpFrom.Value.ToShortDateString();
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
                    if (dt.Rows.Count>0 )
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
                for (int i = 0; i < 13; i++)
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
                            Cost_Type ="S";
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

        private void btnGet_Click(object sender, EventArgs e)
        {
            string sql = string.Empty;
            string cn = ConfigurationManager.ConnectionStrings["Import"].ConnectionString;
            int projectId = int.Parse(tbxProjectId.Text);
            for (int i = 0; i < 2; i++)
            {
                if (i == 0)
                {
                    sql = "spNewCustomersFromProjectId";
                    dgvJobs.DataSource = null;
                    DataTable dt = new DataTable();
                    using (SqlConnection con = new SqlConnection(cn))
                    {
                        try
                        {

                            con.Open();
                            SqlCommand cmd = new SqlCommand(sql, con);
                            cmd.CommandType = CommandType.StoredProcedure;
                            SqlDataAdapter da = new SqlDataAdapter(cmd);
                            cmd.Parameters.Clear();
                            cmd.Parameters.AddWithValue("@projectId", projectId);
                            cmd.Parameters.AddWithValue("@company_code", "HTC");
                            da.Fill(dt);
                            dgvJobs.DataSource = dt;
                            con.Close();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.StackTrace);
                            con.Close();
                        }
                    }
                }

                else if (i == 1)
                {
                    sql = "spNewProjectsFromProjectId";
                    dgvProjects.DataSource = null;
                    DataTable dt = new DataTable();
                    using (SqlConnection con = new SqlConnection(cn))
                    {
                        try
                        {
                            con.Open();
                            SqlCommand cmd = new SqlCommand(sql, con);
                            cmd.CommandType = CommandType.StoredProcedure;
                            SqlDataAdapter da = new SqlDataAdapter(cmd);
                            cmd.Parameters.Clear();
                            cmd.Parameters.AddWithValue("@projectId", projectId);
                            cmd.Parameters.AddWithValue("@company_code", "HTC");
                            da.Fill(dt);
                            dgvProjects.DataSource = dt;
                            con.Close();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.StackTrace);
                            con.Close();
                        }
                    }
                }
     

            }
        }
    
    }
}

