namespace MauiMaterialEntry.Controls;

public partial class MaterialEntry : ContentView
{
	public MaterialEntry()
	{
		InitializeComponent();
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
		MELabel.TranslateTo(-50, -20, 250, Easing.Linear);
	}

	private void ScaleLabelUp()
	{
		MELabel.ScaleTo(1, 250, Easing.Linear);
		MELabel.TranslateTo(0, 0, 250, Easing.Linear);
	}
}