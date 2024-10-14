function sortNumbers(numbers) {
    numbers.sort(function(a, b){return a-b});
    const resultingArray = new Array();

    while(numbers.length > 0) {
        let smallestNumebr = numbers.shift();
        const biggestNumebr = numbers.pop();

        resultingArray.push(smallestNumebr);
        resultingArray.push(biggestNumebr);
    }

    return resultingArray;
}

// console.log(sortNumbers([1, 65, 3, 52, 48, 63, 31, -3, 18, 56]));
