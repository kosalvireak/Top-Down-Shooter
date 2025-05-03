using UnityEngine;

public enum AxelType { Front, Back }

[RequireComponent(typeof(WheelCollider))]
public class Car_Wheel : MonoBehaviour
{
    public AxelType axelType;
    public WheelCollider cd { get; private set; }
    public TrailRenderer trail { get; private set; }
    public GameObject model;

    private float defaultSideStiffnes;

    private void Awake()
    {
        cd = GetComponent<WheelCollider>();
        trail = GetComponentInChildren<TrailRenderer>();

        trail.emitting = false;

        if (model == null)
            model = GetComponentInChildren<MeshRenderer>().gameObject;
    }

    public void SetDefaultStiffnes(float newValue)
    {
        defaultSideStiffnes = newValue;
        RestoreDefaultStiffnes();
    }

    public void RestoreDefaultStiffnes()
    {
        WheelFrictionCurve sidewayFriction = cd.sidewaysFriction;

        sidewayFriction.stiffness = defaultSideStiffnes;
        cd.sidewaysFriction = sidewayFriction;
    }
}
