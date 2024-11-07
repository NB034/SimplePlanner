using System.ComponentModel;

namespace SimplePlanner.SimplePlannerCode
{
    internal class PlannerPageViewModel : INotifyPropertyChanged
    {
        readonly MarksLoader _loader;

        public PlannerPageViewModel(MarksLoader loader)
        {
            _loader = loader;
            Marks = _loader.LoadMarks();
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public Command ClearCommand => new(Clear);
        public Command SaveCommand => new(Save);
        public IList<MarkViewModel> Marks { get; set; }

        void Save()
        {
            Task.Run(() => _loader.SaveMarks(Marks));
        }

        void Clear()
        {
            Marks = _loader.GetDefault();
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Marks)));
        }
    }
}
