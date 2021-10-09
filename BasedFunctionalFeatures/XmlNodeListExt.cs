using System.Collections.Generic;
using System.Xml;

namespace BasedFunctionalFeatures
{
    public static class XmlNodeListExt
    {
        public static IEnumerable<XmlNode> Nodes(this XmlNodeList? nodeList)
        {
            if (nodeList is null)
            {
                yield break;
            }

            foreach (XmlNode current in nodeList)
            {
                yield return current;
            }
        }
    }
}
