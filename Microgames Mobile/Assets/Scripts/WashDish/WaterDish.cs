using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterDish : MonoBehaviour
{
    // Start is called before the first frame update

    public Dish dish;
    private void OnParticleTrigger()
    {
        dish.Fade();
    }
}
