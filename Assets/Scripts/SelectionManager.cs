using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    public float interactionDistance;

    public static int openDoor;
    private bool gotKey;
    private int limit1;
    private int limit2;

    private int redOpenDoor;

    public float mainDoorSpeed;
    public float cabinetDoorsSpeed;

    public static bool lever2;

    public bool lever3;

    public GameObject canvas;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, interactionDistance))
            {
                var selection = hit.transform;
                var selectionRenderer = selection.GetComponent<Renderer>();
                if (selectionRenderer != null)
                {
                    print(selectionRenderer.name);

                    if (selectionRenderer.name == "doorWing" && openDoor == 1 && lever3)
                    {
                        openDoor = 2;
                        canvas.GetComponent<PauseMenu>().panel5Open();
                    }


                    if ((selectionRenderer.name == "DoorLeft" || selectionRenderer.name == "DoorRight") && redOpenDoor == 0)
                    {
                        redOpenDoor = 1;
                        GameObject.Find("DoorLeft").GetComponent<BoxCollider>().isTrigger = true;
                        GameObject.Find("DoorRight").GetComponent<BoxCollider>().isTrigger = true;
                    }

                    if (selectionRenderer.name == "sm_key_01" && openDoor == 0 && lever2)
                    {
                        selection.gameObject.SetActive(false);
                        openDoor = 1;
                    }

                    if (selectionRenderer.name == "FirstAidKit_Biohazard" && redOpenDoor > 0 && lever2)
                    {
                        selection.gameObject.SetActive(false);
                        lever3 = true;
                    }

                    
                }
            }
        }

        if (openDoor == 2)
        {
            GameObject pv = GameObject.Find("doorWing");
            GameObject.Find("doorWing").transform.rotation = Quaternion.Euler(new Vector3(pv.transform.rotation.eulerAngles.x, pv.transform.rotation.eulerAngles.y + (mainDoorSpeed * 0.5f), pv.transform.rotation.eulerAngles.z));
            limit1++;
        }

        if (limit1 > 200 / mainDoorSpeed && openDoor == 2)
        {
            openDoor = 3;
            GameObject.Find("doorWing").GetComponent<BoxCollider>().isTrigger = true;
            limit1 = 0;
        }

        if (redOpenDoor == 1)
        {
            GameObject pv = GameObject.Find("DoorLeft");
            GameObject.Find("DoorLeft").transform.rotation = Quaternion.Euler(new Vector3(pv.transform.rotation.eulerAngles.x, pv.transform.rotation.eulerAngles.y + (cabinetDoorsSpeed * 0.1f), pv.transform.rotation.eulerAngles.z));
            pv = GameObject.Find("DoorRight");
            GameObject.Find("DoorRight").transform.rotation = Quaternion.Euler(new Vector3(pv.transform.rotation.eulerAngles.x, pv.transform.rotation.eulerAngles.y - (cabinetDoorsSpeed * 0.16f), pv.transform.rotation.eulerAngles.z));
            limit2++;
        }

        if (limit2 > 800 / cabinetDoorsSpeed && redOpenDoor == 1)
        {
            redOpenDoor = 2;
            limit2 = 0;
        }
    }
}
