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
        public string AbatereCalciu;
        public string AbatereFier;
        public string InterpretareCalorii;
        public string InterpretareProteine;
        public string InterpretareLipide;
        public string InterpretareGlucide;
        public string InterpretareCalciu;
        public string InterpretareFier;
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
            proteineVeg_lbl.Text = tn.ProteineVegetale;
            proteineAnim_lbl.Text = tn.ProteineAnimale;
            totalL_lbl.Text = tn.TotalLipide;
            lipideVeg_lbl.Text = tn.LipideVegetale;
            lipideAnim_lbl.Text = tn.LipideAnimale;
            totalG_lbl.Text = tn.TotalGlucide;
            totalC_lbl.Text = tn.TotalCalorii;
            calciu_lbl.Text = tn.TotalCalciu;
            fier_lbl.Text = tn.TotalFier;

            procentP_lbl.Text = tn.ProcentProteine;
            procentL_lbl.Text = tn.ProcentLipide;
            procentG_lbl.Text = tn.ProcentGlucide;
            CalculAbatereMedie(out string totalAbatereC, out string totalAbatereP, out string totalAbatereL, out string totalAbatereG, out string totalAbatereCalciu, out string totalAbatereFier);
            InterpretareRezultate(out string interpretareC, out string interpretareP, out string interpretareL, out string interpretareG, out string interpretareCalciu, out string interpretareFier);
        }
        private void AnchetaAlimentara_Load(object sender, EventArgs e)
        {
            RefreshData();
        }
        public void CalculAbatereMedie(out string totalAbatereC, out string totalAbatereP, out string totalAbatereL, out string totalAbatereG, out string totalAbatereCalciu, out string totalAbatereFier)
        {
            totalAbatereC = "0.00";
            totalAbatereP = "0.00";
            totalAbatereL = "0.00";
            totalAbatereG = "0.00";
            totalAbatereCalciu = "0.00";
            totalAbatereFier = "0.00";

            TotalNutrienti totalNutrienti = new TotalNutrienti();
            // Fix CS0019: Convert string to double before calculation
            if (double.TryParse(totalNutrienti.TotalCalorii, out double totalCaloriiValue))
                if (double.TryParse(totalNutrienti.TotalProteine, out double totalProteineValue))
                    if (double.TryParse(totalNutrienti.TotalLipide, out double totalLipideValue))
                        if (double.TryParse(totalNutrienti.TotalGlucide, out double totalGlucideValue))
                            if(double.TryParse(totalNutrienti.TotalCalciu, out double totalCalciuValue))
                                if(double.TryParse (totalNutrienti.TotalFier, out double totalFierValue))

                        {
                            // Fix CS1002 and CS1513: Correct parentheses and syntax
                            AbatereCalorii = ((totalCaloriiValue * 100 / 1175.2) - 100).ToString("F2");
                            AbatereProteine = ((totalProteineValue * 100 / 29.6) - 100).ToString("F2");
                            AbatereLipide = ((totalLipideValue * 100 / 35.2) - 100).ToString("F2");
                            AbatereGlucide = ((totalGlucideValue * 100 / 158.2) - 100).ToString("F2");
                                    AbatereCalciu = ((totalCalciuValue * 100 / 640) - 100).ToString("F2");
                                    AbatereFier = ((totalFierValue * 100 / 5.6) - 100).ToString("F2");

                                    abatereCalorii_lbl.Text = AbatereCalorii + " %";
                            abatereProteine_lbl.Text = AbatereProteine + " %";
                            abatereLipide_lbl.Text = AbatereLipide + " %";
                            abatereGlucide_lbl.Text = AbatereGlucide + " %";
                                    abatereCalciu_lbl.Text = AbatereCalciu + " %";
                                    abatereFier_lbl.Text = AbatereFier + " %";

                                }
                        else
                        {
                            AbatereCalorii = "Valuare invalida";
                            AbatereProteine = "Valoare invalida";
                            AbatereLipide = "Valoare invalida";
                            AbatereGlucide = "Valoare invalida";
                                    AbatereCalciu = "Valoare invalida";
                                    AbatereFier = "Valoare invalida";

                                }
            totalAbatereC = abatereCalorii_lbl.Text;
            totalAbatereP = abatereProteine_lbl.Text;
            totalAbatereL = abatereLipide_lbl.Text;
            totalAbatereG = abatereGlucide_lbl.Text;
            totalAbatereCalciu = abatereCalciu_lbl.Text;
            totalAbatereFier = abatereFier_lbl.Text;
        }
        private void generarePDF_btn_Click(object sender, EventArgs e)
        {
            AnchetaAlimentaraPDF document = new AnchetaAlimentaraPDF(this);
            document.GeneratePdfAndShow();
        }
        public void InterpretareRezultate(out string interpretareC, out string interpretareP, out string interpretareL, out string interpretareG, out string interpretareCalciu, out string interpretareFier)
        {
            interpretareC = "0.00";
            interpretareP = "0.00";
            interpretareL = "0.00";
            interpretareG = "0.00";
            interpretareCalciu = "0.00";
            interpretareFier = "0.00";

            TotalNutrienti tn = new TotalNutrienti();
            bool okCal = double.TryParse(tn.TotalCalorii, out double totalCalorii);
            bool okProt = double.TryParse(tn.TotalProteine, out double totalProteine);
            bool okLip = double.TryParse(tn.TotalLipide, out double totalLipide);
            bool okGlu = double.TryParse(tn.TotalGlucide, out double totalGlucide);
            bool okCalciu = double.TryParse(tn.TotalCalciu, out double totalCalciu);
            bool okFier = double.TryParse(tn.TotalFier, out double totalFier);

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
                if (totalProteine > 52.8)
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
                    interpretareP_lbl.Text = InterpretareProteine;
                }

            }

            if (okLip)
            {
                if (totalLipide > 54.4)
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
            if (okCalciu)
            {
                // Interpretare pentru calciu 
                if (totalCalciu > 640)
                {
                    InterpretareCalciu = " Valoarea realizată depășește" + "\n" + "   limita maximă a" + "\n" + "   necesarului estimat 80%";
                    interpretareCalciu_lbl.Text = InterpretareCalciu;
                }
                else if (totalCalciu == 640)
                {
                    InterpretareCalciu = "  Valoarea realizată este" + "\n" + "   în limitele necesarului" + "\n" + "   estimat 80 %";
                    interpretareCalciu_lbl.Text = InterpretareCalciu;
                }
                else
                {
                    InterpretareCalciu = " Valoarea realizată este" + "\n" + " sub limita minimă a" + "\n" + "  necesarului estimat 80%";
                    interpretareCalciu_lbl.Text = InterpretareCalciu;
                }
            }
            if (okFier)
            {
                // Interpretare pentru fier 
                if (totalFier > 5.6)
                {
                    InterpretareFier = " Valoarea realizată depășește" + "\n" + "   limita maximă a" + "\n" + "   necesarului estimat 80%";
                    interpretareFier_lbl.Text = InterpretareFier;
                }
                else if (totalFier == 5.6)
                {
                    InterpretareFier = "  Valoarea realizată este" + "\n" + "   în limitele necesarului" + "\n" + "   estimat 80 %";
                    interpretareFier_lbl.Text = InterpretareFier;
                }
                else
                {
                    InterpretareFier = " Valoarea realizată este" + "\n" + " sub limita minimă a" + "\n" + "  necesarului estimat 80%";
                    interpretareFier_lbl.Text = InterpretareFier;
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
                InterpretareCalciu = "Valoarea este invalida ";
                interpretareCalciu_lbl.Text = InterpretareCalciu;
                InterpretareFier = "Valoarea este invalida ";
                interpretareFier_lbl.Text = InterpretareFier;
            }
            interpretareC = interpretareC_lbl.Text;
            interpretareP = interpretareP_lbl.Text;
            interpretareL = interpretareL_lbl.Text;
            interpretareG = interpretareG_lbl.Text;
            interpretareCalciu = interpretareCalciu_lbl.Text;
            interpretareFier = interpretareFier_lbl.Text;
        }
    }
}
