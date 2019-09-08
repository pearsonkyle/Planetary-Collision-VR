using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class frameControl : MonoBehaviour
{
    public List<GameObject> Children;
    public int index = 0;
    public bool Animate = false;
    public float AnimationSpeed = 0.25f;
    float animTime = 0f;
    public Material masterMat;

    void setMaterial(GameObject obj)
    {
        foreach (Transform child in obj.transform)
        {
            child.GetComponent<MeshRenderer>().material = masterMat;
        }
    }
    // Start is called before the first frame update
    void setAlpha(GameObject obj, float alpha)
    {
        foreach(Transform child in obj.transform)
        {
            child.GetComponent<MeshRenderer>().material.color = new Color(1.0f, 1f, 1.0f, alpha);
        }
    }
    void Start()
    {
         foreach (Transform child in transform)
         {
             Children.Add(child.gameObject);
             setMaterial(child.gameObject); 
             setAlpha(child.gameObject, 0f); 
         }
         UpdateAlpha();
    }

    void UpdateAlpha()
    {
        for (int i = 0; i < Children.Count; i++)
        {
            if (i == index)
            {
                setAlpha(Children[i], 1f);
            }
            else
            {
                setAlpha(Children[i], 0f);
            }
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        { 
            index -= 1;
            if (index < 0) index = Children.Count - 1;
            UpdateAlpha();
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            index += 1;
            if (index > Children.Count - 1) index = 0;
            UpdateAlpha();
        }

        if( (Time.time > animTime + AnimationSpeed) & Animate)
        {
            index += 1;
            if (index > Children.Count - 1) index = 0;
            UpdateAlpha();
            animTime = Time.time; 
        }
    }

}
