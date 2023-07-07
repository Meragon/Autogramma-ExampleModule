namespace ExampleModule
{
    using Autogramma.SharedLibrary.DataDictionary;

    public class ExampleDeclaration : BaseDeclaration
    {
        public static readonly DeclarationInfo DefaultInfo = new(20, "Example Declaration");

        public override DeclarationInfo Info => DefaultInfo;
    }
}