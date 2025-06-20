using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlfaButtons : MonoBehaviour
{
    private List<Button> _buttons = new List<Button>();
    public void Init()
    {
        foreach (Transform child in transform)
        {
            if (child.GetComponent<Button>())
            {
                _buttons.Add(child.GetComponent<Button>());
            }
        }
        for (int i = 0; i < _buttons.Count; i++)
        {
            int idx = i;
            _buttons[i].onClick.AddListener(() => { ChangeAlfa(idx); });
        }
    }
    private void ChangeAlfa(int idx)
    {
        for (int i = 0; i < S_ObjectsSettings.Instance.GetSelectObjects().Count; i++)
        {
            S_ObjectsSettings.Instance.GetSelectObjects()[i].GetComponent<MeshRenderer>().material.color = _buttons[idx].image.color;
        }

    }

}
