namespace ExampleModule
{
    using Autogramma.SharedLibrary.Core;

    public class ExampleLibraryCategory : ComponentLibraryCategory
    {
        public ExampleLibraryCategory(string name) : base(name, Items)
        { }

        private static readonly ComponentLibraryCategoryItem[] Items =
        {
            ComponentLibraryCategoryItem.New(ExampleDeclaration.DefaultInfo),
            ComponentLibraryCategoryItem.New<ExampleBlockSign>(), 
        };
    }
}