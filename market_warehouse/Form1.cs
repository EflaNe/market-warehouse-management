using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;


namespace EntityFrameworkDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void dgwProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        ProductDal _productDal = new ProductDal();
        private void Form1_Load(object sender, EventArgs e)
        {
             LoadProducts();

        }
        private void SearchProducts(string key)
        {
            //var result = _productDal.GetAll().Where(p => p.Name.Contains(tbxSearch.Text));
            var result = _productDal.GetByName(key);  
            dgwProducts.DataSource = result;
        }
        private void LoadProducts()
        {
            // Form yüklendiğinde ürünleri getirir
            dgwProducts.DataSource = _productDal.GetAll();
        }
        
        private void btnAdd_Click(object sender, EventArgs e)
        {
            _productDal.Add(new Product
            {
                Name = tbxName.Text,
                UnitPrice = Convert.ToDecimal(tbxUnitPrice.Text),
                StockAmount = Convert.ToInt32(tbxStockAmount.Text)
            });
            LoadProducts(); // Ürünler listesi güncellenir
            MessageBox.Show("Ürün eklendi.");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            _productDal.Update(new Product
            {
                Id = Convert.ToInt32(dgwProducts.CurrentRow.Cells[0].Value), // Seçilen satırdaki ürün Id'sini alır
                Name = tbxNameUpdate.Text, // Güncelleme için TextBox'tan ürün adını alır
                UnitPrice = Convert.ToDecimal(tbxUnitPriceUpdate.Text), // Güncelleme için TextBox'tan birim fiyatı alır
                StockAmount = Convert.ToInt32(tbxStockAmountUpdate.Text) // Güncelleme için TextBox'tan stok miktarını alır
            }); 
            LoadProducts(); // Ürünler listesi güncellenir
            MessageBox.Show("Ürün güncellendi.");   
        }

        private void dgwProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tbxNameUpdate.Text = dgwProducts.CurrentRow.Cells[1].Value.ToString(); // Seçilen satırdaki ürün adını alır 
            tbxUnitPriceUpdate.Text = dgwProducts.CurrentRow.Cells[2].Value.ToString(); // Seçilen satırdaki birim fiyatı alır
            tbxStockAmountUpdate.Text = dgwProducts.CurrentRow.Cells[3].Value.ToString(); // Seçilen satırdaki stok miktarını alır
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            _productDal.Delete(new Product
            {
                Id = Convert.ToInt32(dgwProducts.CurrentRow.Cells[0].Value) // Seçilen satırdaki ürün Id'sini alır
            });
            LoadProducts(); // Ürünler listesi güncellenir
            MessageBox.Show("Ürün silindi.");
        }

        private void tbxSearch_TextChanged(object sender, EventArgs e)
        {
            SearchProducts(tbxSearch.Text);
        }

        private void tbxId_Click(object sender, EventArgs e)
        {
            _productDal.GetById(5);
        }
    }
}
