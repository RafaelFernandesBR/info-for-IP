using telegramIp;

namespace rafaGt
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //definir o título da janela
            this.Text = "Informações IP";
            //criar um campo de edição
            TextBox txt = new TextBox();
            txt.Text = "google.com";
            txt.Location = new Point(10, 10);
            txt.Size = new Size(100, 20);
            this.Controls.Add(txt);
            //quando for precionado o enter
            txt.KeyDown += new KeyEventHandler(GetIpInfo);
        }

        void GetIpInfo(object sender, KeyEventArgs e)
        {
            //se precionar enter
            if (e.KeyCode == Keys.Enter)
            {
                var Buscar = new getInfo();
                //pegar o valor do campo de edição
                TextBox txtTotal = (TextBox)sender;
                //pegar o valor do campo de edição
                string ip = txtTotal.Text;
                //buscar o ip
                string[] retorno = Buscar.buscaInfoIp(ip);
                //criar e exibir o retorno em uma lista
                ListBox lista = new ListBox();
                lista.Location = new Point(10, 40);
                lista.Size = new Size(300, 200);
                this.Controls.Add(lista);
                foreach (string item in retorno)
                {
                    lista.Items.Add(item);
                }

                //copiar um item da lista com ctrl+c
                lista.KeyDown += new KeyEventHandler(CopyItem);

            }
        }
        void CopyItem(object sender, KeyEventArgs e)
        {
            //se precionar ctrl+c
            if (e.KeyCode == Keys.C && e.Control)
            {
                //pegar o item selecionado
                ListBox lista = (ListBox)sender;
                //copiar o item selecionado
                Clipboard.SetText(lista.SelectedItem.ToString());
            }
        }

    }
}
