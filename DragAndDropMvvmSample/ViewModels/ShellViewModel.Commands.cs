namespace Gajda.ProofOfConcept.DragAndDropMvvmSample.ViewModels
{
    using Prism.Commands;

    using System.Windows;
    using System.Windows.Input;

    public sealed partial class ShellViewModel
    {
        public ICommand FileDeleteCommand => new DelegateCommand<string>(e =>
          {
              if (e is string item)
              {
                  var result = this.dialogService.ShowMessageBox(
                                   this,
                                   $"Do you want to remove \"{item}\" item?",
                                   "Question...",
                                   MessageBoxButton.YesNo);
                  if (result == MessageBoxResult.Yes)
                  {
                      this.Items.Remove(item);
                  }
              }
          }, e => e != null);
    }
}
