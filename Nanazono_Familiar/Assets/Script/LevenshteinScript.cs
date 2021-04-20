﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevenshteinScript : MonoBehaviour
{
    public KotodamariScript text;
    public string enemyName;
    public float Ruijido;

    // Start is called before the first frame update
    void Start()
    {
        enemyName = "ジョンソン";
    }

    // Update is called once per frame
    void Update()
    {
        if (text.Levenflag == true)
        {
            //LevenshteinDistance(text.inputText, enemyName);
            Ruijido = LevenshteinRate(text.inputText, enemyName);
            Debug.Log(Ruijido);
            text.Levenflag = false;
        }
    }

    public static int LevenshteinDistance(string str1, string str2)
    {
        int n1 = 0;
        int n2 = str2.Length + 2;
        int[] d = new int[n2 << 1];

        for (int i = 0; i < n2; i++)
        {
            d[i] = i;
        }

        d[n2 - 1]++;
        d[d.Length - 1] = 0;

        for (int i = 0; i < str1.Length; i++)
        {
            d[n2] = i + 1;

            for (int j = 0; j < str2.Length; j++)
            {
                int v = d[n1++];

                if (str1[i] == str2[j])
                {
                    v--;
                }

                v = (v < d[n1]) ? v : d[n1];
                v = (v < d[n2]) ? v : d[n2];

                d[++n2] = ++v;
            }

            n1 = d[n1 + 1];
            n2 = d[n2 + 1];
        }

        return d[d.Length - n2 - 2];
    }

    public static float LevenshteinRate(string str1, string str2)
    {
        int len1 = (str1 != null) ? str1.Length : 0;
        int len2 = (str2 != null) ? str2.Length : 0;

        if (len1 > len2)
        {
            int tmp = len1;
            len1 = len2;
            len2 = tmp;
        }

        if (len1 == 0)
        {
            return (len2 == 0) ? 0.0f : 1.0f;
        }

        return LevenshteinDistance(str1, str2) / (float)len2;
    }

}