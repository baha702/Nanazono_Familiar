using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeMicrophone : MonoBehaviour
{
    [SerializeField] private Dropdown _micDropdown;
    [SerializeField] private bool isTest;

    public void Awake()
    {
        
        foreach (string device in Microphone.devices)
        {
            Debug.Log("Name: " + device);
            _micDropdown.options.Add(new Dropdown.OptionData { text = device });
            //_micDropdown.RefreshShownValue();
        }
        Debug.Log("選ばれたデバイス名は" + Microphone.devices[_micDropdown.value]);

    }

    public void SerectMicDevices()
    {
        if (Microphone.devices != null)
        {
            Microphone.End(deviceName: Microphone.devices[_micDropdown.value]);
            Debug.Log("録音停止");
        }
        Debug.Log("設定されたデバイス名は" + Microphone.devices[_micDropdown.value]);
        Microphone.Start(deviceName: Microphone.devices[_micDropdown.value], true, 10, 44100);

    }
    public void SerectMic(int value)
    {
        if (Microphone.devices != null)
        {
            Microphone.End(deviceName: Microphone.devices[value]);
            Debug.Log("録音停止");
        }
        Debug.Log("設定されたデバイス名は" + Microphone.devices[value]);
        Microphone.Start(deviceName: Microphone.devices[value], true, 10, 44100);

    }
    void Update()
    {
        //DropdownのValueが0のとき（赤が選択されているとき）
        for (int i = 0; i < Microphone.devices.Length; i++)
        {
            //Debug.Log(i + " : " + Microphone.devices[i]);
            //_micDropdown.options.Add(new Dropdown.OptionData { text = Microphone.devices[i] });

            if (_micDropdown.value == i)
            {
                StartCoroutine("SetDevice");
            }
        }
    }

    public IEnumerator SetDevice()
    {
        bool Exit = false;
        while (!Exit)
        {
            Debug.Log("一回繰り返す");
            if (Microphone.devices != null)
            {
                Microphone.End(deviceName: Microphone.devices[_micDropdown.value]);
                //Debug.Log("録音停止");
            }
            //Debug.Log("設定されたデバイス名は" + Microphone.devices[_micDropdown.value]);
            Microphone.Start(deviceName: Microphone.devices[_micDropdown.value], true, 10, 44100);
            Exit = true;
        }

        yield break;
    }
}