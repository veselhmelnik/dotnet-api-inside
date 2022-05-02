using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailKit;
using MailKit.Net.Imap;
using MailKit.Search;
using dotnet_api_inside.Models;
using System.Net;
using System.Text.RegularExpressions;

namespace dotnet_api_inside.Services
{
    public class EmailService
    {
        private const string _server = "imap.gmail.com";
        private const int _port = 993;
        private const string _login = "hmelniknikita@gmail.com";
        private const string _password = "zwjcfmpbzydxfsmb";
        private const string _subjectReady = "(MOBILE) Project advanced to READY state";

        public int GetNumberOfEmails()
        {
            using (var client = new ImapClient())
            {
                client.Connect(_server, _port, true);
                client.Authenticate(_login, _password);
                var inbox = client.Inbox;
                inbox.Open(FolderAccess.ReadWrite);
                IEnumerable<UniqueId> listOfEmails;
                listOfEmails = inbox.Search(SearchQuery.SubjectContains(_subjectReady));
                return listOfEmails.Count();
            }
        }

        public Project GetProjectFromEmail()
        {
            Project project = new Project();

            using (var client = new ImapClient())
            {
                client.Connect(_server, _port, true);
                client.Authenticate(_login, _password);
                var inbox = client.Inbox;
                inbox.Open(FolderAccess.ReadWrite);
                var trashFolder = client.GetFolder(SpecialFolder.Trash);

                var index = inbox.Count - 1;
                string subject = inbox.GetMessage(index).Subject;

                if (!subject.Contains(_subjectReady))
                {
                    inbox.AddFlags(index, MessageFlags.Seen, true, default);
                    inbox.MoveTo(index, trashFolder);
                }
                else
                {
                    var body = inbox.GetMessage(index).HtmlBody;
                    string path = "EmailBody";
                    File.WriteAllText(path, body);
                    string bodytxt = File.ReadAllText(path);
                    DateTime date = inbox.GetMessage(index).Date.UtcDateTime;
                    project = GetProject(bodytxt, subject, date);

                    inbox.AddFlags(index, MessageFlags.Seen, true, default);
                    inbox.MoveTo(index, trashFolder);
                }
                return project;
            }
        }

        private string GetLink(string path)
        {
            string url;

            while (!path.StartsWith("https://"))
            {
                path = path.Remove(0, 1);
            }
            while (!path.EndsWith("this"))
            {
                path = path.Remove(path.Length - 1);
            }
            path = path.Remove(path.Length - 6);

            Uri myUri = new Uri(path);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(myUri);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            url = response.ResponseUri.ToString();
            response.Close();
            return url;
        }

        private Project GetProject(string txt, string subject, DateTime date)
        {
            Project project = new Project();
            string nameReg = "\\((.*?)\\)";
            string idReg = @".+(\=)";
            string newSubject = subject.Remove(0, 42);
            project.Name = Regex.Replace(newSubject, nameReg, "");
            project.Link = GetLink(txt);
            project.Date = date;
            project.ProjectId = Regex.Replace(project.Link, idReg, "");

            return project;
        }
    }
}
