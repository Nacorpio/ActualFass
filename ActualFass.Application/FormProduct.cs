namespace ActualFass.Window
{

  public partial class FormProduct : Form
  {
    public FormProduct()
    {
      InitializeComponent();
    }

    internal void Display(FassProductCard card)
    {
      Text = card.Label;

      labelName.Text    = card.Label;
      labelCompany.Text = card.CompanyName;

      txtAppearance.Text = card.AppearanceText;
      txtName.Text       = card.Label;
      txtAtcCode.Text    = card.AtcCode;
      txtCompany.Text    = card.CompanyName;
      txtSummary.Text    = card.Summary;
      txtWeight.Text     = card.WeightText;

      pictureBoxImage.ImageLocation = $@"http://www.fass.se{card.ImageUrl?.CleanText()}";
    }
  }

}