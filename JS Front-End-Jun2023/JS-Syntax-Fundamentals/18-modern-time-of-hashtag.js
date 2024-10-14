function findHashTagWords(inputText){
    let text = inputText.split(" ");
    
    for (const word of text) {
        let isValid = false;

        if (word.startsWith("#") && word.length > 1) {
            for (const ch of word){
                if (Number.isInteger(+ch)){
                    isValid = false;
                    break;
                }
                isValid = true;
            }
        }

        if (isValid) {
            let finalWord = word.substring(1, word.length);
            console.log(finalWord);
        }
    }
}

findHashTagWords('The symbol # is known #variously in English-speaking #regions as the #number sign');