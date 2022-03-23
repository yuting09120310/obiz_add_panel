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
        public int i = 0;

        public Create[] ct = new Create[5];
        public Form1()
        {
            InitializeComponent();
        }

        //按下新增後 調用create 生成控制項 並將生成出來的物件 綁定事件
        private void button1_Click(object sender, EventArgs e)
        {
            ct[i] = new Create(panel2);
            ct[i].Btn_send.Click += new EventHandler(Btn_send_Click);
            ReName();
        }


        //動態生成的送出按鈕
        protected void Btn_send_Click(object sender, EventArgs e)
        {
            MessageBox.Show(ct[i].text.Text);
        }


        //將panel取名 便於排版
        public void ReName()
        {
            
            foreach (Control control in panel2.Controls)
            {
                if(!control.Name.Contains("Panel"))
                {
                    control.Name = "Panel" + i;
                    i++;
                }
            }
            TypeSetting();
        }

        //將panel重新排版
        public void TypeSetting()
        {
            foreach (Control control in panel2.Controls)

                for (int j = 1; j < panel2.Controls.Count; j++)
                {
                    if (control.Name == $"Panel{j}")
                    {
                        control.Top = j * 100;
                    }
                }
            }
        }

        //按下新增後 會創建新的panel以及子層物件
        public class Create
        {
            public Button Btn_send = new Button()
            {
                Text = "123"
            };

            public TextBox text = new TextBox()
            {
                Text = "445566",
                Width = 150
            };

            public Panel panel = new Panel()
            {
                Width = 712,
                Height = 50,
                BackColor = Color.Tan,
            };

            public Create(Panel panel2)
            {
                panel2.Controls.Add(panel);
                panel.Controls.Add(Btn_send);
                panel.Controls.Add(text);

                Btn_send.Left = 400;
                Btn_send.Top = 12;

                text.Top = 12;
                text.Left = 200;
            }
        }

    }

