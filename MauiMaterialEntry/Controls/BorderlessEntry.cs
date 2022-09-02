namespace MauiMaterialEntry.Controls;

public class BorderlessEntry : Entry
{
	public BorderlessEntry()
	{
		var transparentBackgroundSetter = new Setter
		{
			Property = BackgroundColorProperty,
			Value = Colors.Transparent
		};

        var focusedTrigger = new Trigger(typeof(Entry));
		focusedTrigger.Property = IsFocusedProperty;
		focusedTrigger.Value = true;
		focusedTrigger.Setters.Add(transparentBackgroundSetter);

		Triggers.Add(focusedTrigger);
	}
}
