function findSmallestOfThree(...nums) {
  let smallest = Number.MAX_VALUE;
  for (const num of nums) {
    if (num < smallest) {
      smallest = num;
    }
  }

  console.log(smallest);
}

//findSmallestOfThree(2,2,2);
