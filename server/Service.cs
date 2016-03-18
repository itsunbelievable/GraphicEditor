using System;
using System.IO;
using System.ServiceProcess;
using System.Text;
using System.Xml;
using ShapeInterfaces;

namespace server
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service" in both code and config file together.
    public class Service : IService
    {
        private string pathToXML = Environment.SpecialFolder.MyDocuments + "workspace_state.xml";

        public string GetPathToXml()
        {
            return pathToXML;
        }
    }
}
