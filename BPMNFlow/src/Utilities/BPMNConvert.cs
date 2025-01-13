using BPMNFlow.Classes;
using BPMNFlow.Enums;
using System.Reflection;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace BPMNFlow.Utilities
{
    public static class BPMNConvert
    {
        public static BPMNObject DeserializeModel(string model)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(model);

            RemoveElements(doc, "//extensionElements");
            RemoveElements(doc, "//BPMNDiagram");
            RemoveElements(doc, "//bpmndi:BPMNDiagram");

            using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(doc.OuterXml)))
            {
                var serializer = new XmlSerializer(typeof(BPMNObject));
                var bpmn = (BPMNObject)serializer.Deserialize(stream);
                MappingTargetRef(bpmn.Process);

                return bpmn;
            }
        }

        private static void RemoveElements(XmlDocument doc, string xpath)
        {
            XmlNodeList nodes = doc.SelectNodes(xpath);
            foreach (XmlNode node in nodes)
            {
                XmlNode parent = node.ParentNode;
                parent?.RemoveChild(node);
            }
        }

        private static void MappingTargetRef(ProcessElement process)
        {
            foreach (var subProcess in process.SubProcess)
            {
                subProcess.ElementType = ElementTypeEnum.SubProcess;
                MappingTargetRef(subProcess);
            }

            process.MappingTarget = new Dictionary<string, object>();
            process.MappingRef = new Dictionary<string, object>();

            foreach (var sequenceFlow in process.SequenceFlow)
            {
                foreach (var item in GetObjectForId(process, sequenceFlow.TargetRef))
                {
                    process.MappingTarget.Add(sequenceFlow.Id, item);
                }

                foreach (var item in GetObjectForId(process, sequenceFlow.SourceRef))
                {
                    process.MappingRef.Add(sequenceFlow.Id, item);
                }
            }
        }

        private static List<object> GetObjectForId(object obj, string id)
        {
            List<object> list = new List<object>();
            Type t = obj.GetType();
            PropertyInfo[] props = t.GetProperties();

            foreach (var prop in props)
            {
                try
                {
                    object propValue = prop.GetValue(obj);
                    if (propValue == null)
                        continue;

                    if (prop.GetIndexParameters().Length == 0)
                    {
                        if (propValue is BaseElement && ((BaseElement)propValue).Id == id)
                        {
                            list.Add(propValue);
                        }
                        else if (propValue is IEnumerable<BaseElement>)
                        {
                            foreach (var item in (propValue as IEnumerable<BaseElement>))
                            {
                                if (item.Id == id)
                                {
                                    list.Add(item);
                                }
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    
                }
            }

            return list;
        }
    }
}
