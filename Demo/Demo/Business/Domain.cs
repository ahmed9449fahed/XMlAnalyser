using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Windows;
using Demo.Business;

namespace XMLAnalyzer.Business
{
    internal class Domain : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private static Domain _instance;
        private StructureInfo _selectedStructureInfo;
        private StructureInfo _structureInfo;
        public static Domain Instance => _instance ?? (_instance = new Domain());

        private Domain()
        {
        }

        internal StructureInfo StructureInfo
        {
            get { return _structureInfo; }
            set
            {
                if (_structureInfo != value)
                {
                    _structureInfo = value;
                    RaisePropertyChanged(nameof(StructureInfo));
                }
            }
        }

        public StructureInfo SelectedStructureInfo
        {
            get
            {
                if (_selectedStructureInfo != null) return _selectedStructureInfo;
                return null;
            }
            set
            {
                if (_selectedStructureInfo != value)
                {
                    _selectedStructureInfo = value;
                    RaisePropertyChanged(nameof(SelectedStructureInfo));
                    RefresData();
                }
            }
        }

        public static string[] _sort = new[] {"Alpha", "Numeric", "Datetime"};
        private List<string> _sortType = new List<string>(_sort.ToList());

        public List<string> SortType
        {
            get { return _sortType; }
            set
            {
                _sortType = value;
                RaisePropertyChanged(nameof(SortType));
            }
        }

        private string _selectedSort = string.Empty;

        public string SelectedSort
        {
            get { return _selectedSort; }
            set
            {
                if (_selectedSort == value)
                    return;
                _selectedSort = value;
                RaisePropertyChanged(nameof(SelectedSort));
                StructureInfo.Sort = value;
                RefresData();
            }
        }

        public void RefresData()
        {
            try
            {
                SelectedData = Domain.Instance.SelectedStructureInfo.FilteredData.ToList();
                GesamtAnzahl = XmlParser.RootInfo.Childs.First().Childs.Max(x => x.Data.Count()).ToString();
                Anzahl = Domain.Instance.SelectedStructureInfo.FilteredData.Count().ToString();
                AnzahlProzent =
                    String.Format("{0:0.00}",
                        Convert.ToDouble(Convert.ToDouble(Anzahl)) * 100 / Convert.ToDouble(GesamtAnzahl)) + "%";
                MaximumZeichen = FindMaximalZeichen(Domain.Instance.SelectedStructureInfo.FilteredData.ToArray());
                DataType = Testdatatype(Domain.Instance.SelectedStructureInfo.FilteredData.ToArray());
            }
            catch (Exception e)
            {
                MessageBox.Show("Bitte zu erste einen Datei Offnen ");
            }
        }

        private string FindMaximalZeichen(string[] array)
        {
            int maximalZeichen = 0;
            foreach (string info in array)
            {
                if (info.Length > maximalZeichen)
                    maximalZeichen = info.Length;
            }
            return maximalZeichen.ToString();
        }

        private string Testdatatype(string[] array)
        {
            bool testdata = false;
            int x;
            int counter = 0;
            int count = array.Length;
            foreach (string info in array)
            {
                if (int.TryParse(info, out x))
                {
                    counter += 1;
                }
            }
            if (counter == count)
            {
                testdata = true;
                return "Numerisch";
            }
            else counter = 0;
            if (testdata == false)
            {
                foreach (string info in array)
                {
                    DateTime atime;
                    string[] formats =
                    {
                        "dd/MM/yyyy", "dd/M/yyyy", "d/M/yyyy", "d/MM/yyyy",
                        "dd/MM/yy", "dd/M/yy", "d/M/yy", "d/MM/yy", "dd.MM.yyyy"
                    };

                    if (DateTime.TryParseExact(info, formats, CultureInfo.CurrentCulture, DateTimeStyles.None, out atime))
                    {
                        counter += 1;
                    }
                }
                if (counter == count)
                {
                    testdata = true;
                    return "Datatime";
                }
            }
            if (testdata == false)
                return "Alpha";
            return "Alpha";
        }

    private List<string> _selectedData =new List<string>();
        public List<string> SelectedData
        {
            get { return _selectedData; }
            set
            {     if(_selectedData==value)
                    return;        
                _selectedData = value;
                RaisePropertyChanged(nameof(SelectedData));              
            }
        }
        private bool _filterDuplicates;
        private bool _filterLeereData;
        private bool _filterLeerzeicheneData;
        private bool _sortAcsending;
        private bool _sortDescending;
        public bool FilterDuplicates
        {
            get { return _filterDuplicates; }
            set
            {
                if (_filterDuplicates != value)
                {
                    _filterDuplicates = value;
                    RaisePropertyChanged(nameof(FilterDuplicates));
                    StructureInfo.FilterDuplicates = value;
                    RefresData();
                }
            }
        }
        public bool SortAcsending
        {
            get { return _sortAcsending; }
            set
            {
                if (_sortAcsending != value)
                {
                    _sortAcsending = value;
                    RaisePropertyChanged(nameof(SortAcsending));
                    StructureInfo.SortAscending = value;
                    RefresData();
                }
            }
        }
        public bool SortDescending
        {
            get { return _sortDescending; }
            set
            {
                if (_sortDescending != value)
                {
                    _sortDescending = value;
                    RaisePropertyChanged(nameof(SortDescending));
                    StructureInfo.SortDescinding = value;
                    RefresData();
                }
            }
        }
        public bool FilterLeereData
        {
            get { return _filterLeereData; }
            set
            {
                if (_filterLeereData != value)
                {
                    _filterLeereData = value;
                    RaisePropertyChanged(nameof(FilterLeereData));
                    StructureInfo.FilterLeereData = value;
                    RefresData();
                }
            }
        }
        public bool FilterLeerZeichneData
        {
            get { return _filterLeerzeicheneData; }
            set
            {
                if (_filterLeerzeicheneData != value)
                {
                    _filterLeerzeicheneData = value;
                    RaisePropertyChanged(nameof(FilterLeerZeichneData));
                    StructureInfo.FilterLeerZeichneData = value;
                    RefresData();

                }
            }
        }

        private string _anzahl = string.Empty;

        public string Anzahl
        {
            get { return _anzahl; }
            set
            {
                if(_anzahl==value)
                    return;
                _anzahl = value;
                RaisePropertyChanged(nameof(Anzahl));
            }
        }

        private string _anzahlProzent = string.Empty;

        public string AnzahlProzent
        {
            get { return _anzahlProzent; }
            set
            {
                if (_anzahlProzent == value)
                    return;
                _anzahlProzent = value;
                RaisePropertyChanged(nameof(AnzahlProzent));
            }
        }


        private string _gesamtAnzahl = string.Empty;

        public string GesamtAnzahl
        {
            get { return _gesamtAnzahl; }
            set
            {
                if (_gesamtAnzahl == value)
                    return;
                _gesamtAnzahl = value;
                RaisePropertyChanged(nameof(GesamtAnzahl));
            }
        }


        private string _maximumZeichen = string.Empty;

        public string MaximumZeichen
        {
            get { return _maximumZeichen; }
            set
            {
                if (_maximumZeichen == value)
                    return;
                _maximumZeichen = value;
                RaisePropertyChanged(nameof(MaximumZeichen));
            }
        }


        private string _dataType = string.Empty;

        public string DataType
        {
            get { return _dataType; }
            set
            {
                if (_dataType == value)
                    return;
                _dataType = value;
                RaisePropertyChanged(nameof(DataType));
            }
        }

        protected virtual void RaisePropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        
        }


    }
}
