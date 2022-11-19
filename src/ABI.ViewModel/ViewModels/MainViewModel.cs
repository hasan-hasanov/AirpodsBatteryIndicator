namespace ABI.ViewModel.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public MainViewModel()
        {
            Test = "AAAAAAAAAAAAAA";
        }

        private string test;
        public string Test
        {
            get
            {
                return test;
            }
            set
            {
                test = value;
                RaisePropertyChanged(nameof(Test));
            }
        }

    }
}
