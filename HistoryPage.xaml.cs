using Calculator.Models;
using Calculator.Services;
using Calculator.ViewModels;
using System.Collections.ObjectModel;
using System.Linq.Expressions;

namespace Calculator;

public partial class HistoryPage : ContentPage
{
    public HistoryPage(HistoryViewModel h)
    {
        InitializeComponent();
        getAllExpr();
        BindingContext = h;
    }

  
    public async void getAllExpr()
    {

        ObservableCollection<HistoryModel> result = await HistoryService.GetExpr();
        //HistoryViewModel.expressions.Clear();
        HistoryViewModel.expressions = result;

        historyList.ItemsSource = HistoryViewModel.expressions;

        System.Diagnostics.Debug.WriteLine("THESE ARE THE EXPRESSIONS", result);
    }

    public async void OnGetAllExprClicked(object sender, EventArgs e)
    {
        //x.Expr = $" => {count} This is added";
        //MainViewModel.toBeAdded = $" => {count} This is added";

        //      MainViewModel.expressions.Add(x);
        getAllExpr();
    }

    public async void OnDeleteExprClicked(object sender, EventArgs e)
    {
        await HistoryService.DeleteExprs();
        getAllExpr();
    }
}