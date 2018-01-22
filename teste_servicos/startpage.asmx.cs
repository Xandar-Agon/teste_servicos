using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Data.SqlClient;

namespace teste_servicos
{
    /// <summary>
    /// Summary description for startpage
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class startpage : System.Web.Services.WebService
    {
        [WebMethod]
        public DataSet GetFavourites()
        {
            DataSet dataSet = new DataSet();
            using (SqlConnection myConn = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=servicos_teste;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                SqlCommand myCommand = new SqlCommand();

                myCommand.Connection = myConn;
                myCommand.CommandText = "select recipe.name, count(case favourite when 1 then 1 else null end) as likes " +
                    "from person_has_recipe " +
                    "inner join recipe on recipe.id = id_recipe " +
                    "group by recipe.name " +
                    "order by count(favourite) desc";

                myConn.Open();

                SqlDataAdapter dataAdapter = new SqlDataAdapter(myCommand.CommandText, myConn);

                dataAdapter.Fill(dataSet);
            }
            return dataSet;
        }
        [WebMethod]
        public DataSet GetFollowers()
        {
            DataSet dataSet = new DataSet();
            using (SqlConnection myConn = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=servicos_teste;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                SqlCommand myCommand = new SqlCommand();

                myCommand.Connection = myConn;
                myCommand.CommandText = "select person.id,count(id_following) " +
                    "from following " +
                    "inner join person on id_following=person.id " +
                    "group by person.id " +
                    "order by count(id_following)";

                myConn.Open();

                SqlDataAdapter dataAdapter = new SqlDataAdapter(myCommand.CommandText, myConn);

                dataAdapter.Fill(dataSet);
            }
            return dataSet;
        }
    }
}
