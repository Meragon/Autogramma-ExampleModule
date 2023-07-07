namespace ExampleModule
{
    using Autogramma.SharedLibrary;
    using Autogramma.SharedLibrary.Core;
    using Autogramma.SharedLibrary.Fabrics;
    using Autogramma.SharedLibrary.Logging;
    using Autogramma.SharedLibrary.Simulation.Interpreter;

    // ReSharper disable once ClassNeverInstantiated.Global
    public class ExampleLibInfo : ILibraryInfo
    {
        static ExampleLibInfo()
        {
            try
            {
                DeclarationFabric.Register<ExampleDeclaration>();
                Interpreter.FunctionMap.Register(ExampleBlockSign.FunctionName, ExampleBlockSign.FunctionSign);
            }
            catch (Exception ex)
            {
                Logger.Error(nameof(ExampleLibInfo), ex.ToString());
            }
        }

        public ComponentLibraryCategory[] Library => new[] { new ExampleLibraryCategory("Example") };
    }
}