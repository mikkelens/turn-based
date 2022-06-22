using UnityEditor;
using UnityEngine;

namespace Custom_Attributes
{
    [CustomPropertyDrawer(typeof(NoteAttribute))]
    public class NoteDrawer : DecoratorDrawer
    {
        private NoteAttribute _attribute;
        private NoteAttribute Attribute => _attribute ??= (attribute as NoteAttribute)!;

        private float _mHeight;
        
        public override float GetHeight()
        {
            GUIStyle style = EditorStyles.helpBox;
            style.alignment = TextAnchor.MiddleLeft;
            style.wordWrap = true;
            style.padding = new RectOffset(10, 10, 10, 10);
            // style.fontSize = 12;

            _mHeight = style.CalcHeight(new GUIContent(Attribute.Text), Screen.width);
            return Attribute.Padding + _mHeight;
        }

        public override void OnGUI(Rect rect)
        {
            rect.height = _mHeight;
            rect.y += Attribute.Padding * 0.5f;
            rect.StandardizeWidth();
            EditorGUI.HelpBox(rect, Attribute.Text, Attribute.MessageType);
        }
    }
}