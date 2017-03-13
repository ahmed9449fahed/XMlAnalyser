using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Demo.Business.Comparer;

namespace XMLAnalyzer.Business
{
   public class StructureInfo: INotifyPropertyChanged
    {
        private List<StructureInfo> _childCollection;
        private List<string> _dataCollection;
        public string Name { get; }
        public StructureInfo(string name)
        {
            Name = name;
        }       
        public static bool FilterDuplicates { get; set; }
        public static bool FilterLeereData{ get; set; }
        public static bool FilterLeerZeichneData { get; set; }
        public static string Sort { get; set; }
        public static bool SortAscending { get; set; }

        public static bool SortDescinding { get; set; }

        public IEnumerable<string> FilteredData
        {
            get
            {
                var result = Data;
                if (FilterDuplicates)
                    result = result.Distinct();
                if (FilterLeereData)
                    result = result.Where(s => s != "");
                if (FilterLeerZeichneData)
                    result = result.Select(x => x.Trim());
                if (SortAscending)
                    switch (Sort)
                    {
                        case "Numeric":
                            result = result.OrderBy(s => s, new StringComparerNumeric());
                            break;

                        case "Alpha":
                            result = result.OrderBy(s => s, new StringComparerAlpha());
                            break;

                        case "Datetime":
                            result = result.OrderBy(s => s, new StringComparerDatetime());
                            break;
                        default:
                            break;
                    }
                if (SortDescinding)
                    switch (Sort)
                    {
                        case "Numeric":
                            result = result.OrderByDescending(s => s, new StringComparerNumeric());
                            break;
                        case "Alpha":
                            result = result.OrderByDescending(s => s, new StringComparerAlpha());
                            break;
                        case "Datetime":
                            result = result.OrderByDescending(s => s, new StringComparerDatetime());
                            break;
                        default:
                            break;
                    }
                return result;
            }
        }
        public void AddChild(StructureInfo child)
        {
            ChildCollection.Add(child);
        }

        public void AddData(string value)
        {
            DataCollection.Add(value);
        }
        private List<StructureInfo> ChildCollection=> _childCollection ?? (_childCollection = new List<StructureInfo>());
        private List<string> DataCollection => _dataCollection ?? (_dataCollection = new List<string>());
        public IEnumerable<StructureInfo> Childs => ChildCollection;
        public IEnumerable<string> Data => DataCollection;
        public event PropertyChangedEventHandler PropertyChanged; 
        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
