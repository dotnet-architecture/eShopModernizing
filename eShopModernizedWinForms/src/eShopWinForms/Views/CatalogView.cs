using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.Linq.Expressions;
using eShopWinForms.eShopServiceReference;
using System.Net.Http;
using eShopWinForms.Controllers;

namespace eShopWinForms
{
    public partial class CatalogView : Form, ICatalogView
    {
        public CatalogView()
        {
            InitializeComponent();
            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private CatalogController _controller;
        public event ViewHandler<ICatalogView> filterChanged;
        public event SearchStockHandler<ICatalogView> searchStockButtonClicked;
        public event AvailabilityHandler<ICatalogView> availabilityButtonClicked;

        public void SetController(CatalogController controller)
        {
            _controller = controller;
        }

        /*
         * Removes all catalog items from the gridview
         */
        public void ClearGrid()
        {
            catalogItemDataGridView.Rows.Clear();
            catalogItemDataGridView.Refresh();
        }

        /*
         * Populates the gridview with catalog items and applies an appropriate discount to their price if there is one.
         */
        public void SetCatalogItems(IEnumerable<CatalogItem> items, double discountVal)
        {
            foreach (CatalogItem catalogItem in items)
            {
                double price = double.Parse(catalogItem.Price.ToString());
                double discountPrice = price * (1 - discountVal);

                /* Item assets are stored relative to the program executable's directory. In the database, they have a filename.
                   We depend on the fact that this filename refences an image already in the "assets" directory */
                string imagename = Environment.CurrentDirectory + "\\..\\..\\Assets\\Images\\Catalog\\" + catalogItem.Picturefilename;
                Image img = Image.FromFile(imagename);
                Image thumb = img.GetThumbnailImage(384, 216, null, IntPtr.Zero);

                catalogItemDataGridView.Rows.Add(thumb, catalogItem.Id.ToString(), catalogItem.Name, catalogItem.Description, String.Concat("$", discountPrice.ToString("F")));
            }
        }

        public void SetShipmentView(IEnumerable<CatalogItem> items)
        {
            foreach (CatalogItem catalogItem in items)
            {
                listBox1.Items.Add(String.Format("{0} - {1}", catalogItem.Id, catalogItem.Name));
                productIdInput.Items.Add(catalogItem.Id);
            }
        }

        /*
         * Should there be a discount for the current day, we populate a banner reflecting the value of the discount
         */
        public void SetDiscountBanner(String text)
        {
            discountBanner.Text = text;
        }

        /*
         * Populates the catalog item type dropdown with all types stored in the database
         */
        public void SetTypeFilter(Dictionary<int, string> typeFilters)
        {
            catalogTypeComboBox.DataSource = new BindingSource(typeFilters, null);
            catalogTypeComboBox.DisplayMember = "Value";
            catalogTypeComboBox.ValueMember = "Key";
        }

        /*
         * Populates the catalog item brands dropdown with all brands stored in the database
         */
        public void SetBrandFilter(Dictionary<int, string> brandFilter)
        {
            catalogBrandComboBox.DataSource = new BindingSource(brandFilter, null);
            catalogBrandComboBox.DisplayMember = "Value";
            catalogBrandComboBox.ValueMember = "Key";
        }

        /*
         * Called in response to the catalog brand dropdown being changed. Fire an event
         * to notify the controller that we've changed a filter.
         */
        private void catalogBrandComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int brandId = 0;
            int typeId = 0;

            if (catalogBrandComboBox.SelectedItem != null)
                brandId = ((KeyValuePair<int, string>)catalogBrandComboBox.SelectedItem).Key;

            if (catalogTypeComboBox.SelectedItem != null)
                typeId = ((KeyValuePair<int, string>)catalogTypeComboBox.SelectedItem).Key;

            filterChanged.Invoke(this, new FilterEventArgs(typeId, brandId));
        }

        /*
         * Called in response to the catalog type dropdown being changed. Fire an event
         * to notify the controller that we've changed a brand filter
         */
        private void catalogTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int brandId = 0;
            int typeId = 0;

            if (catalogBrandComboBox.SelectedItem != null)
                brandId = ((KeyValuePair<int, string>)catalogBrandComboBox.SelectedItem).Key;

            if (catalogTypeComboBox.SelectedItem != null)
                typeId = ((KeyValuePair<int, string>)catalogTypeComboBox.SelectedItem).Key;

            filterChanged.Invoke(this, new FilterEventArgs(typeId, brandId));
        }

        /*
         * Fire an event to notify the controller that the user wants to check for stock availability
         * of the selected item.
         */
        private void searchAvailabilityButton_Click(object sender, EventArgs e)
        {
            string[] separator = new string[] { " - " };
            string[] results = listBox1.SelectedItem.ToString().Split(separator, StringSplitOptions.None);

            DateTime date = monthCalendar1.SelectionRange.Start.Date;
            int id = int.Parse(results[0]);

            SearchStockEventArgs ex = new SearchStockEventArgs(id, date);
            searchStockButtonClicked.Invoke(this, ex);
        }

        /*
         * Fire an event to notify the controller that the user wants to add stock for a given item.
         */
        private void addAvailabilityButton_Click(object sender, EventArgs e)
        {
            if (productIdInput.SelectedItem == null || String.IsNullOrEmpty(quantityInput.Text) || String.IsNullOrEmpty(arrivalDateInput.Text))
                return;

            int id = (int)productIdInput.SelectedItem;
            int quantity = int.Parse(quantityInput.Text);
            DateTime shipDate = Convert.ToDateTime(arrivalDateInput.Text);

            AvailabilityEventArgs args = new AvailabilityEventArgs(id, quantity, shipDate);
            availabilityButtonClicked.Invoke(this, args);
        }

        /*
         * Updates the stock availability listview to show the latest stock availability result.
         */
        public void ShowStockAvailability(SearchStockEventArgs args, int availability)
        {
            ListViewItem lvi = new ListViewItem(args.date.ToShortDateString());
            lvi.SubItems.Add(args.itemId.ToString());
            lvi.SubItems.Add(availability.ToString());
            listView1.Items.Add(lvi);

            listView1.Columns[0].Width = -1;
            listView1.Columns[1].Width = -2;
            listView1.Columns[2].Width = -2;
        }

        /*
         * Display a message box to the user indicating that we've successfully added
         * an item availability to the database
         */
        public void NotifyAvailabilityUpdated()
        {
            MessageBox.Show("Shipment has been added to the database.");

            productIdInput.ResetText();
            quantityInput.Clear();
            arrivalDateInput.Clear();
        }
    }
}