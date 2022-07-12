using UnityEngine;

namespace Helpers
{
    public class HelperTest : MonoBehaviour
    {
        void Test()
        {
            Vector2 vector = Vector2.zero;
            vector.SetX(1);

            transform.position.SetX(1f);
        }
    }
}