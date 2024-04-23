using UnityEngine;


public class Torch : Item
{
    // Other properties and methods specific to the Torch class...

    protected override void Pickup()
    {
        base.Pickup();

        Transform lightTransform = player.transform.Find("Light");
        UnityEngine.Rendering.Universal.Light2D lightComponent = lightTransform.GetComponent<UnityEngine.Rendering.Universal.Light2D>();

        if (lightComponent != null)
        {
            lightComponent.intensity = 1f;
        }
        else
        {
            Debug.Log("Player light is null!");
        }
    }

    public override void Use()
    {

    }
}