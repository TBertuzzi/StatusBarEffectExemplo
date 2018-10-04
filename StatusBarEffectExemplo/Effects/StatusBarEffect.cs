using System;
using Xamarin.Forms;

namespace StatusBarEffectExemplo.Effects
{
    public class StatusBarEffect : RoutingEffect
    {

        public Color BackgroundColor { get; set; }

        public StatusBarEffect() : base("Bertuzzi.StatusBarEffect")
        {

        }
    }
}
