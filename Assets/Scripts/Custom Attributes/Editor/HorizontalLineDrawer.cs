using UnityEditor;
using UnityEngine;

namespace Custom_Attributes
{
    [CustomPropertyDrawer(typeof(HorizontalLineAttribute))]
    public class HorizontalLineDrawer : DecoratorDrawer
    {
        public override float GetHeight()
        {
            HorizontalLineAttribute attr = (attribute as HorizontalLineAttribute)!;
            return attr.Padding + attr.Thickness + attr.Padding;
        }

        public override void OnGUI(Rect line)
        {
            HorizontalLineAttribute attr = (attribute as HorizontalLineAttribute)!;

            line.y += attr.Padding;
            line.height = attr.Thickness;

            Color color = EditorGUIUtility.isProSkin == attr.UseContrast ? new Color(0.7f, 0.7f, 0.7f) : new Color(0.3f, 0.3f, 0.3f);
            EditorGUI.DrawRect(line, color);
        }
    }
}