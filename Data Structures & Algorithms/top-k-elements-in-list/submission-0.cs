public class Solution {
    public int[] TopKFrequent(int[] nums, int k) {
        Dictionary<int, int> count = new Dictionary<int, int>();
        foreach (int n in nums)
            count[n] = count.GetValueOrDefault(n, 0) + 1;

        // bucket[f] = lista brojeva koji se javljaju tačno f puta
        List<int>[] bucket = new List<int>[nums.Length + 1];
        foreach (var pair in count) {
            int freq = pair.Value;
            if (bucket[freq] == null)
                bucket[freq] = new List<int>();
            bucket[freq].Add(pair.Key);
        }

        List<int> result = new List<int>();
        for (int f = bucket.Length - 1; f >= 0 && result.Count < k; f--) {
            if (bucket[f] != null)
                result.AddRange(bucket[f]);
        }
        return result.Take(k).ToArray();

    }
}