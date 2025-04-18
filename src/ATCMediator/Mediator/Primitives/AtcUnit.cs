
namespace ATCMediator.Mediator.Primitives
{
    public sealed class AtcUnit
    {
        public static readonly AtcUnit Value = new();
        private AtcUnit() { }
        public override string ToString() => "()";
    }
}