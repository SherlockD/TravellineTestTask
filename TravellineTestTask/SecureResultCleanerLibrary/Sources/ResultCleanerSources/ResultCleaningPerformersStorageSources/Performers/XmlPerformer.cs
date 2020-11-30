using SecureResultCleanerLibrary.Sources.Extensions;
using System.Linq;
using System.Xml;

namespace SecureResultCleanerLibrary.Sources.ResultCleanerSources.ResultCleaningPerformersStorageSources.Performers
{
    public class XmlPerformer : IResultCleaningPerformer
    {
        public string Clear(string inputResult, string[] clearKeys)
        {
            XmlDocument document = new XmlDocument();
            document.LoadXml(inputResult);

            foreach (var key in clearKeys)
            {
                XmlNodeList nodes = document.GetElementsByTagName(key);

                for (int i = 0; i < nodes.Count; i++)
                {
                    ClearNode(nodes[i], clearKeys);
                }
            }

            return document.OuterXml;
        }

        private void ClearNode(XmlNode currentNode, string[] clearKeys)
        {
            if (currentNode.HasChildNodes)
            {
                foreach(XmlNode child in currentNode.ChildNodes)
                {
                    ClearNode(child, clearKeys);
                }
            }
            else
            {
                if (clearKeys.Contains(currentNode.ParentNode.Name))
                {
                    currentNode.InnerText = currentNode.InnerText.GetSecureString('X');
                }
            }
        }
    }
}