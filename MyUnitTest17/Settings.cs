using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace MyUnitTest17
{
    public static class Settings
    {
        public static string file = "Settings.xml";

        private static string baseURL;
        private static string login;
        private static string password;

        private static XmlDocument document;

        static Settings()
        {
            if (!System.IO.File.Exists(file))
            {
                document = new XmlDocument();
                string path = System.Reflection.Assembly.GetExecutingAssembly().Location;
                string dir = Path.GetDirectoryName(path);
                document.Load(Path.Combine(Directory.GetParent(dir).Parent.FullName, file));
            }
        }

        public static string BaseURL
        {
            get
            {
                if (baseURL == null)
                {
                    XmlNode node = document.DocumentElement.SelectSingleNode("BaseURL");
                    baseURL = node.InnerText;
                }
                return baseURL;
            }
        }

        public static string Login
        {
            get
            {
                if (login == null)
                {
                    XmlNode node = document.DocumentElement.SelectSingleNode("Login");
                    login = node.InnerText;
                }
                return login;
            }
        }

        public static string Password
        {
            get
            {
                if (password == null)
                {
                    XmlNode node = document.DocumentElement.SelectSingleNode("Password");
                    password = node.InnerText;
                }
                return password;
            }
        }
    }
}
