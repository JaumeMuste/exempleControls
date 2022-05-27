namespace exempleControls
{
    public partial class Form1 : Form
    {

        // EXEMPLE PER TREBALLAR:
        //  - List (Afegir, Eliminar, Ordenar, accedir a un element per índex, ...)
        //  - ListBox + events
        //  - ComboBox + events
        //  - Enviar dades entre formularis


        static List<string> llistacompra = new List<string>();
        BindingSource llistacompraBindingSource = new BindingSource();

        public Form1()
        {
            //s'executa una vegada per cada nova instància de Form1
            InitializeComponent();



            //afegir elements a la llista
            //llistacompra.Add("Pà");
            //llistacompra.Add("Fruita");
            //llistacompra.Add("Pasta");
            //llistacompra.Add("Verdura");

            //definir el data source
            llistacompraBindingSource.DataSource = llistacompra;

            //definir binding del listbox
            listBox1.DataSource=llistacompraBindingSource;

        }

        internal void rebredades(string itemnou)
        {
            llistacompra.Add(itemnou);
            MessageBox.Show("Tens " + llistacompra.Count + " items a la llista.");
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
            //només s'executa quan carrega el formulari
            //afegir elements a la llista
            llistacompra.Add("Pà");
            llistacompra.Add("Fruita");
            llistacompra.Add("Pasta");
            llistacompra.Add("Verdura");
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            //refrescar les dades
            llistacompraBindingSource.ResetBindings(false);
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
            //MessageBox.Show("Has seleccionat l'ítem: " + listBox1.SelectedItem + " que està a la posició: " + listBox1.SelectedIndex);

            int index = listBox1.SelectedIndex;

            if (index >= 0)
            {
                DialogResult resposta = MessageBox.Show("Vols eliminar " + llistacompra[index] + " ?", "CONFIRMA ACCIÓ", MessageBoxButtons.YesNo);

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