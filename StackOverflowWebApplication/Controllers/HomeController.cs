using Microsoft.Extensions.Logging;
using StackOverflowWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.Services.Description;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using static StackOverflowWebApplication.Models.Model1;


namespace StackOverflowWebApplication.Controllers
{
    public class HomeController : Controller
    {
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;
        SqlConnection con = new SqlConnection();
        
        List<Post> posts = new List<Post>();
        List<User> user = new List<User>();
        List<Res> postResults = new List<Res>();
        private readonly ILogger<HomeController> _logger;

        public HomeController()
        {
            con.ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\manas\\source\\repos\\StackOverflowWebApplication\\StackOverflowWebApplication\\App_Data\\StackOverflow2010.mdf;Integrated Security=True;Connect Timeout=30";
        }

        public ActionResult Index(string searchString)
        {
            

            FetchData(searchString);
            // Pass the view model to the view
            return View(postResults);
        }
        private void FetchData(string searchString)
        {
            if (posts.Count > 0)
            {
                posts.Clear();
            }
            
            try
            {
                con.Open();
                com.Connection = con;
                com.CommandTimeout = 600;

                com.CommandText ="SELECT TOP(10) " +
                      "P.[Title], LEFT(P.[Body], 140) as Body, " +
                      "(SELECT COUNT(V.[Id]) FROM [Votes] V WHERE V.[PostId] = P.[Id]) AS TotalVotes, " +
                      "U.[DisplayName], U.[Reputation] " +
                      "FROM [Posts] P " +
                      "JOIN [Users] U ON P.[OwnerUserId] = U.[Id] " +
                      "WHERE P.[Body] LIKE '%" + searchString + "%' " +
                      "ORDER BY TotalVotes DESC";


                dr = com.ExecuteReader();
                while (dr.Read())
                {
                    string postTitle = dr["Title"] as string;
                    string postBody = Regex.Replace(dr["Body"] as string, "<[^>]*>", string.Empty);
                    int totalVotes = int.Parse(dr["TotalVotes"].ToString());
                    string displayName = dr["DisplayName"] as string;
                    int reputation = int.Parse(dr["Reputation"].ToString());

                        postResults.Add(new Res()
                        {
                            PostTitle = postTitle,
                            PostBody = postBody,
                            TotalVotes = totalVotes,
                            DisplayName = displayName,
                            Reputation = reputation
                        });
                    }
                











                con.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}