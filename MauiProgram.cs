﻿
using Calculator.ViewModels;

namespace Calculator;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});
		builder.Services.AddSingleton<MainPage>();
		builder.Services.AddSingleton<HistoryViewModel>();
		builder.Services.AddSingleton<HistoryPage>();
		builder.Services.AddSingleton<ComplexMathPage>();

		return builder.Build();
	}
}
