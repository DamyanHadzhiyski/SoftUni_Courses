function printAndSum(start, end)
{
    let sum = 0;
    let allNumbers = "";

    for (let index = start; index <= end; index++) {
        allNumbers += (index + " "); 
        sum += index;
    }

    console.log(allNumbers.trimEnd());
    console.log(`Sum: ${sum}`);
}

//printAndSum(50, 60);