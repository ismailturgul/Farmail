using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Highlight_Controller : MonoBehaviour
{

    [SerializeField] GameObject highlighter;

    GameObject current_Target;

    public void Highlight(GameObject target)
    {
        if(current_Target == target)
        {
            return;
        }
        current_Target = target;
        Vector3 position = target.transform.position;
        Highlight(position);
    }

    public void Highlight(Vector3 position)
    {
        highlighter.SetActive(true);
        highlighter.transform.position = position;
    }

    public void Hide()
    {
        current_Target = null;
        highlighter.SetActive(false);
    }
}
