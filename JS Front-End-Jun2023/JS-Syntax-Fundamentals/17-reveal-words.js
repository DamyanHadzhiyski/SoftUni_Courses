function revealWords(inputWords, inputText) {
    let words = inputWords.split(", ");
    for (let word of words) {
        let template = '*'.repeat(word.length);
        inputText = inputText.replace(template, word);
    }
    console.log(inputText);
}

//revealWords('great, learning', 'softuni is ***** place for ******** new programming languages');