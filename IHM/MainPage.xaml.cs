using System.Collections.ObjectModel;
using DataContracts;
using Services;
using ServicesContracts;

namespace IHM;

public partial class MainPage : ContentPage
{
    private IAbstractRecipesService _recipesService;
    public ObservableCollection<Recipe> Recipes { get; set; } = new ObservableCollection<Recipe>();

    public MainPage()
    {
        InitializeComponent();
        _recipesService = RecipesServiceFactory.CreateRecipesService();
        BindingContext = this;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await LoadRecipesAsync();
    }

    private async Task LoadRecipesAsync()
    {
        var recipes = await _recipesService.GetRecipesAsync();
        Recipes.Clear();
        foreach (var recipe in recipes)
        {
            Recipes.Add(recipe);
        }
    }

    private async void OnAddRecipeClicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(RecipeNameEntry.Text) ||
            string.IsNullOrWhiteSpace(IngredientsEntry.Text) ||
            string.IsNullOrWhiteSpace(InstructionsEntry.Text) ||
            !int.TryParse(PrepTimeEntry.Text, out int prepTime) ||
            !int.TryParse(CookTimeEntry.Text, out int cookTime))
        {
            await DisplayAlert("Error", "Please fill all fields correctly.", "OK");
            return;
        }

        var ingredients = IngredientsEntry.Text.Split(',').Select(i => i.Trim()).ToList();
        var newRecipe = new Recipe(RecipeNameEntry.Text, ingredients, InstructionsEntry.Text, prepTime, cookTime);
        await _recipesService.AddRecipeAsync(newRecipe);
        Recipes.Add(newRecipe);

        // Clear fields
        RecipeNameEntry.Text = "";
        IngredientsEntry.Text = "";
        InstructionsEntry.Text = "";
        PrepTimeEntry.Text = "";
        CookTimeEntry.Text = "";
    }

    private async void OnEditRecipeClicked(object sender, EventArgs e)
    {
        var button = sender as Button;
        var recipe = button?.BindingContext as Recipe;
        if (recipe != null)
        {
            var editPage = new EditRecipePage(recipe);
            await Navigation.PushModalAsync(editPage);
            editPage.Disappearing += async (s, args) =>
            {
                if (editPage.IsSaved)
                {
                    await _recipesService.UpdateRecipeAsync(recipe);
                    // Reload to reflect changes
                    await LoadRecipesAsync();
                }
            };
        }
    }

    private async void OnDeleteRecipeClicked(object sender, EventArgs e)
    {
        var button = sender as Button;
        var recipe = button?.BindingContext as Recipe;
        if (recipe != null)
        {
            bool confirm = await DisplayAlert("Confirm Delete", $"Are you sure you want to delete '{recipe.Name}'?", "Yes", "No");
            if (confirm)
            {
                await _recipesService.DeleteRecipeAsync(recipe.Name);
                Recipes.Remove(recipe);
            }
        }
    }
}
