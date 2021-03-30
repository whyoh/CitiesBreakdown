using ColossalFramework.UI;
using System.Linq;
using UnityEngine;

namespace Breakdown
{
    public class UIBreakdownPanel : UIPanel
    {
        public UILabel[] topTen = null;

        public override void Start()
        {
            base.Start();
            this.backgroundSprite = "GenericPanel";
            this.color = new Color32(254, 254, 254, 255);
            this.relativePosition = new Vector3(parent.width, 0);
            this.isInteractive = false;
            this.name = "BreakdownModPanel";
            this.autoLayout = true;
            this.autoLayoutDirection = LayoutDirection.Vertical;
            this.autoFitChildrenHorizontally = true;
            this.autoFitChildrenVertically = true;
            this.topTen = Enumerable.Range(0, 10).Select(x => this.AddUIComponent<UILabel>()).ToArray();
            foreach (var label in this.topTen)
            {
                label.padding = new RectOffset(5, 5, 5, 5);
            }
        }

        public void SetTopTen(string[] messages)
        {
            if (this.topTen == null)
            {
                return;
            }
            var topTenIndex = 0;
            foreach (var label in this.topTen)
            {
                this.topTen[topTenIndex].text = topTenIndex < messages.Length ? messages[topTenIndex] : string.Empty;
                topTenIndex++;
            }
        }
    }
}
