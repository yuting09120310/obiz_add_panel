using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Alex_Component;

namespace obiz_add_panel
{
    public partial class Form1 : Form
    {
        public int i = 1;

        string AppName = "obiz_add_panel";
        Msg_log msg_Log = new Msg_log();

        public Form1()
        {
            InitializeComponent();
        }

        //按下新增後 調用create 生成控制項
        private void Btn_Add_Click(object sender, EventArgs e)
        {
            Create();
        }


        //動態生成的送出按鈕
        protected void Btn_send_Click(object sender, EventArgs e)
        {
            try
            {
                //將sender轉型成Button型態 抓取當前按鍵的數字
                Button button = (Button)sender;

                string num = button.Name.Split('_')[1];

                Control t = Controls.Find($"panel_{num}", true)[0];


                //將撈回來的資料 以便用foreach去找panel內的各項控制項
                Panel panel = (Panel)t;

                foreach (Control c in panel.Controls)
                {
                    if (c.Name.Contains("Lb_"))
                    {
                        MessageBox.Show(c.Text);
                    }
                }
            }catch(Exception ex)
            {
                msg_Log.save_log(AppName, ex);
            }
        }

        public void Create()
        {
            try
            {
                for (int j = 0; j < i; j++)
                {
                    Button Btn_send = new Button()
                    {
                        Name = $"btn_{j}",
                        Text = $"按鈕{j}"
                    };

                    Label text = new Label()
                    {
                        Name = $"Lb_{j}",
                        Text = $"Lb_{j}",
                        Width = 150
                    };

                    Panel panel = new Panel()
                    {
                        Name = $"panel_{j}",
                        Width = 712,
                        Height = 50,
                        BackColor = Color.Tan,
                    };

                    this.Controls.Add(panel);
                    panel.Controls.Add(Btn_send);
                    panel.Controls.Add(text);

                    panel.Top = 10 + (j * 100);

                    Btn_send.Left = 400;
                    Btn_send.Top = 12;

                    text.Top = 12;
                    text.Left = 200;

                    Btn_send.Click += Btn_send_Click;
                }

                i++;
            }catch(Exception ex)
            {
                msg_Log.save_log(AppName, ex);
            }
        }
    }
}

