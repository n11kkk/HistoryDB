using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using Calculator.Models;
using Calculator.Services;

namespace Calculator.ViewModels
{
    public partial class HistoryViewModel : ObservableObject
    {
        public HistoryViewModel()
        {
            Expressions = new ObservableCollection<HistoryModel>();
            //getAllExpr();
        }

        [ObservableProperty]
        public static ObservableCollection<HistoryModel> expressions;

        public static string exprString = "";

        [RelayCommand]
        public static async void AddExpr(string a)
        {
            if (string.IsNullOrEmpty(a))
            {
                return;
            }
            await HistoryService.AddExpr(a);

            ObservableCollection<HistoryModel> result = await HistoryService.GetExpr();

            System.Diagnostics.Debug.WriteLine("THESE ARE THE EXPRESSIONS", result);

        }


    }
}
