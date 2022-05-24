using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectShakeEffect : MonoBehaviour
{
    public GameObject GameObjectToShake;
    bool shaking = false;

    //loop - d�ng�
    private void FixedUpdate()
    {
        shakeGameObject(GameObjectToShake, 5, 3f, false);
    }

    void shakeGameObject(GameObject objectToShake, float shakeDuration, float decreasePoint, bool objectIs2D = false)
    {

        shaking = true;
        StartCoroutine(shakeGameObjectCOR(objectToShake, shakeDuration, decreasePoint, objectIs2D));
    }
    IEnumerator shakeGameObjectCOR(GameObject objectToShake, float totalShakeDuration, float decreasePoint, bool objectIs2D = false)
    {
        if (decreasePoint >= totalShakeDuration)
        {
            Debug.LogError("decreasePoint must be less than totalShakeDuration...Exiting");
            yield break; //Exit!
        }
        Transform objTransform = objectToShake.transform;
        Vector3 defaultPos = objTransform.position;
        Quaternion defaultRot = objTransform.rotation;

        float counter = 0f;

        //shake speef - sallama h�z�
        const float speed = 0.1f;

        //rotation - rotasyon
        const float angleRot = 0.1f;


        while (counter < totalShakeDuration)
        {
            counter += Time.deltaTime;
            float decreaseSpeed = speed;


            //objeyi salla

            {
                objTransform.position = defaultPos + UnityEngine.Random.insideUnitSphere * decreaseSpeed;
                objTransform.rotation = defaultRot * Quaternion.AngleAxis(UnityEngine.Random.Range(-angleRot, angleRot), new Vector3(1f, 1f, 1f));
            }
            yield return null;



        }
    }
}
    