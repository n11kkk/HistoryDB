using Calculator.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Services
{
    public static class HistoryService
    {
        static SQLiteAsyncConnection db;

        static async Task Init()
        {
            if (db != null)
            {
                return;
            }

            var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "HistoryDb.db");

            db = new SQLiteAsyncConnection(databasePath);

            await db.CreateTableAsync<HistoryModel>();
        }

        public static async Task AddExpr(string a)
        {
            try
            {
                await Init();
                var HistoryModel = new HistoryModel
                {
                    Expr = a
                };
                var id = await db.InsertAsync(HistoryModel);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }

        }

        public static async Task<ObservableCollection<HistoryModel>> GetExpr()
        {
            try
            {
                await Init();
                var Expr = await db.Table<HistoryModel>().ToListAsync();
                ObservableCollection<HistoryModel> result = new ObservableCollection<HistoryModel>(Expr);
                return result;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }

            return new ObservableCollection<HistoryModel>();
        }

    }
}
