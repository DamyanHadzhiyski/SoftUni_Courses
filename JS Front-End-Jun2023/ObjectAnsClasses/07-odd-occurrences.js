function findOddOccurrences(input) {
  const splitedInput = input.split(" ");

  wordsCount = splitedInput.reduce((acc, curr) => {
    if (acc.hasOwnProperty(curr.toLowerCase())) {
      acc[curr.toLowerCase()]++;
    } else {
      acc[curr.toLowerCase()] = 1;
    }
    return acc;
  }, {});

  const oddCountWords = [];

  Object.entries(wordsCount).forEach(([key, value]) => {
    if (value % 2 !== 0) {
      oddCountWords.push(key);
    }
  });

  console.log(oddCountWords.join(" "));
}

findOddOccurrences("Java C# Php PHP Java PhP 3 C# 3 1 5 C#");
