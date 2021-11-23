using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuManager : MonoBehaviour
{
    private int totalCombinations, currentlight = 0, currentCapsule = 0, currentChasis = 0, code, lightIndx, chasisIndx, holderIndx, capsuleIndx;
    private bool changeCapsule, changeChasis;

    public TextMeshProUGUI shipCodeText;
    public TMP_InputField searchCodeField;
    public Button searchCodeButton;
    public Button nextButton;
    public Button previousButton;
    public Button showCodesButton;

    public List<Material> capsuleMaterial = new List<Material>(); 
    public List<Material> neonMaterial = new List<Material>(); 
    public List<Material> chasisMaterial = new List<Material>();

    public ColourShip ship;

    // Start is called before the first frame update
    void Start()
    {
        searchCodeButton.onClick.AddListener(SearchCode);
        nextButton.onClick.AddListener(NextCombination);
        previousButton.onClick.AddListener(PreviousCombination);
        showCodesButton.onClick.AddListener(ShowCodes);

        totalCombinations = capsuleMaterial.Count * neonMaterial.Count * chasisMaterial.Count;
        shipCodeText.text = "Total number of combinations: " + totalCombinations;
    }
    private void TransformCode(int codeRef)
    {
        lightIndx = code % neonMaterial.Count;
        holderIndx = Mathf.FloorToInt(code / neonMaterial.Count) % chasisMaterial.Count;
        chasisIndx = Mathf.FloorToInt(code / (neonMaterial.Count * chasisMaterial.Count)) % chasisMaterial.Count;
        capsuleIndx = Mathf.FloorToInt(code / (neonMaterial.Count * chasisMaterial.Count * chasisMaterial.Count)) % capsuleMaterial.Count;

        ship.capsuleMaterial = capsuleMaterial[capsuleIndx];
        ship.shipMaterial = chasisMaterial[chasisIndx];
        ship.holderMaterial = chasisMaterial[holderIndx];
        ship.lightsMaterial = neonMaterial[lightIndx];
    }
    void SearchCode()
    {
        string searchCode = searchCodeField.text;
        code = System.Convert.ToInt32(searchCode);

        TransformCode(code);

        ship.ColourShipNow();
        shipCodeText.text = code.ToString();
    }

    void NextCombination()
    {
        code++;

        TransformCode(code);

        ship.ColourShipNow();
        shipCodeText.text = code.ToString();
    }

    void PreviousCombination()
    {
        code--;

        TransformCode(code);

        ship.ColourShipNow();
        shipCodeText.text = code.ToString();
    }

    void ShowCodes()
    {
        /*
        ship.capsuleMaterial = capsuleMaterial[0];
        ship.shipMaterial = chasisMaterial[0];
        ship.holderMaterial = chasisMaterial[0];
        ship.lightsMaterial = neonMaterial[0];
        ship.ColourShipNow();
        */
        code = 0;

        StartCoroutine(ChangeMats());
    }

    IEnumerator ChangeMats()
    {
        yield return new WaitForSeconds(.5f);

        TransformCode(code);
        ship.ColourShipNow();
        shipCodeText.text = code.ToString();

        code++;
        /*
        ship.lightsMaterial = neonMaterial[currentlight];
        ship.capsuleMaterial = capsuleMaterial[currentCapsule];
        ship.shipMaterial = chasisMaterial[currentChasis];
        ship.holderMaterial = chasisMaterial[currentChasis];
        ship.ColourShipNow();

        if (ship.lightsMaterial == neonMaterial[neonMaterial.Count - 1])
        {
            currentCapsule++;
            currentlight = 0;
        }
        if (ship.capsuleMaterial == capsuleMaterial[capsuleMaterial.Count - 1])
        {
            currentChasis++;
            currentCapsule = 0;
        }
        currentlight++;
        */

        StartCoroutine(ChangeMats());
    }
}
