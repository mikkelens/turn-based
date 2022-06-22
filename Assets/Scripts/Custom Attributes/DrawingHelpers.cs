using System;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;

namespace Custom_Attributes
{
    [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
    public static class DrawingHelpers
    {
        public const float Offset = 5f;
        public static void StandardizeWidth(this ref Rect rect)
        {
            rect.width -= Offset * 2f;
            rect.x += Offset;
        }
    }
}