using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    public float maxDistance; // 1 works fine.
    private bool openDoor;
    private int limit;

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
                    if (selectionRenderer.name == "doorWing")
                    {
                        openDoor = true;
                    }
                }
            }
        }

        if (openDoor)
        {
            GameObject pv = GameObject.Find("doorWing");
            GameObject.Find("doorWing").transform.rotation = Quaternion.Euler(new Vector3(pv.transform.rotation.eulerAngles.x, pv.transform.rotation.eulerAngles.y + 1, pv.transform.rotation.eulerAngles.z));
            limit++;
        }

        if (limit > 100)
        {
            openDoor = false;
            GameObject.Find("doorWing").GetComponent<BoxCollider>().isTrigger = true;
        }
    }
}
