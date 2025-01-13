using System.Xml.Serialization;

namespace BPMNFlow.Classes
{
    public class SequenceFlow
    {
        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }

        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }

        [XmlAttribute(AttributeName = "sourceRef")]
        public string SourceRef { get; set; }

        [XmlAttribute(AttributeName = "targetRef")]
        public string TargetRef { get; set; }
    }
}
