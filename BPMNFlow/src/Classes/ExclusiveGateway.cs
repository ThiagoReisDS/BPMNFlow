using BPMNFlow.Enums;

namespace BPMNFlow.Classes
{
    public class ExclusiveGateway : BaseElement, ICloneable
    {
        public ExclusiveGateway()
        {
            ElementType = ElementTypeEnum.ExclusiveGateway;
        }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
