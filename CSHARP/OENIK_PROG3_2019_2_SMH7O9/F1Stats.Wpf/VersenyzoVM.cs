using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1Stats.Wpf
{
    class VersenyzoVM : ObservableObject
    {
		private int rajtszam;
		private string nev;
		private string csapatNev;
		private int eletkor;
		private int osszPont;
		private int idenbyeliPont;

		public int IdenybeliPont
		{
			get { return idenbyeliPont; }
			set { Set(ref idenbyeliPont, value); }
		}


		public int OsszPont
		{
			get { return osszPont; }
			set { Set(ref osszPont, value); }
		}


		public int Eletkor
		{
			get { return eletkor; }
			set { Set(ref eletkor, value); }
		}


		public string CsapatNev
		{
			get { return csapatNev; }
			set { Set(ref csapatNev, value); }
		}


		public string Nev
		{
			get { return nev; }
			set { Set(ref nev, value); }
		}


		public int Rajtszam
		{
			get { return rajtszam; }
			set { Set(ref rajtszam, value); }
		}

		public void CopyFrom(VersenyzoVM other)
		{
			if (other == null) return;
			this.Rajtszam = other.Rajtszam;
			this.Nev = other.Nev;
			this.CsapatNev = other.CsapatNev;
			this.Eletkor = other.Eletkor;
			this.IdenybeliPont = other.IdenybeliPont;
			this.OsszPont = other.OsszPont;
		}

	}
}
