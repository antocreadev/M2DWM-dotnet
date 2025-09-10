using DataContracts;

namespace IHM;

public partial class EditRecipePage : ContentPage
{
    public Recipe Recipe { get; set; }
    public bool IsSaved { get; private set; } = false;

    public EditRecipePage(Recipe recipe)
    {
        InitializeComponent();
        Recipe = recipe;
        LoadRecipeData();
    }

    private void LoadRecipeData()
    {
        RecipeNameEntry.Text = Recipe.Name;
        IngredientsEntry.Text = string.Join(", ", Recipe.Ingredients);
        InstructionsEntry.Text = Recipe.Instructions;
        PrepTimeEntry.Text = Recipe.PrepTime.ToString();
        CookTimeEntry.Text = Recipe.CookTime.ToString();
    }

    private async void OnSaveClicked(object sender, EventArgs e)
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

        Recipe.Name = RecipeNameEntry.Text;
        Recipe.Ingredients = IngredientsEntry.Text.Split(',').Select(i => i.Trim()).ToList();
        Recipe.Instructions = InstructionsEntry.Text;
        Recipe.PrepTime = prepTime;
        Recipe.CookTime = cookTime;

        IsSaved = true;
        await Navigation.PopModalAsync();
    }

    private async void OnCancelClicked(object sender, EventArgs e)
    {
        IsSaved = false;
        await Navigation.PopModalAsync();
    }
}
