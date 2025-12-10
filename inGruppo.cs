using System;
using System.Runtime.CompilerServices;
class inGruppo
{
    static void BoobleSort(ref int[] votiPartiti, ref string[] numeriPartiti)
    {
        bool switched = true;
        while (switched)
        {
            switched = false;
            for (int i = 0; i < votiPartiti.Length - 1; i++)
            {
                if (votiPartiti[i] < votiPartiti[i + 1])
                {
                    int tempVoto = votiPartiti[i];
                    votiPartiti[i] = votiPartiti[i + 1];
                    votiPartiti[i + 1] = tempVoto;
                    string tempNumero = numeriPartiti[i];
                    numeriPartiti[i] = numeriPartiti[i + 1];
                    numeriPartiti[i + 1] = tempNumero;
                    switched = true;
                }
            }
        }
    }

    static int TrovaMassimo(int[] array)
    {
        int max = array[0];
        for (int i = 1; i < array.Length; i++)
        {
            if (array[i] > max)
            {
                max = array[i];
            }
        }
        return max;
    }

    static int removeMax(ref int[] array)
    {
        int max = TrovaMassimo(array);
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] == max)
            {
                array[i] = 0;
                max = i;
                break;
            }
        }
        return max;
    }

    static int[] CalcolaVincitore(int[] votiPartiti, string[] nomePartito, int numeroSeggi)
    {
        // metto in ordine l'array dei voti e dei partiti
        BoobleSort(ref votiPartiti, ref nomePartito);
        // genero la matrice
        int[][] calcolaSeggi = new int[numeroSeggi][];
        for (int i = 0; i < numeroSeggi; i++)
        {
            calcolaSeggi[i] = new int [votiPartiti.Length];
        }
        for(int i=0;i<calcolaSeggi[0].Length;i++){
            calcolaSeggi[0][i] = votiPartiti[i];
        }
        for(int i=1;i<calcolaSeggi.Length;i++){
            for(int j=0;j<calcolaSeggi[i].Length;j++){
                calcolaSeggi[i][j] = calcolaSeggi[0][j]/(i+1);
            }
        }
        // variabile dove salvare i seggi assegnati
        int[] seggiAssegnati = new int[nomePartito.Length];
        bool finished = false;
        while(!finished && numeroSeggi>0){
            int i=0;
            while(TrovaMassimo(calcolaSeggi[i]) == 0){
                i++;
            }
            if(i==calcolaSeggi.Length-1){
                seggiAssegnati[removeMax(ref calcolaSeggi[i])]++;
                numeroSeggi--;
            }else{
                if(TrovaMassimo(calcolaSeggi[i]) > TrovaMassimo(calcolaSeggi[i+1])){
                    seggiAssegnati[removeMax(ref calcolaSeggi[i])]++;
                    numeroSeggi--;
                }else{
                    seggiAssegnati[removeMax(ref calcolaSeggi[i+1])]++;
                    numeroSeggi--;
                }
            }


            finished = true;
            foreach(int[] row in calcolaSeggi){
                if(TrovaMassimo(row) != 0){
                    finished = false;
                }
            }
        }
        return seggiAssegnati;
    }
    static void Main(string[] args)
    {
        Console.WriteLine("inserisci il numero di partiti");
        int numeroPartiti = /*/5/*/Int32.Parse(Console.ReadLine())/**/;
        int[] votiPartiti = new int[numeroPartiti];
        string[] nomePartito = new string[numeroPartiti];
        for(int i = 0; i < numeroPartiti; i++)
        {
            nomePartito[i] = ((char)('A' + i)).ToString();
            Console.WriteLine($"inserisci i voti del partito {nomePartito[i]}");
            votiPartiti[i] = /*/(numeroPartiti-i)*15/*/Int32.Parse(Console.ReadLine())/**/;
        }
        Console.WriteLine("inserisci il numero di seggi da assegnare");
        int numeroSeggi = /*/9/*/Int32.Parse(Console.ReadLine())/**/;
        int[] eletti = CalcolaVincitore(votiPartiti, nomePartito, numeroSeggi);
        for(int i=0;i<eletti.Length;i++){
            Console.WriteLine($"Il partito {nomePartito[i]} ha ottenuto {eletti[i]} seggi");
        }
    }
}