namespace Gajda.ProofOfConcept.DragAndDropMvvmSample
{
    using MvvmDialogs;

    using Prism.Ioc;
    using Prism.Unity;

    using System.Windows;

    using Views;

    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterInstance<IDialogService>(new DialogService());
        }

        protected override Window CreateShell()
        {
            return this.Container.Resolve<ShellView>();
        }
    }
}
