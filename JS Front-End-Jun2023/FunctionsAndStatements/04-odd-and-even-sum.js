function sumOddAndEven(number){
    let sumOdd = 0;
    let sumEven = 0;
    let numberLeft = number;

    while (numberLeft !== 0) {

        let checknumber = parseInt(numberLeft % 10);

        if ((checknumber % 2) === 0){
            sumEven += checknumber;
        } else {
            sumOdd += checknumber;
        }

        numberLeft = parseInt(numberLeft / 10)
    }

    console.log(`Odd sum = ${sumOdd}, Even sum = ${sumEven}`)
}

//sumOddAndEven(3495892137259234);