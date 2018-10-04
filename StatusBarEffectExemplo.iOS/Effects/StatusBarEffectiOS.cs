using System;
using System.Linq;
using Foundation;
using StatusBarEffectExemplo.iOS.Effects;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ResolutionGroupName("Bertuzzi")]
[assembly: ExportEffect(typeof(StatusBarEffectiOS), "StatusBarEffect")]
namespace StatusBarEffectExemplo.iOS.Effects
{
    public class StatusBarEffectiOS : PlatformEffect
    {
        protected override void OnAttached()
        {
            var statusBarEffect = (StatusBarEffectExemplo.Effects.StatusBarEffect)Element.Effects.FirstOrDefault(e => e is StatusBarEffectExemplo.Effects.StatusBarEffect);

            if (statusBarEffect != null)
            {
                UIView statusBar = UIApplication.SharedApplication.ValueForKey(new NSString("statusBar")) as UIView;
                if (statusBar.RespondsToSelector(new ObjCRuntime.Selector("setBackgroundColor:")))
                {
                    statusBar.BackgroundColor = statusBarEffect.BackgroundColor.ToUIColor();
                }
            }
        }

        protected override void OnDetached()
        {

        }
    }
}
