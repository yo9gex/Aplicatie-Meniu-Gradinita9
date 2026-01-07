using QuestPDF.Fluent;
using System.CodeDom;

namespace Aplicatie_Meniu_Gradinita9
{
    public partial class AnchetaAlimentara : UserControl
    {
        public string Date;
        public string AbatereCalorii;
        public string AbatereProteine;
        public string AbatereLipide;
        public string AbatereGlucide;
        public string InterpretareCalorii;
        public string InterpretareProteine;
        public string InterpretareLipide;
        public string InterpretareGlucide;
        public MeniulZilei MeniulZileiInstance { get; set; }

        public AnchetaAlimentara()
        {
            InitializeComponent();
            Date = DateTime.Now.ToString("dd-MM-yyyy");

        }
        public void RefreshData()
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)RefreshData);
                return;

            }
            TotalNutrienti tn = new TotalNutrienti();
            dataToday_lbl.Text = Date;
            totalP_lbl.Text = tn.TotalProteine;
            totalL_lbl.Text = tn.TotalLipide;
            totalG_lbl.Text = tn.TotalGlucide;
            totalC_lbl.Text = tn.TotalCalorii;
            procentP_lbl.Text = tn.ProcentProteine;
            procentL_lbl.Text = tn.ProcentLipide;
            procentG_lbl.Text = tn.ProcentGlucide;
            CalculAbatereMedie(out string totalAbatereC, out string totalAbatereP, out string totalAbatereL, out string totalAbatereG);
            InterpretareRezultate(out string interpretareC, out string interpretareP, out string interpretareL, out string interpretareG);
        }   
        private void AnchetaAlimentara_Load(object sender, EventArgs e)
        {
            RefreshData();
        }
        public void CalculAbatereMedie(out string totalAbatereC, out string totalAbatereP, out string totalAbatereL, out string totalAbatereG )
        {
            totalAbatereC = "0.00";
            totalAbatereP = "0.00";
            totalAbatereL = "0.00";
            totalAbatereG = "0.00";

           TotalNutrienti totalNutrienti = new TotalNutrienti();
            // Fix CS0019: Convert string to double before calculation
            if (double.TryParse(totalNutrienti.TotalCalorii, out double totalCaloriiValue))
                if (double.TryParse(totalNutrienti.TotalProteine, out double totalProteineValue))
                    if (double.TryParse(totalNutrienti.TotalLipide, out double totalLipideValue))
                        if (double.TryParse(totalNutrienti.TotalGlucide, out double totalGlucideValue))

                        {
                            // Fix CS1002 and CS1513: Correct parentheses and syntax
                            AbatereCalorii = ((totalCaloriiValue * 100 / 1175.2) - 100).ToString("F2");
                            AbatereProteine = ((totalProteineValue * 100 / 29.6) - 100).ToString("F2");
                            AbatereLipide = ((totalLipideValue * 100 / 35.2) - 100).ToString("F2");
                            AbatereGlucide = ((totalGlucideValue * 100 / 158.2) - 100).ToString("F2");

                            abatereCalorii_lbl.Text = AbatereCalorii + " %";
                            abatereProteine_lbl.Text = AbatereProteine + " %";
                            abatereLipide_lbl.Text = AbatereLipide + " %";
                            abatereGlucide_lbl.Text = AbatereGlucide + " %";
                          
                        }
                        else
                        {
                            AbatereCalorii = "Valuare invalida";
                            AbatereProteine = "Valoare invalida";
                            AbatereLipide = "Valoare invalida";
                            AbatereGlucide = "Valoare invalida";
                        }
            totalAbatereC = abatereCalorii_lbl.Text;
            totalAbatereP = abatereProteine_lbl.Text;
            totalAbatereL = abatereLipide_lbl.Text;
            totalAbatereG = abatereGlucide_lbl.Text;
        }
        private void generarePDF_btn_Click(object sender, EventArgs e)
        {           
            AnchetaAlimentaraPDF document = new AnchetaAlimentaraPDF(this);
            document.GeneratePdfAndShow();
        }
        public void InterpretareRezultate(out string interpretareC, out string interpretareP, out string interpretareL, out string interpretareG )
        {
            interpretareC = "0.00";
            interpretareP = "0.00";
            interpretareL = "0.00";
            interpretareG = "0.00";  

            TotalNutrienti tn = new TotalNutrienti();
            bool okCal = double.TryParse(tn.TotalCalorii, out double totalCalorii);
            bool okProt = double.TryParse(tn.TotalProteine, out double totalProteine);
            bool okLip = double.TryParse(tn.TotalLipide, out double totalLipide);
            bool okGlu = double.TryParse(tn.TotalGlucide, out double totalGlucide);

            if (okCal)
            {
                if (totalCalorii > 1456)
                {
                    InterpretareCalorii = " Valoarea realizată depășește" + "\n" + "   limita maximă a" + "\n" + "   necesarului estimat 80%";
                    interpretareC_lbl.Text = InterpretareCalorii;

                }
                else if (totalCalorii > 936)
                {
                    InterpretareCalorii = "  Valoarea realizată este" + "\n" + "   în limitele necesarului" + "\n" + "   estimat 80 %";
                    interpretareC_lbl.Text = InterpretareCalorii;
                }
                else
                {
                    InterpretareCalorii = " Valoarea realizată este" + "\n" + " sub limita minimă a" + "\n" + "  necesarului estimat 80%";
                    interpretareC_lbl.Text = InterpretareCalorii;
                }               
            }

            if (okProt)
            {
                if(totalProteine > 52.8)
                {
                    InterpretareProteine = " Valoarea realizată depășește" + "\n" + "   limita maximă a" + "\n" + "   necesarului estimat 80%";
                    interpretareP_lbl.Text = InterpretareProteine;
                }
                else if (totalProteine > 36)
                {
                    InterpretareProteine = "  Valoarea realizată este" + "\n" + "   în limitele necesarului" + "\n" + "   estimat 80 %";
                    interpretareP_lbl.Text = InterpretareProteine;
                }
                else
                {
                    InterpretareProteine = " Valoarea realizată este" + "\n" + " sub limita minimă a" + "\n" + "  necesarului estimat 80%";
                    interpretareP_lbl.Text= InterpretareProteine;
                }
             
            }

            if (okLip)
            {
                if(totalLipide > 54.4)
                {
                    InterpretareLipide = " Valoarea realizată depășește" + "\n" + "   limita maximă a" + "\n" + "   necesarului estimat 80%";
                    interpretareL_lbl.Text = InterpretareLipide;
                }
                else if (totalLipide > 20)

                {
                    InterpretareLipide = "  Valoarea realizată este" + "\n" + "   în limitele necesarului" + "\n" + "   estimat 80 %";
                    interpretareL_lbl.Text = InterpretareLipide;
                }
                else
                {
                  InterpretareLipide = " Valoarea realizată este" + "\n" + " sub limita minimă a" + "\n" + "  necesarului estimat 80%";
                    interpretareL_lbl.Text = InterpretareLipide;
                }
           
            }

            if (okGlu)
            {
                if (totalGlucide > 159.2)
                {
                    InterpretareGlucide = " Valoarea realizată depășește" + "\n" + "   limita maximă a" + "\n" + "   necesarului estimat 80%";
                    interpretareG_lbl.Text = InterpretareGlucide;
                }
                else if (totalGlucide > 136.2)
                {
                    InterpretareGlucide = "  Valoarea realizată este" + "\n" + "   în limitele necesarului" + "\n" + "   estimat 80 %";
                    interpretareG_lbl.Text = InterpretareGlucide;
                }
                else 
                { 
                InterpretareGlucide = " Valoarea realizată este" + "\n" + " sub limita minimă a" + "\n" + "  necesarului estimat 80%";
                    interpretareG_lbl.Text = InterpretareGlucide; 
                }
            }

            else 
            {
                InterpretareCalorii = "Valoarea este invalida ";
                interpretareC_lbl.Text = InterpretareCalorii;
                InterpretareProteine = "Valoarea este invalida ";
                interpretareP_lbl.Text = InterpretareProteine;
                InterpretareLipide = "Valoarea este invalida ";
                interpretareL_lbl.Text = InterpretareCalorii;
                InterpretareGlucide = "Valoarea este invalida ";
                interpretareG_lbl.Text = InterpretareGlucide;              
            }
            interpretareC = interpretareC_lbl.Text;
            interpretareP = interpretareP_lbl.Text;
            interpretareL = interpretareL_lbl.Text;
            interpretareG = interpretareG_lbl.Text;
        }
    }
}
