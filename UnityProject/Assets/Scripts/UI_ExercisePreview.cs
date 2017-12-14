using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using System.IO;

public class UI_ExercisePreview : MonoBehaviour {

    public bool Initialize = false;
    public GameObject UserBlobManager;
    public GameObject UIManager;
    public GameObject ExerciseNameText;
    public GameObject WeightText;
    public GameObject RepsText;
    public GameObject MissingAnimationImage;
    private AnimationClip[] ExerciseAnimations;
    public GameObject MaleModel;
    public GameObject ModelRoot;
    public int CurrentExerciseIndex = 0;
    public ExerciseData CurrentExercise = new ExerciseData();

    void Awake()
    {
        UserBlobManager = GameObject.Find("UserBlob_Prefab");
        UIManager = GameObject.Find("UI_Manager_Prefab");
    }

    // Use this for initialization
    void Start()
    {
        ExerciseAnimations = Resources.LoadAll<AnimationClip>("UI/ExerciseAnimations");
    }

    // Update is called once per frame
    void Update()
    {
        if (Initialize)
        {
            Init();
        }

#if UNITY_IOS
    // update touch for rotating the model
    if(Input.touchCount == 1)
    {
        float h = 0f;
        float horozontalSpeed = 0.5f;
        Touch touch = Input.GetTouch(0);
        h = horozontalSpeed * touch.deltaPosition.x;
        ModelRoot.transform.Rotate(0, -h, 0, Space.World);
    }
#endif
    }

    public void Init()
    {
        Initialize = false;
        MissingAnimationImage.SetActive(false);
        ModelRoot.SetActive(true);
        CurrentExerciseIndex = UserBlobManager.GetComponent<UserBlobManager>().CurrentExerciseIndex;
        CurrentExercise = UserBlobManager.GetComponent<UserBlobManager>().UserExerciseData.Exercise[CurrentExerciseIndex];
        ExerciseNameText.GetComponent<Text>().text = CurrentExercise.Name;
        WeightText.GetComponent<Text>().text = CurrentExercise.Weight.ToString();
        RepsText.GetComponent<Text>().text = CurrentExercise.Reps.ToString();

        GetExerciseAnimation();

#if UNITY_IOS
                ModelRoot.transform.rotation = new Quaternion(0, 0, 0, 0);
                ModelRoot.transform.Rotate(0, 0, 0, Space.World);
#endif
    }

    public void GetExerciseAnimation()
    {
        // try to load the animation from resources
        AnimationClip ResourcesMotion = LoadExerciseAnimationsFromResources();
        if (ResourcesMotion != null)
        {
            MaleModel.SetActive(true);
            MissingAnimationImage.SetActive(false);
            MaleModel.GetComponent<Animation>().AddClip(ResourcesMotion, ResourcesMotion.name);
            MaleModel.GetComponent<Animation>().clip = ResourcesMotion;
            /*
            if (CurrentExercise.Reps > 0)
            {
                float AnimationSpeed = (float)MaleModel.GetComponent<Animation>().clip.length / ((float)CurrentExercise.Time / (float)CurrentExercise.Reps);
                Animation anim = MaleModel.GetComponent<Animation>();
                foreach (AnimationState state in anim)
                {
                    state.speed = AnimationSpeed;
                }
            }
            */
            MaleModel.GetComponent<Animation>().Play();
            MaleModel.SetActive(true);
        }
        else
        {
            MissingAnimationImage.SetActive(true);
            AnimationClip restAnimation = GetClipByName("Rest_Time");
            MaleModel.GetComponent<Animation>().AddClip(restAnimation, restAnimation.name);
            MaleModel.GetComponent<Animation>().clip = restAnimation;
            MaleModel.GetComponent<Animation>().Play();
            MaleModel.SetActive(false);
        }
    }

    public AnimationClip GetClipByName(string clipName)
    {
        for (int i = 0; i < ExerciseAnimations.Length; i++)
        {
            if (ExerciseAnimations[i].name == clipName)
            {
                return ExerciseAnimations[i];
            }
        }
        return ExerciseAnimations[0];
    }

    private AnimationClip LoadExerciseAnimationsFromResources()
    {
        // try to load animation from resources
        string ResourcesAnimationFileName = "UI/ExerciseAnimations/";
        ResourcesAnimationFileName += CurrentExercise.Name.ToCharArray(0, 1)[0].ToString().ToUpper() + "/";
        ResourcesAnimationFileName += CurrentExercise.Name;
        ResourcesAnimationFileName = ResourcesAnimationFileName.Replace(" ", "_");
        AnimationClip ResoucesAnimation = Resources.Load<AnimationClip>(ResourcesAnimationFileName);
        //return null;
        return ResoucesAnimation;
    }
}
