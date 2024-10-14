function splitter(inputText) {
    const splitedText = [];
    let index = 0;
    let word = "";

    for (const ch of inputText) {
        if (ch === ch.toUpperCase()){
            if (word.length > 0) {
                splitedText[index] = word;
                index++;
            }
            word = ch;
        } else {
            word += ch;
        }       
    };
    
    splitedText[index] = word;

    console.log(splitedText.join(", "));        
}

splitter('SplitMeIfYouCanHaHaYouCantOrYouCan');