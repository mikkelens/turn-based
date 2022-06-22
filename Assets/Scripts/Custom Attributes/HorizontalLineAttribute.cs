using System.Diagnostics.CodeAnalysis;
using UnityEngine;

namespace Custom_Attributes
{
    [SuppressMessage("ReSharper", "FieldCanBeMadeReadOnly.Global")]
    [SuppressMessage("ReSharper", "ConvertToConstant.Global")]
    public class HorizontalLineAttribute : PropertyAttribute
    {
        public float Thickness = 2f;
        public float Padding = 1f;
        public bool UseContrast = false;

        public HorizontalLineAttribute()
        {
            
        }
    }
}