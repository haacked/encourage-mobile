using System.Windows.Input;
using Xamarin.Forms;

namespace Encourage.Mobile.Effects
{
	/// <summary>
	/// Long pressed effect. Used for invoking commands on long press detection cross platform
	/// </summary>
	/// <remarks>CREDIT: https://alexdunn.org/2017/12/27/xamarin-tip-xamarin-forms-long-press-effect/</remarks>
	public class LongPressedEffect : RoutingEffect
	{
		public LongPressedEffect() : base("Encourage.LongPressedEffect")
		{
		}

		public static readonly BindableProperty CommandProperty = BindableProperty.CreateAttached("Command", typeof(ICommand), typeof(LongPressedEffect), null);
		public static ICommand GetCommand(BindableObject view)
		{
			return (ICommand)view.GetValue(CommandProperty);
		}

		public static void SetCommand(BindableObject view, ICommand value)
		{
			view.SetValue(CommandProperty, value);
		}

		public static readonly BindableProperty CommandParameterProperty = BindableProperty.CreateAttached("CommandParameter", typeof(object), typeof(LongPressedEffect), null);
		public static object GetCommandParameter(BindableObject view)
		{
			return view.GetValue(CommandParameterProperty);
		}

		public static void SetCommandParameter(BindableObject view, object value)
		{
			view.SetValue(CommandParameterProperty, value);
		}
	}
}
