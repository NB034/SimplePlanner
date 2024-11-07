using SimplePlanner.SimplePlannerCode;

namespace SimplePlanner
{
    public partial class App : Application
    {
        const int _countOfMarks = 28;
        const string _keyName = "Marks";

        public App()
        {
            InitializeComponent();

            var loader = new MarksLoader(_countOfMarks, _keyName);
            var viewModel = new PlannerPageViewModel(loader);
            var page = new PlannerPage { BindingContext = viewModel };

            MainPage = page;
        }
    }
}
