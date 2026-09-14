public class Solution {
    public List<List<string>> GroupAnagrams(string[] strs) {
        Dictionary<string, List<string>> groups = new Dictionary<string, List<string>>();
        foreach(string s in strs){
            int[] count = new int[26];
            foreach(char c in s)
                count[c - 'a']++;

            string key = string.Join(",", count);
            
            if(!groups.ContainsKey(key))
                groups[key] = new List<string>();

            groups[key].Add(s);
        }

        return new List<List<string>>(groups.Values);
    }
}

/*
 Potpis frekvencije kao ključ (bez sortiranja).

 Za svaku reč: prebroji slova u niz od 26 (count[c-'a']++),
 pa taj niz pretvori u string-ključ: string.Join(",", count).
 Anagrami daju isti niz brojača -> isti ključ -> ista kutija.

 Primer: ["act","pots","tops","cat","stop","hat"]

   "act"  -> [a:1,c:1,t:1]      -> nova kutija
   "pots" -> [o:1,p:1,s:1,t:1]  -> nova kutija
   "tops" -> [o:1,p:1,s:1,t:1]  -> postoji (ista slova kao pots)
   "cat"  -> [a:1,c:1,t:1]      -> postoji (ista slova kao act)
   "stop" -> [o:1,p:1,s:1,t:1]  -> postoji
   "hat"  -> [a:1,h:1,t:1]      -> nova kutija

 Vrati vrednosti mape:
   [ [act,cat], [pots,tops,stop], [hat] ]

 Broji (O(n) po reči) -> ukupno O(m * n), brže.
*/