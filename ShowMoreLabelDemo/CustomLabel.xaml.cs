namespace ShowMoreLabelDemo;

public partial class CustomLabel : ContentView
{
	public CustomLabel()
	{
		InitializeComponent();
	}
    #region Bindable Property
    public static readonly BindableProperty TextProperty =
        BindableProperty.Create(propertyName: nameof(TextProperty), returnType: typeof(string),
            declaringType: typeof(CustomLabel),defaultBindingMode: BindingMode.TwoWay,
            propertyChanged: TextPropertyChanged);
    public string Text
    {
        get { return (string)base.GetValue(TextProperty); }
        set { base.SetValue(TextProperty, value); }
    }
    //Show the dots.... if word length > 240
    private static void TextPropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var control = (CustomLabel)bindable;
        if (newValue != null)
        {
            control.customLabel.Text = (string)newValue;
            if (control.customLabel.Text.Count<char>() > 240)
            {
                control.ShortTextVisible = true;
            }
        }
    }
    #endregion
    private bool _shortTextVisible;
    public bool ShortTextVisible
    {
        get => _shortTextVisible;
        set { _shortTextVisible = value; ShortTextPropertyChanged(); }
    }
    //By Default show first 20.
    private void ShortTextPropertyChanged()
    {
        if (Text != null)
        {
              customLabel.Text = string.Join(" ", Text.Split().Take(20))+".........";
        }
    }
     
}