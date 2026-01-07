using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aplicatie_Meniu_Gradinita9
{
    public partial class Echivalente : UserControl
    {
        public Echivalente()
        {
            InitializeComponent();
            PopulateEquivalences();
        }
        public void RefreshData()
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)RefreshData);
                return;

            }
            PopulateEquivalences();
        }

        private void PopulateEquivalences()
        {
            // Data for the first table
            richTextBox1.Text = @"* 100 g orez nefiert = 300 g orez fiert
* 100 g paste nefierte = 430 g paste fierte
* 100 g cartofi nefierti = 120 g cartofi fierti
* 100 g fasole verde nefiarta = 105-110 g fasole fiarta
* 100 g leguminoase nefierte = 330 g leguminoase fierte
* 100 g carne nefiarta = 75 g fiarta = 80 g carne prajita = 70 g carne fripta pe gratar
* 100 g varza cruda = 60 g varza calita";

            // Data for the second table
            richTextBox2.Text = @"a) 100 ml lapte concentrat (condensat) = 250 ml lapte proaspăt;
b) 100 g lapte praf integral = 800 ml lapte proaspăt;
c) 100 g caşcaval = 700 ml lapte proaspăt;
d) 100 g brânză telemea de vacă = 550 ml lapte proaspăt;
e) 100 g brânză telemea de oi = 450 ml lapte proaspăt;
f) 100 g brânză proaspătă de vacă = 400 ml lapte proaspăt;
g) 100 g caş = la fel ca la brânza telemea;
h) 100 g mezeluri = 125 g carne;
i) 100 g specialităţi din carne (şuncă de Praga, muşchi file, muşchi ţigănesc, ceafă, pastramă etc.) = 135 g carne;
j) 100 g smântână = 40 g unt;
k) 100 g pâine neagră = 71 g făină;
l) 100 g pâine semialbă (intermediară) = 73 g făină;
m) 100 g pâine albă = 76 g făină;
n) 100 g paste făinoase (inclusiv biscuiţi fără cremă) = 100 g făină;
o) 100 g mălai, orez, griş = 100 g făină;
p) 100 g compot = 15 g zahăr;
q) 100 g dulceaţă = 70 g zahăr;
r) 100 g gem, peltea, marmeladă = 40 g zahăr;
s) 100 g nectar de fructe = 30 g zahăr;
t) 100 g sirop de fructe concentrat = 60 g zahăr;
u) 100 g bomboane = 90 g zahăr;
v) 100 g miere = 80 g zahăr;
w) 100 g ciocolată = 50 g zahăr şi 30 g grăsime vegetală;
x) 100 g bulion sau pastă de roşii = 600 g pătlăgele roşii (tomate);
y) 100 g suc de roşii = 135 g tomate;
z) 100 g varză acră = 130 g varză crudă;
aa) 100 g murături = 125 g legume crude;
bb) 100 g fructe deshidratate, afumate, uscate = 400 g fructe crude;
cc) 100 g morcovi deshidrataţi = 1.700 g morcovi cruzi;
dd) 100 g conserve de legume = 100 g legume crude.";
        }
    }
}
