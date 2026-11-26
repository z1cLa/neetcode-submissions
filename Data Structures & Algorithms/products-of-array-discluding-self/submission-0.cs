public class Solution {
    public int[] ProductExceptSelf(int[] nums) {
        int len = nums.Length;
        int[] output = new int[len];

        // 1. prolaz: output[i] = proizvod svega LEVO od i
        output[0] = 1;    // levo od prvog nema ničega → 1
        for(int i = 1; i<len; i++){
            output[i] = output[i-1] * nums[i-1];
        }

        // 2. prolaz: pomnoži sa proizvodom svega DESNO od i
        int right = 1; // desno od poslednjeg nema ničega → 1
        for(int i = len - 1; i >= 0; i--){
            output[i] = output[i] * right;
            right = right * nums[i];  // ažuriraj desni proizvod za sledeću (levlju) poziciju
        }

        return output;
    }
}
