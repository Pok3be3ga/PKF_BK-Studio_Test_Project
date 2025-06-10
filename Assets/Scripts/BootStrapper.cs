using UnityEngine;

public class BootStrapper : MonoBehaviour
{
    [SerializeField] private ObjectsData objectsData;
    [SerializeField] private AlfaButtons alfaButtons;
    [SerializeField] private ObjectCellsSettings cellsSettings;

    public void Init()
    {
        objectsData.Init(cellsSettings);
        alfaButtons.Init(objectsData);
        cellsSettings.Init(objectsData);
    }
}
