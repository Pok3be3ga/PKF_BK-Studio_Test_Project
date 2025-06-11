using System.Collections.Generic;
using Exoa.Cameras.Demos;
using UnityEngine;

public sealed class S_ObjectsSettings : MonoBehaviour
{
    public static S_ObjectsSettings Instance;

    private ObjectCellsSettings _objectCellsSettings;
    private List<Object> _objects = new List<Object>();//Все объекты которые есть на сцене
    private List<Object> _selectObjects = new List<Object>();//Объекты выбранные пользователем
    private void Awake()
    {
        Instance = this;
    }
    public void Init(ObjectCellsSettings objectCellsSettings)
    {
        //Добавляем дочерние объекты в список
        foreach (Transform child in transform)
        {
            if (child.gameObject.activeSelf)
            {
                _objects.Add(child.GetComponent<Object>());
            }
        }
        _objectCellsSettings = objectCellsSettings;
    }


    //Обьекты на сцене
    public List<Object> GetListObjects()
    {
        return _objects;
    }
    public Object GetObject(int index)
    {
        return _objects[index];
    }
    //Выбранные Объекты
    public void SelectObject(Object go)
    {

        if (_selectObjects.Contains(go))
        {

        }
        else
        {
            _selectObjects.Add(go);
        }
    }
    public void RemoveSelectObject(Object go)
    {
        _selectObjects.Remove(go);
    }
    public List<Object> GetSelectObjects()
    {
        return _selectObjects;
    }
    //Подсветить кнопку выбранного объекта
    public void HightLightCell(Object go)
    {
        int index = _objects.IndexOf(go);
        _objectCellsSettings.HightLightCell(index);
    }
}
