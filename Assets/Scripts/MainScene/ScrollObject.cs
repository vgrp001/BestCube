using UnityEngine;

public class ScrollObject : MonoBehaviour
{
    // this script scroll menu items off screen and back
    public float SpeedScrolling = 20f, CheckPosition = 0f;
    private RectTransform RectTransformObject;
    void Start()
    {
        RectTransformObject = GetComponent<RectTransform>();
    }
    void Update()
    {
        if(RectTransformObject.offsetMin.y != CheckPosition)
        {
            RectTransformObject.offsetMin += new Vector2(RectTransformObject.offsetMin.x, SpeedScrolling);
            RectTransformObject.offsetMax += new Vector2(RectTransformObject.offsetMax.x, SpeedScrolling);
        }
    }
}
