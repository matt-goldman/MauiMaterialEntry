namespace MauiMaterialEntry.Controls;

public partial class MaterialEntry : ContentView
{
	public MaterialEntry()
	{
		InitializeComponent();
	}

	private void MEEntry_Focused(object sender, FocusEventArgs e)
	{
		MELabel.IsVisible = false;
    }

	private void MEEntry_Unfocused(object sender, FocusEventArgs e)
	{
		if (string.IsNullOrWhiteSpace(MEEntry.Text))
			MELabel.IsVisible = true;
    }
}