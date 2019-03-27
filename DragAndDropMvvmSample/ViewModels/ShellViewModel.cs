namespace Gajda.ProofOfConcept.DragAndDropMvvmSample.ViewModels
{
    using Events;

    using GongSolutions.Wpf.DragDrop;

    using MvvmDialogs;

    using Prism.Events;
    using Prism.Mvvm;

    using System.IO;
    using System.Linq;
    using System.Windows;

    public sealed partial class ShellViewModel : BindableBase, IDropTarget
    {
        private readonly IDialogService dialogService;
        private readonly IEventAggregator eventAggregator;

        public ShellViewModel(IDialogService dialogService, IEventAggregator eventAggregator)
        {
            this.dialogService = dialogService;
            this.eventAggregator = eventAggregator;

            this.eventAggregator.GetEvent<FileUploadEvent>().Subscribe(e =>
            {

                this.Items.Add(new FileInfo(e).Name);
            }, ThreadOption.UIThread, true);
        }

        public void DragOver(IDropInfo dropInfo)
        {
            dropInfo.DropTargetAdorner = DropTargetAdorners.Insert;
            if (dropInfo.Data is DataObject dataObject && dataObject.GetDataPresent(DataFormats.FileDrop))
            {
                dropInfo.Effects = DragDropEffects.Copy;
            }
        }

        public void Drop(IDropInfo dropInfo)
        {
            if (dropInfo.Data is DataObject dataObject && dataObject.ContainsFileDropList())
            {
                var files = dataObject.GetFileDropList().Cast<string>();
                foreach (var file in files)
                {
                    this.eventAggregator.GetEvent<FileUploadEvent>().Publish(file);
                }
            }
        }
    }
}
