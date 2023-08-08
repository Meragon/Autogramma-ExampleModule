namespace ExampleModule
{
    using Autogramma.SharedLibrary.Abstractions;
    using Autogramma.SharedLibrary.BinaryFormatter;
    using Autogramma.SharedLibrary.Blocks;
    using Autogramma.SharedLibrary.Core;
    using Autogramma.SharedLibrary.Core.Comparison;
    using Autogramma.SharedLibrary.Simulation.Interpreter;
    using Autogramma.SharedLibrary.Utility;

    public class ExampleBlockSign : BaseUserBlock
    {
        public const string FunctionName = "sign";
        
        public override BlockInfo Info { get; } = new BlockInfo(11000, "Sign");
        public override BlockStyle Style { get; } = new BlockStyle();
        public override string UserFunctionName { get; set; } = FunctionName;

        protected override int DefaultPortsInCount => 1;
        protected override int DefaultPortsOutCount => 1;

        public int CustomField { get; set; }
        private string customFieldSerializationKey = "custom_field";

        public static InterpreterStepResult FunctionSign(Interpreter e)
        {
            var inputAddress = e.Stack.Pop().ToInt32Safe();
            var input = e.Memory[inputAddress];
            
            e.Stack.Push(input.Get() >= 0 ? 1 : 0);

            return InterpreterStepResult.Continue;
        }

        public override void Serialize(ISerializableCollection info)
        {
            base.Serialize(info);
            info.Add(customFieldSerializationKey, CustomField);
        }

        public override void Deserialize(ISerializableCollection info)
        {
            base.Deserialize(info);
            this.CustomField = info.FirstOrDefaultInt32(customFieldSerializationKey);
        }

        public override void Compare<T>(ICollection<ComponentCompareResult> list, T i1, T i2)
        {
            base.Compare(list, i1, i2);

            var thisI1 = i1 as ExampleBlockSign;
            var thisI2 = i2 as ExampleBlockSign;

            if (thisI1 != null && thisI2 != null)
            {
                if (list.CanCompare(thisI1, thisI2, "ExampleBlockSign"))
                {
                    list.Compare(thisI1.CustomField, thisI2.CustomField, "ExampleBlockSign_CustomField");
                }
            }
        }

        public override void CopyTo(IProjectItem destination)
        {
            base.CopyTo(destination);

            var destinationThisType = destination as ExampleBlockSign;
            if (destinationThisType != null)
            {
                destinationThisType.CustomField = CustomField;
            }
        }
    }
}