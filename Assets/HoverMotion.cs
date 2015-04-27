using UnityEngine;
using System.Collections;

public class HoverMotion : MonoBehaviour 
{
    public float hoverMagnitude = 1.0f;
    public float hoverTop = 1.0f;
    public float hoverBottom = -1.0f;

    private bool goingDown = false;

    void Update()
    {
        if (goingDown)
        {
            Vector3 deltaHover = new Vector3(0.0f, Time.deltaTime * hoverMagnitude, 0.0f);

            GetComponent<Transform>().position -= deltaHover;

            if (GetComponent<Transform>().position.y > hoverBottom)
                goingDown = false;
        }
        else
        {
            Vector3 deltaHover = new Vector3(0.0f, Time.deltaTime * hoverMagnitude, 0.0f);
            GetComponent<Transform>().position += deltaHover;

            if (GetComponent<Transform>().position.y > hoverTop)
                goingDown = true;
        }
    }
}
