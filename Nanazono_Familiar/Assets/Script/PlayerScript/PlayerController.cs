using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    public GameObject Player;
    public GameObject Camera;
    public float speed;
    private Transform PlayerTransform;
    private Transform CameraTransform;
    [SerializeField] float ANGLE_LIMIT_UP = 45f;
    [SerializeField] float ANGLE_LIMIT_DOWN = -45f;
    [SerializeField] float ANGLE_LIMIT_RIGHT = 60f;
    [SerializeField] float ANGLE_LIMIT_LEFT = 60f;
    [SerializeField] GameObject targetObj;
    Vector3 targetPos;
    Vector3 roteuler;

    // Use this for initialization
    void Start()
    {

        PlayerTransform = transform.parent;
        // CameraTransform = GetComponent<Transform>();
        targetPos = targetObj.transform.position;
        roteuler = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, 0f);

    }

    // Update is called once per frame
    void Update()
    { 

        //float X_Rotation = Input.GetAxis("Mouse X");
        //float Y_Rotation = Input.GetAxis("Mouse Y");
        // PlayerTransform.transform.Rotate(0, X_Rotation, 0);
        //CameraTransform.transform.Rotate(-Y_Rotation, 0, 0);
        rotateCameraAngle();

        float angleDir = PlayerTransform.transform.eulerAngles.y * (Mathf.PI / 180.0f);
        Vector3 dir1 = new Vector3(Mathf.Sin(angleDir), 0, Mathf.Cos(angleDir));
        Vector3 dir2 = new Vector3(-Mathf.Cos(angleDir), 0, Mathf.Sin(angleDir));
     

        if (Input.GetKey(KeyCode.W))
        {
            PlayerTransform.transform.position += dir1 * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            PlayerTransform.transform.position += dir2 * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            PlayerTransform.transform.position += -dir2 * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            PlayerTransform.transform.position += -dir1 * speed * Time.deltaTime;
        }

    }

    private void rotateCameraAngle()
    {
        // targetの移動量分、自分（カメラ）も移動する
        transform.position += targetObj.transform.position - targetPos;
        targetPos = targetObj.transform.position;

        // マウスの右クリックを押している間
        // if (Input.GetMouseButton(2)) {

        // マウスの移動量
        float mouseInputX = Input.GetAxis("Mouse X");
        float mouseInputY = Input.GetAxis("Mouse Y");

        // targetの位置のY軸を中心に、回転（公転）する
        transform.RotateAround(targetPos, Vector3.up, mouseInputX * Time.deltaTime * 300f);       

        // カメラの垂直移動（※角度制限なし）
        //transform.RotateAround(targetPos, transform.right, mouseInputY * Time.deltaTime * 300f);

        //カメラの垂直移動(角度制限あり)
        roteuler = new Vector3(Mathf.Clamp(roteuler.x - mouseInputY * Time.deltaTime * 200f,
            ANGLE_LIMIT_DOWN, ANGLE_LIMIT_UP),
            transform.localEulerAngles.y, 0f);
        transform.localEulerAngles = roteuler;

        }
    }
