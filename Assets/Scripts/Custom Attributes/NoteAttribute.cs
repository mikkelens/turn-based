using System.Diagnostics.CodeAnalysis;
using UnityEditor;
using UnityEngine;

namespace Custom_Attributes
{
    [SuppressMessage("ReSharper", "FieldCanBeMadeReadOnly.Global")]
    [SuppressMessage("ReSharper", "ConvertToConstant.Global")]
    public class NoteAttribute : PropertyAttribute
    {
        public string Text;
        public float Padding = 5f;
        public MessageType MessageType = MessageType.None;
        
        public NoteAttribute(string text)
        {
            Text = text;
        }
    }
}