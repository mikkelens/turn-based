using UnityEngine;

namespace Helpers
{
    public static class VectorHelpers
    {
    #region Vector2
        public static Vector2 SetX(this Vector2 vector, float value)
        {
            vector.x = value;
            return vector;
        }
        public static Vector2 SetY(this Vector2 vector, float value)
        {
            vector.y = value;
            return vector;
        }

        public static Vector2 ClampBetween(this Vector2 vector, Vector2 lower, Vector2 upper)
        {
            vector.x =
                vector.x < lower.x ? lower.x :
                vector.x > upper.x ? upper.x :
                vector.x;
            vector.y =
                vector.y < lower.y ? lower.y :
                vector.y > upper.y ? upper.y :
                vector.y;
            return vector;
        }
    #endregion
        
    #region Vector3
        public static Vector3 SetX(this Vector3 vector, float value)
        {
            vector.x = value;
            return vector;
        }
        public static Vector3 SetY(this Vector3 vector, float value)
        {
            vector.y = value;
            return vector;
        }
        public static Vector3 SetZ(this Vector3 vector, float value)
        {
            vector.z = value;
            return vector;
        }
        
        public static Vector3 ClampBetween(this Vector3 vector, Vector3 lower, Vector3 upper)
        {
            vector.x =
                vector.x < lower.x ? lower.x :
                vector.x > upper.x ? upper.x :
                vector.x;
            vector.y =
                vector.y < lower.y ? lower.y :
                vector.y > upper.y ? upper.y :
                vector.y;
            vector.z =
                vector.z < lower.z ? lower.z :
                vector.z > upper.z ? upper.z :
                vector.z;
            return vector;
        }
    #endregion
    }
}
