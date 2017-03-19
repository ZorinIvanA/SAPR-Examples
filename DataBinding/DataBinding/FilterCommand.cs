using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Collections.ObjectModel;
using System.Reflection;

namespace DataBinding
{
    /// <summary>
    /// Команда фильтрации
    /// </summary>
    public class FilterCommand : ICommand
    {
        /// <summary>
        /// Может ли команда выполниться
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(Object parameter)
        {
            return true;
        }

        /// <summary>
        /// Запуск команды
        /// </summary>
        /// <param name="parameter">Параметр</param>
        public void Execute(Object parameter)
        {
            var methFlats = parameter.GetType().GetMethod("FillFlats",
                BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.InvokeMethod);
            if (methFlats != null)
            {
                Object[] parameters = null;
                methFlats.Invoke(parameter, parameters);
            }

            var vmFilter = parameter as MainWindowViewModel;
            if (vmFilter == null)
                throw new ArgumentNullException("Модель представления не может быть null!");

            if (String.IsNullOrWhiteSpace(vmFilter.SelectedStation.Key))
                throw new ArgumentNullException("Название станции не может быть пустым!");

            var flats = vmFilter.Flats.Where(
                x => x.Area >= vmFilter.AreaMin && x.Area <= vmFilter.AreaMax &&
                x.Price >= vmFilter.PriceMin && x.Price <= vmFilter.PriceMax &&
                x.SubwayStation.Equals(vmFilter.SelectedStation.Key, StringComparison.CurrentCultureIgnoreCase));

            ObservableCollection<FlatViewModel> newElements = new ObservableCollection<FlatViewModel>();
            foreach (var f in flats)
            {
                newElements.Add(f);
            }

            var prop = parameter.GetType().GetProperty("Flats",
                BindingFlags.GetProperty | BindingFlags.Public | BindingFlags.Instance);
            prop.SetValue(parameter, newElements);

            var meth = parameter.GetType().GetMethod("DoPropertyChanged");
            if (meth != null)
            {
                Object[] parameters = new object[] { "Flats" };
                meth.Invoke(parameter, parameters);
            }
        }

        public event EventHandler CanExecuteChanged;
    }
}
