using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    private static Manager instance = new Manager();

    public static Manager Instance => instance;

    public int penize = 1000;
    public int drevo = 1000;


}
