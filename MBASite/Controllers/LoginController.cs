using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MBASite.ViewModels;
using System.Security.Cryptography;
using System.Text;
using MBASite.Helpers;
using System.Threading.Tasks;
using System.Web.Security;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text.RegularExpressions;

namespace MBASite.Controllers
{
    public class LoginController : Controller
    {
        LoginDetails details;
        string role;

        public LoginController()
        {
            details = new LoginDetails();
            role = string.Empty;
        }
        
        // GET: Login
        public ActionResult LoginPage()
        {
            return View(details);
        }

        [HttpPost]
        public ActionResult LoginPage(LoginDetails login)
        {
            details.Username = login.Username;
            MD5 md5 = new MD5CryptoServiceProvider();
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(login.Password));
            byte[] result = md5.Hash;
            StringBuilder strBuilder = new StringBuilder();
            foreach(var i in result)
            {
                strBuilder.Append(i.ToString("x2"));
            }
            details.Password = strBuilder.ToString();
            bool userValid = AuthenticateUser(details);
            if(userValid)
            {
                CreateCookie(details);
                //string user = HttpContext.User.Identity.Name;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                details = new LoginDetails();
                return View(details);
            }
        }

        private bool AuthenticateUser(LoginDetails details)
        {
            string url = System.Web.Configuration.WebConfigurationManager.AppSettings["baseUrl"];
            string uri = System.Web.Configuration.WebConfigurationManager.AppSettings["login"];
            LoginStatus login = new LoginStatus();
            login.ID = int.Parse(details.Username);
            login.Password = details.Password;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.PostAsJsonAsync(uri, login).Result;
                string resultString = response.Content.ReadAsStringAsync().Result;
                bool authResult = String.Equals(resultString, "true") ? true : false;
                return authResult;
            }
        }

        private string GetRoleOfUser(int id)
        {
            string url = System.Web.Configuration.WebConfigurationManager.AppSettings["baseUrl"];
            string uri = System.Web.Configuration.WebConfigurationManager.AppSettings["GetUserRole"] + id.ToString();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.GetAsync(uri).Result;
                string resultString = response.Content.ReadAsStringAsync().Result;
                string result = Regex.Replace(resultString, "[^a-zA-Z]+", "", RegexOptions.Compiled);
                return result;
            }
        }

        private void CreateCookie(LoginDetails details)
        {
            role = GetRoleOfUser(int.Parse(details.Username));
            FormsAuthentication.SetAuthCookie(details.Username.ToString(), false);
        }

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("LoginPage", "Login");
        }
    }
}