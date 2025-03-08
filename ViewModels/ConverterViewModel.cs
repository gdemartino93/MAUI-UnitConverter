using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UnitsNet;

namespace MAUI_UnitConverter.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class ConverterViewModel
    {
        public string QuantityName { get; set; }
        public ObservableCollection<string> FromMeasures { get; set; }
        public ObservableCollection<string> ToMeasures { get; set; }
        public string CurrentFromMeasure { get; set; }
        public string CurrentToMeasure { get; set; }
        public double FromValue { get; set; } = 1;
        public double ToValue { get; set; }
        public ICommand ReturnCommand =>
            new Command(() =>
            {
                Convert();
            });
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

        public ConverterViewModel(string quantityName)
        {
            QuantityName = quantityName;
            FromMeasures = LoadMeasures();
            ToMeasures = LoadMeasures();
            CurrentFromMeasure = FromMeasures.FirstOrDefault();
            CurrentToMeasure = ToMeasures.FirstOrDefault();
            Convert();
        }

        public void Convert()
        {
            var result = UnitConverter.ConvertByName(FromValue, QuantityName, CurrentFromMeasure, CurrentToMeasure);
            ToValue = result;
        }
    }
}
