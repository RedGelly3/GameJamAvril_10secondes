using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public double time;
    public List<GameObject> transformations;
    public GameObject nextTranformation;
    public GameObject currentTransformation;
    private void Awake()
    {
        time = 10.0f;
        Cursor.visible = false;
        StartCoroutine(LaunchTime());
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    IEnumerator LaunchTime()
    {
        float oldTime = Time.realtimeSinceStartup;
        while (true)
        {   
           
            time -= Time.realtimeSinceStartup - oldTime;
            oldTime = Time.realtimeSinceStartup;

            if (time <= 0.0f)
            {
                TransformationRoulette();
                time = 10.0f;
            }
            else if (time <= 5.0f)
            {
                TransformationRoulette();
                time = 10.0f;
            }
            yield return new WaitForSeconds(0.01f);
        }
    }

    void Tranformation()
    {


    }
    void TransformationRoulette()
    {   
        GameObject transformationActuelle = FindTransformationActuelle(gameObject);
        GameObject newTransformation = Instantiate(transformations[0], gameObject.transform.position, Quaternion.identity);
        Vector2 playerVelocity = transformationActuelle.GetComponent<Rigidbody2D>().velocity;
        do
        {
            Destroy(newTransformation);
            double dice = Random.Range(0f, 100f);
            // set new prefab et lui donner la transform player
            if (dice > 50)
            {

                newTransformation = Instantiate(transformations[0], gameObject.transform.position, Quaternion.identity);

            }
            else
            {
                newTransformation = Instantiate(transformations[1], gameObject.transform.position, Quaternion.identity);
            }
            
        } while (GetObjectNameWithoutCareForClone(transformationActuelle) == GetObjectNameWithoutCareForClone(newTransformation));
        Destroy(transformationActuelle);
        newTransformation.transform.parent = gameObject.transform;
        if (GetObjectNameWithoutCareForClone(newTransformation) == "Sanglier")
        {
            newTransformation.GetComponent<ComportementSanglier>().player = gameObject.transform;
        }
        else if (GetObjectNameWithoutCareForClone(newTransformation) == "Lapin")
        {
            newTransformation.GetComponent<ComportementLapin>().player = gameObject.transform;
        }
        else if (GetObjectNameWithoutCareForClone(newTransformation) == "Escargot")
        {
            //newTransformation.GetComponent<ComportementEscargot>().player = gameObject.transform;
        }
        else if (GetObjectNameWithoutCareForClone(newTransformation) == "Herisson")
        {
            //newTransformation.GetComponent<ComportementHerisson>().player = gameObject.transform;
        }
        newTransformation.transform.tag = "Transformation";
        newTransformation.GetComponent<Rigidbody2D>().velocity += playerVelocity;


    }

    public static string GetObjectNameWithoutCareForClone(GameObject gameObject) {
        string name = gameObject.transform.name;
        return name.Split('(')[0];    
    }
    public static GameObject FindTransformationActuelle(GameObject parent)
    {
        for (int i = 0; i < parent.transform.childCount; i++)
        {
            if (parent.transform.GetChild(i).gameObject.tag == "Transformation")
            {
                return parent.transform.GetChild(i).gameObject;
            }

        }
        print("error transformationActuelle not found");
        return null;
    }
}