using BPMNFlow.Enums;

namespace BPMNFlow.Classes
{
    [Serializable]
    public class ComplexGateway : BaseElement, ICloneable
    {
        public ComplexGateway()
        {
            ElementType = ElementTypeEnum.ComplexGateway;
        }

        public ComplexGateway(ComplexGateway complexGateway)
        {

        }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
