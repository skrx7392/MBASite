using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MBASite.ViewModels;
using MBASite.Models;
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
        
        public LoginController()
        {
            details = new LoginDetails();
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
            details.Password = PasswordGenerator.HashPassword(login.Password);
            bool userValid = AuthenticateUser(details);
            if(userValid)
            {
                CreateCookie(details);
                if(StaticVariables.Role.Equals("Director"))
                {
                    return RedirectToAction("Director", "Home");
                }
                else if (StaticVariables.Role.Equals("Advisor"))
                {
                    return RedirectToAction("Advisor", "Home");
                }
                else
                {
                    return RedirectToAction("Student", "Home");
                }
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
            UserLogin login = new UserLogin();
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
            StaticVariables.Role = GetRoleOfUser(int.Parse(details.Username));
            FormsAuthentication.SetAuthCookie(details.Username.ToString(), false);
        }

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("LoginPage", "Login");
        }
    }
}