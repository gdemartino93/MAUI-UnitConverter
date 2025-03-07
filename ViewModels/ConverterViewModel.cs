using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitsNet;

namespace MAUI_UnitConverter.ViewModels
{
    public class ConverterViewModel
    {
        public string QuantityName { get; set; }
        public ObservableCollection<string> FromMeasures { get; set; }
        public ObservableCollection<string> ToMeasures { get; set; }
        public string CurrentFromMeasure { get; set; }
        public string CurrentToMeasure { get; set; }
        private ObservableCollection<string> LoadMeasures()
        {
            var types = Quantity.Infos?
                .FirstOrDefault(x => x.Name == QuantityName)?
                .UnitInfos
                .Select(u => u.Name)
                .ToList();
            if (types?.Any() == true)
            {
                return new ObservableCollection<string>(types);
            }
            return new ObservableCollection<string>();
        }

        public ConverterViewModel()
        {
            QuantityName = "Length";
            FromMeasures = LoadMeasures();
            ToMeasures = LoadMeasures();
            CurrentFromMeasure = "Meter";
            CurrentToMeasure = "Centimeter";
        }
    }
}
