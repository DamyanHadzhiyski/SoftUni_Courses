function stringSubstring(inputWord, inputText) {
  let text = inputText.toLowerCase().split(" ");
  let searchWord = inputWord.toLowerCase();

  for (const word of text) {
    if (word.localeCompare(searchWord) === 0) {
      console.log(inputWord)
      return;
    }
  };

  console.log(`${inputWord} not found!`);
}

//stringSubstring("javaScript", "JavaScript is the best programming language");