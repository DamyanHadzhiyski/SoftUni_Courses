function showCharacters(char1, char2) {
  let firstChar = char1;
  let secondChar = char2;

  if (char1.charCodeAt(0) > char2.charCodeAt(0)) {
    firstChar = char2;
    secondChar = char1;
  }

  const charArray = [];
  for (let i = firstChar.charCodeAt(0) + 1; i < secondChar.charCodeAt(0); i++) {
    charArray.push(String.fromCharCode(i));
  }

  console.log(charArray.join(" "));
}

//showCharacters("C", "#");