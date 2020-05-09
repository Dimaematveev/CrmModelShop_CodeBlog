using CrmBl.Model;
using CrmUi.Form_for_Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace CrmUi
{
    public partial class CustomerForm : Form
    {
        public Customer Customer { get; set; }

        private List<TieToPropertyUIElement> Svaz { get; set; } = new List<TieToPropertyUIElement>();
        public CustomerForm()
        {
            InitializeComponent();
            Customer = Customer ?? new Customer();
        }
        public CustomerForm(Customer customer) : this()
        {

            //textBox1.Text = Customer.Name;
            Customer = customer ?? new Customer();
            
        }

        private void CustomerForm_Load(object sender, EventArgs e)
        {
            DrawPanel("Введите имя: ", Customer, nameof(Customer.Name));
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Customer = Customer ?? new Customer();
            //Customer.Name = textBox1.Text;

            //Customer.Name = Svaz[nameof(Customer.Name)].ToString();
            foreach (var item in Svaz)
            {
                item.SetProp();
            }
            Close();
        }

        private void DrawPanel(string mess, Customer value,string nameProperty)
        {
            
            var textBox = new TextBox();
            var label = new Label();
            var temp = new TieToPropertyUIElement(value, nameProperty, textBox, nameof(textBox.Text));
            Svaz.Add(temp);
            textBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBox.Location = new Point(144, 6);
            textBox.Name = "textBox1";
            textBox.Size = new Size(262, 20);
            textBox.TabIndex = 0;
            var zz = Svaz[Svaz.Count - 1].GetProp();
            textBox.Text = zz == null ? "" : zz.ToString();

            

            // 
            // label1
            // 
            label.AutoSize = true;
            label.Location = new Point(12, 9);
            label.Name = "label1";
            label.Size = new Size(126, 13);
            label.TabIndex = 1;
            label.Text = mess;

            Controls.Add(label);
            Controls.Add(textBox);
        }
    }
}
