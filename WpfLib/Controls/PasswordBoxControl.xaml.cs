using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfLib.Controls
{
	/// <summary>
	/// PasswordBoxControl.xaml에 대한 상호 작용 논리
	/// </summary>
	public partial class PasswordBoxControl : UserControl
	{
		#region Fields
		private bool _isFirst = true;
		#endregion

		#region Methods
		private void Pwd_PasswordChanged(object sender, RoutedEventArgs e)
		{
			Password = pwd.Password;
		}

		private void Txt_TextChanged(object sender, TextChangedEventArgs e)
		{
			if (_isFirst || DesignerProperties.GetIsInDesignMode(this))
			{
				if(pwd.Password != txt.Text)
					pwd.Password = txt.Text;

				_isFirst = false;
			}
		}
		#endregion

		public PasswordBoxControl()
		{
			InitializeComponent();

			txt.TextChanged += Txt_TextChanged;
			pwd.PasswordChanged += Pwd_PasswordChanged;
		}

		#region Public Properties
		public bool Validating
		{
			get { return (bool)GetValue(ValidatingProperty); }
			set { SetValue(ValidatingProperty, value); }
		}

		public new Brush BorderBrush
		{
			get { return (Brush)GetValue(BorderBrushProperty); }
			set { SetValue(BorderBrushProperty, value); }
		}

		public new Thickness BorderThickness
		{
			get { return (Thickness)GetValue(BorderThicknessProperty); }
			set { SetValue(BorderThicknessProperty, value); }
		}

		public String WaterMarkText
		{
			get { return (String)GetValue(WaterMarkTextProperty); }
			set { SetValue(WaterMarkTextProperty, value); }
		}

		public Brush WaterMarkTextColor
		{
			get { return (Brush)GetValue(WaterMarkTextColorProperty); }
			set { SetValue(WaterMarkTextColorProperty, value); }
		}

		public String Password
		{
			get { return (String)GetValue(PasswordProperty); }
			set { SetValue(PasswordProperty, value); }
		}
		#endregion

		#region Public Statics
		// Using a DependencyProperty as the backing store for BorderBrush.  This enables animation, styling, binding, etc...
		public static new readonly DependencyProperty BorderBrushProperty =
			DependencyProperty.Register("BorderBrush", typeof(Brush), typeof(PasswordBoxControl), new UIPropertyMetadata(Brushes.SkyBlue));

		// Using a DependencyProperty as the backing store for BorderThickness.  This enables animation, styling, binding, etc...
		public static new readonly DependencyProperty BorderThicknessProperty =
			DependencyProperty.Register("BorderThickness", typeof(Thickness), typeof(PasswordBoxControl), new UIPropertyMetadata(new Thickness(1)));

		// Using a DependencyProperty as the backing store for WaterMarkText.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty WaterMarkTextProperty =
			DependencyProperty.Register("WaterMarkText", typeof(String), typeof(PasswordBoxControl), new UIPropertyMetadata(null));

		// Using a DependencyProperty as the backing store for WaterMarkTextColor.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty WaterMarkTextColorProperty =
			DependencyProperty.Register("WaterMarkTextColor", typeof(Brush), typeof(PasswordBoxControl), new UIPropertyMetadata(Brushes.Gray));

		// Using a DependencyProperty as the backing store for Text.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty PasswordProperty =
			DependencyProperty.Register("Text", typeof(String), typeof(PasswordBoxControl), new FrameworkPropertyMetadata("", FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

		// Using a DependencyProperty as the backing store for Validating.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty ValidatingProperty =
			DependencyProperty.Register("Validating", typeof(bool), typeof(PasswordBoxControl), new UIPropertyMetadata(false));

		#endregion
	}
}
