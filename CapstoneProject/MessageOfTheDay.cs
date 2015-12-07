using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Xml;

namespace CapstoneProject
{
    class MessageOfTheDay
    {
        private string filePath;
        
        
        public MessageOfTheDay(string path)
        {
            filePath = path;

        }

        public bool ShowMotd
        {
            get
            {
                XmlDocument resultXml = new XmlDocument();
                resultXml = this.GetResourceXmlFile(filePath);
                if (resultXml.DocumentElement.SelectSingleNode("show").InnerText.Trim().Equals("true"))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            set {
                XmlDocument xmlFile = new XmlDocument();
                xmlFile = this.GetResourceXmlFile(filePath);
                xmlFile.DocumentElement.SelectSingleNode("show").InnerText = value.ToString().ToLowerInvariant();
                xmlFile.Save(filePath);
            }
        }
 

        public Panel GetMotdPanel()
        {
            Panel mPanel = new Panel();

            Label msgText = new Label();
            var msg = this.GetCurrentMessageFromFile();

            if (msg != null)
            {
                switch (msg.Item2)
                {
                    case 1:
                        mPanel.CssClass = "alert alert-success";
                        mPanel.Attributes.Add("role", "alert");
                        msgText.Text = msg.Item1.ToString();
                        break;
                    case 2:
                        mPanel.CssClass = "alert alert-info";
                        mPanel.Attributes.Add("role", "alert");
                        msgText.Text = msg.Item1.ToString();
                        break;
                    case 3:
                        mPanel.CssClass = "alert alert-warning";
                        mPanel.Attributes.Add("role", "alert");
                        msgText.Text = msg.Item1.ToString();
                        break;
                    case 4:
                        mPanel.CssClass = "alert alert-danger";
                        mPanel.Attributes.Add("role", "alert");
                        msgText.Text = msg.Item1.ToString();
                        break;
                }
            }

            mPanel.Controls.Add(msgText);

            return mPanel;
        }

        public void SetMessage(string msg, int typeID)
        {
            XmlDocument xmlFile = GetResourceXmlFile(filePath);

            XmlNodeList nodes = xmlFile.DocumentElement.SelectSingleNode("messages").ChildNodes;

            foreach (XmlNode node in nodes)
            {
                if (node.SelectSingleNode("current").InnerText.Trim().Equals("true"))
                {
                    node.SelectSingleNode("current").InnerText = "false";
                }
            }


            XmlElement msgElem = xmlFile.CreateElement("message");

            //add current node to message node
            XmlElement msgCurrentNode = xmlFile.CreateElement("current");
            XmlText trueMsgNode = xmlFile.CreateTextNode("true");
            msgCurrentNode.AppendChild(trueMsgNode);
            msgElem.AppendChild(msgCurrentNode);
            xmlFile.DocumentElement.AppendChild(msgElem);

            //add text node to message node
            XmlElement messageTextNode = xmlFile.CreateElement("text");
            //XmlText xmlMsg = xmlFile.CreateTextNode(msg.Trim());
            //messageTextNode.AppendChild(xmlMsg);
            msg = msg.Replace("\r\n", "<br />");
            var cdata = xmlFile.CreateCDataSection(msg.Trim());
            messageTextNode.AppendChild(cdata);
            msgElem.AppendChild(messageTextNode);
            xmlFile.DocumentElement.AppendChild(msgElem);

            //add type node to message node
            XmlElement messageTypeNode = xmlFile.CreateElement("msgType");
            XmlText xmlmsgType = xmlFile.CreateTextNode(typeID.ToString());
            messageTypeNode.AppendChild(xmlmsgType);
            msgElem.AppendChild(messageTypeNode);
            xmlFile.DocumentElement.SelectSingleNode("messages").AppendChild(msgElem);

            xmlFile.Save(filePath);

        }

        private Tuple<string, int> GetCurrentMessageFromFile()
        {
            Tuple<string, int> msgObj = null; //null tuple for msg

            //read from xml file
            //generate list

            XmlDocument resultXml = new XmlDocument();
            resultXml = this.GetResourceXmlFile(filePath);

            XmlNodeList nodes = resultXml.DocumentElement.SelectSingleNode("messages").ChildNodes;

            foreach (XmlNode node in nodes)
            {
                //list.Add(new ListItem("Text", "Value"));
                //list.Add(new ListItem(node.SelectSingleNode("text").InnerText.Trim(), node.SelectSingleNode("value").InnerText.Trim()));

                if (node.SelectSingleNode("current").InnerText.Trim().Equals("true"))
                {
                    string msgText = node.SelectSingleNode("text").InnerText.Trim();
                    int typeID = Convert.ToInt32(node.SelectSingleNode("msgType").InnerText.Trim());
                    msgObj = new Tuple<string, int>(msgText, typeID);
                }
                //msgObj = new Tuple<bool, string, int>()

            }

            return msgObj;
        }

        private XmlDocument GetResourceXmlFile(string filePath)
        {
            XmlDocument resultXml = new XmlDocument();
            resultXml.Load(filePath);
            return resultXml;
        }
    }
}
