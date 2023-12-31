﻿using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;

namespace RGBColorGenerate;

public partial class MainPage : ContentPage
{
     bool isRandom = false;
    string colorHex = string.Empty;


	public MainPage()
	{
		InitializeComponent();
	}

	public void GenerateColor_Clicked(object sender, EventArgs e)
	{
        isRandom = true;
        Random ram = new Random();
        Color color = Color.FromRgb(ram.Next(0, 256), ram.Next(0, 256), ram.Next(0, 256));
        SetColor(color);
        Slider_Red.Value = color.Red; Slider_Green.Value =color.Green; Slider_Blue.Value = color.Blue;
        isRandom = false;
    }

    private void Slider_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        if(!isRandom) {
            double colorRed = Slider_Red.Value;
            double colorBlue = Slider_Blue.Value;
            double colorGreen = Slider_Green.Value;

            Color color = Color.FromRgb(colorRed, colorGreen, colorBlue);
            SetColor(color);
        }
		
    }

    private void SetColor(Color color)
    {
        colorHex = color.ToHex();
        Grid_Color.Background = color;
        BtnGenerateColor.BackgroundColor = color;
        ResultColor.Text = color.ToHex();
    }

    private async void Copy_Clicked(object sender, EventArgs e)
    {
        await Clipboard.SetTextAsync(colorHex);
        IToast toast = Toast.Make("Color Copied", CommunityToolkit.Maui.Core.ToastDuration.Short, 12);
        await toast.Show();
    }
}

