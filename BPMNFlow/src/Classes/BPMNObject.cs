using BPMNFlow.Enums;
using System.Xml.Serialization;

namespace BPMNFlow.Classes
{
    [XmlRoot(ElementName = "definitions", Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL")]
    public class BPMNObject
    {
        [XmlElement(ElementName = "process")]
        public ProcessElement Process { get; set; }
    }

    [Serializable]
    public class BaseElement
    {
        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }

        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }

        [XmlElement(ElementName = "outgoing")]
        public List<string> Outgoing { get; set; }

        [XmlElement(ElementName = "incoming")]
        public List<string> Incoming { get; set; }

        [XmlIgnore]
        public ElementTypeEnum ElementType { get; set; }
    }

    public class ProcessElement : BaseElement
    {
        [XmlElement(ElementName = "startEvent")]
        public StartEvent StartEvent { get; set; }

        [XmlElement(ElementName = "endEvent")]
        public EndEvent EndEvent { get; set; }

        [XmlElement("task")]
        public TaskElement[] Task { get; set; }

        [XmlElement("userTask")]
        public List<UserTask> UserTask { get; set; }

        [XmlElement("sendTask")]
        public List<SendTask> SendTask { get; set; }

        [XmlElement("scriptTask")]
        public List<ScriptTask> ScriptTask { get; set; }

        [XmlElement("receiveTask")]
        public List<ReceiveTask> ReceiveTask { get; set; }

        [XmlElement("manualTask")]
        public List<ManualTask> ManualTask { get; set; }

        [XmlElement(ElementName = "businessRuleTask")]
        public List<BusinessRuleTask> BusinessRuleTask { get; set; }

        [XmlElement(ElementName = "serviceTask")]
        public List<ServiceTask> ServiceTask { get; set; }

        [XmlElement(ElementName = "sequenceFlow")]
        public List<SequenceFlow> SequenceFlow { get; set; }

        [XmlElement(ElementName = "inclusiveGateway")]
        public List<IncluiveGateway> InclusiveGateway { get; set; }

        [XmlElement(ElementName = "exclusiveGateway")]
        public List<ExclusiveGateway> ExclusiveGateway { get; set; }

        [XmlElement(ElementName = "complexGateway")]
        public List<ComplexGateway> ComplexGateway { get; set; }

        [XmlElement(ElementName = "parallelGateway")]
        public List<ParallelGateway> ParallelGateway { get; set; }

        [XmlElement(ElementName = "subProcess")]
        public List<ProcessElement> SubProcess { get; set; }

        [XmlIgnore]
        public Dictionary<string, object> MappingRef { get; set; } = new Dictionary<string, object>();

        [XmlIgnore]
        public Dictionary<string, object> MappingTarget { get; set; } = new Dictionary<string, object>();
    }
}
