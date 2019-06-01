using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    GameObject counterTex;
    public GameObject timeLogText;
    public GameObject cubePrefab;



    // Use this for initialization
    void Start()
    {
        counterTex = GameObject.Find("CounterText");

        //授業中に指示があれば以下のコメントアウトを解除してください
        var tempBehaviour = GameObject.Find("ClassTestObject").GetComponent<DummyClass>();
        if (tempBehaviour != null)
        {
            Debug.Log(tempBehaviour.GetType());
        }

#if UNITY_ANDROID
        Debug.Log("we are android");
#elif UNITY_EDITOR
        Debug.Log("we are editor");
#endif





    }

    // Update is called once per frame
    void Update()
    {
        //1.インスペクターで設定する場合の使用例
        timeLogText.GetComponent<TextMesh>().text = Time.realtimeSinceStartup.ToString("F2");


        var cubeNumber = GameObject.FindGameObjectsWithTag("Respawn").Length;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            var tempObj = Instantiate(cubePrefab);
            tempObj.transform.position = new Vector3(Random.Range(-5, 5), Random.Range(-2, 2), 4);
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            ////一つだけをとる場合（複数ある場合はどれが取得できるか保証されない）
            //var cube = GameObject.FindGameObjectWithTag("Respawn");
            //cube.GetComponent<Renderer>().material.color = Color.green;

            //複数のGameObjectを配列で取得する、という使い方がよくあるパターン
            var cubes = GameObject.FindGameObjectsWithTag("Respawn");
            foreach (var eachCube in cubes)
            {
                //                eachCube.SendMessage("ChangeColor");
                eachCube.GetComponent<Renderer>().material.color = Color.red;
            }
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            var cubes = GameObject.FindGameObjectsWithTag("Respawn");
            foreach (var eachCube in cubes)
            {
                Destroy(eachCube);
            }
        }




        //2.Findをつかい、名前で探す場合の使用例
        counterTex.GetComponent<Text>().text = "current cubes: " + cubeNumber.ToString();

        ////以下のようにUpdateの中にまとめて書いても動きますが、処理が遅くなるので推奨しません
        //GameObject.Find("CounterText").GetComponent<Text>().text = "よくない例\n cubes: " + cubeNumber;

    }


}
