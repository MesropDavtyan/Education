namespace BinarySearch
{
    public class Solution
    {
        public bool BinarySearchRecursive(int[] arr, int itemToSearch, int left, int right)
        {
            if(left > right)
            {
                return false;
            }

            int mid = (left + right) / 2;
            if (arr[mid] == itemToSearch)
            {
                return true;
            }
            else if (itemToSearch < arr[mid])
            {
                return BinarySearchRecursive(arr, itemToSearch, left, mid - 1);
            }
            else
            {
                return BinarySearchRecursive(arr, itemToSearch, mid + 1, right);
            }
        }

        public bool BinarySearchIterative(int[] arr, int itemToSearch)
        {
            int left = 0;
            int right = arr.Length - 1;

            while (left <= right)
            {
                int mid = (left + right) / 2;
                if (itemToSearch == arr[mid])
                {
                    return true;
                }
                else if (itemToSearch < arr[mid])
                {
                    right = mid - 1;
                }
                else
                {
                    left = mid + 1;
                }
            }
            return false;
        }
    }
}
