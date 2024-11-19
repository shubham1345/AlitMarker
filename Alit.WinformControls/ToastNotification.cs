using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Alit.WinformControls
{
    public static class ToastNotification
    {
        public static void Show(Form Parent, string Text)
        {
            ToastNotificationForm Toast = new ToastNotificationForm(Text, Parent);
            Toast.ShowToast();
            if (Parent != null)
            {
                Parent.Focus();
                Parent.Select();
            }
        }

        private class ToastNotificationForm : Form
        {
            Control NotificationParent;
            Label lblDescr;
            Timer Timer1;
            public ToastNotificationForm(string Text, Control parent)
            {
                NotificationParent = parent;
                this.SuspendLayout();

                Timer1 = new Timer();
                Timer1.Interval = 500;
                Timer1.Tick += Timer1_Tick;

                lblDescr = new Label();
                lblDescr.Name = "lblDescr";
                lblDescr.Location = new Point(10, 10);
                lblDescr.AutoSize = true;
                lblDescr.Text = Text;
                lblDescr.ForeColor = Color.AntiqueWhite;
                //lblDescr.Dock = DockStyle.Fill;
                lblDescr.Font = new Font("Calibri", 12);

                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                this.Padding = new Padding(5);
                this.Size = new Size(3, 5);
                //this.MinimumSize = new Size(100, 100);
                this.BackColor = Color.Black;
                this.StartPosition = FormStartPosition.CenterScreen;
                this.AutoSize = true;
                this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly;
                this.TopMost = true;
                this.ShowInTaskbar = false;

                this.Controls.Add(lblDescr);
                this.ResumeLayout(false);
                this.PerformLayout();
            }

            void Timer1_Tick(object sender, EventArgs e)
            {
                FadeOut();
                Timer1.Enabled = false;
            }

            public void ShowToast()
            {
                this.Opacity = 0;
                Show();
                FadeIn();
            }

            const int DefaultInterval = 20;
            public async void FadeIn(int interval = DefaultInterval)
            {
                //Object is not fully invisible. Fade it in
                while (this.Opacity < 1.0)
                {
                    await Task.Delay(interval);
                    this.Opacity += 0.05;
                }
                this.Opacity = 1; //make fully visible
                Timer1.Enabled = true;
            }

            public async void FadeOut(int interval = DefaultInterval)
            {
                //Object is fully visible. Fade it out
                while (this.Opacity > 0.0)
                {
                    await Task.Delay(interval);
                    this.Opacity -= 0.05;
                }
                this.Opacity = 0; //make fully invisible

                Close();
                lblDescr.Dispose();
                Timer1.Dispose();
                if(NotificationParent != null && !NotificationParent.IsDisposed && !NotificationParent.Disposing)
                {
                    if(NotificationParent.CanFocus)
                    {
                        NotificationParent.Focus();
                    }
                }
                this.Dispose();
            }

            protected override void OnPaint(PaintEventArgs e)
            {
                e.Graphics.DrawRectangle(new Pen(Color.Aqua, 1),
                    new Rectangle(0, 0, this.ClientRectangle.Width - 1, this.ClientRectangle.Height - 1));
                base.OnPaint(e);
            }
        }
    }
}
