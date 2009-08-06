using System.ComponentModel;
using System.Threading;
using System.Windows.Input;
using AttachedAnimations.Commands;
using AttachedAnimations.Foundation;

namespace AttachedAnimations.RunABatch
{
    public class RunABatchViewModel : ViewModel
    {
        private bool _runningBatch;
        public ICommand RunABatchCommand { get; set; }

        public bool RunningBatch
        {
            get { return _runningBatch; }
            set
            {
                _runningBatch = value;
                OnPropertyChanged(this, m => m.RunningBatch);
            }
        }

        public RunABatchViewModel()
        {
            RunABatchCommand = new ActionCommand(OnRunABatch);
        }

        private void OnRunABatch()
        {
            RunningBatch = true;

            var worker = new BackgroundWorker();
            worker.DoWork += (sender, e) => Thread.Sleep(3000);
            worker.RunWorkerCompleted += (sender, e) => RunningBatch = false;
            worker.RunWorkerAsync();            
        }
    }
}