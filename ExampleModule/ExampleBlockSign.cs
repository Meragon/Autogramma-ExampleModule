namespace ExampleModule
{
    using Autogramma.SharedLibrary.Blocks;
    using Autogramma.SharedLibrary.Core;
    using Autogramma.SharedLibrary.Simulation.Interpreter;
    using Autogramma.SharedLibrary.Utility;

    public class ExampleBlockSign : BaseUserBlock
    {
        public const string FunctionName = "sign";
        
        public override BlockInfo Info { get; } = new BlockInfo(11000, "Sign");
        public override BlockStyle Style { get; } = new BlockStyle();
        public override string UserFunctionName => FunctionName;

        protected override int DefaultPortsInCount => 1;
        protected override int DefaultPortsOutCount => 1;

        public static InterpreterStepResult FunctionSign(Interpreter e)
        {
            var inputAddress = e.Stack.Pop().ToInt32Safe();
            var input = e.Memory[inputAddress];
            
            e.Stack.Push(input.Get() >= 0 ? 1 : 0);

            return InterpreterStepResult.Continue;
        }
    }
}