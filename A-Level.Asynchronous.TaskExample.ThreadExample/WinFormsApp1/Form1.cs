namespace WinFormsApp1;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    private void button1_Click(object sender, EventArgs e)
    {
        //Thread.Sleep(3000);
        //await Task.Delay(3000)
        Task.Delay(3000)
            .ContinueWith(x =>
            {
                this.Invoke(() =>
                {
                    this.button1.Text = "Changed Text";
                });
            });
    }
}
