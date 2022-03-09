using UnityEngine;

namespace ArBird.Pipes
{
    public class PipeBlock : MonoBehaviour
    {
        [SerializeField] private Pipe _top;
        [SerializeField] private Pipe _bottom;

        public void SetCenter(float center, float minTop, float maxTop, float spacing)
        {
            center = Mathf.Clamp(center, minTop + 0.5f, maxTop - spacing - 0.5f);

            _top.transform.localPosition = Vector3.up * maxTop;
            _top.SetSize(maxTop - center - spacing);
            _bottom.SetSize(center - spacing);
        }
    }
}
