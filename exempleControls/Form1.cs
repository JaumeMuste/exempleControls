namespace exempleControls
{
    public partial class Form1 : Form
    {

        // EXEMPLE PER TREBALLAR:
        //  - List (Afegir, Eliminar, Ordenar, accedir a un element per �ndex, ...)
        //  - ListBox + events
        //  - ComboBox + events
        //  - Enviar dades entre formularis


        static List<string> llistacompra = new List<string>();
        static int enter1 = 0;
        static int enter2 = 0;
 
        BindingSource llistacompraBindingSource = new BindingSource();

        public Form1()
        {
            //s'executa una vegada per cada nova inst�ncia de Form1
            InitializeComponent();



            //afegir elements a la llista
            //llistacompra.Add("P�");
            //llistacompra.Add("Fruita");
            //llistacompra.Add("Pasta");
            //llistacompra.Add("Verdura");

            //definir el data source
            llistacompraBindingSource.DataSource = llistacompra;

            //definir binding del listbox
            listBox1.DataSource=llistacompraBindingSource;

        }

        internal void rebredades(string itemnou, int e1, int e2)
        {
            llistacompra.Add(itemnou);
            MessageBox.Show("Tens " + llistacompra.Count + " items a la llista. E1="+e1+" E2="+e2);
            enter1 = e1;
            enter2 = e2;

            
            //label1.Text = e1.ToString();
            //label2.Text = e2.ToString();

        }
        private void button1_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.ShowDialog();
            
            
            //enviar les dades a Form1

            //this.Close();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //nom�s s'executa quan carrega el formulari
            //afegir elements a la llista
            llistacompra.Add("P�");
            llistacompra.Add("Fruita");
            llistacompra.Add("Pasta");
            llistacompra.Add("Verdura");

            label1.Text = enter1.ToString();
            label2.Text = enter2.ToString();
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            //refrescar les dades
            llistacompraBindingSource.ResetBindings(false);
            label1.Text = enter1.ToString();
            label2.Text = enter2.ToString();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == "ordenar A->Z")
            {
                llistacompra.Sort();
            }
            else
            {
                llistacompra.Sort();
                llistacompra.Reverse();
            }
            //refrescar les dades
            llistacompraBindingSource.ResetBindings(false);


            //MessageBox.Show("has canviat el valor");
        }

        private void listBox1_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Has seleccionat l'�tem: " + listBox1.SelectedItem + " que est� a la posici�: " + listBox1.SelectedIndex);

            int index = listBox1.SelectedIndex;

            if (index >= 0)
            {
                DialogResult resposta = MessageBox.Show("Vols eliminar " + llistacompra[index] + " ?", "CONFIRMA ACCI�", MessageBoxButtons.YesNo);

                if (resposta == DialogResult.Yes)
                {

                    llistacompra.RemoveAt(index);
                    llistacompraBindingSource.ResetBindings(false);
                }
            }

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}