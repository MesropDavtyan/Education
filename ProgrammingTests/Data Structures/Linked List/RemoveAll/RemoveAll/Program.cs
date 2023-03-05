using RemoveAll;

Solution solution = new Solution();
List<int> values = new List<int> { 1,2,3,4,5,6,7,8,9,0,8 };
////List<int> values = new List<int> { 1,1,2 };


solution.FindDoublesInList(values);


////List<List<int>> rawData = new List<List<int>>
////{
////    new List<int>{ 2001, 1001, 3 },
////    new List<int>{ 2001, 1002, 2 },
////    new List<int>{ 2002, 1003, 1 },
////    new List<int>{ 2002, 1001, 2 },
////    new List<int>{ 2003, 1005, 9 },
////    new List<int>{ 2002, 1002, 3 },
////    new List<int>{ 2002, 1004, 4 },
////    new List<int>{ 2001, 1003, 1 },
////    new List<int>{ 2001, 1004, 7 },
////};

////solution.PrintClassification(rawData);

List<int> test = new List<int> { 1,3,2,5,4 };
solution.CountPairs(test, 2); //3

//solution.MaxRepeated("AB", "ABCABCABABABC");