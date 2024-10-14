function trackWords(input) {
  const [searchWords, ...text] = input;

  const searchWordsSplit = searchWords.split(" ").reduce((acc, curr) => {
    acc[curr] = 0;
    return acc;
  }, {});

  text.forEach((word) => {
    if (searchWordsSplit.hasOwnProperty(word)) {
      searchWordsSplit[word]++;
    }
  });

  const sortedWordsCount = Object.keys(searchWordsSplit).sort(
    (a, b) => parseFloat(searchWordsSplit[b]) - parseFloat(searchWordsSplit[a])
  );

  sortedWordsCount.forEach((word) => {
    console.log(`${word} - ${searchWordsSplit[word]}`);
  });
}

trackWords([
  "this sentence",
  "In",
  "this",
  "sentence",
  "you",
  "have",
  "to",
  "count",
  "the",
  "occurrences",
  "of",
  "the",
  "words",
  "this",
  "and",
  "sentence",
  "because",
  "this",
  "is",
  "your",
  "task",
]);
