using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AdoDisconnected
{
    internal class ContactLayer
    {
        private string _connectionstring;
        SqlDataAdapter dataAdapter;
        DataSet dataset;
        public ContactLayer()
        {
            _connectionstring = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=AddressBook;Integrated Security=True;";
        }

        public void Insert(Contact c)
        {
            try
            {
                dataAdapter = new SqlDataAdapter("select * from Contact", _connectionstring);
                DataSet ds = new DataSet();

                dataAdapter.Fill(ds, "Contact");

                DataRow dataRow = ds.Tables["Contact"].NewRow();


                dataRow["firstName"] = c.firstName;
                dataRow["lastName"] = c.lastName;
                dataRow["address"] = c.address;
                dataRow["city"] = c.city;
                dataRow["state"] = c.state;
                dataRow["zip"] = c.zip;
                dataRow["phone"] = c.phone;
                dataRow["email"] = c.email;
                dataRow["bookName"] = c.bookName;

                ds.Tables["Contact"].Rows.Add(dataRow);

                SqlCommandBuilder scd = new SqlCommandBuilder(dataAdapter);
                dataAdapter.Update(ds, "Contact");

                Console.WriteLine("Data added succesfully");

            }   
            catch(SqlException se)
            {
                Console.WriteLine(se.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void DisplayByName(string FName)
        {
            try
            {
                dataAdapter = new SqlDataAdapter("select * from Contact", _connectionstring);
                DataSet ds = new DataSet();

                dataAdapter.Fill(ds, "Contact");
                DataTable dt = ds.Tables["Contact"];
                bool flag = false;
                foreach (DataRow row in dt.Rows)
                {
                    if (row["firstName"].ToString() == FName)
                    {
                        foreach (DataColumn col in dt.Columns)
                        {
                            Console.Write(col.ToString()+": "+row[col].ToString() + ", ");
                        }
                        flag = true;
                        Console.WriteLine();
                    }
                }
                if (!flag)
                {
                    Console.WriteLine("Data not found");
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
