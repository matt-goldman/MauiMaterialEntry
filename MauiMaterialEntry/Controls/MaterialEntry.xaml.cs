namespace MauiMaterialEntry.Controls;

public partial class MaterialEntry : ContentView
{
	private readonly int _yScale;
	private readonly int _xScale;

	public MaterialEntry()
	{
		InitializeComponent();

		if (DeviceInfo.Current.Platform == DevicePlatform.Android || DeviceInfo.Current.Platform == DevicePlatform.iOS)
		{
			_yScale = -20;
			_xScale = -50;
		}
		else if (DeviceInfo.Current.Platform == DevicePlatform.WinUI)
		{
            _yScale = -15;
            _xScale = -40;
        }
	}

	private void MEEntry_Focused(object sender, FocusEventArgs e)
	{
		//MELabel.IsVisible = false;
		ScaleLabelDown();
    }

	private void MEEntry_Unfocused(object sender, FocusEventArgs e)
	{
		if (string.IsNullOrWhiteSpace(MEEntry.Text))
			//MELabel.IsVisible = true;
			ScaleLabelUp();
    }

	private void ScaleLabelDown()
	{
		MELabel.ScaleTo(0.8, 250, Easing.Linear);
		MELabel.TranslateTo(_xScale, _yScale, 250, Easing.Linear);
	}

	private void ScaleLabelUp()
	{
		MELabel.ScaleTo(1, 250, Easing.Linear);
		MELabel.TranslateTo(0, 0, 250, Easing.Linear);
	}
}