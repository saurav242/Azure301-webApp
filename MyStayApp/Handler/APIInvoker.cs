using MyStayApp.Models;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Text;

namespace MyStayApp.Handler
{
    public class APIInvoker
    {
        private readonly string _host;
        public APIInvoker()
        {
            _host = System.Configuration.ConfigurationManager.AppSettings["APIUrl"]; ;
        }


        public string GetAllHotels()
        {
            string result = "";
            try
            {
                result = Invoke($"{_host}hotel", "GET", "");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.TraceError(ex.Message);
            }
            return result;
        }

        public string GetHotelById(int? id)
        {
            string result = "";
            try
            {
                result = Invoke($"{_host}hotel/{id}", "GET", "");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.TraceError(ex.Message);
            }
            return result;
        }

        public User CreateUser(User user)
        {
            User usr =new User();
            try
            {
                var result = Invoke($"{_host}user", "POST", JsonConvert.SerializeObject(user));
                usr = JsonConvert.DeserializeObject<User>(result);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.TraceError(ex.Message);
            }
            return usr;
        }

        public User ValidateUser(string email, string password)
        {
            //var obj = new UserValidation()
            //{
            //    email = email,
            //    password= password

            //};

            //string req = JsonConvert.SerializeObject(obj);


            var result = Invoke($"{_host}user/validate?email={email}&password={password}", "GET", "");
            return JsonConvert.DeserializeObject<User>(result);
        }
        private string Invoke(string url, string method, string json)
        {
            try
            {
                string result;
                var webRequest = (HttpWebRequest)WebRequest.Create(url);
                webRequest.Method = method;
                webRequest.ContentType = "application/json";

                if (json.Length > 0)
                {
                    var buf = Encoding.UTF8.GetBytes(json);
                    webRequest.ContentLength = buf.Length;
                    var st = webRequest.GetRequestStream();
                    st.Write(buf, 0, buf.Length);
                }

                var response = (HttpWebResponse)webRequest.GetResponse();
                using (var responseReader = new StreamReader(response.GetResponseStream()))
                {
                    result = responseReader.ReadToEnd();
                }
                return result;
            }
            catch (Exception exception)
            {
                return exception.Message;
            }
        }
    }

    public class UserValidation
    {
        public string email { get; set; }
        public string password { get; set; }
    }
}
