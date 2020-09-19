using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle : MonoBehaviour
{
    public enum VehicleType {Car, Truck, Van};
     
    public VehicleType type;
    public float timeToExtinguish = 0.0f;
    public Sprite extinguishedSprite;
    public Sprite onFireSprite;
    public int vehicleScore;
}
