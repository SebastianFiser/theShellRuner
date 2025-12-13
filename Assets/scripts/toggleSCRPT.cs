using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using System.ComponentModel.DataAnnotations;
using System.Drawing;

public class toggleSCRPT : MonoBehaviour, IPointerClickHandler
{
    [Header("Slider Setup")]
    [SerializeField, Range(0,1f)] private float sliderValue;
    public bool CurrentValue { get; private set; }
    private Slider _slider;

    [Header("animations")]
    [SerializeField, Range(0,1f)] private float animationDuration = 0.5f;
    [SerializeField] private AnimationCurve slideEase =
        AnimationCurve.EaseInOut(0, 0, 1, 1);
    private Coroutine _currentAnimation;

    [Header("Events")]
    [SerializedField] private UnityObject OnToggleOn;
    [SerializedField] private UnityObject OnToggleOff;

    private ToggleSwitchGroupManager _toggleSwitchGroupManager;

    protected void OnValidate()
    {
        SetupToggleComponents();

        _sliderValue = sliderValue;

    }

    private void SetupSliderComponents()
    {
        if(_slider != null)
            return;

        SetupSliderComponents();
    }

    private void SetupSliderComponent()
    {
        _slider = GetComponentInChildren<Slider>();

        if(_slider == null)
        {
            Debug.LogError("No Slider component found in children.");
        }

        _slider.interactable = false;
        var SliderColours = _slider.colours;
        SliderColours.disabledcolour = Color.white;
        _slider.colours = SliderColours;
        _slider.transition = Selectable.Transition.None;
    }

    public void SetupToggleGroupManager(ToggleSwitchGroupManager manager)
    {
        _toggleSwitchGroupManager = manager;
    }

    private void Awake()
    {
        SetupToggleComponents();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Toggle();
    }

    private void Toggle()
    {
        if (_toggleSwitchGroupManager != null)
            _toggleSwitchGroupManager.ToggleGroup(this);
        
        else
            SetStateAndStartAnimaion(!CurrentValue);
    }    

    public void ToggleByGroupManager(bool vauleToSetTo)
    {
        SetStateAndStartAnimaion(vauleToSetTo);
    }

    private void SetStateAndStartAnimaion(bool valueToSetTo)
    {
        CurrentValue = state;

        if (CurrentValue)
            OnToggleOn?.Invoke();
        else
            OnToggleOff?.Invoke();

        if(_animationSliderCorutine != null)
            StopCoroutine(_animationSliderCoroutine);

        _animationSliderCoroutine = StartCoroutine(AnimationSlider());
    }

    private IEnumerator AnimateSlider()
    {
        float startValue = _slider.value;
        float endValue = CurrentValue ? 1 : 0;

        float time = 0;
        if (animationDuration > 0)
        {
            while (time < animationDuration)
            {
                time += Time.deltaTime;

                float lerpFactor = slideEase.Evaluate(time / animationDuration);
                _slider.value = sliderValue = Mathf.Lerp(startValue, endValue, lerpFactor);
                yield return null;
            }
        }
        _slider.value = endValue;
    }

}
