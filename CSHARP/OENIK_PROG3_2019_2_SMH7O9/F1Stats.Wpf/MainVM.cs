using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace F1Stats.Wpf
{
    class MainVM : ViewModelBase
    {
        private MainLogic logic;
		private VersenyzoVM selectedVersenyzo;
		private ObservableCollection<VersenyzoVM> allVersenyzo;

		public ObservableCollection<VersenyzoVM> AllVersenyzo
		{
			get { return allVersenyzo; }
			set { Set(ref allVersenyzo, value); }
		}


		public VersenyzoVM SelectedVersenyzo
		{
			get { return selectedVersenyzo; }
			set { Set(ref selectedVersenyzo, value); }
		}

		public ICommand Addcmd { get; set; }
		public ICommand Delcmd { get; set; }
		public ICommand Modcmd { get; set; }
		public ICommand Loadcmd { get; set; }

		public Func<VersenyzoVM,bool> EditorFunc { get; set; }

		public MainVM()
		{
			this.logic = new MainLogic();
			Delcmd = new RelayCommand(() => logic.ApiDelVersenyzo(selectedVersenyzo));
			Addcmd = new RelayCommand(() => logic.EditVersenyzo(null,EditorFunc));
			Modcmd = new RelayCommand(() => logic.EditVersenyzo(selectedVersenyzo,EditorFunc));
			Loadcmd = new RelayCommand(() => AllVersenyzo = new ObservableCollection<VersenyzoVM>(logic.ApiGetVersenyzo()));
		}

	}
}
