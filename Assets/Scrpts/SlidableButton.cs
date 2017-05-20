using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

[RequireComponent(typeof(Image))]
public class SlidableButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {
    Sprite notPressedSprite;
    public Sprite pressedSprite;
    Key key;

    Image image;

    bool isButtonDown = false;

    bool isPointerDown = false;
    bool isPointerIn = false;

    public UnityEvent onButtonDown;
    public UnityEvent onButtonUp;

    string mKey;

    Player player;

    public void Start() {
        key = GameObject.Find("Key").GetComponent<Key>();
        mKey = gameObject.name;
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
        image = GetComponent<Image>();
        notPressedSprite = image.sprite;
    }

    void UpdateState() {
        if (!isPointerDown || !isPointerIn) {
            image.sprite = notPressedSprite;
            if (isButtonDown) {
                onButtonUp.Invoke();
                isButtonDown = false;
            }
            return;
        }
        image.sprite = pressedSprite;
        if (!isButtonDown) {
            onButtonDown.Invoke();
            isButtonDown = true;
        }
    }

    public void OnPointerEnter(PointerEventData ev) {
        isPointerIn = true;
        UpdateState();
        Debug.Log("Enter");
        key.keys[mKey] = true;
    }

    public void OnPointerExit(PointerEventData ev) {
        isPointerIn = false;
        UpdateState();
        //key.SetKey(mKey, false);
        //Debug.Log("Exit");
        key.keys[mKey] = false;
    }

    public void OnGroupPointerDown() {
        isPointerDown = true;
        Debug.Log("Down");
        UpdateState();
    }

    public void OnGroupPointerUp() {
        isPointerDown = false;
        Debug.Log("Up");
        UpdateState();
    }
}