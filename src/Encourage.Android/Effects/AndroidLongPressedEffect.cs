﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using static Android.Views.View;

[assembly: ResolutionGroupName("Encourage")]
[assembly: ExportEffect(typeof(Encourage.Mobile.Effects.AndroidLongPressedEffect), "LongPressedEffect")]
namespace Encourage.Mobile.Effects
{
	/// <summary>
	/// Android long pressed effect.
	/// </summary>
	/// <remarks>CREDIT: https://alexdunn.org/2017/12/27/xamarin-tip-xamarin-forms-long-press-effect/</remarks>
	public class AndroidLongPressedEffect : PlatformEffect
	{
		private bool _attached;

		/// <summary>
		/// Initializer to avoid linking out
		/// </summary>
		public static void Initialize() { }

		/// <summary>
		/// Initializes a new instance of the
		/// <see cref="T:Yukon.Application.AndroidComponents.Effects.AndroidLongPressedEffect"/> class.
		/// Empty constructor required for the odd Xamarin.Forms reflection constructor search
		/// </summary>
		public AndroidLongPressedEffect()
		{
		}

		/// <summary>
		/// Apply the handler
		/// </summary>
		protected override void OnAttached()
		{
			//because an effect can be detached immediately after attached (happens in listview), only attach the handler one time.
			if (!_attached)
			{
				if (Control != null)
				{
					Control.LongClickable = true;
					Control.LongClick += Control_LongClick;
				}
				else
				{
					Container.LongClickable = true;
					Container.LongClick += Control_LongClick;
				}
				_attached = true;
			}
		}

		/// <summary>
		/// Invoke the command if there is one
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="e">E.</param>
		private void Control_LongClick(object sender, LongClickEventArgs e)
		{
			Console.WriteLine("Invoking long click command");
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
				if (Control != null)
				{
					Control.LongClickable = true;
					Control.LongClick -= Control_LongClick;
				}
				else
				{
					Container.LongClickable = true;
					Container.LongClick -= Control_LongClick;
				}
				_attached = false;
			}
		}
	}
}	