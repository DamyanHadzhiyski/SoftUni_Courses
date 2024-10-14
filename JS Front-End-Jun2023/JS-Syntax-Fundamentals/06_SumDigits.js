function sumDigits(number)
{
    calcNumber = number;
    let sum = 0;

    while (calcNumber !== 0)
    {
        sum += calcNumber % 10;
        calcNumber = parseInt(calcNumber / 10);
    }

    console.log(sum)
}

//sumDigits(543);