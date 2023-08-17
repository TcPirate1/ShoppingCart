using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShoppingCart
{
    public partial class Form1 : Form
    {
        readonly ArrayList cartItems = new ArrayList();
        readonly List<Product> products = new List<Product>();
        public Form1()
        {
            InitializeComponent();
            InitializeProducts();
        }

        private void InitializeProducts()
        {
            // Products that are avaliable in the list
            products.Add(new Product("Chicken Drumsticks", 5.00m));
            products.Add(new Product("Chicken Legs", 11.49m));
            products.Add(new Product("Beef Rump Steak", 22.99m));
            products.Add(new Product("Lamb Leg Roast", 13.69m));
            products.Add(new Product("Whole Snapper", 21.99m));
            products.Add(new Product("Salmon Fillets", 44.99m));
            products.Add(new Product("Portobello Mushroom", 18.79m));
            products.Add(new Product("Red Chilli", 1.89m));
            products.Add(new Product("Unwashed Potatoes", 2.99m));

            ProductsListBox.DataSource = products;
            ProductsListBox.DisplayMember = "Name";
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            int selectedIndex = ProductsListBox.SelectedIndex;

            if (selectedIndex >= 0)
            {
                Product selectedProduct = products[selectedIndex];
                cartItems.Add(selectedProduct);
                ShoppingCartListBox.Items.Add(selectedProduct.Name);
            }
        }

        private void CheckOutButton_Click(object sender, EventArgs e)
        {
            {
                decimal total = Product.TotalCalc(cartItems.OfType<Product>());
                string message = "Items in your cart:\n\n";

                foreach (Product product in cartItems)
                {
                    message += $"{product.Name} - ${product.Price}\n";
                }

                message += $"\nTotal: ${total}";

                MessageBox.Show(message, "Total");
            }
        }
    }
}
