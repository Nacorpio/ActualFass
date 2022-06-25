namespace ActualFass.Window
{

    public partial class Form1 : Form
    {
        private readonly FassClient _fc;

        public Form1()
        {
            InitializeComponent();
            _fc = new FassClient();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
        }

        private async void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private async void btnSök_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                return;
            }

            treeResultat.Nodes.Clear();

            var input  = textBox1.Text.Trim();
            var result = await _fc.SearchAsync(input);
            var panels = result?.GetProductPanels();

            foreach (var panel in panels!)
            {
                var productPanelNode = CreateProductPanelNode(panel);

                foreach (var tradeName in panel.GetResults()!)
                {
                    var tradeNameNode = CreateTradeNameNode(tradeName);
                    productPanelNode.Nodes.Add(tradeNameNode);

                    foreach (var product in tradeName.GetResults()!)
                    {
                        var productNode = CreateProductNode(product);
                        tradeNameNode.Nodes.Add(productNode);
                    }
                }

                treeResultat.Nodes.Add(productPanelNode);
            }

            treeResultat.ExpandAll();
        }

        public const int PillImageIndex = 1;
        public const int PackageImageIndex = 2;
        public const int CategoryImageIndex = 3;

        private static TreeNode CreateProductNode(FassProductResult product) =>
            new($"{product.Label} ({product.CompanyName})")
            {
                Tag                = product,
                ImageIndex         = PillImageIndex,
                SelectedImageIndex = PillImageIndex,
            };

        private static TreeNode CreateTradeNameNode(FassProductTradeName tradeName) =>
            new(tradeName.Label)
            {
                Tag                = tradeName,
                ImageIndex         = PackageImageIndex,
                SelectedImageIndex = PackageImageIndex,
            };

        private static TreeNode CreateProductPanelNode(FassProductResultPanel panel) =>
            new(string.IsNullOrWhiteSpace(panel.Label) ? "Läkemedel" : panel.Label)
            {
                Tag                = panel,
                ImageIndex         = CategoryImageIndex,
                SelectedImageIndex = CategoryImageIndex,
            };

        private async void treeResultat_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Tag is not FassProductResult product)
            {
                return;
            }

            var productCard   = await _fc.GetProductCardAsync(product.GetProductId()!);
            var productDialog = new FormProduct();

            try
            {
                productDialog.Display(productCard!);
                productDialog.Show();
            }
            catch (Exception)
            {
                MessageBox.Show("");
            }
        }
    }

}