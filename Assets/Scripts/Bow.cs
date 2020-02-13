using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems; 

public class Bow : MonoBehaviour {

    public float Tension;
    private bool _pressed;


    public Transform RopeTransform;

    public Vector3 RopeNearLocalPosition;
    public Vector3 RopeFarLocalPosition;

    public AnimationCurve RopeReturnAnimation;

    public float ReturnTime;

    public Arrow CurrentArrow;
    private int ArrowIndex = 0;
    public float ArrowSpeed;

    public AudioSource BowTensionAudioSource;
    public AudioSource BowWhistlingAudioSource;

    public Arrow[] ArrowsPool;
    public GameObject PhantomArrowObj;

    // Use this for initialization
    void Start () {
        RopeNearLocalPosition = RopeTransform.localPosition;
        PhantomArrowObj.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            _pressed = true;

            ArrowIndex++;
            if (ArrowIndex >= ArrowsPool.Length)
            {
                ArrowIndex = 0;
            }
            CurrentArrow = ArrowsPool[ArrowIndex];

            CurrentArrow.SetToRope(RopeTransform);

            BowTensionAudioSource.pitch = Random.Range(0.8f, 1.2f);
            BowTensionAudioSource.Play();

        }

      
    if (Input.GetMouseButtonUp(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            _pressed = false;
            PhantomArrowObj.SetActive(false);
            StartCoroutine(RopeReturn());
            CurrentArrow.Shot(ArrowSpeed * Tension);

            Tension = 0;

            BowTensionAudioSource.Stop();

            BowWhistlingAudioSource.pitch = Random.Range(0.8f, 1.2f);
            BowWhistlingAudioSource.Play();

        }
        if (_pressed)
        {
            if (Tension < 1f)
            {
                Tension += Time.deltaTime;
            }
            RopeTransform.localPosition = Vector3.Lerp(RopeNearLocalPosition, RopeFarLocalPosition, Tension);
        }

        if (Tension >= 1f && _pressed)
        {
            PhantomArrowObj.SetActive(true);
        }


    }
    IEnumerator RopeReturn() {
        Vector3 startLocalPosition = RopeTransform.localPosition;
        for (float f = 0; f < 1f; f += Time.deltaTime / ReturnTime) {
            RopeTransform.localPosition = Vector3.LerpUnclamped(startLocalPosition, RopeNearLocalPosition, RopeReturnAnimation.Evaluate(f));
            yield return null;
        }
        RopeTransform.localPosition = RopeNearLocalPosition;
    }

}
