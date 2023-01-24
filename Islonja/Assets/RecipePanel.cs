using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipePanel : ItemPanel
{
    [SerializeField] RecipeList recipeList;
    [SerializeField] Crafting crafting;
    public override void Show()
    {
        for (int i = 0; i < buttons.Count && i < recipeList.craftingRecipes.Count; i++)
        {
            buttons[i].Set(recipeList.craftingRecipes[i].output);
        }
    }

    public override void OnClick(int id)
    {
        if(id >= recipeList.craftingRecipes.Count) { return; }
        
            crafting.Craft(recipeList.craftingRecipes[id]);
        
    }
}
