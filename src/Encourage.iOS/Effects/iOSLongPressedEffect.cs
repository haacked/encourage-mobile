using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ResolutionGroupName("Encourage")]
[assembly: ExportEffect(typeof(Encourage.Mobile.Effects.iOSLongPressedEffect), "LongPressedEffect")]
namespace Encourage.Mobile.Effects
{
	/// <summary>
	/// iOS long pressed effect
	/// </summary>
	/// <remarks>CREDIT: https://alexdunn.org/2017/12/27/xamarin-tip-xamarin-forms-long-press-effect/</remarks>
	public class iOSLongPressedEffect : PlatformEffect
	{
		private bool _attached;
		private readonly UILongPressGestureRecognizer _longPressRecognizer;
		/// <summary>
		/// Initializes a new instance of the
		/// <see cref="T:Yukon.Application.iOSComponents.Effects.iOSLongPressedEffect"/> class.
		/// </summary>
		public iOSLongPressedEffect()
		{
			_longPressRecognizer = new UILongPressGestureRecognizer(HandleLongClick);
		}

		/// <summary>
		/// Apply the handler
		/// </summary>
		protected override void OnAttached()
		{
			//because an effect can be detached immediately after attached (happens in listview), only attach the handler one time
			if (!_attached)
			{
				Container.AddGestureRecognizer(_longPressRecognizer);
				_attached = true;
			}
		}

		/// <summary>
		/// Invoke the command if there is one
		/// </summary>
		private void HandleLongClick()
		{
			var command = LongPressedEffect.GetCommand(Element);
			command?.Execute(LongPressedEffect.GetCommandParameter(Element));
		}

		/// <summary>
		/// Clean the event handler on detach
		/// </summary>
		protected override void OnDetached()
		{
			if (_attached)
			{
				Container.RemoveGestureRecognizer(_longPressRecognizer);
				_attached = false;
			}
		}
	}
}

