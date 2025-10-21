using System;
using System.ComponentModel;
using System.Threading;
using System.Windows.Forms;

namespace Практична_робота__1
{
    public class Form1 : Form
    {
        // --- поля контролів ---
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;

        private TextBox textBox1;

        private Button button1;
        private Button button2;
        private Button button3;

        private ListBox listBox1;
        private ListBox listBox2;
        private ListBox listBox3;

        private ProgressBar progressBar1;
        private ProgressBar progressBar2;
        private ProgressBar progressBar3;

        private BackgroundWorker backgroundWorker1;
        private BackgroundWorker backgroundWorker2;
        private BackgroundWorker backgroundWorker3;
        private BackgroundWorker backgroundWorker4;

        // --- робочі поля ---
        int[] array;
        int[] arrayBub;
        int[] arrayIns;
        int[] arraySel;

        TimeSpan tsBubble;
        TimeSpan tsIns;
        TimeSpan tsSel;

        bool fCancelBub;
        bool fCancelIns;
        bool fCancelSel;

        public Form1()
        {
            InitializeComponent();

            // Події
            button1.Click += button1_Click;
            button2.Click += button2_Click;
            button3.Click += button3_Click;

            backgroundWorker1.DoWork += backgroundWorker1_DoWork;
            backgroundWorker1.ProgressChanged += backgroundWorker1_ProgressChanged;
            backgroundWorker1.RunWorkerCompleted += backgroundWorker1_RunWorkerCompleted;

            backgroundWorker2.DoWork += backgroundWorker2_DoWork;
            backgroundWorker2.ProgressChanged += backgroundWorker2_ProgressChanged;
            backgroundWorker2.RunWorkerCompleted += backgroundWorker2_RunWorkerCompleted;

            backgroundWorker3.DoWork += backgroundWorker3_DoWork;
            backgroundWorker3.ProgressChanged += backgroundWorker3_ProgressChanged;
            backgroundWorker3.RunWorkerCompleted += backgroundWorker3_RunWorkerCompleted;

            backgroundWorker4.DoWork += backgroundWorker4_DoWork;
            backgroundWorker4.ProgressChanged += backgroundWorker4_ProgressChanged;
            backgroundWorker4.RunWorkerCompleted += backgroundWorker4_RunWorkerCompleted;

            // Початковий стан
            textBox1.Text = "";
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();
            progressBar1.Value = 0;
            progressBar2.Value = 0;
            progressBar3.Value = 0;

            SetActive(false);
            fCancelBub = fCancelIns = fCancelSel = false;
        }

        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.listBox3 = new System.Windows.Forms.ListBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.progressBar2 = new System.Windows.Forms.ProgressBar();
            this.progressBar3 = new System.Windows.Forms.ProgressBar();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker3 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker4 = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Array size:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(43, 136);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Bubble sorting";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(189, 136);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Insertion sorting";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(327, 136);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Selection sorting";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(43, 341);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 13);
            this.label5.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(189, 341);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(0, 13);
            this.label6.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(327, 341);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(0, 13);
            this.label7.TabIndex = 16;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(104, 66);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(218, 63);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(88, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Generate array";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(46, 100);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Sort";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(127, 100);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 4;
            this.button3.Text = "Stop";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // listBox1
            // 
            this.listBox1.Location = new System.Drawing.Point(46, 152);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(110, 147);
            this.listBox1.TabIndex = 8;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // listBox2
            // 
            this.listBox2.Location = new System.Drawing.Point(330, 152);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(114, 147);
            this.listBox2.TabIndex = 9;
            // 
            // listBox3
            // 
            this.listBox3.Location = new System.Drawing.Point(192, 152);
            this.listBox3.Name = "listBox3";
            this.listBox3.Size = new System.Drawing.Size(110, 147);
            this.listBox3.TabIndex = 10;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(46, 305);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(110, 18);
            this.progressBar1.TabIndex = 11;
            // 
            // progressBar2
            // 
            this.progressBar2.Location = new System.Drawing.Point(192, 305);
            this.progressBar2.Name = "progressBar2";
            this.progressBar2.Size = new System.Drawing.Size(114, 18);
            this.progressBar2.TabIndex = 12;
            // 
            // progressBar3
            // 
            this.progressBar3.Location = new System.Drawing.Point(330, 305);
            this.progressBar3.Name = "progressBar3";
            this.progressBar3.Size = new System.Drawing.Size(114, 18);
            this.progressBar3.TabIndex = 13;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            // 
            // backgroundWorker2
            // 
            this.backgroundWorker2.WorkerReportsProgress = true;
            this.backgroundWorker2.WorkerSupportsCancellation = true;
            this.backgroundWorker2.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker2_DoWork_1);
            // 
            // backgroundWorker3
            // 
            this.backgroundWorker3.WorkerReportsProgress = true;
            this.backgroundWorker3.WorkerSupportsCancellation = true;
            // 
            // backgroundWorker4
            // 
            this.backgroundWorker4.WorkerReportsProgress = true;
            this.backgroundWorker4.WorkerSupportsCancellation = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(784, 391);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.listBox3);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.progressBar2);
            this.Controls.Add(this.progressBar3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.MinimumSize = new System.Drawing.Size(800, 430);
            this.Name = "Form1";
            this.Text = "Form array";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        // ---- Допоміжні методи і обробники ----
        private void SetActive(bool active)
        {
            label2.Enabled = active; label3.Enabled = active; label4.Enabled = active;
            label5.Enabled = active; label6.Enabled = active; label7.Enabled = active;

            listBox1.Enabled = active; listBox2.Enabled = active; listBox3.Enabled = active;
            progressBar1.Enabled = active; progressBar2.Enabled = active; progressBar3.Enabled = active;

            button2.Enabled = active;
            button3.Enabled = active;
        }

        private void DisplayArray(int[] A, ListBox LB)
        {
            LB.Items.Clear();
            if (A == null) return;
            for (int i = 0; i < A.Length; i++) LB.Items.Add(A[i]);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SetActive(false);
            label5.Text = label6.Text = label7.Text = "";
            if (!backgroundWorker1.IsBusy)
                backgroundWorker1.RunWorkerAsync();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            if (!backgroundWorker2.IsBusy) backgroundWorker2.RunWorkerAsync();
            if (!backgroundWorker3.IsBusy) backgroundWorker3.RunWorkerAsync();
            if (!backgroundWorker4.IsBusy) backgroundWorker4.RunWorkerAsync();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                backgroundWorker2.CancelAsync();
                backgroundWorker3.CancelAsync();
                backgroundWorker4.CancelAsync();
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            var rnd = new Random();

            if (!int.TryParse(textBox1.Text, out var n) || n <= 0)
            {
                MessageBox.Show("Введіть додатне ціле число для розміру масиву.");
                return;
            }

            array = new int[n];
            arrayBub = new int[n];
            arrayIns = new int[n];
            arraySel = new int[n];

            for (int i = 0; i < n; i++)
            {
                Thread.Sleep(1);
                int val = rnd.Next(1, n + 1);
                array[i] = val;
                arrayBub[i] = val;
                arrayIns[i] = val;
                arraySel[i] = val;

                try { backgroundWorker1.ReportProgress((i * 100) / n); }
                catch (InvalidOperationException ex) { MessageBox.Show(ex.Message); return; }
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            button1.Text = "Generate array " + e.ProgressPercentage + "%";
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            button1.Text = "Generate array";
            SetActive(true);

            DisplayArray(array, listBox1);
            DisplayArray(array, listBox2);
            DisplayArray(array, listBox3);
        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            tsBubble = new TimeSpan(DateTime.Now.Ticks);

            for (int i = 0; i < arrayBub.Length - 1; i++)
            {
                Thread.Sleep(1);
                for (int j = arrayBub.Length - 1; j > i; j--)
                {
                    if (arrayBub[j - 1] > arrayBub[j])
                    {
                        int x = arrayBub[j];
                        arrayBub[j] = arrayBub[j - 1];
                        arrayBub[j - 1] = x;
                    }
                }

                try { backgroundWorker2.ReportProgress((i * 100) / arrayBub.Length); }
                catch (InvalidOperationException ex) { MessageBox.Show(ex.Message); return; }

                if (backgroundWorker2.CancellationPending) { fCancelBub = true; break; }
            }
        }

        private void backgroundWorker2_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            label5.Text = e.ProgressPercentage + "%";
            progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (fCancelBub)
            {
                label5.Text = "";
                DisplayArray(array, listBox1);
                fCancelBub = false;
            }
            else
            {
                TimeSpan time = new TimeSpan(DateTime.Now.Ticks) - tsBubble;
                label5.Text = $"{time.Hours}.{time.Minutes}.{time.Seconds}.{time.Milliseconds}";
                DisplayArray(arrayBub, listBox1);
            }
            progressBar1.Value = 0;
            button1.Enabled = true;
        }

        private void backgroundWorker3_DoWork(object sender, DoWorkEventArgs e)
        {
            tsIns = new TimeSpan(DateTime.Now.Ticks);

            for (int i = 0; i < arrayIns.Length; i++)
            {
                Thread.Sleep(1);
                int x = arrayIns[i];
                int j = i - 1;
                while (j >= 0 && arrayIns[j] > x)
                {
                    arrayIns[j + 1] = arrayIns[j];
                    j--;
                }
                arrayIns[j + 1] = x;

                try { backgroundWorker3.ReportProgress((i * 100) / arrayIns.Length); }
                catch (InvalidOperationException ex) { MessageBox.Show(ex.Message); return; }

                if (backgroundWorker3.CancellationPending) { fCancelIns = true; break; }
            }
        }

        private void backgroundWorker3_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            label6.Text = e.ProgressPercentage + "%";
            progressBar2.Value = e.ProgressPercentage;
        }

        private void backgroundWorker3_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (fCancelIns)
            {
                label6.Text = "";
                DisplayArray(array, listBox2);
                fCancelIns = false;
            }
            else
            {
                TimeSpan time = new TimeSpan(DateTime.Now.Ticks) - tsIns;
                label6.Text = $"{time.Hours}.{time.Minutes}.{time.Seconds}.{time.Milliseconds}";
                DisplayArray(arrayIns, listBox2);
            }
            progressBar2.Value = 0;
            button1.Enabled = true;
        }

        private void backgroundWorker4_DoWork(object sender, DoWorkEventArgs e)
        {
            tsSel = new TimeSpan(DateTime.Now.Ticks);

            for (int i = 0; i < arraySel.Length; i++)
            {
                Thread.Sleep(1);
                int k = i;
                int x = arraySel[i];
                for (int j = i + 1; j < arraySel.Length; j++)
                {
                    if (arraySel[j] < x) { k = j; x = arraySel[j]; }
                }
                arraySel[k] = arraySel[i];
                arraySel[i] = x;

                try { backgroundWorker4.ReportProgress((i * 100) / arraySel.Length); }
                catch (InvalidOperationException ex) { MessageBox.Show(ex.Message); return; }

                if (backgroundWorker4.CancellationPending) { fCancelSel = true; break; }
            }
        }

        private void backgroundWorker4_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            label7.Text = e.ProgressPercentage + "%";
            progressBar3.Value = e.ProgressPercentage;
        }

        private void backgroundWorker4_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (fCancelSel)
            {
                label7.Text = "";
                DisplayArray(array, listBox3);
                fCancelSel = false;
            }
            else
            {
                TimeSpan time = new TimeSpan(DateTime.Now.Ticks) - tsSel;
                label7.Text = $"{time.Hours}.{time.Minutes}.{time.Seconds}.{time.Milliseconds}";
                DisplayArray(arraySel, listBox3);
            }
            progressBar3.Value = 0;
            button1.Enabled = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void backgroundWorker2_DoWork_1(object sender, DoWorkEventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
