using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pSplatHealthBar : MonoBehaviour
{
    public GameObject splatprefab;
    public Health health;
    List<paintSplatHealth> splats = new List<paintSplatHealth>();

    private void Start()
    {
        DrawSplats();
    }

    public void DrawSplats()
    {
        ClearSplats();

        //how many hearts make total?
        //based off maxhealth
        float maxHealthRemainder = health.maxHealth % 2;
        int splatsToMake = (int)((health.maxHealth / 2) + maxHealthRemainder);

        for (int i = 0; i < splatsToMake; i++)
        {
            CreateEmptySplat();
        }

        for(int i = 0; i < splats.Count; i++)
        {
            int splatStatusRemainder = Mathf.Clamp(health.currentHealth - (i*2), 0, 2);
            splats[i].SetSplatImage((splatStatus)splatStatusRemainder);
        }
    }

    public void CreateEmptySplat()
    {
        GameObject newSplat = Instantiate(splatprefab);
        newSplat.transform.SetParent(transform);

        paintSplatHealth splaComponent = newSplat.GetComponent<paintSplatHealth>();
        splaComponent.SetSplatImage(splatStatus.Empty);
        splats.Add(splaComponent);
    }

    public void ClearSplats()
    {
        foreach(Transform t in transform)
        {
            Destroy(t.gameObject);
        }
        splats = new List<paintSplatHealth>();
    }
}
