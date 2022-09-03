namespace MauiMaterialEntry.Controls;

public partial class MaterialEntry : ContentView
{
	private readonly int _yScale;
	private readonly int _xScale;

	private readonly Color _primary;

	public MaterialEntry()
	{
		InitializeComponent();

        var rd = App.Current.Resources.MergedDictionaries.First();

		_primary = (Color)rd["Primary"];

        if (DeviceInfo.Current.Platform == DevicePlatform.Android)
		{
			_yScale = -18;
			_xScale = -50;
		}
		else if (DeviceInfo.Current.Platform == DevicePlatform.WinUI)
		{
            _yScale = -15;
            _xScale = -40;
        }
		else if (DeviceInfo.Current.Platform == DevicePlatform.iOS || DeviceInfo.Current.Platform == DevicePlatform.MacCatalyst)
		{
            _yScale = -22;
            _xScale = -50;
        }

		MEEntry.ZIndex = 2;
		MEBorder.ZIndex = 2;
		MELabel.ZIndex = 3;

        BindingContext = this;
	}

	public static readonly BindableProperty TextProperty = BindableProperty.Create(nameof(Text), typeof(string), typeof(MaterialEntry), null);
	public string Text
	{ 
		get => (string)GetValue(TextProperty);
		set => SetValue(TextProperty, value);
	}

	public static readonly BindableProperty LabelProperty = BindableProperty.Create(nameof(Label), typeof(string), typeof(MaterialEntry), null);
	public string Label
	{
		get => (String)GetValue(LabelProperty);
		set => SetValue(LabelProperty, value);
	}

	private void MEEntry_Focused(object sender, FocusEventArgs e)
	{
		//MELabel.IsVisible = false;
		MEBorder.Stroke = (Color)_primary;
		MELabel.TextColor = (Color)_primary;
		ScaleLabelDown();
    }

	private void MEEntry_Unfocused(object sender, FocusEventArgs e)
	{
		if (string.IsNullOrWhiteSpace(MEEntry.Text))
		{
            //MELabel.IsVisible = true;
            ScaleLabelUp();
        }
		else
		{
			if (DeviceInfo.Current.Platform == DevicePlatform.iOS || DeviceInfo.Current.Platform == DevicePlatform.MacCatalyst)
			{
				MELabel.TranslateTo(_xScale, _yScale + 2, 50, Easing.Default);
			}
		}
    }

	private void ScaleLabelDown()
	{
		MELabel.ScaleTo(0.8, 250, Easing.Linear);
		MELabel.TranslateTo(_xScale, _yScale, 250, Easing.Linear);
		MELabel.ZIndex = 3;
	}

	private void ScaleLabelUp()
	{
        MELabel.ZIndex = 1;
        MELabel.ScaleTo(1, 250, Easing.Linear);
		MELabel.TranslateTo(0, 0, 250, Easing.Linear);
	}
}