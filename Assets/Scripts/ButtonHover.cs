using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ButtonHover : MonoBehaviour
{
    // Start is called before the first frame update

    public TMP_Text txt;
    public Color hoverColor = new Color(238, 51, 51);
    void Awake()
    {
        txt =  GetComponent<TMP_Text>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (RectTransformUtility.RectangleContainsScreenPoint(txt.rectTransform, Input.mousePosition))
        {
            // Mouse cursor is hovering over the TextMeshPro UI component
            txt.color = hoverColor;
           
        }
        else
        {
            txt.color = Color.white;
        }
       
    }
}
