namespace Gajda.ProofOfConcept.DragAndDropMvvmSample.ViewModels
{
    using System.Collections.ObjectModel;

    public sealed partial class ShellViewModel
    {
        private ObservableCollection<string> items = new ObservableCollection<string>();

        private string selectedItem;

        private string title = "Drag & Drop MVVM Sample";

        public ObservableCollection<string> Items
        {
            get => this.items;
            set => this.SetProperty(ref this.items, value);
        }

        public string SelectedItem
        {
            get => this.selectedItem;
            set => this.SetProperty(ref this.selectedItem, value);
        }

        public string Title
        {
            get => this.title;
            set => this.SetProperty(ref this.title, value);
        }
    }
}
