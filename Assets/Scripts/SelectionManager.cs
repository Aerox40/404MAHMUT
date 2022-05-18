using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    public float maxDistance; // 1 works fine.

    private bool openDoor;
    private int limit;

    private bool redOpedDoor;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, maxDistance))
            {
                var selection = hit.transform;
                var selectionRenderer = selection.GetComponent<Renderer>();
                if (selectionRenderer != null)
                {
                    print(selectionRenderer.name);

                    if (selectionRenderer.name == "doorWing")
                    {
                        openDoor = true;
                    }

                    if (selectionRenderer.name == "DoorLeft" || selectionRenderer.name == "DoorRight")
                    {
                        print("HORSE");
                        redOpedDoor = true;
                        GameObject.Find("DoorLeft").GetComponent<BoxCollider>().isTrigger = true;
                        GameObject.Find("DoorRight").GetComponent<BoxCollider>().isTrigger = true;
                    }
                }
            }
        }

        if (openDoor)
        {
            GameObject pv = GameObject.Find("doorWing");
            GameObject.Find("doorWing").transform.rotation = Quaternion.Euler(new Vector3(pv.transform.rotation.eulerAngles.x, pv.transform.rotation.eulerAngles.y + 0.5f, pv.transform.rotation.eulerAngles.z));
            limit++;
        }

        if (limit > 200 && openDoor)
        {
            openDoor = false;
            GameObject.Find("doorWing").GetComponent<BoxCollider>().isTrigger = true;
            limit = 0;
        }

        if (redOpedDoor)
        {
            GameObject pv = GameObject.Find("DoorLeft");
            GameObject.Find("DoorLeft").transform.rotation = Quaternion.Euler(new Vector3(pv.transform.rotation.eulerAngles.x, pv.transform.rotation.eulerAngles.y + 0.1f, pv.transform.rotation.eulerAngles.z));
            pv = GameObject.Find("DoorRight");
            GameObject.Find("DoorRight").transform.rotation = Quaternion.Euler(new Vector3(pv.transform.rotation.eulerAngles.x, pv.transform.rotation.eulerAngles.y - 0.16f, pv.transform.rotation.eulerAngles.z));
            limit++;
        }

        if (limit > 800 && redOpedDoor)
        {
            redOpedDoor = false;
            limit = 0;
        }
    }
}
