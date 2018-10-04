using System;
using System.Linq;
using Android.Views;
using Plugin.CurrentActivity;
using StatusBarEffectExemplo.Droid.Effects;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ResolutionGroupName("Bertuzzi")]
[assembly: ExportEffect(typeof(StatusBarEffectAndroid), "StatusBarEffect")]
namespace StatusBarEffectExemplo.Droid.Effects
{
    public class StatusBarEffectAndroid : PlatformEffect
    {
        protected override void OnAttached()
        {
            var statusBarEffect = (StatusBarEffectExemplo.Effects.StatusBarEffect)Element.Effects.FirstOrDefault(e => e is StatusBarEffectExemplo.Effects.StatusBarEffect);

            if (statusBarEffect != null)
            {
                var backgroundColor = statusBarEffect.BackgroundColor.ToAndroid();
                Window currentWindow = GetCurrentWindow();
                currentWindow.SetStatusBarColor(backgroundColor);
            }
        }

        protected override void OnDetached()
        {

        }

        Window GetCurrentWindow()
        {
            var window = CrossCurrentActivity.Current.Activity.Window;

            window.ClearFlags(WindowManagerFlags.TranslucentStatus);
            window.AddFlags(WindowManagerFlags.DrawsSystemBarBackgrounds);

            return window;
        }
    }
}
