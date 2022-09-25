using System;
using System.IO;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Dbadapter
{
    public class LW
    {
        //zmienne globalne
        const int rozmiar = 22;
        string[][] raportTable = new string[rozmiar][]{
                                new string[100000],
                                new string[100000],
                                new string[100000],
                                new string[100000],
                                new string[100000],
                                new string[100000],
                                new string[100000],
                                new string[100000],
                                new string[100000],
                                new string[100000],
                                new string[100000],
                                new string[100000],
                                new string[100000],
                                new string[100000],
                                new string[100000],
                                new string[100000],
                                new string[100000],
                                new string[100000],
                                new string[100000],
                                new string[100000],
                                new string[100000],
                                new string[100000]};

        public static void plikilw2(string strTxtFilePath)
        {
            string namesourceLW = "";
            if (File.Exists("//anakonda1/print/dbadapter/lw.txt"))
                namesourceLW = "//anakonda1/print/dbadapter/lw.txt";
            else
                namesourceLW = "c:\\Program Files\\_MojeProgramy\\Dbadapter\\lw.txt";
            StreamReader srlw = new StreamReader(namesourceLW, Encoding.Default);
            string linelw = "";
            ArrayList lwvalue = new ArrayList();
            while ((linelw = srlw.ReadLine()) != null)
            {
                lwvalue.Add(linelw);
            }
            srlw.Close();
            StreamReader sr2 = new StreamReader(strTxtFilePath, Encoding.Default);
            string naglowek = sr2.ReadLine();
            string line = "";
            string rodz = "";
            ArrayList proofvalue = new ArrayList();
            while ((line = sr2.ReadLine()) != null)
            {
                string letter_id = line.Split(';')[0].Replace(" ", "").Replace("\"", "").ToUpper();
                foreach (string item in lwvalue)
                {
                    rodz = "REST";
                    if (item.Split('|')[0].Trim(' ') == letter_id)
                    {
                        rodz = item.Split('|')[1];
                        goto next; 
                    }               
                }
            next:
                string path1 = Path.GetDirectoryName(strTxtFilePath) + "/_SORT_LW_" + rodz + ".txt";
                bool nag = File.Exists(path1);
                StreamWriter sw2 = new StreamWriter(path1, true, Encoding.Default);
                if (nag == false)
                    sw2.WriteLine(naglowek);
                sw2.WriteLine(line);
                sw2.Close();
                //proofy
                if (letter_id != "")
                {
                    if (proofvalue.IndexOf(letter_id) == -1)
                    {
                        proofvalue.Add(letter_id);
                        string path2 = Path.GetDirectoryName(strTxtFilePath) + "/_SORT_LW_PRO0F.txt";
                        nag = File.Exists(path2);
                        StreamWriter sw3 = new StreamWriter(path2, true, Encoding.Default);
                        if (nag == false)
                            sw3.WriteLine(naglowek);
                        sw3.WriteLine(line);
                        sw3.Close();

                    }
                }
            }
            sr2.Close();
        }

        public static void plikilw(string strTxtFilePath, string dbAll, string dbProof)
        {
            int wielkosc_kolumny = 40;
            int blad = 0;
            string line;

            string naglowek = "LP".PadRight(wielkosc_kolumny) + ";" + "IMIE_NAZWISKO".PadRight(wielkosc_kolumny) + ";" + "ADRES1".PadRight(wielkosc_kolumny) + ";" +
            "ADRES2".PadRight(wielkosc_kolumny) + ";" + "KOD".PadRight(wielkosc_kolumny) + ";" + "MIASTO".PadRight(wielkosc_kolumny) + ";" +
            "ADRES1_KORESP".PadRight(wielkosc_kolumny) + ";" + "ADRES2_KORESP".PadRight(wielkosc_kolumny) + ";" + "KOD_KORESP".PadRight(wielkosc_kolumny) + ";" +
            "MIASTO_KORESP".PadRight(wielkosc_kolumny) + ";" + "DATA_DANYCH".PadRight(wielkosc_kolumny) + ";" + "NR_KONTA".PadRight(wielkosc_kolumny) + ";" +
            "DUE_DATE".PadRight(wielkosc_kolumny) + ";" + "DEATH_DATE".PadRight(wielkosc_kolumny) + ";" + "KWOTA".PadRight(wielkosc_kolumny) + ";" +
            "CB".PadRight(wielkosc_kolumny) + ";" + "NR_DOWODU".PadRight(wielkosc_kolumny) + ";" + "NR_PESEL".PadRight(wielkosc_kolumny) + ";" +
            "RODZAJ_KARTY".PadRight(wielkosc_kolumny) + ";" + "NR_KARTY".PadRight(wielkosc_kolumny) + ";" + "OPEN_DATE".PadRight(wielkosc_kolumny) + ";" +
            "IBAN".PadRight(wielkosc_kolumny) + ";" + "BAZA_DANYCH".PadRight(wielkosc_kolumny);
            Encoding mojeKodowanie = Encoding.Default; 
            if (!File.Exists(dbAll))
            {
                File.WriteAllText(dbAll, naglowek + "\n", mojeKodowanie);
            }
            if (!File.Exists(dbProof))
            {
                File.WriteAllText(dbProof, naglowek + "\n", mojeKodowanie);
            }
            StreamWriter sw = new StreamWriter(dbAll, true, mojeKodowanie);
            StreamWriter sw2 = new StreamWriter(dbProof, true, mojeKodowanie);
            StringBuilder myTextProof = new StringBuilder();

            List<string> strTxtFileName = new List<string>();

            strTxtFileName.Add(Path.GetFileName(strTxtFilePath));
            StreamReader sr = new StreamReader(strTxtFilePath, mojeKodowanie);
            //StreamReader sr2 = new StreamReader(strTxtFilePath, mojeKodowanie);

            line = sr.ReadLine(); //mamy naglowek
            //zliczamy ilosc pol
            int ile_pol_dodac = rozmiar - line.Split(';').Length;
            for (int ileDodac = 0; ileDodac < ile_pol_dodac; ileDodac++)
            {
                line += ";";
            }
            int ile_pol = line.Split(';').Length;
            string[] nag = new string[ile_pol];
            int i = 0;
            for (i = 0; i < ile_pol; i++)
            {
                nag[i] = line.Split(';')[i].Replace("\"", "");
            }
            //tabelka do raportu
            //slownik aliasow      
            string[][] slownik_aliasow = new string[rozmiar][] {
                    new string[] { "L.P.", "LP", "LP." },
                    new string[] { "IMIE_I_NAZWISKO" , "IMIE_NAZWISKO", "NAME" },
                    new string[] { "ADRES1", "ULICA_NR", "ADRESS1" },
                    new string[] { "ADRES2", "ADRESS2" },
                    new string[] { "KOD", "AMNA_ZIP_CODE", "KOD_POCZTOWY" },
                    new string[] { "MIASTO", "CITY" },
                    new string[] { "AMPA_PA_ADDR1" },
                    new string[] { "AMPA_PA_ADDR2" },
                    new string[] { "AMPA_PA_ZIP_CODE" },
                    new string[] { "AMPA_PA_CITY" },
                    new string[] { "DATA", "DATA_DANYCH", "DATA_GENEROWANIA_PLIKU", "DATA GENEROWANIA PLIKU", "DATA_PLIKU" },
                    new string[] { "NUMER_KONTA", "KONTO", "NR_UMOWY" },
                    new string[] { "DATA_DUE_DATE", "DUE_DATE", "DUEDATE" },
                    new string[] { "DATA2", "DATA_PLATNOSCI" },
                    new string[] { "KWOTA", "AMT_PAST_DUE" },
                    new string[] { "CB", "PAST_DUE" },
                    new string[] { "AMPX_ID_DOC" },
                    new string[] { "AMPX_PESEL" },
                    new string[] { "LOGO", "RODZAJ_KARTY" },
                    new string[] { "AMBS_ACCT" },
                    new string[] { "AMBS_DATE_OPENED" },
                    new string[] { "IBAN" }};

            int[] kolumny = new int[rozmiar];
            string wynik = match_headers(kolumny, slownik_aliasow, nag);
            if (wynik != "")
            {
                MessageBox.Show(wynik);
            }
            int liczProof = 0;
            List<StringBuilder> myText = new List<StringBuilder>();
            while ((line = sr.ReadLine()) != null)
            {
                myText.Add(new StringBuilder());
                for (int ileDodac = 0; ileDodac < ile_pol_dodac; ileDodac++)
                {
                    line += ";";
                }
                for (i = 0; i < ile_pol; i++)
                {
                    string srednik = "";
                    if (kolumny[i] == -1)
                    {
                        myText[0].Append(srednik.PadRight(wielkosc_kolumny) + ";");
                    }
                    else
                    {
                        if (line.Split(';')[kolumny[i]].Trim().Length >= wielkosc_kolumny)
                        {
                            MessageBox.Show("Uwaga! Iloœæ znaków w stringu: '" + line.Split(';')[kolumny[i]] + "' jest równa b¹dŸ wieksza od " + wielkosc_kolumny + ". POPRAW TO!");
                            blad = 1;
                            break;
                        }
                        myText[0].Append(line.Split(';')[kolumny[i]].Trim().PadRight(wielkosc_kolumny) + ";");
                        int ii = kolumny[i];
                        string rowData = line.Split(';')[kolumny[i]];
                    }
                }
                myText[0].AppendLine(strTxtFileName[0].PadRight(wielkosc_kolumny));
                liczProof++;
                if (liczProof <= 2)
                {
                    myTextProof.Remove(0, myTextProof.Length);
                    myTextProof.Append(myText[0]);
                }
            }
            if (blad != 1)
            {
                sw.Write(myText[0]);
                sw.Close();
                sw2.Write(myTextProof);
                sw2.Close();
            }
        }
      
        private static string match_headers(int[] zwroc, string[][] wzor, string[] nag)
        {
            int rozmiar = wzor.Length;
            if (nag.Length > wzor.Length)
                return "Wielkoœæ tableli wzorcowej: " + wzor.Length.ToString() +
                       " wielkoœæ tabeli nag³ówka: " + nag.Length.ToString();


            Dictionary<string, int[]> slownik = new Dictionary<string, int[]>();
            for (int i = 0; i < rozmiar; i++)
            {
                for (int j = 0; j < wzor[i].Length; slownik.Add(wzor[i][j], new int[] { i, j }), j++) ;
                zwroc[i] = -1;
            }
            for (int i = 0; i < nag.Length; i++)
            {
                if (slownik.ContainsKey(nag[i].ToUpper()))
                    zwroc[slownik[nag[i].ToUpper()][0]] = i;
                else
                    if (nag[i] != "")
                    {
                        return "Nie mam w s³owniku: " + nag[i] + " Koñczê prace.";
                    }
            }
            return "";
        }
   }
}
