using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Keyboard : MonoBehaviour
{
    [Header(" Elements ")]
    [SerializeField] private RectTransform rectTransfor;
    [SerializeField] private KeyScript keyPrefab ;
    [SerializeField] private KeyScript backspacekeyPrefab;

    [Header(" Settings ")]
    [Range(0f, 1f)]
    [SerializeField] private float widthPercent;
    [Range(0f, 1f)]
    [SerializeField] private float heightPercent;
    [Range(0f, .5f)]
    [SerializeField] private float bottomOffset;

    [Header(" Keyboard Lines ")]
    [SerializeField] private KeyboardLine[] lines;

    [Header(" Key Settings ")]
    [Range(0f, 1f)]
    [SerializeField] private float keyToLineRatio;
    [Range(0f, 1f)]
    [SerializeField] private float keyXSpacing;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    IEnumerator Start()
    {
        CreateKeys();

        yield return null;

        UpdateRectTransform();
        

        //rectTransfor sizeDelta = new Vector2(Screen.width, Screen.height / 2);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateRectTransform();
        PlaceKeys();
    }

    private void UpdateRectTransform()
    {
        float width = widthPercent * Screen.width * 4;
        float height = heightPercent * Screen.height * 2;

        rectTransfor.sizeDelta = new Vector2(width, height);

        Vector2 position;

        position.x = Screen.width / 2;
        position.y = bottomOffset * Screen.height * height / 2;

        rectTransfor.position = position;
    }

    private void CreateKeys()
    {
        for(int i = 0; i< lines.Length;i++)
        {
            for(int j = 0; j < lines[i].keys.Length;j++)
            {
                char key = lines[i].keys[j];

                if(key == '.')
                {
                    KeyScript keyInstance = Instantiate(backspacekeyPrefab, rectTransfor);

                    //keyInstance.GetButton().onClick.AddListener(() => BackspacePressedCallback())
                    
                }
                else
                {
                    KeyScript keyInstance = Instantiate(keyPrefab, rectTransfor);
                    keyInstance.SetKey(key);

                   // keyInstance.GetButton().onClick.AddListener(() => KeyPressedCallback(key))
                }

            }
        }
    }

    private void PlaceKeys()
    {
        int lineCount = lines.Length;

        float lineHeight = rectTransfor.rect.height / lineCount ;

        float keyWidth = lineHeight * keyToLineRatio;
        float xSpacing = keyXSpacing * lineHeight;

        int currentKeyIndex = 0;

        for (int i = 0; i < lineCount; i++)
        {

            bool containsBackspace = lines[i].keys.Contains(".");

            float halfKeyCount = (float)lines[i].keys.Length / 2;


            if (containsBackspace)
                halfKeyCount += .5f;


            float startX = rectTransfor.position.x - (keyWidth) * halfKeyCount + keyWidth / 2;

            float lineY = rectTransfor.position.y + rectTransfor.rect.height / 2 - lineHeight / 2 - i * lineHeight;





            for (int j = 0; j < lines[i].keys.Length; j++)
            {
                bool isBackspaceKey = lines[i].keys[j] == '.';
                float keyX = startX + j * keyWidth;
                if(isBackspaceKey)
                    keyX += keyWidth;
                Vector2 keyPosition = new Vector2(keyX, lineY);

                RectTransform keyRectTransform = rectTransfor.GetChild(currentKeyIndex).GetComponent<RectTransform>();

                keyRectTransform.position = keyPosition;

                float thisKeyWidth = keyWidth;
                if (isBackspaceKey)
                    thisKeyWidth *= 2;

                keyRectTransform.sizeDelta = new Vector2(thisKeyWidth, keyWidth);


                currentKeyIndex++;

            }
        }

    }

    //private void BackspacePressedCallback()
    //{

    //}

}

[System.Serializable]
public struct KeyboardLine
{
    public string keys;
}

