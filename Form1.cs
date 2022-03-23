using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace obiz_add_panel
{
    public partial class Form1 : Form
    {
        public int i = 1;

        public Form1()
        {
            InitializeComponent();
        }

        //按下新增後 調用create 生成控制項 並將生成出來的物件 委派事件
        private void button1_Click(object sender, EventArgs e)
        {
            Create(panel2);
        }


        //動態生成的送出按鈕
        protected void Btn_send_Click(object sender, EventArgs e)
        {

            MessageBox.Show("");
        }



        

        public void Create(Panel panel2)
        {
            for(int j = 0; j < i; j++)
            {

                //按下新增後 會創建新的panel以及子層物件
                Button Btn_send = new Button()
                {
                   Name = $"btn_{j}",
                   Text = "123"
                };

                TextBox text = new TextBox()
                {
                   Name = $"Tb_{j}",
                   Text = "445566",
                   Width = 150
                };

                Panel panel = new Panel()
                {
                   Name = $"panel_{j}",
                   Width = 712,
                   Height = 50,
                   BackColor = Color.Tan,
                };

                panel2.Controls.Add(panel);
                panel.Controls.Add(Btn_send);
                panel.Controls.Add(text);

                panel.Top = 10 + (j * 100);

                Btn_send.Left = 400;
                Btn_send.Top = 12;

                text.Top = 12;
                text.Left = 200;
            }

            i++;
        }

    }
}

