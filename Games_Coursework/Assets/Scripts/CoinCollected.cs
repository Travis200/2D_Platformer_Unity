using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script simply stores a boolean value associated with each coinin respect to if it has been collected yet or not. This is used to stop the
/// same coin being collected twice. 
/// </summary>
public class CoinCollected : MonoBehaviour
{
    public bool isCollected = false;
}
