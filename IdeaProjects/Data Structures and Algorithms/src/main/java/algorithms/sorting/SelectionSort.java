package algorithms.sorting;

public class SelectionSort {
    public static int[] sort(int[] arr){
        int min, temp;

        for (int i = 0; i < arr.length; i++) {
            min = i;
            for (int j = i + 1; j < arr.length; j++) {
                if (arr[j] < arr[min]) {
                    temp = arr[min];
                    arr[min] = arr[j];
                    arr[j] = temp;

                    min = j;
                }
            }
        }

        return arr;
    }
}
