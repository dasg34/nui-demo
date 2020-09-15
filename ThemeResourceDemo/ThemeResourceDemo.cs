using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace ThemeResourceDemo
{
    class Program : NUIApplication
    {
        protected override void OnCreate()
        {
            base.OnCreate();

            string resourceDefault = Current.DirectoryInfo.Resource + "MyThemeResourceDefault.xaml";
            string resourceDark = Current.DirectoryInfo.Resource + "MyThemeResourceDark.xaml";

            Theme myTheme = new Theme(Current.DirectoryInfo.Resource + "MyTheme.xaml", resourceDefault);
            ThemeManager.ApplyTheme(myTheme);

            Window.Instance.BackgroundColor = new Color(227 / 255f, 255 / 255f, 227 / 255f, 1.0f);
            Window.Instance.KeyEvent += OnKeyEvent;

            View root = new View();
            root.WidthSpecification = LayoutParamPolicies.MatchParent;
            root.HeightSpecification = LayoutParamPolicies.MatchParent;
            root.Layout = new GridLayout() { Columns = 3 };
            Window.Instance.GetDefaultLayer().Add(root);

            Button button = new Button();
            button.ThemeChangeSensitive = true;
            GridLayout.SetHorizontalStretch(button, GridLayout.StretchFlags.ExpandAndFill);
            root.Add(button);

            CheckBox checkBox = new CheckBox();
            checkBox.ThemeChangeSensitive = true;
            checkBox.IsSelected = true;
            GridLayout.SetHorizontalStretch(checkBox, GridLayout.StretchFlags.ExpandAndFill);
            root.Add(checkBox);

            RadioButton radioButton = new RadioButton();
            radioButton.ThemeChangeSensitive = true;
            radioButton.IsSelected = true;
            GridLayout.SetHorizontalStretch(radioButton, GridLayout.StretchFlags.ExpandAndFill);
            root.Add(radioButton);

            TextLabel textLabel = new TextLabel();
            textLabel.Text = "Dark Resource";
            root.Add(textLabel);

            Switch themeResourceChangeSwitch = new Switch();
            themeResourceChangeSwitch.ThemeChangeSensitive = true;
            themeResourceChangeSwitch.SelectedChanged += (object sender, SelectedChangedEventArgs e) =>
            {
                if (e.IsSelected)
                {
                    myTheme.Resource = resourceDark;
                    Window.Instance.BackgroundColor = new Color(0.811f, 0.811f, 0.811f, 1.0f);
                 
                }
                else
                {
                    myTheme.Resource = resourceDefault;
                    Window.Instance.BackgroundColor = new Color(227 / 255f, 255 / 255f, 227 / 255f, 1.0f);
                }
            };
            root.Add(themeResourceChangeSwitch);
        }

        public void OnKeyEvent(object sender, Window.KeyEventArgs e)
        {
            if (e.Key.State == Key.StateType.Down && (e.Key.KeyPressedName == "XF86Back" || e.Key.KeyPressedName == "Escape"))
            {
                Exit();
            }
        }

        static void Main(string[] args)
        {
            var app = new Program();
            app.Run(args);
        }
    }
}
