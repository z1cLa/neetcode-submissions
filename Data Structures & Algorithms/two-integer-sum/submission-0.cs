public class Solution {
    public int[] TwoSum(int[] nums, int target) {
        Dictionary<int, int> seen = new Dictionary<int, int>();
        for (int i = 0; i < nums.Length; i++)
        {
            int complement = target - nums[i];
            if(seen.ContainsKey(complement)){
                return new int[] { seen[complement], i};
            }
        seen[nums[i]] = i;
        }
        return new int[]{};
    }
}

/*
nums=[4,5,6]; target=10;

i=0, gledamo nums[0] = 4
complement = target - nums[0] = 10 - 4 = 6
Pitam mapu: je li 6 u {}?  → NE (mapa je prazna)
Pa zapamtim trenutni broj: seen[4] = 0
Mapa sad: {4: 0}

i=1, gledamo nums[1] = 5
complement = 10 - 5 = 5
Pitam mapu: je li 5 u {4: 0}?  → NE (unutra je samo 4)
Pa zapamtim: seen[5] = 1
Mapa sad: {4: 0, 5: 1}

i=2, gledamo nums[2] = 6
complement = 10 - 6 = 4
Pitam mapu: je li 4 u {4: 0, 5: 1}?  → DA! na indeksu 0
Našao sam par → vrati [ seen[4], i ] = [0, 2]   ✓
*/