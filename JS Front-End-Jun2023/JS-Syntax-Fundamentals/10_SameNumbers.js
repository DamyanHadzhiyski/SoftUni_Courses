function sameNumbers(number){
    let calcNumber = number;
    let sum = 0;
    let firstDigit = calcNumber % 10;
    let areTheSame = true;

    while (calcNumber !== 0)
    {
        sum += calcNumber % 10;

        if (firstDigit !== calcNumber % 10)
        {
            areTheSame = false;
        }

        calcNumber = parseInt(calcNumber / 10);
    }

    console.log(areTheSame);
    console.log(sum);
}

//sameNumbers(1234)